using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Security.Cryptography;

/*
 	public void foobar()
	{
		this.an = true
		if (this.s == null)
		{
			ert ert = a2t.a();
			int num = Convert.ToInt32((double)ert.d * 0.75);
			if (num % 2 == 1)
			{
				num++;
			}
			ert ert2 = new ert(ert.c, num);
			this.ao = 0.0;
			this.s = new j8(ert2);
			this.s.Location = new Point(0, -ert2.d);
			this.an7(this.s);
		}
	}
*/

namespace ConsoleApp
{
    internal class Program
    {
        Int32 resWidth;
        Int32 resHeight;
        string path;
        string md5sum = "892310c34d90e53fbfb5a433e73cc27e";
        static void Main(string[] args)
        {
            Program patcher = new Program();
            patcher.GetUserInput();
            patcher.CheckVersion();
            patcher.PatchGame();
        }

        void CheckVersion()
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    var hash = md5.ComputeHash(stream);
                    if (md5sum != BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant())
                    {
                        Console.WriteLine("This patcher only works for Underrail.exe (version 1.20.0.18)");
                        Environment.Exit(1);
                    }
                }
            }
        }

        void GetUserInput()
        {
            Console.WriteLine("This program will patch Underail 1.20.0.18 to enable the developers console using ~ (tilde) key");
            Console.WriteLine("This program cannot harm your computer or the integrity of your files (even in error/crash)");
            Console.WriteLine("Output is saved to a different file");
            Console.WriteLine();
            Console.WriteLine("Input your game resolution (My default 1920 x 1080)");

            string input;

            Console.WriteLine("Width (default 1920): ");
            input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
                resWidth = 1920;
            else
                resWidth = Convert.ToInt32(input);

            Console.WriteLine("Height (default 1080): ");
            input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
                resHeight = 1080;
            else
                resHeight = Convert.ToInt32(input);

            Console.WriteLine($"Configured Resolution: {resWidth} x {resHeight}");
            Console.WriteLine();
            resHeight = Convert.ToInt32((resHeight * 0.75));

            Console.WriteLine("Input full path to underrail.exe (version 1.20.0.18)");
            Console.WriteLine("Default: C:\\Program Files (x86)\\GOG Galaxy\\Games\\UnderRail\\underrail.exe");
            input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
                path = "C:\\Program Files (x86)\\GOG Galaxy\\Games\\UnderRail\\underrail.exe";
            else
                path = input;

            Console.WriteLine();
            Console.WriteLine($"Attempting to read {path}");

        }

        void PatchGame()
        {
            ModuleDefinition module = ModuleDefinition.ReadModule(path);
            AssemblyDefinition netXnaAssembly = default(AssemblyDefinition);

            DefaultAssemblyResolver resolver = new DefaultAssemblyResolver();

            foreach (var dir in Directory.GetDirectories("C:\\Windows\\Microsoft.NET\\assembly\\GAC_32\\Microsoft.Xna.Framework\\", "*", SearchOption.AllDirectories))
            {
                resolver.AddSearchDirectory(dir);
            }

            foreach (var reference in module.AssemblyReferences)
            {
                if (reference.Name == "Microsoft.Xna.Framework")
                {
                    netXnaAssembly = resolver.Resolve(AssemblyNameReference.Parse(reference.Name));
                }
            }

            // Unused
            MethodDefinition method_a2t_a = module.Types
              .Where(t => t.Name == "a2t")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "ert a2t::a()")
              .First();

            // Unused
            MethodDefinition method_cin_j = module.Types
              .Where(t => t.Name == "cin")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void cin::j()")
              .First();

            FieldDefinition var_cin_an = module.Types
              .Where(t => t.Name == "cin")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "System.Boolean cin::an")
              .First();

            FieldDefinition var_cin_s = module.Types
              .Where(t => t.Name == "cin")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "j8 cin::s")
              .First();

            FieldDefinition var_cin_ao = module.Types
              .Where(t => t.Name == "cin")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "System.Double cin::ao")
              .First();

            MethodDefinition method_ert_ctor = module.Types
              .Where(t => t.Name == "ert")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void ert::.ctor(System.Int32,System.Int32)")
              .First();

            FieldDefinition var_ert_d = module.Types
              .Where(t => t.Name == "ert")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "System.Int32 ert::d")
              .First();

            MethodDefinition method_j8_ctor = module.Types
              .Where(t => t.Name == "j8")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void j8::.ctor(ert)")
              .First();

            MethodDefinition method_et8_an7 = module.Types
              .Where(t => t.Name == "et8")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Boolean et8::an7(et8)")
              .First();

            MethodDefinition method_et8_g = module.Types
              .Where(t => t.Name == "et8")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void et8::g(Microsoft.Xna.Framework.Point)")
              .First();

            FieldDefinition var_and_a = module.Types
              .Where(t => t.Name == "and")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "Microsoft.Xna.Framework.Input.Keys and::a")
              .First();

            FieldDefinition var_djr_d = module.Types
              .Where(t => t.Name == "djr")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "cin djr::d")
              .First();

            TypeDefinition type_ert = module.Types
              .Where(t => t.FullName == "ert")
              .First();

            TypeDefinition type_cin = module.Types
              .Where(t => t.FullName == "cin")
              .First();

            MethodDefinition method_point_ctor = netXnaAssembly.MainModule.Types
              .Where(t => t.Name == "Point")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void Microsoft.Xna.Framework.Point::.ctor(System.Int32,System.Int32)")
              .First();

            // var origInstanceField = type.Fields.First(fld => fld.Name.Equals("_original"));

            // Add .NET code which enables the developer console

            var enableConsole = new MethodDefinition("foobar", MethodAttributes.Public, module.TypeSystem.Void);
            var ilProcessor = enableConsole.Body.GetILProcessor();

            type_cin.Methods.Add(enableConsole);

            VariableDefinition local_ert = new VariableDefinition(type_ert);
            enableConsole.Body.Variables.Add(local_ert);

            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldc_I4_1);
            ilProcessor.Emit(OpCodes.Stfld, var_cin_an);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldfld, var_cin_s);
            var IL_0063 = ilProcessor.Create(OpCodes.Ret);
            ilProcessor.Emit(OpCodes.Brtrue, IL_0063);
            ilProcessor.Emit(OpCodes.Ldloca_S, local_ert);
            ilProcessor.Emit(OpCodes.Ldc_I4, resWidth);
            ilProcessor.Emit(OpCodes.Ldc_I4, resHeight);
            ilProcessor.Emit(OpCodes.Call, method_ert_ctor);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldc_R8, 0.0);
            ilProcessor.Emit(OpCodes.Stfld, var_cin_ao);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldloc_0);
            ilProcessor.Emit(OpCodes.Newobj, method_j8_ctor);
            ilProcessor.Emit(OpCodes.Stfld, var_cin_s);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldfld, var_cin_s);
            ilProcessor.Emit(OpCodes.Ldc_I4_0);
            ilProcessor.Emit(OpCodes.Ldloc_0);
            ilProcessor.Emit(OpCodes.Ldfld, var_ert_d);
            ilProcessor.Emit(OpCodes.Neg);
            ilProcessor.Emit(OpCodes.Newobj, module.Import(method_point_ctor));
            ilProcessor.Emit(OpCodes.Callvirt, method_et8_g);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldfld, var_cin_s);
            ilProcessor.Emit(OpCodes.Callvirt, method_et8_an7);
            ilProcessor.Emit(OpCodes.Pop);
            ilProcessor.Append(IL_0063);


            MethodDefinition method_cin_foobar = module.Types
              .Where(t => t.Name == "cin")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void cin::foobar()")
              .First();

            MethodDefinition method_djr_a = module.Types
              .Where(t => t.Name == "djr")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void djr::a(System.Object,and)")
              .First();


            // Add .NET code which checks for ~ (tilde) key press

            ilProcessor = method_djr_a.Body.GetILProcessor();

            /*
             foreach (var instruction in method.Body.Instructions)
                 Console.WriteLine($"{instruction.OpCode} \"{instruction.Operand}\"");

            Console.WriteLine($"{ilProcessor.Body.Instructions[45]}");
            Console.WriteLine($"{ilProcessor.Body.Instructions[46]}");
            Console.WriteLine($"{ilProcessor.Body.Instructions[47]}");
            Console.WriteLine($"{ilProcessor.Body.Instructions[48]}");
            Console.WriteLine($"{ilProcessor.Body.Instructions[49]}");
            Console.WriteLine($"{ilProcessor.Body.Instructions[50]}");
            */

            Int32 index = 49;
            var start_check = ilProcessor.Create(OpCodes.Ldarg_2);
            ilProcessor.InsertAfter(index++, start_check);
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Ldfld, var_and_a));
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Ldc_I4, 192));
            var finish_check = ilProcessor.Create(OpCodes.Nop);
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Bne_Un, finish_check));
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Ldarg_0));
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Ldfld, var_djr_d));
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Callvirt, method_cin_foobar));
            ilProcessor.InsertAfter(index++, finish_check);

            ilProcessor.Replace(46, Instruction.Create(OpCodes.Bne_Un, start_check));


            string outPath = Path.GetDirectoryName(path) + "\\" + "underrail_console_enabled.exe";
            module.Write(outPath);

            Console.WriteLine();
            Console.WriteLine("Game has been successfully patched and saved to:");
            Console.WriteLine($"{outPath}");

            Console.WriteLine("\nGoodBye!\n");
        }
    }
}
