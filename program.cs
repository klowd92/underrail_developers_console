using Mono.Cecil;
using Mono.Cecil.Cil;

/*
 	public void foobar()
	{
		this.an = true
		if (this.s == null)
		{
			ero ero = a2t.a();
			int num = Convert.ToInt32((double)ero.d * 0.75);
			if (num % 2 == 1)
			{
				num++;
			}
			ero ero2 = new ero(ero.c, num);
			this.ao = 0.0;
			this.s = new j8(ero2);
			this.s.Location = new Point(0, -ero2.d);
			this.an7(this.s);
		}
	}
*/

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Int32 resWidth = 1920;
            Int32 resHeight = 1080;

            Console.WriteLine("This program will patch Underail 1.20.0.16 to enable the developers console using ~ (tilde) key");
            Console.WriteLine("This program cannot harm your computer or the integrity of your files (even in error/crash)");
            Console.WriteLine("Output is saved to a different file");
            Console.WriteLine();
            Console.WriteLine("Input your game resolution (My default 1920 x 1080)");

            Console.WriteLine("Width (e.g. 1920): ");
            resWidth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Height (e.g. 1080): ");
            resHeight = Convert.ToInt32(Console.ReadLine());
            resHeight = Convert.ToInt32((resHeight * 0.75));

            ModuleDefinition module = ModuleDefinition.ReadModule("C:\\Program Files (x86)\\GOG Galaxy\\Games\\UnderRail\\underrail.exe");
            AssemblyDefinition netXnaAssembly = default(AssemblyDefinition);
            AssemblyDefinition netXnaInputAssembly = default(AssemblyDefinition);

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

            MethodDefinition method_a2t_a = module.Types
              .Where(t => t.Name == "a2t")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "ero a2t::a()")
              .First();

            MethodDefinition method_cil_j = module.Types
              .Where(t => t.Name == "cil")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void cil::j()")
              .First();

            FieldDefinition var_cil_an = module.Types
              .Where(t => t.Name == "cil")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "System.Boolean cil::an")
              .First();

            FieldDefinition var_cil_s = module.Types
              .Where(t => t.Name == "cil")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "j8 cil::s")
              .First();

            FieldDefinition var_cil_ao = module.Types
              .Where(t => t.Name == "cil")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "System.Double cil::ao")
              .First();

            MethodDefinition method_ero_ctor = module.Types
              .Where(t => t.Name == "ero")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void ero::.ctor(System.Int32,System.Int32)")
              .First();

            FieldDefinition var_ero_d = module.Types
              .Where(t => t.Name == "ero")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "System.Int32 ero::d")
              .First();

            MethodDefinition method_j8_ctor = module.Types
              .Where(t => t.Name == "j8")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void j8::.ctor(ero)")
              .First();

            MethodDefinition method_et3_an7 = module.Types
              .Where(t => t.Name == "et3")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Boolean et3::an7(et3)")
              .First();

            MethodDefinition method_et3_g = module.Types
              .Where(t => t.Name == "et3")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void et3::g(Microsoft.Xna.Framework.Point)")
              .First();

            FieldDefinition var_and_a = module.Types
              .Where(t => t.Name == "and")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "Microsoft.Xna.Framework.Input.Keys and::a")
              .First();

            FieldDefinition var_djn_d = module.Types
              .Where(t => t.Name == "djn")
              .SelectMany(t => t.Fields)
              .Where(f => f.FullName == "cil djn::d")
              .First();

            TypeDefinition type_ero = module.Types
              .Where(t => t.FullName == "ero")
              .First();

            TypeDefinition type_cil = module.Types
              .Where(t => t.FullName == "cil")
              .First();

            MethodDefinition method_point_ctor = netXnaAssembly.MainModule.Types
              .Where(t => t.Name == "Point")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void Microsoft.Xna.Framework.Point::.ctor(System.Int32,System.Int32)")
              .First();

            // var origInstanceField = type.Fields.First(fld => fld.Name.Equals("_original"));

            var enableConsole = new MethodDefinition("foobar", MethodAttributes.Public, module.TypeSystem.Void);
            var ilProcessor = enableConsole.Body.GetILProcessor();

            type_cil.Methods.Add(enableConsole);

            VariableDefinition local_ero = new VariableDefinition(type_ero);
            enableConsole.Body.Variables.Add(local_ero);

            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldc_I4_1);
            ilProcessor.Emit(OpCodes.Stfld, var_cil_an);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldfld, var_cil_s);
            var IL_0063 = ilProcessor.Create(OpCodes.Ret);
            ilProcessor.Emit(OpCodes.Brtrue, IL_0063);
            ilProcessor.Emit(OpCodes.Ldloca_S, local_ero);
            ilProcessor.Emit(OpCodes.Ldc_I4, resWidth);
            ilProcessor.Emit(OpCodes.Ldc_I4, resHeight);
            ilProcessor.Emit(OpCodes.Call, method_ero_ctor);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldc_R8, 0.0);
            ilProcessor.Emit(OpCodes.Stfld, var_cil_ao);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldloc_0);
            ilProcessor.Emit(OpCodes.Newobj, method_j8_ctor);
            ilProcessor.Emit(OpCodes.Stfld, var_cil_s);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldfld, var_cil_s);
            ilProcessor.Emit(OpCodes.Ldc_I4_0);
            ilProcessor.Emit(OpCodes.Ldloc_0);
            ilProcessor.Emit(OpCodes.Ldfld, var_ero_d);
            ilProcessor.Emit(OpCodes.Neg);
            ilProcessor.Emit(OpCodes.Newobj, module.Import(method_point_ctor));
            ilProcessor.Emit(OpCodes.Callvirt, method_et3_g);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldarg_0);
            ilProcessor.Emit(OpCodes.Ldfld, var_cil_s);
            ilProcessor.Emit(OpCodes.Callvirt, method_et3_an7);
            ilProcessor.Emit(OpCodes.Pop);
            ilProcessor.Append(IL_0063);


            MethodDefinition method_cil_foobar = module.Types
              .Where(t => t.Name == "cil")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void cil::foobar()")
              .First();

            MethodDefinition method_djn_a = module.Types
              .Where(t => t.Name == "djn")
              .SelectMany(t => t.Methods)
              .Where(m => m.FullName == "System.Void djn::a(System.Object,and)")
              .First();


            ilProcessor = method_djn_a.Body.GetILProcessor();
            // foreach (var instruction in method.Body.Instructions)
                // Console.WriteLine($"{instruction.OpCode} \"{instruction.Operand}\"");

            //Console.WriteLine($"{ilProcessor.Body.Instructions[45]}");
            //Console.WriteLine($"{ilProcessor.Body.Instructions[46]}");
            //Console.WriteLine($"{ilProcessor.Body.Instructions[47]}");
            //Console.WriteLine($"{ilProcessor.Body.Instructions[48]}");
            //Console.WriteLine($"{ilProcessor.Body.Instructions[49]}");
            //Console.WriteLine($"{ilProcessor.Body.Instructions[50]}");

            Int32 index = 49;
            var start_check = ilProcessor.Create(OpCodes.Ldarg_2);
            ilProcessor.InsertAfter(index++, start_check);
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Ldfld, var_and_a));
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Ldc_I4, 192));
            var finish_check = ilProcessor.Create(OpCodes.Nop);
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Bne_Un, finish_check));
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Ldarg_0));
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Ldfld, var_djn_d));
            ilProcessor.InsertAfter(index++, Instruction.Create(OpCodes.Callvirt, method_cil_foobar));
            ilProcessor.InsertAfter(index++, finish_check);

            ilProcessor.Replace(46, Instruction.Create(OpCodes.Bne_Un, start_check));

            module.Write("C:\\Program Files (x86)\\GOG Galaxy\\Games\\UnderRail\\underrail_console_enabled.exe");

            Console.WriteLine("Game has been successfully patched and saved to: underrail_console_enabled.exe");
        }
    }
}
