using System;

namespace Open
{
	partial class GL
	{
		protected glActiveTexture activeTexture	= null;
		protected glAttachShader attachShader	= null;

		////////////////////////////////////////////////////////////////

		protected glBeginQuery beginQuery	= null;
		protected glEndQuery endQuery	= null;

		////////////////////////////////////////////////////////////////

		protected glBindAttribLocation bindAttribLocation	= null;

		protected glBindBuffer bindBuffer	= null;

		protected glBindTexture bindTexture	= null;

		////////////////////////////////////////////////////////////////

		protected glBlendColor blendColor	= null;

		protected glBlendEquation blendEquation	= null;
		protected glBlendEquationSeparate blendEquationSeparate	= null;

		protected glBlendFunc blendFunc	= null;
		protected glBlendFuncSeparate blendFuncSeparate	= null;

		////////////////////////////////////////////////////////////////

		protected glBufferData bufferData	= null;
		protected glBufferSubData bufferSubData	= null;

		////////////////////////////////////////////////////////////////

		protected glClear clear	= null;

		protected glClearColor clearColor	= null;
		protected glClearDepth clearDepth	= null;
		protected glClearStencil clearStencil	= null;

		////////////////////////////////////////////////////////////////

		protected glColorMask colorMask	= null;

		////////////////////////////////////////////////////////////////

		protected glCompileShader compileShader	= null;

		////////////////////////////////////////////////////////////////

		protected glCompressedTexImage1D compressedTexImage1D	= null;
		protected glCompressedTexImage2D compressedTexImage2D	= null;
		protected glCompressedTexImage3D compressedTexImage3D	= null;

		protected glCompressedTexSubImage1D compressedTexSubImage1D	= null;
		protected glCompressedTexSubImage2D compressedTexSubImage2D	= null;
		protected glCompressedTexSubImage3D compressedTexSubImage3D	= null;

		////////////////////////////////////////////////////////////////

		protected glCopyTexImage1D copyTexImage1D	= null;
		protected glCopyTexImage2D copyTexImage2D	= null;

		protected glCopyTexSubImage1D copyTexSubImage1D	= null;
		protected glCopyTexSubImage2D copyTexSubImage2D	= null;
		protected glCopyTexSubImage3D copyTexSubImage3D	= null;

		////////////////////////////////////////////////////////////////

		protected glCreateProgram createProgram	= null;
		protected glCreateShader createShader	= null;

		////////////////////////////////////////////////////////////////

		protected glCullFace cullFace	= null;

		////////////////////////////////////////////////////////////////

		protected glDeleteBuffers deleteBuffers	= null;
		protected glDeleteProgram deleteProgram	= null;
		protected glDeleteQueries deleteQueries	= null;
		protected glDeleteShader deleteShader	= null;
		protected glDeleteTextures deleteTextures	= null;

		////////////////////////////////////////////////////////////////

		protected glDepthFunc depthFunc	= null;

		protected glDepthMask depthMask	= null;

		protected glDepthRange depthRange	= null;

		////////////////////////////////////////////////////////////////

		protected glDetachShader detachShader	= null;

		////////////////////////////////////////////////////////////////

		protected glDrawArrays drawArrays	= null;

		protected glDrawBuffer drawBuffer	= null;

		protected glDrawBuffers drawBuffers	= null;

		protected glDrawElements drawElements	= null;

		protected glDrawRangeElements drawRangeElements	= null;

		////////////////////////////////////////////////////////////////

		protected glEnable enable	= null;
		protected glDisable disable	= null;

		protected glEnableVertexAttribArray enableVertexAttribArray	= null;
		protected glDisableVertexAttribArray disableVertexAttribArray	= null;

		////////////////////////////////////////////////////////////////

		protected glFinish finish	= null;

		protected glFlush flush	= null;

		////////////////////////////////////////////////////////////////

		protected glFrontFace frontFace	= null;

		////////////////////////////////////////////////////////////////

		protected glGenBuffers genBuffers	= null;

		protected glGenQueries genQueries	= null;

		protected glGenTextures genTextures	= null;

		////////////////////////////////////////////////////////////////

		protected glGetBooleanv getBooleanv	= null;
		protected glGetDoublev getDoublev	= null;
		protected glGetFloatv getFloatv	= null;
		protected glGetIntegerv getIntegerv	= null;

		protected glGetActiveAttrib getActiveAttrib	= null;
		protected glGetActiveUniform getActiveUniform	= null;

		protected glGetAttachedShaders getAttachedShaders	= null;

		protected glGetAttribLocation getAttribLocation	= null;

		protected glGetBufferParameteriv getBufferParameteriv	= null;
		protected glGetBufferPointerv getBufferPointerv	= null;
		protected glGetBufferSubData getBufferSubData	= null;

		protected glGetCompressedTexImage getCompressedTexImage	= null;

		////////////////////////////////////////////////////////////////

		protected glGetError getError	= null;

		protected glGetPointerv getPointerv	= null;

		protected glGetProgramiv getProgramiv	= null;

		protected glGetProgramInfoLog getProgramInfoLog	= null;

		protected glGetQueryiv getQueryiv	= null;

		protected glGetQueryObjectiv getQueryObjectiv	= null;

		protected glGetQueryObjectuiv getQueryObjectuiv	= null;

		protected glGetShaderiv getShaderiv	= null;
		protected glGetShaderInfoLog getShaderInfoLog	= null;
		protected glGetShaderSource getShaderSource	= null;

		protected glGetString getString	= null;

		protected glGetTexImage getTexImage	= null;

		protected glGetTexLevelParameterfv getTexLevelParameterfv	= null;
		protected glGetTexLevelParameteriv getTexLevelParameteriv	= null;

		protected glGetTexParameterfv getTexParameterfv	= null;
		protected glGetTexParameteriv getTexParameteriv	= null;

		protected glGetUniformfv getUniformfv	= null;
		protected glGetUniformiv getUniformiv	= null;
		protected glGetUniformLocation getUniformLocation	= null;

		protected glGetVertexAttribdv getVertexAttribdv	= null;
		protected glGetVertexAttribfv getVertexAttribfv	= null;
		protected glGetVertexAttribiv getVertexAttribiv	= null;
		protected glGetVertexAttribPointerv getVertexAttribPointerv	= null;

		////////////////////////////////////////////////////////////////

		protected glHint hint	= null;

		////////////////////////////////////////////////////////////////

		protected glIsBuffer isBuffer	= null;
		protected glIsEnabled isEnabled	= null;
		protected glIsProgram isProgram	= null;
		protected glIsQuery isQuery	= null;
		protected glIsShader isShader	= null;
		protected glIsTexture isTexture	= null;

		////////////////////////////////////////////////////////////////

		protected glLineWidth lineWidth	= null;

		////////////////////////////////////////////////////////////////

		protected glLinkProgram linkProgram	= null;

		////////////////////////////////////////////////////////////////

		protected glLogicOp logicOp	= null;

		////////////////////////////////////////////////////////////////

		protected glMapBuffer mapBuffer	= null;
		protected glUnmapBuffer unmapBuffer	= null;

		////////////////////////////////////////////////////////////////

		protected glMultiDrawArrays multiDrawArrays	= null;

		protected glMultiDrawElements multiDrawElements	= null;

		////////////////////////////////////////////////////////////////

		protected glPixelStoref pixelStoref	= null;
		protected glPixelStorei pixelStorei	= null;

		////////////////////////////////////////////////////////////////

		protected glPointParameterf pointParameterf	= null;
		protected glPointParameteri pointParameteri	= null;
		protected glPointParameterfv pointParameterfv	= null;
		protected glPointParameteriv pointParameteriv	= null;

		protected glPointSize pointSize	= null;

		////////////////////////////////////////////////////////////////

		protected glPolygonMode polygonMode	= null;

		protected glPolygonOffset polygonOffset	= null;

		////////////////////////////////////////////////////////////////

		protected glReadBuffer readBuffer	= null;
		protected glReadPixels readPixels	= null;

		////////////////////////////////////////////////////////////////

		protected glSampleCoverage sampleCoverage	= null;

		////////////////////////////////////////////////////////////////

		protected glScissor scissor	= null;

		////////////////////////////////////////////////////////////////

		protected glShaderSource shaderSource	= null;

		////////////////////////////////////////////////////////////////

		protected glStencilFunc stencilFunc	= null;
		protected glStencilFuncSeparate stencilFuncSeparate	= null;

		protected glStencilMask stencilMask	= null;
		protected glStencilMaskSeparate stencilMaskSeparate	= null;

		protected glStencilOp stencilOp	= null;
		protected glStencilOpSeparate stencilOpSeparate	= null;

		////////////////////////////////////////////////////////////////

		protected glTexImage1D texImage1D	= null;
		protected glTexImage2D texImage2D	= null;
		protected glTexImage3D texImage3D	= null;

		protected glTexParameterf texParameterf	= null;
		protected glTexParameteri texParameteri	= null;
		protected glTexParameterfv texParameterfv	= null;
		protected glTexParameteriv texParameteriv	= null;

		protected glTexSubImage1D texSubImage1D	= null;
		protected glTexSubImage2D texSubImage2D	= null;
		protected glTexSubImage3D texSubImage3D	= null;

		////////////////////////////////////////////////////////////////

		protected glUniform1f uniform1f	= null;
		protected glUniform2f uniform2f	= null;
		protected glUniform3f uniform3f	= null;
		protected glUniform4f uniform4f	= null;

		protected glUniform1i uniform1i	= null;
		protected glUniform2i uniform2i	= null;
		protected glUniform3i uniform3i	= null;
		protected glUniform4i uniform4i	= null;

		protected glUniform1fv uniform1fv	= null;
		protected glUniform2fv uniform2fv	= null;
		protected glUniform3fv uniform3fv	= null;
		protected glUniform4fv uniform4fv	= null;

		protected glUniform1iv uniform1iv	= null;
		protected glUniform2iv uniform2iv	= null;
		protected glUniform3iv uniform3iv	= null;
		protected glUniform4iv uniform4iv	= null;

		protected glUniformMatrix2fv uniformMatrix2fv	= null;
		protected glUniformMatrix3fv uniformMatrix3fv	= null;
		protected glUniformMatrix4fv uniformMatrix4fv	= null;

		protected glUniformMatrix2x3fv uniformMatrix2x3fv	= null;
		protected glUniformMatrix3x2fv uniformMatrix3x2fv	= null;
		protected glUniformMatrix2x4fv uniformMatrix2x4fv	= null;
		protected glUniformMatrix4x2fv uniformMatrix4x2fv	= null;
		protected glUniformMatrix3x4fv uniformMatrix3x4fv	= null;
		protected glUniformMatrix4x3fv uniformMatrix4x3fv	= null;

		////////////////////////////////////////////////////////////////

		protected glUseProgram useProgram	= null;

		protected glValidateProgram validateProgram	= null;

		////////////////////////////////////////////////////////////////

		protected glVertexAttrib1f vertexAttrib1f	= null;
		protected glVertexAttrib1s vertexAttrib1s	= null;
		protected glVertexAttrib1d vertexAttrib1d	= null;

		protected glVertexAttrib2f vertexAttrib2f	= null;
		protected glVertexAttrib2s vertexAttrib2s	= null;
		protected glVertexAttrib2d vertexAttrib2d	= null;

		protected glVertexAttrib3f vertexAttrib3f	= null;
		protected glVertexAttrib3s vertexAttrib3s	= null;
		protected glVertexAttrib3d vertexAttrib3d	= null;

		protected glVertexAttrib4f vertexAttrib4f	= null;
		protected glVertexAttrib4s vertexAttrib4s	= null;
		protected glVertexAttrib4d vertexAttrib4d	= null;

		protected glVertexAttrib4Nub vertexAttrib4Nub	= null;

		protected glVertexAttrib1fv vertexAttrib1fv	= null;
		protected glVertexAttrib1sv vertexAttrib1sv	= null;
		protected glVertexAttrib1dv vertexAttrib1dv	= null;

		protected glVertexAttrib2fv vertexAttrib2fv	= null;
		protected glVertexAttrib2sv vertexAttrib2sv	= null;
		protected glVertexAttrib2dv vertexAttrib2dv	= null;

		protected glVertexAttrib3fv vertexAttrib3fv	= null;
		protected glVertexAttrib3sv vertexAttrib3sv	= null;
		protected glVertexAttrib3dv vertexAttrib3dv	= null;

		protected glVertexAttrib4fv vertexAttrib4fv	= null;
		protected glVertexAttrib4sv vertexAttrib4sv	= null;
		protected glVertexAttrib4dv vertexAttrib4dv	= null;
		protected glVertexAttrib4iv vertexAttrib4iv	= null;
		protected glVertexAttrib4bv vertexAttrib4bv	= null;
		protected glVertexAttrib4ubv vertexAttrib4ubv	= null;
		protected glVertexAttrib4usv vertexAttrib4usv	= null;
		protected glVertexAttrib4uiv vertexAttrib4uiv	= null;

		protected glVertexAttrib4Nbv vertexAttrib4Nbv	= null;
		protected glVertexAttrib4Nsv vertexAttrib4Nsv	= null;
		protected glVertexAttrib4Niv vertexAttrib4Niv	= null;
		protected glVertexAttrib4Nubv vertexAttrib4Nubv	= null;
		protected glVertexAttrib4Nusv vertexAttrib4Nusv	= null;
		protected glVertexAttrib4Nuiv vertexAttrib4Nuiv	= null;

		protected glVertexAttribPointer vertexAttribPointer	= null;

		////////////////////////////////////////////////////////////////

		protected glViewport viewport	= null;
	}
}