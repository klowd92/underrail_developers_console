using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Ouroboros.Common.Data;

namespace underrail
{
    // ============================================================================
    // Foobar_GClass3285 - Effect Name argument type
    // ============================================================================
    public sealed class Foobar_GClass3285 : Foobar_GClass3283
    {
        public override string vmethod_0()
        {
            return "effectName";
        }

        public override object vmethod_3(string string_0)
        {
            return string_0;
        }

        protected override List<object> vmethod_2()
        {
            List<object> list = new List<object>();
            GInterface72 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface72>();
            if (serviceOrThrow.imethod_0().method_6() != null)
            {
                foreach (string text in serviceOrThrow.imethod_0().method_6().Keys)
                {
                    if (text.StartsWith("locale\\effects\\", StringComparison.OrdinalIgnoreCase))
                    {
                        string text2 = text.Substring("locale\\effects\\".Length);
                        list.Add(text2);
                        list.Add("!" + Path.GetFileNameWithoutExtension(text2));
                    }
                }
                foreach (string text3 in Directory.GetFiles(serviceOrThrow.imethod_0().method_3(), "*.upeb", SearchOption.AllDirectories))
                {
                    try
                    {
                        string text4 = text3.Substring(serviceOrThrow.imethod_0().method_3().Length, text3.Length - (serviceOrThrow.imethod_0().method_3().Length + 5)).ToLowerInvariant().TrimStart(new char[] { '\\' });
                        if (text4.StartsWith("locale\\effects\\", StringComparison.OrdinalIgnoreCase))
                        {
                            text4 = text4.Substring("locale\\effects\\".Length);
                            list.Add(text4);
                            list.Add("!" + Path.GetFileNameWithoutExtension(text4));
                        }
                    }
                    catch
                    {
                    }
                }
            }
            return list;
        }

        public string method_1(string string_0)
        {
            foreach (object obj in base.method_0())
            {
                string text = (string)obj;
                if (!text.StartsWith("!") && text.EndsWith("\\" + string_0, StringComparison.OrdinalIgnoreCase))
                {
                    return text;
                }
            }
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3288 - Status Effect argument type
    // ============================================================================
    public sealed class Foobar_GClass3288 : Foobar_GClass3283
    {
        public override string vmethod_0()
        {
            return "statusEffect";
        }

        public override object vmethod_3(string string_0)
        {
            Type type = Type.GetType("TimelapseVertigo.Rules.Effects.StatusEffects." + string_0);
            if (type != null)
            {
                ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
                if (constructor != null)
                {
                    return constructor.Invoke(null);
                }
                constructor = type.GetConstructor(new Type[] { typeof(int) });
                if (constructor != null)
                {
                    return constructor.Invoke(new object[] { 0 });
                }
            }
            return null;
        }

        protected override List<object> vmethod_2()
        {
            List<Type> list = GClass1181.GetServiceOrThrow<GInterface11>().imethod_0(t => !t.IsAbstract && typeof(GClass4262).IsAssignableFrom(t));
            List<object> list2 = new List<object>();
            foreach (Type type in list)
            {
                list2.Add(type.Name);
            }
            return list2;
        }
    }

    // ============================================================================
    // Foobar_GClass3290 - Global Property argument type
    // ============================================================================
    public sealed class Foobar_GClass3290 : Foobar_GClass3283
    {
        protected override bool vmethod_1()
        {
            return false;
        }

        public override string vmethod_0()
        {
            return "globalProperty(name|pattern)";
        }

        public override object vmethod_3(string string_0)
        {
            if (!string.IsNullOrWhiteSpace(string_0))
            {
                if (string_0.StartsWith("*"))
                {
                    List<string> list = new List<string>();
                    List<object> list2 = base.method_0();
                    if (string_0.EndsWith("*"))
                    {
                        string value = string_0.TrimStart(new char[] { '*' }).TrimEnd(new char[] { '*' });
                        using (List<object>.Enumerator enumerator = list2.GetEnumerator())
                        {
                            while (enumerator.MoveNext())
                            {
                                string text = (string)enumerator.Current;
                                if (text.Contains(value))
                                {
                                    list.Add(text);
                                }
                            }
                            return list;
                        }
                    }
                    string value2 = string_0.TrimStart(new char[] { '*' });
                    foreach (object obj2 in list2)
                    {
                        string text2 = (string)obj2;
                        if (text2.EndsWith(value2))
                        {
                            list.Add(text2);
                        }
                    }
                    return list;
                }
                if (string_0.EndsWith("*"))
                {
                    List<string> list3 = new List<string>();
                    List<object> list4 = base.method_0();
                    string value3 = string_0.TrimEnd(new char[] { '*' });
                    foreach (object obj3 in list4)
                    {
                        string text3 = (string)obj3;
                        if (text3.StartsWith(value3))
                        {
                            list3.Add(text3);
                        }
                    }
                    return list3;
                }
            }
            return string_0;
        }

        protected override List<object> vmethod_2()
        {
            List<object> list = new List<object>();
            GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
            if (serviceOrThrow.imethod_2() != null)
            {
                foreach (Property property in serviceOrThrow.imethod_2().method_8().Properties)
                {
                    list.Add(property.Name);
                }
            }
            return list;
        }
    }

    // ============================================================================
    // Foobar_GClass3292 - Item Definition Path argument type
    // ============================================================================
    public sealed class Foobar_GClass3292 : Foobar_GClass3283
    {
        public override string vmethod_0()
        {
            return "itemDefinitionPath";
        }

        public override object vmethod_3(string string_0)
        {
            if (string_0 != null && string_0.StartsWith("!"))
            {
                return this.method_1(string_0.Substring(1));
            }
            return string_0;
        }

        protected override List<object> vmethod_2()
        {
            List<object> list = new List<object>();
            string text = Path.Combine(GClass1181.GetServiceOrThrow<GInterface28>().imethod_17(), GClass2626.string_34);
            foreach (string text2 in Directory.GetFiles(text, "*.item", SearchOption.AllDirectories))
            {
                try
                {
                    string text3 = text2.Substring(text.Length, text2.Length - (text.Length + 5)).ToLowerInvariant().TrimStart(new char[] { '\\' });
                    list.Add(text3);
                    string text4 = "!" + Path.GetFileNameWithoutExtension(text3);
                    if (!list.Contains(text4))
                    {
                        list.Add(text4);
                    }
                    else
                    {
                        int num = 0;
                        string item;
                        do
                        {
                            string str = text4;
                            string str2 = "^";
                            int num2;
                            num = (num2 = num + 1);
                            item = str + str2 + num2.ToString();
                        }
                        while (list.Contains(item));
                        list.Add(item);
                    }
                }
                catch
                {
                }
            }
            return list;
        }

        public string method_1(string string_0)
        {
            if (string_0 != null)
            {
                string text = string_0;
                int num = 0;
                int num2 = string_0.IndexOf('^');
                if (num2 != -1)
                {
                    text = string_0.Substring(0, num2);
                    if (string.IsNullOrEmpty(text))
                    {
                        return null;
                    }
                    if (num2 < string_0.Length - 1)
                    {
                        int.TryParse(string_0.Substring(num2 + 1), out num);
                    }
                    else
                    {
                        num = 1;
                    }
                }
                List<object> list = base.method_0();
                int num3 = 0;
                foreach (object obj in list)
                {
                    string text2 = (string)obj;
                    if (!text2.StartsWith("!") && text2.EndsWith("\\" + text, StringComparison.OrdinalIgnoreCase))
                    {
                        if (num3 == num)
                        {
                            return text2;
                        }
                        num3++;
                    }
                }
            }
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3296 - Entity Definition Path argument type
    // ============================================================================
    public sealed class Foobar_GClass3296 : Foobar_GClass3283
    {
        public override string vmethod_0()
        {
            return "entityDefinitionPath";
        }

        public override object vmethod_3(string string_0)
        {
            return string_0;
        }

        protected override List<object> vmethod_2()
        {
            List<object> list = new List<object>();
            GInterface72 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface72>();
            if (serviceOrThrow.imethod_0().method_6() != null)
            {
                foreach (string text in serviceOrThrow.imethod_0().method_6().Keys)
                {
                    string text2;
                    if (text.StartsWith("locale\\", StringComparison.OrdinalIgnoreCase))
                    {
                        text2 = text.Substring("locale\\".Length);
                    }
                    else
                    {
                        text2 = text;
                    }
                    list.Add(text2);
                    list.Add("!" + Path.GetFileNameWithoutExtension(text2));
                }
                foreach (string text3 in Directory.GetFiles(serviceOrThrow.imethod_0().method_3(), "*.upeb", SearchOption.AllDirectories))
                {
                    try
                    {
                        string text4 = text3.Substring(serviceOrThrow.imethod_0().method_3().Length, text3.Length - (serviceOrThrow.imethod_0().method_3().Length + 5)).ToLowerInvariant().TrimStart(new char[] { '\\' });
                        if (text4.StartsWith("locale\\", StringComparison.OrdinalIgnoreCase))
                        {
                            text4 = text4.Substring("locale\\".Length);
                        }
                        list.Add(text4);
                        list.Add("!" + Path.GetFileNameWithoutExtension(text4));
                    }
                    catch
                    {
                    }
                }
            }
            return list;
        }

        public string method_1(string string_0)
        {
            foreach (object obj in base.method_0())
            {
                string text = (string)obj;
                if (!text.StartsWith("!") && text.EndsWith("\\" + string_0, StringComparison.OrdinalIgnoreCase))
                {
                    return text;
                }
            }
            return null;
        }
    }
}