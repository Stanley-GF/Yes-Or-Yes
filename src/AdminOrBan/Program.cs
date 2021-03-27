using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace AdminOrBan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[");
            Console.ResetColor();
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("] ");
            Console.ResetColor();
            Console.Write("Command ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("> ");
            Console.ResetColor();
            string commandToBeExecute = Console.ReadLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[");
            Console.ResetColor();
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("] ");
            Console.ResetColor();
            Console.Write("File Name ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("> ");
            Console.ResetColor();
            string FileName = Console.ReadLine();

            if (!FileName.EndsWith(".exe"))
            {
                FileName = FileName + ".exe";
            }

            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = true;
            parameters.GenerateInMemory = false;
            parameters.OutputAssembly = FileName;
            parameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("System.Data.dll");
            parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            parameters.ReferencedAssemblies.Add("System.Xml.dll");
            parameters.ReferencedAssemblies.Add("System.Xml.Linq.dll");


            CompilerResults results = icc.CompileAssemblyFromSource(parameters, Properties.Resource.stub.Replace("$[.**.]$", commandToBeExecute));
            Console.Clear();


            if (results.Errors.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                foreach (var item in results.Errors)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Succesfully build and saved at \"")
;
                Console.ForegroundColor = ConsoleColor.DarkGreen
                    ;
                Console.Write(FileName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\"");
                Console.ReadKey()
                    ; }
        }
    }
}
