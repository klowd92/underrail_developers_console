using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Security.Cryptography;

/*
 	public void foobar()
	{
		this.an = true
		if (this.s == null)
		{
			er0 er0 = a2y.a();
			int num = Convert.ToInt32((double)er0.d * 0.75);
			if (num % 2 == 1)
			{
				num++;
			}
			er0 er02 = new er0(er0.c, num);
			this.ao = 0.0;
			this.s = new j8(er02);
			this.s.Location = new Point(0, -er02.d);
			this.an8(this.s);
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
        string md5sum = "1b947febb8364120030507c0117f4cb3";
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
                    string game_md5sum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    if (md5sum != game_md5sum)
                    {
                        Console.WriteLine($"\nExpected game md5sum (version 1.2.0.20): {md5sum}");
                        Console.WriteLine($"Found md5sum: {game_md5sum}");
                        Console.WriteLine("\nThis patcher only works for Underrail.exe (version 1.2.0.20)");
                        while (!Console.KeyAvailable) { }
                        Environment.Exit(1);
                    }
                }
            }
        }

        void GetUserInput()
        {
            Console.WriteLine("This program will patch Underail 1.2.0.20 to enable the developers console using ~ (tilde) key");
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

            Console.WriteLine("Input full path to underrail.exe (version 1.2.0.20)");
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
            MethodDefinition method_a2y_a = module.Types
              .Where(t => t.Name == "a2y")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "er0 a2y::a()")
              .First();

            // Unused
            MethodDefinition method_ciu_j = module.Types
              .Where(t => t.Name == "ciu")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void ciu::j()")
              .First();

            FieldDefinition var_ciu_an = module.Types
              .Where(t => t.Name == "ciu")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "System.Boolean ciu::an")
              .First();

            FieldDefinition var_ciu_s = module.Types
              .Where(t => t.Name == "ciu")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "j8 ciu::s")
              .First();

            FieldDefinition var_ciu_ao = module.Types
              .Where(t => t.Name == "ciu")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "System.Double ciu::ao")
              .First();

            MethodDefinition method_er0_ctor = module.Types
              .Where(t => t.Name == "er0")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void er0::.ctor(System.Int32,System.Int32)")
              .First();

            FieldDefinition var_er0_d = module.Types
              .Where(t => t.Name == "er0")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "System.Int32 er0::d")
              .First();

            MethodDefinition method_j8_ctor = module.Types
              .Where(t => t.Name == "j8")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void j8::.ctor(er0)")
              .First();

            MethodDefinition method_eug_an8 = module.Types
              .Where(t => t.Name == "eug")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Boolean eug::an8(eug)")
              .First();

            MethodDefinition method_eug_g = module.Types
              .Where(t => t.Name == "eug")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void eug::g(Microsoft.Xna.Framework.Point)")
              .First();

            FieldDefinition var_ang_a = module.Types    
              .Where(t => t.Name == "ang")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "Microsoft.Xna.Framework.Input.Keys ang::a")
              .First();

            FieldDefinition var_djw_d = module.Types
              .Where(t => t.Name == "djw")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "ciu djw::d")
              .First();

            TypeDefinition type_er0 = module.Types
              .Where(t => t.FullName == "er0")
              .First();

            TypeDefinition type_ciu = module.Types
              .Where(t => t.FullName == "ciu")
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

            type_ciu.Methods.Add(enableConsole);

            VariableDefinition local_er0 = new VariableDefinition(type_er0);
            enableConsole.Body.Variables.Add(local_er0);

            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldc_I4_1);
            ilProcessor.Emit(OpCodes.Stfld, var_ciu_an);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldfld, var_ciu_s);
            var IL_0063 = ilProcessor.Create(OpCodes.Ret);
            ilProcessor.Emit(OpCodes.Brtrue, IL_0063);
            ilProcessor.Emit(OpCodes.Ldloca_S, local_er0);
            ilProcessor.Emit(OpCodes.Ldc_I4, resWidth);
            ilProcessor.Emit(OpCodes.Ldc_I4, resHeight);
            ilProcessor.Emit(OpCodes.Call, method_er0_ctor);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldc_R8, 0.0);
            ilProcessor.Emit(OpCodes.Stfld, var_ciu_ao);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldloc_0);
            ilProcessor.Emit(OpCodes.Newobj, method_j8_ctor);
            ilProcessor.Emit(OpCodes.Stfld, var_ciu_s);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldfld, var_ciu_s);
            ilProcessor.Emit(OpCodes.Ldc_I4_0);
            ilProcessor.Emit(OpCodes.Ldloc_0);
            ilProcessor.Emit(OpCodes.Ldfld, var_er0_d);
            ilProcessor.Emit(OpCodes.Neg);
            ilProcessor.Emit(OpCodes.Newobj, module.Import(method_point_ctor));
            ilProcessor.Emit(OpCodes.Callvirt, method_eug_g);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldfld, var_ciu_s);
            ilProcessor.Emit(OpCodes.Callvirt, method_eug_an8);
            ilProcessor.Emit(OpCodes.Pop);
            ilProcessor.Append(IL_0063);


            MethodDefinition method_ciu_foobar = module.Types
              .Where(t => t.Name == "ciu")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void ciu::foobar()")
              .First();

            MethodDefinition method_djw_a = module.Types
              .Where(t => t.Name == "djw")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void djw::a(System.Object,ang)")
              .First();


            // Add .NET code which checks for ~ (tilde) key press

            ilProcessor = method_djw_a.Body.GetILProcessor();

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
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Ldfld, var_ang_a));
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Ldc_I4, 192));
            var finish_check = ilProcessor.Create(OpCodes.Nop);
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Bne_Un, finish_check));
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Ldarg_0));
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Ldfld, var_djw_d));
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Callvirt, method_ciu_foobar));
            ilProcessor.InsertAfter(index++, finish_check);

            ilProcessor.Replace(46, Instruction.Create(OpCodes.Bne_Un, start_check));


            string outPath = Path.GetDirectoryName(path) + "\\" + "underrail_console_enabled.exe";
            module.Write(outPath);

            Console.WriteLine();
            Console.WriteLine("Game has been successfully patched and saved to:");
            Console.WriteLine($"{outPath}");

            Console.WriteLine("\nGoodBye!\n");
            while (!Console.KeyAvailable) { }
        }
    }
}
