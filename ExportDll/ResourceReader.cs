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
using System.ComponentModel;

namespace ExportDLL
{
	struct VersionInfoResource
	{
		public VS_FIXEDFILEINFO FixedFileInfo;
		public ID VarFileInfoID;
		public ID StringFileInfoID;
	}
	[ModuleName("VS_VERSION_INFO")]
	class VersionInfoReader : FileResourceReader<VersionInfoResource>
	{
		protected override void OnSave(ushort index,BinaryWriter writer)
		{
			base.OnSave(index,writer);

			writer.Write(ref resource[index].FixedFileInfo);
			MessageBox.Show("Write : " + resource[index].FixedFileInfo.ToString());

			Write(writer,resource[index].VarFileInfoID);
			Write(writer,resource[index].StringFileInfoID);
		}
		protected override void OnLoad(ushort index,BinaryReader reader)
		{
			base.OnLoad(index,reader);

			reader.Read(out resource[index].FixedFileInfo);
			MessageBox.Show(GetType().Name + '\n' + resource[index].FixedFileInfo.ToString());

			Read(reader,out resource[index].VarFileInfoID);
			Read(reader,out resource[index].StringFileInfoID);
		}
	}
	[ModuleName("VarFileInfo")]
	class VarFileInfoReader : FileResourceReader<ID>
	{
		protected override void OnLoad(ushort index,BinaryReader reader)
		{
			base.OnLoad(index,reader);

			Read(reader,out resource[index]);
		}
		protected override void OnSave(ushort index,BinaryWriter writer)
		{
			base.OnSave(index,writer);

			Write(writer,resource[index]);
		}
	}

	[ModuleName("StringFileInfo")]
	class StringFileInfoReader : FileResourceReader<Dictionary<string,SortedDictionary<string,string>>>
	{
		protected override void OnAlloc(ushort index)
		{
			base.OnAlloc(index);
			resource[index]	= new Dictionary<string,SortedDictionary<string,string>>();
		}

		void WriteValue(SortedDictionary<string,string> stringTable,BinaryWriter writer)
		{
			var result	= string.Empty;
			foreach(var stringData in stringTable)
			{
				result	+= stringData.ToString() + '\n';
				
				var startPosition	= writer.BaseStream.Position;

				writer.Write((ushort)0);
				writer.Write((ushort)(stringData.Value.Length + 1));
				writer.Write((ushort)1);
				writer.WriteUnicode(stringData.Key);
				
				//Padding
				while((writer.BaseStream.Position % 4) != 0)
					writer.Write((byte)0);

				writer.WriteUnicode(stringData.Value);
				
				//Padding
				while((writer.BaseStream.Position % 4) != 0)
					writer.Write((byte)0);

				var endPosition	= writer.BaseStream.Position;
				writer.Seek((int)startPosition,SeekOrigin.Begin);
				writer.Write((ushort)(endPosition - startPosition));

				writer.Seek((int)endPosition,SeekOrigin.Begin);
			}
			MessageBox.Show(result);
		}
		protected override void OnSave(ushort index,BinaryWriter writer)
		{
			base.OnSave(index,writer);

			foreach(var stringTable in resource[index])
			{
				FileResourceHeader.Write(writer,stringTable.Key,false,null
					,(written) => WriteValue(stringTable.Value,writer));
			}
		}

		void ReadValue(FileResourceHeader header,SortedDictionary<string,string> stringTable,BinaryReader reader)
		{
			var result	= string.Empty;
			var endPosition	= reader.BaseStream.Position + header.Length;
			while(reader.BaseStream.Position < endPosition)
			{
				header	= new FileResourceHeader(reader);
				if(header.Length < 1)
					continue;

				string value;
				reader.ReadUnicode(out value);
				stringTable.Add(header.Name,value);

				//Padding
				while((reader.BaseStream.Position % 4) != 0)
					reader.ReadByte();
				
				result	+= header.Length + " : " + header.ValueLength
					+ " : " + header.Type + " : " + header.Name + " = " + value + " : " + value.Length + '\n';
			}

			MessageBox.Show(result);
		}
		protected override void OnLoad(ushort index,BinaryReader reader)
		{
			base.OnLoad(index,reader);
			
			var endPosition	= reader.BaseStream.Position + Data[index].Length;
			while(reader.BaseStream.Position < endPosition)
			{
				var header	= new FileResourceHeader(reader);
				if(header.Length < 1)
					continue;

				SortedDictionary<string,string> stringTable;
				if(!resource[index].TryGetValue(header.Name,out stringTable))
				{
					stringTable	= new SortedDictionary<string,string>();
					resource[index].Add(header.Name,stringTable);
				}

				ReadValue(header,stringTable,reader);
			}
		}
		protected override void OnFree(ushort index)
		{
			base.OnFree(index);
			resource[index]	= null;
		}

		public static IEnumerable<string> GetAllLangID(ID id)
		{
			var module	= Get(id) as StringFileInfoReader;
			if(module == null)
				throw new ArgumentException();

			foreach(var langID in module.resource[id.Index].Keys)
				yield return langID;
		}
		public static void CopyLangID(ID id,string srcLangID,string dstLangID)
		{
			var module	= Get(id) as StringFileInfoReader;
			if(module == null)
				throw new ArgumentException();

			SortedDictionary<string,string> srcTable;
			if(module.resource[id.Index].TryGetValue(srcLangID,out srcTable))
			{
				SortedDictionary<string,string> dstTable;
				if(!module.resource[id.Index].TryGetValue(dstLangID,out dstTable))
				{
					dstTable	= new SortedDictionary<string,string>();
					module.resource[id.Index].Add(dstLangID,dstTable);
				}

				foreach(var pair in srcTable)
					dstTable[pair.Key]	= pair.Value;
			}
		}

		void AddStringTable(ushort index,string langID,IEnumerable<KeyValuePair<string,string>> values)
		{
			SortedDictionary<string,string> stringTable;
			if(!resource[index].TryGetValue(langID,out stringTable))
			{
				stringTable	= new SortedDictionary<string,string>();
				resource[index].Add(langID,stringTable);
			}

			foreach(var pair in values)
				stringTable[pair.Key]	= pair.Value;
		}
		public static void AddStringTable(ID id,string langID,IEnumerable<KeyValuePair<string,string>> values)
		{
			var module	= Get(id) as StringFileInfoReader;
			if(module == null)
				throw new ArgumentException();

			module.AddStringTable(id.Index,langID,values);
		}
	}

	struct TranslationCode
	{
		public ushort MS;
		public ushort LS;
		public TranslationCode(BinaryReader reader)
		{
			MS	= reader.ReadUInt16();
			LS	= reader.ReadUInt16();
		}
		public void Save(BinaryWriter writer)
		{
			writer.Write(MS);
			writer.Write(LS);
		}
		public override string ToString()
		{
			return string.Format("{0:X4}{1:X4}",MS,LS).ToLower();
		}
	}
	[ModuleName("Translation")]
	class TranslationReader : FileResourceReader<TranslationCode>
	{
		protected override void OnSave(ushort index,BinaryWriter writer)
		{
			base.OnSave(index,writer);

			resource[index].Save(writer);
		}
		protected override void OnLoad(ushort index,BinaryReader reader)
		{
			base.OnLoad(index,reader);

			resource[index]	= new TranslationCode(reader);
		}
	}
}
