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
	enum ParserState
	{
		Normal,
		ClassDeclaration,
		Class,
		DeleteExportDependency,
		MethodDeclaration,
		MethodProperties,
		Method,
		DeleteExportAttribute,
	}
	partial class Program
	{
		static void Call(string file,string args)
		{
			var info	= new ProcessStartInfo(file,args)
			{
				CreateNoWindow	= false,
				UseShellExecute	= false,
				RedirectStandardOutput	= true,
			};

			var proc	= Process.Start(info);
			proc.WaitForExit();
			
			if(proc.ExitCode != 0)
				throw new ExitException(proc.ExitCode
					,"ProcessOutput " + file + " " + args + " : " + proc.StandardOutput.ReadToEnd());
		}

		private static List<string> ParseToIL(string path,int exportscount,Dictionary<string,Dictionary<string,DLLExportAttribute>> dic,ref int exportpos)
		{
			var wholeilfile	= new List<string>();
			var sr	= File.OpenText(path);
			var methodDeclaration	= "";
			var methodname	= "";
			var classdeclaration	= "";
			var methodbefore	= "";
			var methodafter	= "";
			int methodpos	= 0;
			var state	= ParserState.Normal;
			var classnames	= new Stack<string>();
			var externassembly	= new List<string>();
			while(!sr.EndOfStream)
			{
				string line	= sr.ReadLine();
				string trimedline	= line.Trim();
				bool addilne	= true;
				switch(state)
				{
					case ParserState.Normal:
						if(trimedline.StartsWith(".corflags"))
						{
							wholeilfile.Add(".corflags 0x00000002");
							wholeilfile.Add(string.Format(".vtfixup [{0}] int32 fromunmanaged at VT_01",exportscount));
							wholeilfile.Add(string.Format(".data VT_01	= int32[{0}]",exportscount));
							addilne	= false;
						}
						else if(trimedline.StartsWith(".class"))
						{
							state	= ParserState.ClassDeclaration;
							addilne	= false;
							classdeclaration	= trimedline;
						}
						else if(trimedline.StartsWith(".assembly extern " + typeof(DLLExportAttribute).Namespace))
						{
							addilne	= false;
							state	= ParserState.DeleteExportDependency;
						}
						break;
					case ParserState.DeleteExportDependency:
						if(trimedline.StartsWith("}"))
						{
							state	= ParserState.Normal;
						}
						addilne	= false;
						break;
					case ParserState.ClassDeclaration:
						if(trimedline.StartsWith("{"))
						{
							state	= ParserState.Class;
							string classname	= "";
							Regex reg	= new Regex(@".+\s+([^\s]+) extends \[.*");
							Match m	= reg.Match(classdeclaration);
							if(m.Groups.Count > 1)
								classname	= m.Groups[1].Value;
							classname	= classname.Replace("'","");
							if(classnames.Count > 0)
								classname	= classnames.Peek() + "+" + classname;
							classnames.Push(classname);
							wholeilfile.Add(classdeclaration);
						}
						else
						{
							classdeclaration += " " + trimedline;
							addilne	= false;
						}
						break;
					case ParserState.Class:
						if(trimedline.StartsWith(".class"))
						{
							state	= ParserState.ClassDeclaration;
							addilne	= false;
							classdeclaration	= trimedline;
						}
						else if(trimedline.StartsWith(".method"))
						{
							if(dic.ContainsKey(classnames.Peek()))
							{
								methodDeclaration	= trimedline;
								addilne	= false;
								state	= ParserState.MethodDeclaration;
							}
						}
						else if(trimedline.StartsWith("} // end of class"))
						{
							classnames.Pop();
							if(classnames.Count > 0)
								state	= ParserState.Class;
							else
								state	= ParserState.Normal;
						}
						break;
					case ParserState.MethodDeclaration:
						if(trimedline.StartsWith("{"))
						{
							Regex reg	= new Regex(@"(?<before>[^\(]+\s+)(?<method>[^\(]+)(?<after>\(.*)");
							Match m	= reg.Match(methodDeclaration);
							if(m.Groups.Count > 3)
							{
								methodbefore	= m.Groups["before"].Value;
								methodafter	= m.Groups["after"].Value;
								methodname	= m.Groups["method"].Value;
							}

							if(dic[classnames.Peek()].ContainsKey(methodname))
							{
								methodpos	= wholeilfile.Count;
								state	= ParserState.MethodProperties;
							}
							else
							{
								wholeilfile.Add(methodDeclaration);
								state	= ParserState.Method;
								methodpos	= 0;
							}
						}
						else
						{
							methodDeclaration += " " + trimedline;
							addilne	= false;
						}
						break;
					case ParserState.Method:
						if(trimedline.StartsWith("} // end of method"))
						{
							state	= ParserState.Class;
						}
						break;
					case ParserState.MethodProperties:
						if(trimedline.StartsWith(string.Format(".custom instance void [{0}]",typeof(DLLExportAttribute).Namespace)))
						{
							addilne	= false;
							state	= ParserState.DeleteExportAttribute;
						}
						else if(trimedline.StartsWith("// Code"))
						{
							state	= ParserState.Method;
							if(methodpos != 0)
								wholeilfile.Insert(methodpos,methodDeclaration);
						}
						break;
					case ParserState.DeleteExportAttribute:
						if(trimedline.StartsWith(".custum") || trimedline.StartsWith("// Code"))
						{
							var attr	= dic[classnames.Peek()][methodname];
							methodDeclaration	= methodbefore + "modopt([mscorlib]" + attr.Convention + ") " + methodname + methodafter;
							if(methodpos != 0)
								wholeilfile.Insert(methodpos,methodDeclaration);
							wholeilfile.Add(".vtentry 1 : " + exportpos.ToString());
							wholeilfile.Add(string.Format(".export [{0}] as {1}",exportpos,dic[classnames.Peek()][methodname].ExportName));
							
							exportpos++;

							state	= ParserState.Method;
						}
						else addilne	= false;
						break;
				}
				if(addilne)
					wholeilfile.Add(line);
			}

			sr.Close();
			return wholeilfile;
		}
	}
}
