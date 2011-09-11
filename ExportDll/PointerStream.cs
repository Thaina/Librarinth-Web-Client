using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace ExportDLL
{
	static class StreamReaderExtension
	{
		public static void ReadUnicode(this BinaryReader reader,out string value)
		{
			value	= string.Empty;
			char c	= reader.ReadChar();
			while(c != 0)
			{
				value	+= c;
				c	= reader.ReadChar();
			}
		}

		public static void WriteUnicode(this BinaryWriter writer,string value)
		{
			writer.Write(Encoding.Unicode.GetBytes(value + '\0'));
		}

		static readonly Dictionary<int,byte[]> buffers	= new Dictionary<int,byte[]>();
		public static unsafe void Write<T>(this BinaryWriter writer,ref T value) where T : struct
		{
			var data	= new byte[Marshal.SizeOf(typeof(T))];
			fixed(byte* ptr	= data)
			{
				Marshal.StructureToPtr(value,new IntPtr(ptr),false);
				writer.Write(data);
			}
		}
		public static unsafe void Read<T>(this BinaryReader reader,out T value) where T : struct
		{
			var pStream	= reader.BaseStream as PointerStream;
			if(pStream == null)
			{
				var data	= reader.ReadBytes(Marshal.SizeOf(typeof(T)));
				fixed(byte* ptr	= data)
				{
					value	= (T)Marshal.PtrToStructure(new IntPtr(ptr),typeof(T));
				}
			}
			else pStream.Read(out value);
		}
	}

	public class PointerStream : Stream
	{
		readonly uint length;
		readonly IntPtr resource;
		public readonly BinaryReader Reader;
		public PointerStream(IntPtr res,uint size)
		{
			Position	= 0;
			Reader	= new BinaryReader(this,Encoding.Unicode);
			resource	= res;
			length	= size;
		}
		public override void Close()
		{
			Reader.Close();
			base.Close();
		}

		public void Read<T>(out T value) where T : struct
		{
			value	= (T)Marshal.PtrToStructure(new IntPtr(((uint)resource.ToInt32()) + Position),typeof(T));
			Position	+= Marshal.SizeOf(value);
		}
		
		public override long Position { get; set; }
		public sealed override long Length { get { return length; } }
		public sealed override bool CanRead { get { return true; } }
		public sealed override bool CanSeek { get { return true; } }
		public sealed override bool CanWrite { get { return false; } }

		public sealed override void Flush() { }
		public sealed override int Read(byte[] buffer,int offset,int count)
		{
			Marshal.Copy(new IntPtr(resource.ToInt32() + Position),buffer,offset,count);
			Position	+= count;
			return count;
		}

		public sealed override long Seek(long offset,SeekOrigin origin)
		{
			switch(origin)
			{
				case SeekOrigin.Current:
					Position	+= offset;
					break;
				case SeekOrigin.Begin:
					Position	= offset;
					break;
				case SeekOrigin.End:
					Position	= length + offset;
					break;
			}

			return Position;
		}

		public sealed override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public sealed override void Write(byte[] buffer,int offset,int count)
		{
			throw new NotSupportedException();
		}
	}
}
