////////////////////////////////////////////////////////////////////////////////
////	Best regards to http://www.pinvoke.net/ for Win32 mapping API		////
////////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.ComponentModel;

using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using BaseEngine;

namespace ExportDLL
{
	enum Prime : byte
	{
		ENGLISH	= 0x09,
	}
	public enum LangID : ushort
	{
		ENGLISH_US	= Prime.ENGLISH + (0x01 << 10),
	}

	public abstract class FileResourceReader<T> : FileResourceReader
	{
		public T[] Resource { get { return resource; } }

		protected T[] resource;
		protected override void OnResize(int newSize)
		{
			base.OnResize(newSize);
			Array.Resize(ref resource,newSize);
		}
	}
	public abstract class FileResourceReader : Module<FileResourceHeader>
	{
		protected override void OnAlloc(ushort index) { }
		protected override void OnLoad(ushort index,BinaryReader reader) { }
		protected override void OnSave(ushort index,BinaryWriter writer) { }
		protected override void OnFree(ushort index) { }

		public static void SetUp()
		{
			Add<VersionInfoReader>();
			Add<StringFileInfoReader>();
			Add<VarFileInfoReader>();
			Add<TranslationReader>();
		}

		[DllImport("kernel32.dll",SetLastError=true)]
		static extern IntPtr BeginUpdateResource(string pFileName,bool bDeleteExistingResources);
		[DllImport("kernel32.dll",SetLastError=true)]
		static unsafe extern bool UpdateResource(IntPtr hUpdate,ResType lpType,IntPtr lpName,LangID wLanguage,byte* lpData,uint cbData);
		[DllImport("kernel32.dll",SetLastError=true)]
		static extern bool EndUpdateResource(IntPtr hUpdate,bool fDiscard);
		public static unsafe void Write(ID id,ResType type,IntPtr lpName,string fileName,LangID langID)
		{
			using(var memoryStream	= new MemoryStream())
			{
				Write(new BinaryWriter(memoryStream),id);

				var handle	= BeginUpdateResource(fileName,true);
				if(handle == IntPtr.Zero)
					throw new FileNotFoundException();

				var lenght	= (uint)memoryStream.Length;
				fixed(byte* pData	= memoryStream.GetBuffer())
				{
					if(!UpdateResource(handle,type,lpName,langID,pData,lenght))
					{
						var errorCode	= Marshal.GetLastWin32Error();
						EndUpdateResource(handle,true);
						throw new Win32Exception(errorCode);
					}
				
					if(!EndUpdateResource(handle,false))
						throw new Win32Exception(Marshal.GetLastWin32Error());
				}
			}
		}
		protected static void Write(BinaryWriter writer,ID id)
		{
			var module	= Get(id);
			if(module == null)
				throw new NotSupportedException("Cannot find reader for this ID");
			
			module.Data[id.Index].Write(writer,(binaryWriter)=>module.Save(id,binaryWriter));
		}

		[DllImport("kernel32.dll")]
		static extern IntPtr FindResource(IntPtr hModule,IntPtr lpName,ResType lpType);
		[DllImport("kernel32.dll",SetLastError=true)]
		static extern uint SizeofResource(IntPtr hModule,IntPtr hResInfo);
		[DllImport("kernel32.dll",SetLastError=true)]
		static extern IntPtr LoadResource(IntPtr hModule,IntPtr hResInfo);
		[DllImport("kernel32.dll")]
		static unsafe extern IntPtr LockResource(IntPtr hResData);
		[DllImport("kernel32.dll",SetLastError=true)]
		static extern bool FreeResource(IntPtr hResData);

		protected static void Read(FileResourceHeader header,string forcedName,BinaryReader reader,out ID id)
		{
			var module	= Get(forcedName);
			if(module == null)
				throw new NotSupportedException("Cannot find reader for " + header.Name);
			
			module.Alloc(out id);
			module.Data[id.Index]	= header;
			module.Load(id,reader);
		}
		protected static void Read(BinaryReader reader,out ID id)
		{
			var header	= new FileResourceHeader(reader);
			Read(header,header.Name,reader,out id);
		}

		public static void Read(IntPtr loadedHandle,ResType lpszType,IntPtr lpszName,out ID id)
		{
			var resHandle	= FindResource(loadedHandle,lpszName,lpszType);
			if(resHandle == IntPtr.Zero)
				throw new FileNotFoundException();

			var length	= SizeofResource(loadedHandle,resHandle);
			if(length < 1)
				throw new Exception("Zero size of resource");

			var resData	= LoadResource(loadedHandle,resHandle);
			using(var stream	= new PointerStream(LockResource(resData),length))
			{
				Read(stream.Reader,out id);
			}

			FreeResource(resData);
		}
	}
}
