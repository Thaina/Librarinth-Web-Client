using System;

using SlimMath;
using System.Text;

public partial class CSGL
{
	public unsafe struct Texture2D
	{
		internal readonly uint handle;
		public Texture2D(CSGL gl,byte[] data,int width,int height)
		{
			fixed(uint* h	= &handle)
				gl.genTextures(1,h);

			gl.bindTexture((uint)Texture.Target.T2D,handle);

			fixed(byte* pData	= data)
				gl.texImage2D((uint)Texture.Target.T2D,0,(uint)Texture.InternalFormat.RGBA
					,width,height,0,(uint)Texture.Format.RGBA,(uint)Texture.Type.RGBA8,pData);
		}
	}

	public unsafe struct Effect
	{
		readonly Program handle;
		readonly Shader vertex;
		readonly Shader pixel;
		public Effect(CSGL gl,string vertexShader,string pixelShader)
		{
			handle	= gl.createProgram();
			vertex	= gl.createShader((uint)ShaderType.Vertex);
			pixel	= gl.createShader((uint)ShaderType.Fragment);

			fixed(byte* source	= Encoding.ASCII.GetBytes(vertexShader))
			fixed(byte** sources	= new byte*[] { source })
				gl.shaderSource(vertex,1,sources,null);

			fixed(byte* source	= Encoding.ASCII.GetBytes(pixelShader))
			fixed(byte** sources	= new byte*[] { source })
				gl.shaderSource(pixel,1,sources,null);

			gl.compileShader(vertex);
			gl.compileShader(pixel);

			gl.attachShader(handle,vertex);
			gl.attachShader(handle,pixel);

			gl.linkProgram(handle);
		}
		public void Delete(CSGL gl)
		{
			gl.deleteShader(pixel);
			gl.deleteShader(vertex);
			gl.deleteProgram(handle);
			this	= default(Effect);
		}

		public void UseProgram(CSGL gl)
		{
			gl.useProgram(handle);
		}
	}
}