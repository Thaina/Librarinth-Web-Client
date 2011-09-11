using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using BaseExportDLL;

namespace ExportDLL
{
	partial class Program
	{
		class ExitException : Exception
		{
			public readonly int Code;
			public ExitException(int code,string message) : base(message) { Code	= code; }
		}

		static void Work(string path,string filepath,bool debug)
		{
			var asmFile	= Assembly.Load(File.ReadAllBytes(filepath));

			string otherAsm	= string.Empty;
			foreach(var asmRef in asmFile.GetReferencedAssemblies())
			{
				var find	= Array.Find(AppDomain.CurrentDomain.GetAssemblies()
					,(Assembly obj)=>obj.FullName == asmRef.FullName);
				if(find == null)
					otherAsm	+= " \"" + path + Path.DirectorySeparatorChar + asmRef.Name + ".dll\"";
			}

			if(!string.IsNullOrEmpty(otherAsm))
			{
				MessageBox.Show(otherAsm);
				var outPath	= path + Path.DirectorySeparatorChar + "outPath.dll";
				Call(@"C:\Program Files\Microsoft\ILMerge\ILMerge.exe"
					,"/target:library /out:\"" + outPath + "\" \"" + filepath + "\"" + otherAsm);

				File.Copy(outPath,filepath,true);
				asmFile	= Assembly.Load(File.ReadAllBytes(filepath));
			}

			var types	= asmFile.GetTypes();

			int exportscount	= 0;
			var dic	= new Dictionary<string,Dictionary<string,DLLExportAttribute>>();
			foreach(Type type in types)
			{
				var mis	= type.FindMembers(MemberTypes.Method
					,BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,null,null);
				foreach(MemberInfo mi in mis)
				{
					var attrs	= mi.GetCustomAttributes(typeof(DLLExportAttribute),false) as DLLExportAttribute[];
					if(attrs != null && attrs.Length > 0)
					{
						Dictionary<string,DLLExportAttribute> exp;
						while(!dic.TryGetValue(type.FullName,out exp))
							dic.Add(type.FullName,new Dictionary<string,DLLExportAttribute>());

						exp.Add(mi.Name,attrs[0]);
						exportscount++;
					}
				}
			}
			
			if(exportscount > 0)
			{
				int exportpos	= 1;
				Directory.SetCurrentDirectory(path);
				string filename	= Path.GetFileNameWithoutExtension(filepath);

				string arguments	= string.Format("/nobar{1}/out:{0}.il {0}.dll",filename,debug ? " /linenum " : " ");
				MessageBox.Show(string.Format("Deassembling : {0}",arguments));

				Call(@"C:\Program Files\Microsoft SDKs\Windows\v7.0A\bin\ildasm.exe",arguments);

				path	= Path.Combine(path,filename + ".il");
				var wholeilfile = ParseToIL(path,exportscount,dic,ref exportpos);
				using(var sw	= File.CreateText(path))
				{
					foreach(string line in wholeilfile)
						sw.WriteLine(line);
				}

				string res	= filename + ".res";
				if(File.Exists(filename + ".res"))
					res	= " /res:" + res;
				else res	= string.Empty;

				arguments	= string.Format("/DLL /nologo /quiet {0}.il{1} /out:{0}.dll {2}"
					,filename,res,debug ? "/debug" : "/optimize");
				MessageBox.Show(string.Format("Compiling : {0}",arguments));
				
				Call(@"C:\Windows\Microsoft.NET\Framework\v2.0.50727\ilasm.exe",arguments);
			}
			else throw new Exception("Nothing Export!");
		}
		
		static IEnumerable<KeyValuePair<string,string>> FFVersionInfo
		{
			get
			{
				yield return new KeyValuePair<string,string>("FileExtents","lbr");
				yield return new KeyValuePair<string,string>("MIMEType","application/x-librarinth");
				yield return new KeyValuePair<string,string>("ProductName","Librarinth Plugin Canvas");
				yield return new KeyValuePair<string,string>("FileDescription","NPAPI PlugIn for displaying Librarinth Game Engine");
				yield return new KeyValuePair<string,string>("CompanyName","Librarinth Studio");
				yield return new KeyValuePair<string,string>("FileOpenName","nplibrarinth");
				yield return new KeyValuePair<string,string>("InternalName","nplibrarinth");
			}
		}

		[STAThread]
		static int Main(string[] args)
		{
			try
			{
				if(args.Length < 1)
					throw new ExitException(1,"Parameter error!");

				string filepath	= args[0];
				string path	= Path.GetDirectoryName(filepath);
				if(string.IsNullOrEmpty(path))
					throw new ExitException(1,"Full path needed!");

				string ext	= Path.GetExtension(filepath);
				if(ext != ".dll")
					throw new ExitException(1,"Target" + filepath + "should be dll!");

				try
				{
					Work(path,filepath,args.Length > 1 && args[1] == "/Debug");
				}
				catch(ReflectionTypeLoadException e)
				{
					foreach(var loadException in e.LoaderExceptions)
					{
						throw loadException;
					}
				}

				NativeVersionInfo.UpdateVersionResource(filepath,"040904E4",FFVersionInfo);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + ex.StackTrace);
				var exitcode	= ex as ExitException;
				return exitcode == null ? -1 : exitcode.Code;
			}

			return 0;
		}
	}
}
