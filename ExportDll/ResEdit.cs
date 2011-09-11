////////////////////////////////////////////////////////////////////////////////
////	Best regards to http://www.pinvoke.net/ for Win32 mapping API		////
////////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BaseEngine;

namespace ExportDLL
{
	public enum ResType : int
	{
		CURSOR = 1,
		BITMAP = 2,
		ICON = 3,
		MENU = 4,
		DIALOG = 5,
		STRING = 6,
		FONTDIR = 7,
		FONT = 8,
		ACCELERATOR = 9,
		RCDATA = 10,
		MESSAGETABLE = 11,
		GROUP_CURSOR = 12,
		GROUP_ICON = 14,
		VERSION = 16,
		DLGINCLUDE = 17,
		PLUGPLAY = 19,
		VXD = 20,
		ANICURSOR = 21,
		ANIICON = 22,
		HTML = 23,
		MANIFEST = 24
	}

	public class NativeLibrary : IDisposable
	{
		public readonly IntPtr handle;
		public NativeLibrary(string fileName,LoadFlags loadFlag)
		{
			handle	= LoadLibraryEx(fileName,IntPtr.Zero,loadFlag);
		}
		
		public void EnumResourceNames(ResType resType,EnumResNameProcDelegate enumResNameProc)
		{
			EnumResourceNames(handle,resType,enumResNameProc,IntPtr.Zero);
		}

		public void Dispose()
		{
			FreeLibrary(handle);
		}
		
		[DllImport("kernel32.dll")]
		static extern IntPtr LoadLibraryEx(string lpFileName,IntPtr hFile,LoadFlags dwFlags);
		[DllImport("kernel32.dll",SetLastError=true)]
		static extern bool FreeLibrary(IntPtr hModule);
		
		[DllImport("kernel32.dll")]
		static extern IntPtr FindResource(IntPtr module,IntPtr hFile,LoadFlags dwFlags);
		public enum LoadFlags : uint
		{
			None = 0x00000000,
			DontResolveDLLReference = 0x00000001,
			WithAlteredSearchPath = 0x00000008,
			IgnoreCodeAuthZLevel = 0x00000010,

			AsDataFile = 0x00000002,
			AsImageResource = 0x00000020,
			AsDataFileExclsive = 0x00000040,
		}

		[DllImport("kernel32.dll")]
		static extern bool EnumResourceNames(IntPtr hModule,ResType dwID,EnumResNameProcDelegate lpEnumFunc,IntPtr lParam);
	}

	public delegate bool EnumResNameProcDelegate(IntPtr hModule,ResType lpszType,IntPtr lpszName,IntPtr lParam);
	public class NativeVersionInfo
	{
		static NativeVersionInfo()
		{
			FileResourceReader.SetUp();
		}
		
		struct ResHandle
		{
			public IntPtr loadedHandle;
			public ResType lpszType;
			public IntPtr lpszName;
		}
		
		public static void UpdateVersionResource(string fileName,string tatgetLID,IEnumerable<KeyValuePair<string,string>> datas)
		{
			var id	= default(ID);
			bool isGetResHandle	= false;
			var resHandle	= default(ResHandle);
			using(var loaded = new NativeLibrary(fileName,NativeLibrary.LoadFlags.None))
			{
				var enumResNameProc	= new EnumResNameProcDelegate((IntPtr loadedHandle,ResType lpszType,IntPtr lpszName,IntPtr lParam)=>
					{
						if(lpszType != ResType.VERSION)
							return true;

						isGetResHandle	= true;
						resHandle.loadedHandle	= loadedHandle;
						resHandle.lpszType	= lpszType;
						resHandle.lpszName	= lpszName;
						return false;
					});

				loaded.EnumResourceNames(ResType.VERSION,enumResNameProc);
				if(!isGetResHandle)
					throw new Exception("No version info in this file");
				
				FileResourceReader.Read(resHandle.loadedHandle,resHandle.lpszType,resHandle.lpszName,out id);
			}

			var versionModule	= FileResourceReader.Get<VersionInfoReader>(id);
			if(versionModule != null)
			{
				var stringInfoID	= versionModule.Resource[id.Index].StringFileInfoID;
				var allLID	= new List<string>(StringFileInfoReader.GetAllLangID(stringInfoID));
				foreach(var lid in allLID)
				{
					StringFileInfoReader.AddStringTable(stringInfoID,lid,datas);
					StringFileInfoReader.CopyLangID(stringInfoID,lid,tatgetLID);
				}

				FileResourceReader.Write(id,ResType.VERSION,resHandle.lpszName,fileName,LangID.ENGLISH_US);
			}
			else throw new Exception("Why we cannot get VersionInfoReader module ?");
		}
	}
}
