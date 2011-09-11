using System;

using SlimMath;
using System.Text;

using System.Runtime.InteropServices;

public partial class CSGL
{
	public void DrawArrays(DrawMode mode,int i,int count)
	{
		drawArrays((uint)mode,i,count);
	}

	public unsafe struct VertexBuffer
	{
		uint handle;
		public VertexBuffer(CSGL gl)
		{
			fixed(uint* p	= &handle)
				gl.genBuffers(1,p);
		}

		public void SetBuffer<T>(CSGL gl,T[] x) where T : struct
		{
			gl.bindBuffer(ARRAY_BUFFER,handle);
			gl.bufferData(ARRAY_BUFFER,Marshal.SizeOf(typeof(T)),x,STATIC_DRAW);
		}
	}
}