using System;

namespace Open
{
	unsafe partial class GL
	{
		public void InitMatrix()
		{
			matrixMode(PROJECTION);
			loadIdentity();
			matrixMode(MODELVIEW);
			loadIdentity();
		}
		public void VertexPointer(int coordNumber,int stride,float* data)
		{
			vertexPointer(coordNumber,FLOAT,stride,data);
		}
		public void ColorPointer(int coordNumber,int stride,byte* data)
		{
			colorPointer(coordNumber,UNSIGNED_BYTE,stride,data);
		}
		public void EnableVertex()
		{
			enableClientState(VERTEX_ARRAY);
		}
		public void EnableColor()
		{
			enableClientState(COLOR_ARRAY);
		}

		protected delegate void glLoadIdentity();
		protected delegate void glMatrixMode(uint mode);

		protected delegate void glEnableClientState(uint cap);
		protected delegate void glDisableClientState(uint cap);
		protected delegate void glVertexPointer(int size,uint type,int stride,void* pointer);
		protected delegate void glColorPointer(int size,uint type,int stride,void* pointer);

		protected glMatrixMode matrixMode;
		protected glLoadIdentity loadIdentity;
		protected glEnableClientState enableClientState;
		protected glDisableClientState disableClientState;
		protected glVertexPointer vertexPointer;
		protected glColorPointer colorPointer;
	}
}