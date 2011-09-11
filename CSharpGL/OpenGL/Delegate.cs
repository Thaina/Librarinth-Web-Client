using System;
using System.Runtime.InteropServices;

public struct Program
{ uint handle; }
public struct Shader
{ uint handle; }
public struct UniformLocation
{ IntPtr handle; }
public struct AttribLocation
{ IntPtr handle; }

namespace Open
{
	public unsafe partial class GL
	{
		////////////////////////////////////////////////////////////////

		/* VERSION 1.0 */

		////////////////////////////////////////////////////////////////

		public delegate void glCullFace(uint mode);
		public delegate void glFrontFace(uint mode);

		public delegate void glHint(uint target,uint mode);

		public delegate void glLineWidth(float width);

		public delegate void glPointSize(float size);

		public delegate void glPolygonMode(uint face,uint mode);

		public delegate void glScissor(int x,int y,int width,int height);

		public delegate void glTexParameterf(uint target,uint pname,float param);
		public delegate void glTexParameteri(uint target,uint pname,int param);
		public delegate void glTexParameterfv(uint target,uint pname,float* param);
		public delegate void glTexParameteriv(uint target,uint pname,int* param);

		public delegate void glTexImage1D(uint target,int level,uint internalformat,int width,int border,uint format,uint type,void* data);
		public delegate void glTexImage2D(uint target,int level,uint internalformat,int width,int height,int border,uint format,uint type,void* data);

		////////////////////////////////////////////////////////////////

		public delegate void glDrawBuffer(uint mode);
		public delegate void glClear(uint mask);

		public delegate void glClearColor(float r,float g,float b,float a);
		public delegate void glClearDepth(double depth);
		public delegate void glClearStencil(int s);

		public delegate void glColorMask(bool r,bool g,bool b,bool a);
		public delegate void glDepthMask(bool flag);
		public delegate void glStencilMask(uint mask);

		////////////////////////////////////////////////////////////////

		public delegate void glEnable(uint cap);
		public delegate void glDisable(uint cap);

		public delegate void glFinish();
		public delegate void glFlush();

		////////////////////////////////////////////////////////////////

		public delegate void glBlendFunc(uint srcfactor,uint dstfactor);
		public delegate void glLogicOp(uint opcode);

		public delegate void glStencilFunc(uint func,int reference,uint mask);
		public delegate void glStencilOp(uint sfail,uint dpfail,uint dppass);

		public delegate void glDepthFunc(uint func);

		////////////////////////////////////////////////////////////////

		public delegate void glPixelStoref(uint pname,float param);
		public delegate void glPixelStorei(uint pname,int param);

		public delegate void glReadBuffer(uint mode);
		public delegate void glReadPixels(int x,int y,int w,int h,uint format,uint type,void* data);

		////////////////////////////////////////////////////////////////

		public delegate sbyte* glGetString(uint name);
		public delegate uint glGetError();

		public delegate void glGetBooleanv(uint pname,bool* param);
		public delegate void glGetDoublev(uint pname,double* param);
		public delegate void glGetFloatv(uint pname,float* param);
		public delegate void glGetIntegerv(uint pname,int* param);

		public delegate void glGetTexImage(uint target,int level,uint format,uint type,void* img);

		public delegate void glGetTexLevelParameterfv(uint target,int level,uint pname,float* param);
		public delegate void glGetTexLevelParameteriv(uint target,int level,uint pname,int* param);

		public delegate void glGetTexParameterfv(uint target,uint pname,float* param);
		public delegate void glGetTexParameteriv(uint target,uint pname,int* param);

		public delegate bool glIsEnabled(uint cap);

		////////////////////////////////////////////////////////////////

		public delegate void glDepthRange(double near,double far);
		public delegate void glViewport(int x,int y,int width,int height);

		////////////////////////////////////////////////////////////////

		/* VERSION 1.1 */

		////////////////////////////////////////////////////////////////

		public delegate void glDrawArrays(uint mode,int first,int count);
		public delegate void glDrawElements(uint mode,int count,uint type,void* indices);

		public delegate void glGetPointerv(uint pname,void** param);

		public delegate void glPolygonOffset(float factor,float units);

		public delegate bool glIsTexture(uint texture);
		public delegate void glGenTextures(int n,uint* textures);
		public delegate void glBindTexture(uint target,uint texture);
		public delegate void glDeleteTextures(int n,uint* textures);

		public delegate void glCopyTexImage1D(uint target,int level,uint internalformat,int x,int y,int w,int border);
		public delegate void glCopyTexImage2D(uint target,int level,uint internalformat,int x,int y,int w,int h,int border);

		public delegate void glCopyTexSubImage1D(uint target,int level,int xoffset,int x,int y,int w);
		public delegate void glCopyTexSubImage2D(uint target,int level,int xoffset,int yoffset,int x,int y,int w,int h);

		public delegate void glTexSubImage1D(uint target,int level,int xoffset,int width,uint format,uint type,void* data);
		public delegate void glTexSubImage2D(uint target,int level,int xoffset,int yoffset,int width,int height,uint format,uint type,void* data);

		////////////////////////////////////////////////////////////////

		/* VERSION 1.2 */

		////////////////////////////////////////////////////////////////

		public delegate void glBlendEquation(uint mode);
		public delegate void glBlendColor(float r,float g,float b,float a);

		public delegate void glDrawRangeElements(uint mode,uint start,uint end,int count,uint type,void* indices);

		public delegate void glTexImage3D(uint target,int level,uint internalformat,int width,int height,int depth,int border,uint format,uint type,void* data);
		public delegate void glTexSubImage3D(uint target,int level,int xoffset,int yoffset,int zoffset,int width,int height,int depth,uint format,uint type,void* data);

		public delegate void glCopyTexSubImage3D(uint target,int level,int xoffset,int yoffset,int zoffset,int x,int y,int w,int h);

		////////////////////////////////////////////////////////////////

		/* VERSION 1.3 */

		////////////////////////////////////////////////////////////////

		public delegate void glActiveTexture(uint Texture);

		public delegate void glSampleCoverage(float value,bool invert);

		public delegate void glGetCompressedTexImage(uint target,int lod,void* image);

		public delegate void glCompressedTexImage1D(uint target,int level,uint internalformat,int w,int border,int size,void* data);
		public delegate void glCompressedTexImage2D(uint target,int level,uint internalformat,int w,int h,int border,int size,void* data);
		public delegate void glCompressedTexImage3D(uint target,int level,uint internalformat,int w,int h,int d,int border,int size,void* data);

		public delegate void glCompressedTexSubImage1D(uint target,int level,int xoffset,int w,uint format,int size,void* data);
		public delegate void glCompressedTexSubImage2D(uint target,int level,int xoffset,int yoffset,int w,int h,uint format,int size,void* data);
		public delegate void glCompressedTexSubImage3D(uint target,int level,int xoffset,int yoffset,int zoffset,int w,int h,int d,uint format,int size,void* data);

		////////////////////////////////////////////////////////////////

		/* VERSION 1.4 */

		////////////////////////////////////////////////////////////////

		public delegate void glBlendFuncSeparate(uint srcRGB,uint dstRGB,uint srcAlpha,uint dstAlpha);

		public delegate void glMultiDrawArrays(uint mode,int* first,int* count,int primcount);
		public delegate void glMultiDrawElements(uint mode,int* first,uint type,void** indices,int primcount);


		public delegate void glPointParameterf(uint pname,float param);
		public delegate void glPointParameteri(uint pname,int param);

		public delegate void glPointParameterfv(uint pname,float* param);
		public delegate void glPointParameteriv(uint pname,int* param);

		////////////////////////////////////////////////////////////////

		/* VERSION 1.5 */

		////////////////////////////////////////////////////////////////

		public delegate bool glIsQuery(uint id);
		public delegate void glGenQueries(int n,uint* ids);
		public delegate void glDeleteQueries(int n,uint* ids);

		public delegate void glBeginQuery(uint target,uint id);
		public delegate void glEndQuery(uint target);

		public delegate void glGetQueryiv(uint target,uint pname,int* param);

		public delegate void glGetQueryObjectiv(uint id,uint pname,int* param);
		public delegate void glGetQueryObjectuiv(uint id,uint pname,uint* param);

		public delegate bool glIsBuffer(uint buffer);
		public delegate void glGenBuffers(int n,uint* buffers);
		public delegate void glDeleteBuffers(int n,uint* buffers);

		public delegate void glBindBuffer(uint target,uint buffer);

		public delegate void glBufferData(uint target,int size,Array Data,uint usage);
		public delegate void glBufferSubData(uint target,int offset,int size,void* Data);

		public delegate void glGetBufferSubData(uint target,int offset,int size,void* param);

		public delegate uint glMapBuffer(uint target,uint access);
		public delegate bool glUnmapBuffer(uint target);

		public delegate void glGetBufferParameteriv(uint target,uint value,int* data);
		public delegate void glGetBufferPointerv(uint target,uint value,ref uint param);

		////////////////////////////////////////////////////////////////

		/* VERSION 2.0 */

		////////////////////////////////////////////////////////////////

		public delegate void glBlendEquationSeparate(uint modeRGB,uint modeAlpha);

		public delegate void glDrawBuffers(int n,uint* bufs);

		public delegate void glStencilFuncSeparate(uint face,uint func,int reference,uint mask);
		public delegate void glStencilOpSeparate(uint face,uint sfail,uint dpfail,uint dppass);
		public delegate void glStencilMaskSeparate(uint face,uint mask);

		////////////////////////////////////////////////////////////////

		public delegate Program glCreateProgram();
		public delegate Shader glCreateShader(uint shadertype);

		public delegate void glDeleteProgram(Program program);
		public delegate void glDeleteShader(Shader shader);

		public delegate bool glIsProgram(Program program);
		public delegate bool glIsShader(Shader shader);

		public delegate void glShaderSource(Shader shader,int count,byte** source,int* lenght);
		public delegate void glCompileShader(Shader shader);
		public delegate void glLinkProgram(Program program);
		public delegate void glUseProgram(Program program);
		public delegate void glValidateProgram(Program program);

		public delegate void glAttachShader(Program program,Shader shader);
		public delegate void glDetachShader(Program program,Shader shader);

		public delegate void glEnableVertexAttribArray(uint index);
		public delegate void glDisableVertexAttribArray(uint index);

		public delegate void glGetAttachedShaders(Program program,int maxCount,int* count,Shader* shaders);

		public delegate void glGetProgramiv(Program program,uint pname,int* param);
		public delegate void glGetProgramInfoLog(Program program,int maxlenght,int* lenght,sbyte* infolog);

		public delegate void glGetShaderiv(Shader Shader,uint pname,int* param);
		public delegate void glGetShaderInfoLog(Shader Shader,int maxlenght,int* lenght,sbyte* infolog);

		public delegate void glGetShaderSource(Shader Shader,int bufSize,int* lenght,sbyte* source);

		public delegate void glGetActiveAttrib(Program program,uint index,int bufSize,int* length,int* size,uint* type,byte* name);
		public delegate void glGetActiveUniform(Program program,uint index,int bufSize,int* length,int* size,uint* type,byte* name);

		////////////////////////////////////////////////////////////////

		public delegate AttribLocation glGetAttribLocation(Program program,byte* name);
		public delegate void glBindAttribLocation(Program program,AttribLocation index,byte* name);
		public delegate void glGetVertexAttribPointerv(AttribLocation index,uint pname,void** pointer);

		public delegate void glGetVertexAttribdv(AttribLocation index,uint pname,double* param);
		public delegate void glGetVertexAttribfv(AttribLocation index,uint pname,float* param);
		public delegate void glGetVertexAttribiv(AttribLocation index,uint pname,int* param);

		public delegate void glVertexAttrib1f(AttribLocation index,float v0);
		public delegate void glVertexAttrib1s(AttribLocation index,short v0);
		public delegate void glVertexAttrib1d(AttribLocation index,double v0);

		public delegate void glVertexAttrib2f(AttribLocation index,float v0,float v1);
		public delegate void glVertexAttrib2s(AttribLocation index,short v0,short v1);
		public delegate void glVertexAttrib2d(AttribLocation index,double v0,double v1);

		public delegate void glVertexAttrib3f(AttribLocation index,float v0,float v1,float v2);
		public delegate void glVertexAttrib3s(AttribLocation index,short v0,short v1,short v2);
		public delegate void glVertexAttrib3d(AttribLocation index,double v0,double v1,double v2);

		public delegate void glVertexAttrib4f(AttribLocation index,float v0,float v1,float v2,float v3);
		public delegate void glVertexAttrib4s(AttribLocation index,short v0,short v1,short v2,short v3);
		public delegate void glVertexAttrib4d(AttribLocation index,double v0,double v1,double v2,double v3);
		public delegate void glVertexAttrib4Nub(AttribLocation index,byte v0,byte v1,byte v2,byte v3);

		public delegate void glVertexAttrib1fv(AttribLocation index,float* v);
		public delegate void glVertexAttrib1sv(AttribLocation index,short* v);
		public delegate void glVertexAttrib1dv(AttribLocation index,double* v);

		public delegate void glVertexAttrib2fv(AttribLocation index,float* v);
		public delegate void glVertexAttrib2sv(AttribLocation index,short* v);
		public delegate void glVertexAttrib2dv(AttribLocation index,double* v);

		public delegate void glVertexAttrib3fv(AttribLocation index,float* v);
		public delegate void glVertexAttrib3sv(AttribLocation index,short* v);
		public delegate void glVertexAttrib3dv(AttribLocation index,double* v);

		public delegate void glVertexAttrib4fv(AttribLocation index,float* v);
		public delegate void glVertexAttrib4sv(AttribLocation index,short* v);
		public delegate void glVertexAttrib4dv(AttribLocation index,double* v);

		public delegate void glVertexAttrib4iv(AttribLocation index,int* v);
		public delegate void glVertexAttrib4bv(AttribLocation index,sbyte* v);
		public delegate void glVertexAttrib4ubv(AttribLocation index,byte* v);
		public delegate void glVertexAttrib4usv(AttribLocation index,ushort* v);
		public delegate void glVertexAttrib4uiv(AttribLocation index,uint* v);

		public delegate void glVertexAttrib4Nbv(AttribLocation index,sbyte* v);
		public delegate void glVertexAttrib4Nsv(AttribLocation index,short* v);
		public delegate void glVertexAttrib4Niv(AttribLocation index,int* v);
		public delegate void glVertexAttrib4Nubv(AttribLocation index,byte* v);
		public delegate void glVertexAttrib4Nusv(AttribLocation index,ushort* v);
		public delegate void glVertexAttrib4Nuiv(AttribLocation index,uint* v);

		public delegate void glVertexAttribPointer(AttribLocation index,int size,uint type,bool normalize,int stride,void* pointer);

		////////////////////////////////////////////////////////////////

		public delegate UniformLocation glGetUniformLocation(Program program,byte* name);

		public delegate void glGetUniformfv(Program program,UniformLocation location,float* param);
		public delegate void glGetUniformiv(Program program,UniformLocation location,int* param);

		public delegate void glUniform1f(UniformLocation location,float v0);
		public delegate void glUniform2f(UniformLocation location,float v0,float v1);
		public delegate void glUniform3f(UniformLocation location,float v0,float v1,float v2);
		public delegate void glUniform4f(UniformLocation location,float v0,float v1,float v2,float v3);

		public delegate void glUniform1i(UniformLocation location,int v0);
		public delegate void glUniform2i(UniformLocation location,int v0,int v1);
		public delegate void glUniform3i(UniformLocation location,int v0,int v1,int v2);
		public delegate void glUniform4i(UniformLocation location,int v0,int v1,int v2,int v3);

		public delegate void glUniform1fv(UniformLocation location,int count,float* v);
		public delegate void glUniform2fv(UniformLocation location,int count,float* v);
		public delegate void glUniform3fv(UniformLocation location,int count,float* v);
		public delegate void glUniform4fv(UniformLocation location,int count,float* v);

		public delegate void glUniform1iv(UniformLocation location,int count,int* v);
		public delegate void glUniform2iv(UniformLocation location,int count,int* v);
		public delegate void glUniform3iv(UniformLocation location,int count,int* v);
		public delegate void glUniform4iv(UniformLocation location,int count,int* v);

		public delegate void glUniformMatrix2fv(UniformLocation location,int count,bool transpose,float* v);
		public delegate void glUniformMatrix3fv(UniformLocation location,int count,bool transpose,float* v);
		public delegate void glUniformMatrix4fv(UniformLocation location,int count,bool transpose,float* v);

		////////////////////////////////////////////////////////////////

		/* VERSION 2.1 */

		////////////////////////////////////////////////////////////////

		public delegate void glUniformMatrix2x3fv(UniformLocation location,int count,bool transpose,float* v);
		public delegate void glUniformMatrix3x2fv(UniformLocation location,int count,bool transpose,float* v);
		public delegate void glUniformMatrix2x4fv(UniformLocation location,int count,bool transpose,float* v);
		public delegate void glUniformMatrix4x2fv(UniformLocation location,int count,bool transpose,float* v);
		public delegate void glUniformMatrix3x4fv(UniformLocation location,int count,bool transpose,float* v);
		public delegate void glUniformMatrix4x3fv(UniformLocation location,int count,bool transpose,float* v);
	}
}