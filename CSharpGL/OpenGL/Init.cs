using System;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open
{
	public class GL<T> : GL where T : GL,new()
	{
		protected GL() { }
		static readonly Dictionary<PixelFormat,T> instances	= new Dictionary<PixelFormat,T>();
		public static void DoWork(IClient client,IntPtr hwnd,ref Package package)
		{
			if(client.Created)
			{
				if(package.HWND != hwnd)
				{
					if(package.HWND != default(IntPtr))
						package.Release();
					package	= new Package(hwnd,client.PixelFormat);
				}

				package.MakeCurrent();
				client.Draw(package.GL);
				package.SwapBuffers();
			}
			else if(package.HWND != default(IntPtr))
			{
				package.Release();
				package	= default(Package);
			}
		}

		public interface IClient
		{
			PixelFormat PixelFormat { get; }
			bool Created { get; }
			void Draw(T gl);
		}
		public struct Package
		{
			internal readonly IntPtr HWND;
			internal readonly IntPtr HDC;
			internal readonly uint HRC;
			internal readonly T GL;
			internal Package(IntPtr hwnd,PixelFormat pixelFormat)
			{
				HWND	= hwnd;
				HDC	= WGL.GetDC(HWND);
				GLX.SwapBuffers(HDC);
				HRC	= GLX.CreateContext(pixelFormat,HDC);

				GLX.MakeCurrent(HDC,HRC);
				if(!instances.TryGetValue(pixelFormat,out GL))
				{
					GL	= new T();
					instances.Add(pixelFormat,GL);
				}
			}

			internal void MakeCurrent()
			{
				GLX.MakeCurrent(HDC,HRC);
			}
			internal void SwapBuffers()
			{
				GLX.SwapBuffers(HDC);
			}

			internal void Release()
			{
				GLX.MakeCurrent(IntPtr.Zero,0);
				GLX.DeleteContext(HRC);
				WGL.ReleaseDC(HWND,HDC);
			}
		}
	}

	class SystemLib
	{
		static readonly Dictionary<string,IntPtr> allLib	= new Dictionary<string,IntPtr>();
		static SystemLib()
		{
			AppDomain.CurrentDomain.ProcessExit	+= delegate
			{
				System.IO.File.AppendAllText(@"C:\Users\Thaina\Desktop\logger.txt","ProcessExit\n");
				foreach(var handle in allLib)
				{
					System.IO.File.AppendAllText(@"C:\Users\Thaina\Desktop\logger.txt"
						,"Free " + handle.Key + "\n");
					WGL.FreeLibrary(handle.Value);
				}
			};
		}

		readonly IntPtr handle;
		public SystemLib(string name)
		{
			if(allLib.TryGetValue(name,out handle))
				return;

			switch(Environment.OSVersion.Platform)
			{
				case PlatformID.Win32Windows:
				case PlatformID.Win32NT:
				case PlatformID.Win32S:
				case PlatformID.WinCE:
					handle	= WGL.LoadLibrary(name);
					break;

				case PlatformID.MacOSX:
				case PlatformID.Unix:
				default:
					throw new NotImplementedException();
			}
			allLib.Add(name,handle);
		}

		public IntPtr GetProcess(string name)
		{
			switch(Environment.OSVersion.Platform)
			{
				case PlatformID.Win32Windows:
				case PlatformID.Win32NT:
				case PlatformID.Win32S:
				case PlatformID.WinCE:
					return WGL.GetProcAddress(handle,name);
				case PlatformID.MacOSX:
				case PlatformID.Unix:
				default:
					throw new NotImplementedException();
			}
		}
	}

	public partial class GL
	{
		public static string Library
		{
			get
			{
				switch(Environment.OSVersion.Platform)
				{
					case PlatformID.Win32Windows:
					case PlatformID.Win32NT:
					case PlatformID.Win32S:
					case PlatformID.WinCE:
						return "Opengl32.dll";

					case PlatformID.MacOSX:
						return "Opengl.dylib";
					case PlatformID.Unix:
						return "Opengl.so";

					default:
						throw new NotImplementedException();
				}
			}
		}


		static SystemLib libHandle	= new SystemLib(Library);
		internal GL()
		{
			var allFunc	= typeof(GL).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
			foreach(var func in allFunc)
			{
				string error	= string.Empty;
				try
				{
					var ptr	= GLX.GetProcAddress(func.FieldType.Name);
					if(ptr == IntPtr.Zero)
					{
						ptr	= libHandle.GetProcess(func.FieldType.Name);
						func.SetValue(this,Marshal.GetDelegateForFunctionPointer(ptr,func.FieldType));
					}
					else func.SetValue(this,Marshal.GetDelegateForFunctionPointer(ptr,func.FieldType));
				}
				catch
				{
					error	+= "	" + func.FieldType.Name + "\n";
					continue;
				}

				if(!string.IsNullOrEmpty(error))
					throw new Exception("Unsupport :\n" + error);
			}
		}
	}
}