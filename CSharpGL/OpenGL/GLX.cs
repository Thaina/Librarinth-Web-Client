using System;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Collections.Generic;

namespace Open
{
	public unsafe static class GLX
	{
		static readonly PlatformID Platform	= Environment.OSVersion.Platform;
		public static IntPtr GetProcAddress(string FuncName)
		{
			switch(Platform)
			{
				case PlatformID.Win32Windows:
				case PlatformID.Win32NT:
					fixed(byte* Func	= Encoding.UTF8.GetBytes(FuncName))
						return WGL.GetProcAddress(Func);

				case PlatformID.MacOSX:
				case PlatformID.Unix:
					throw new NotSupportedException();

				default:
					throw new NotImplementedException();
			}
		}

		public static uint CreateContext(PixelFormat PF,IntPtr HDC)
		{
			switch(Platform)
			{
				case PlatformID.Win32Windows:
				case PlatformID.Win32NT:
					{
						int PFI	= GDI.ChoosePixelFormat(HDC,ref PF);
						GDI.SetPixelFormat(HDC,PFI,ref PF);

						return WGL.CreateContext(HDC);
					}
				case PlatformID.MacOSX:
				case PlatformID.Unix:
					throw new NotSupportedException();

				default:
					throw new NotImplementedException();
			}
		}

		public static bool DeleteContext(uint HRC)
		{
			switch(Platform)
			{
				case PlatformID.Win32Windows:
				case PlatformID.Win32NT:
					return WGL.DeleteContext(HRC);

				case PlatformID.MacOSX:
				case PlatformID.Unix:
					throw new NotSupportedException();

				default:
					throw new NotImplementedException();
			}
		}

		public static bool MakeCurrent(IntPtr HDC,uint HRC)
		{
			switch(Platform)
			{
				case PlatformID.Win32Windows:
				case PlatformID.Win32NT:
					return WGL.MakeCurrent(HDC,HRC);

				case PlatformID.MacOSX:
				case PlatformID.Unix:
					throw new NotSupportedException();

				default:
					throw new NotImplementedException();
			}
		}

		public static bool SwapBuffers(IntPtr HDC)
		{
			switch(Platform)
			{
				case PlatformID.Win32Windows:
				case PlatformID.Win32NT:
					return WGL.SwapBuffers(HDC);

				case PlatformID.MacOSX:
				case PlatformID.Unix:
					throw new NotSupportedException();

				default:
					throw new NotImplementedException();
			}
		}

		public static bool ShareLists(uint HRCShare,uint HRCScr)
		{
			switch(Platform)
			{
				case PlatformID.Win32Windows:
				case PlatformID.Win32NT:
					return WGL.ShareLists(HRCShare,HRCScr);

				case PlatformID.MacOSX:
				case PlatformID.Unix:
					throw new NotSupportedException();

				default:
					throw new NotImplementedException();
			}
		}
	}
}