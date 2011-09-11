////////////////////////////////////////////////////////////////////////////////
////	Best regards to http://www.pinvoke.net/ for Win32 mapping API		////
////////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BaseEngine;

namespace ExportDLL
{
	public delegate void Written(BinaryWriter binaryWriter);
	public struct FileResourceHeader
	{
		public readonly UInt16 Length;
		public readonly UInt16 ValueLength;
		public readonly UInt16 Type;
		public string Name;
		public FileResourceHeader(BinaryReader reader)
		{
			Length	= reader.ReadUInt16();
			ValueLength	= reader.ReadUInt16();
			Type	= reader.ReadUInt16();

			reader.ReadUnicode(out Name);
			Name	= Name.Trim();
			
			//Padding
			while((reader.BaseStream.Position % 4) != 0)
				reader.ReadByte();
		}

		public static void Write(BinaryWriter writer,string name,bool isStringValue,byte[] value,Written written)
		{
			var startPosition	= writer.BaseStream.Position;
			var valueLenght	= (ushort)(value == null ? 0 : value.Length);

			writer.Write((ushort)0);
			writer.Write(valueLenght);
			writer.Write((ushort)(isStringValue ? 1 : 0));
			writer.WriteUnicode(name);

			//Padding
			while((writer.BaseStream.Position % 4) != 0)
				writer.Write((byte)0);

			written(writer);

			var endPosition	= writer.BaseStream.Position;
			writer.Seek((int)startPosition,SeekOrigin.Begin);
			writer.Write((ushort)(endPosition - startPosition));

			writer.Seek((int)endPosition,SeekOrigin.Begin);
		}
		public void Write(BinaryWriter writer,Written written)
		{
			var startPosition	= writer.BaseStream.Position;

			writer.Write((ushort)0);
			writer.Write(ValueLength);
			writer.Write(Type);
			writer.WriteUnicode(Name);

			//Padding
			while((writer.BaseStream.Position % 4) != 0)
				writer.Write((byte)0);

			written(writer);

			var endPosition	= writer.BaseStream.Position;
			writer.Seek((int)startPosition,SeekOrigin.Begin);
			writer.Write((ushort)(endPosition - startPosition));

			writer.Seek((int)endPosition,SeekOrigin.Begin);
		}

		public override string ToString()
		{
			return string.Format("{0} : {1} : {2} : {3}",Length,ValueLength,Type,Name);
		}
	}

	public unsafe struct VS_FIXEDFILEINFO
	{
		[Flags]
		public enum VS_FF : uint
		{
			DEBUG	= 0x00000001,
			PRERELEASE	= 0x00000002,
			PATCHED	= 0x00000004,
			PRIVATEBUILD	= 0x00000008,
			INFOINFERRED	= 0x00000010,
			SPECIALBUILD	= 0x00000020,
		}

		public enum VOS : uint
		{
			UNKNOWN	= 0x00000000,
			WINDOWS16	= 0x00000001,
			PM16	= 0x00000002,
			PM32	= 0x00000003,
			WINDOWS32	= 0x00000004,
			DOS	= 0x00010000,
			OS216	= 0x00020000,
			OS232	= 0x00030000,
			NT	= 0x00040000,
		}

		public enum VFT : ulong
		{
			UNKNOWN	= 0x00000000,
			APP	= 0x00000001 << sizeof(uint),
			DLL	= 0x00000002 << sizeof(uint),
			DRV	= 0x00000003 << sizeof(uint),
			FONT	= 0x00000004 << sizeof(uint),
			VXD	= 0x00000005 << sizeof(uint),
			STATIC_LIB	= 0x00000007 << sizeof(uint),

			DRV_PRINTER	= DRV + 0x00000001,
			DRV_KEYBOARD	= DRV + 0x00000002,
			DRV_LANGUAGE	= DRV + 0x00000003,
			DRV_DISPLAY	= DRV + 0x00000004,
			DRV_MOUSE	= DRV + 0x00000005,
			DRV_NETWORK	= DRV + 0x00000006,
			DRV_SYSTEM	= DRV + 0x00000007,
			DRV_INSTALLABLE	= DRV + 0x00000008,
			DRV_SOUND	= DRV + 0x00000009,
			DRV_COMM	= DRV + 0x0000000A,
			DRV_VERSIONED_PRINTER	= DRV + 0x0000000C,

			FONT_RASTER	= FONT + 0x00000001,
			FONT_VECTOR	= FONT + 0x00000002,
			FONT_TRUETYPE	= FONT + 0x00000003,
		}

		public uint dwSignature;
		public ushort dwStrucVersion0;
		public ushort dwStrucVersion1;
		public ushort dwFileVersionMS1;
		public ushort dwFileVersionMS0;
		public ushort dwFileVersionLS1;
		public ushort dwFileVersionLS0;
		public ushort dwProductVersionMS1;
		public ushort dwProductVersionMS0;
		public ushort dwProductVersionLS1;
		public ushort dwProductVersionLS0;
		public uint dwFileFlagsMask;
		public VS_FF dwFileFlags;
		public VOS dwFileOS;
		public uint dwFileType;
		public uint dwFileSubtype;
		public uint dwFileDateMS;
		public uint dwFileDateLS;
		public override string ToString()
		{
			return string.Format("[VS_FIXEDFILEINFO {0} bytes]\n",sizeof(VS_FIXEDFILEINFO)) +
					string.Format("{0:X} : {1} : {2} : {3} : {4} : {5} : {6} : {7}"
				,dwSignature,string.Format("{0}.{1}",dwStrucVersion0,dwStrucVersion1)
				,new Version(dwFileVersionMS0,dwFileVersionMS1,dwFileVersionLS0,dwFileVersionLS1)
				,new Version(dwProductVersionMS0,dwProductVersionMS1,dwProductVersionLS0,dwProductVersionLS1)
				,dwFileFlags,dwFileOS,(VFT)(dwFileType << sizeof(uint)) + dwFileSubtype
				,new DateTime((dwFileDateMS << sizeof(uint)) + dwFileDateLS));
		}
	}
}
