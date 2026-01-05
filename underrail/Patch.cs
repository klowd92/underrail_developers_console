using HarmonyLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ouroboros.Core.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TimelapseVertigo.Common.Settings;


namespace underrail
{
    // ============================================================================
    // HARMONY PATCH - Intercepts GClass3289.method_50 to handle tilde key
    // ============================================================================
    [HarmonyPatch]
    public class GClass3289_Patches
    {
        static MethodBase TargetMethod()
        {
            return AccessTools.Method(typeof(GClass3289), "method_50");
        }

        static bool Prefix(GClass3289 __instance, object sender, GEventArgs9 e)
        {
            if (e.keys_0 == Keys.OemTilde)
            {
                var gclass1472Field = AccessTools.Field(typeof(GClass3289), "gclass1472_0");
                GClass1472 gclass1472 = (GClass1472)gclass1472Field.GetValue(__instance);

                if (gclass1472 != null)
                {
                    gclass1472.foobar();
                }

                return false;
            }
            return true;
        }
    }

    // ============================================================================
    // Foobar_GClass1578 - Console UI component
    // ============================================================================
    public sealed class Foobar_GClass1578 : GClass1433
    {
        private static readonly GStruct4 gstruct4_1 = new GStruct4(40, 40);
        private static readonly GStruct4 gstruct4_2 = new GStruct4(120, 14);
        private int int_2 = 28;
        private int int_3 = 7;
        private static string string_2;
        private int int_4 = -1;
        private GClass1550 gclass1550_0;
        private List<string> list_1;
        private string string_3 = GClass2641.string_28;

        public Foobar_GClass1578(GStruct4 gstruct4_3)
        {
            Plugin.Log.LogWarning("Foobar_GClass1578() Called!!");
            base.Size = gstruct4_3;
            GClass3455 gclass = GClass3455.smethod_1();

            if (gclass.uiSize_0 != UiSize.Classic)
            {
                this.int_2 = gclass.int_30;
                this.int_3 = gclass.int_31;
            }

            this.gclass1550_0 = new GClass1550();
            this.gclass1550_0.Location = new Point(this.int_3, base.Size.int_1 - this.int_2 + 4);
            this.gclass1550_0.Size = new GStruct4(base.Size.int_0, 20);
            this.gclass1550_0.method_134(GClass2640.string_1);
            this.gclass1550_0.method_136(GClass2641.string_37);

            if (gclass.uiSize_0 != UiSize.Classic)
            {
                this.gclass1550_0.method_136(gclass.string_12);
                this.string_3 = gclass.string_11;
                this.gclass1550_0.Size = new GStruct4(base.Size.int_0, this.int_2 - 8);

                if (!string.IsNullOrEmpty(this.string_3))
                {
                    SpriteFont resource = GClass1181.GetServiceOrThrow<GInterface30>().GetResource<SpriteFont>(this.string_3, null);
                    if (resource != null)
                    {
                        this.gclass1550_0.method_148(new Point(this.gclass1550_0.method_147().X, (this.gclass1550_0.Size.int_1 - resource.LineSpacing) / 2));
                    }
                }
            }

            this.gclass1550_0.method_130(true);
            this.gclass1550_0.method_140(GClass5395.color_2);
            this.gclass1550_0.method_138(GClass5395.color_0);
            this.gclass1550_0.method_142(GClass5395.color_1);
            this.gclass1550_0.func_1 = new Func<object, Keys, List<Keys>, bool, bool>(this.method_106);
            this.gclass1550_0.func_2 = new Func<string, string>(Foobar_GClass3538.smethod_8);
            this.gclass1550_0.Text = Foobar_GClass1578.string_2;
            this.gclass1550_0.method_58(new EventHandler(this.method_107));
            this.gclass1550_0.method_52(new EventHandler<GEventArgs1>(this.method_103));
            this.vmethod_0(this.gclass1550_0);
        }

        private void method_103(object sender, GEventArgs1 e)
        {
            this.list_1 = Foobar_GClass3538.smethod_9(this.gclass1550_0.Text, 20, false);
        }

        public void method_104()
        {
            this.gclass1550_0.Enabled = true;
            if (!this.gclass1550_0.IsFocus)
            {
                this.gclass1550_0.method_8();
            }
        }

        public void method_105()
        {
            this.gclass1550_0.Enabled = false;
            Foobar_GClass1578.string_2 = this.gclass1550_0.Text;
            if (this.gclass1550_0.IsFocus)
            {
                this.gclass1550_0.method_9();
            }
        }

        public override void vmethod_47(GClass1236 gclass1236_0, GClass1237 gclass1237_0)
        {
            Texture2D texture2D = gclass1237_0.ginterface30_0.imethod_0(GClass2640.string_20, null);
            Point point = base.method_0();

            if (texture2D != null)
            {
                Rectangle rectangle_ = new Rectangle(point.X, point.Y, base.Size.int_0, base.Size.int_1 - this.int_2);
                GClass1614.smethod_0(gclass1237_0, texture2D, Foobar_GClass1578.gstruct4_1, Point.Zero, rectangle_, Color.White * 0.7f, true, null);
            }

            Texture2D texture2D2 = gclass1237_0.ginterface30_0.imethod_0(GClass2640.string_53, null);
            if (texture2D2 != null)
            {
                Rectangle rectangle_2 = new Rectangle(point.X, point.Y + base.Size.int_1 - this.int_2, base.Size.int_0, this.int_2);
                GClass1614.smethod_0(gclass1237_0, texture2D2, Foobar_GClass1578.gstruct4_2, Point.Zero, rectangle_2, Color.White * 0.7f, true, null);
            }

            GClass2647 gclass = Foobar_GClass3538.smethod_3().method_1();
            Point point_ = new Point(point.X + Foobar_GClass3538.int_2, point.Y + base.Size.int_1 - this.int_2 - gclass.gstruct4_0.int_1);
            gclass.method_0(point_, gclass1237_0, null, 0.85f);
            base.vmethod_47(gclass1236_0, gclass1237_0);

            if (this.list_1 != null && this.list_1.Count > 0)
            {
                SpriteFont resource = gclass1237_0.ginterface30_0.GetResource<SpriteFont>(this.string_3, null);
                if (resource != null)
                {
                    Texture2D texture2D3 = gclass1237_0.ginterface30_0.imethod_0(GClass2640.string_55, null);
                    if (texture2D3 != null)
                    {
                        int num = 0;
                        foreach (string text in this.list_1)
                        {
                            num = Convert.ToInt32(Math.Max((float)num, resource.MeasureString(text).X));
                        }
                        Rectangle rectangle_3 = new Rectangle(point.X + base.Size.int_0 - num - 20, point.Y + base.Size.int_1 - this.int_2 - resource.LineSpacing * (this.list_1.Count + 1) - 8, num + 20, resource.LineSpacing * this.list_1.Count + 16);
                        GClass1614.smethod_0(gclass1237_0, texture2D3, new GStruct4(20, 20), Point.Zero, rectangle_3, Color.White * 0.75f, true, null);
                    }
                    for (int i = 0; i < this.list_1.Count; i++)
                    {
                        string text2 = this.list_1[i];
                        if (text2 != null && text2.Length > 30)
                        {
                            text2.Substring(0, 30);
                        }
                        Vector2 position = new Vector2((float)(point.X + base.Size.int_0) - resource.MeasureString(text2).X - 10f, (float)(point.Y + base.Size.int_1 - this.int_2 - resource.LineSpacing * (1 + this.list_1.Count - i)));
                        gclass1237_0.spriteBatch_0.DrawString(resource, text2, position, Color.Gray * 0.75f);
                    }
                }
            }
        }

        protected override void vmethod_31(object sender, GEventArgs9 e)
        {
            base.vmethod_31(sender, e);
            if (e.keys_0 == Keys.OemTilde)
            {
                GInterface122 service = GClass1181.GetService<GInterface122>();
                if (service != null)
                {
                    // The service IS GClass3289, so get gclass1472_0 directly from it
                    var gclass1472Field = AccessTools.Field(service.GetType(), "gclass1472_0");
                    if (gclass1472Field != null)
                    {
                        GClass1472 gclass1472 = (GClass1472)gclass1472Field.GetValue(service);

                        if (gclass1472 != null)
                        {
                            // Call method_141() directly (equivalent to imethod_96(false))
                            gclass1472.method_141();
                        }
                    }
                }
            }
        }

        private bool method_106(object object_1, Keys keys_0, List<Keys> list_2, bool bool_20)
        {
            if (keys_0 == Keys.OemTilde)
            {
                GInterface122 service = GClass1181.GetService<GInterface122>();
                if (service != null)
                {
                    // The service IS GClass3289, so get gclass1472_0 directly from it
                    var gclass1472Field = AccessTools.Field(service.GetType(), "gclass1472_0");
                    if (gclass1472Field != null)
                    {
                        GClass1472 gclass1472 = (GClass1472)gclass1472Field.GetValue(service);

                        if (gclass1472 != null)
                        {
                            // Call method_141() directly (equivalent to imethod_96(false))
                            gclass1472.method_141();
                        }
                    }
                }
                return true;
            }
            if (keys_0 == Keys.Escape)
            {
                this.gclass1550_0.Text = "";
                return true;
            }
            if (keys_0 == Keys.Enter)
            {
                this.int_4 = -1;
                Foobar_GClass3538.smethod_6(this.gclass1550_0.Text);
                this.gclass1550_0.Text = "";
                return true;
            }
            if (keys_0 == Keys.Tab)
            {
                string str = Foobar_GClass3538.smethod_8(this.gclass1550_0.Text);
                GClass1550 gclass = this.gclass1550_0;
                gclass.Text += str;
                this.gclass1550_0.method_111();
            }
            else if (keys_0 == Keys.Up)
            {
                this.int_4 = Math.Min(Foobar_GClass3538.list_0.Count - 1, this.int_4 + 1);
                if (this.int_4 != -1)
                {
                    string text = Foobar_GClass3538.list_0[this.int_4];
                    if (text != null)
                    {
                        this.gclass1550_0.Text = text;
                        this.gclass1550_0.method_111();
                    }
                }
            }
            else if (keys_0 == Keys.Down)
            {
                this.int_4 = Math.Max(-1, this.int_4 - 1);
                if (this.int_4 == -1)
                {
                    this.gclass1550_0.Text = "";
                }
                else
                {
                    string text2 = Foobar_GClass3538.list_0[this.int_4];
                    if (text2 != null)
                    {
                        this.gclass1550_0.Text = text2;
                        this.gclass1550_0.method_111();
                    }
                }
            }
            return false;
        }

        private void method_107(object sender, EventArgs e)
        {
            GInterface122 service = GClass1181.GetService<GInterface122>();
            if (service != null)
            {
                // The service IS GClass3289, so get gclass1472_0 directly from it
                var gclass1472Field = AccessTools.Field(service.GetType(), "gclass1472_0");
                if (gclass1472Field != null)
                {
                    GClass1472 gclass1472 = (GClass1472)gclass1472Field.GetValue(service);

                    if (gclass1472 != null)
                    {
                        // Call method_141() directly (equivalent to imethod_96(false))
                        gclass1472.method_141();
                    }
                }
            }
        }
    }

    // Foobar_GClass3283 - Abstract base for console arguments
    public abstract class Foobar_GClass3283
    {
        private List<object> list_0;

        public abstract string vmethod_0();

        protected virtual bool vmethod_1()
        {
            return true;
        }

        public List<object> method_0()
        {
            if (this.vmethod_1())
            {
                if (this.list_0 == null)
                {
                    this.list_0 = this.vmethod_2();
                }
                return this.list_0;
            }
            return this.vmethod_2();
        }

        protected virtual List<object> vmethod_2()
        {
            return null;
        }

        public abstract object vmethod_3(string string_0);
    }

    // Foobar_GClass3537 - Console command argument definition
    public sealed class Foobar_GClass3537
    {
        public Type type_0;
        public bool bool_0;
        public string string_0;

        public Foobar_GClass3537(Type type_1, string string_1 = null, bool bool_1 = false)
        {
            this.type_0 = type_1;
            this.string_0 = string_1;
            this.bool_0 = bool_1;
        }
    }

    // Foobar_GClass3298 - Abstract base for console commands
    public abstract class Foobar_GClass3298
    {
        private List<Foobar_GClass3537> list_0 = new List<Foobar_GClass3537>();

        public abstract string[] Commands { get; }

        public List<Foobar_GClass3537> Args
        {
            get { return this.list_0; }
        }

        public abstract GClass3312 vmethod_0(List<object> list_1);

        public virtual void vmethod_1(List<object> list_1, object object_0)
        {
        }

        protected void method_0(string string_0, params object[] object_0)
        {
            Foobar_GClass3538.smethod_4(string_0, object_0);
        }

        protected virtual string vmethod_2()
        {
            string text = string.Format("Usage: [cmd]{0}[/cmd]", this.method_2());
            if (this.list_0 != null && this.list_0.Count > 0)
            {
                text += "[param]";
                foreach (Foobar_GClass3537 gclass in this.list_0)
                {
                    string str;
                    if (gclass.string_0 != null)
                    {
                        str = gclass.string_0;
                    }
                    else
                    {
                        Foobar_GClass3283 gclass2 = Foobar_GClass3538.smethod_7(gclass.type_0);
                        if (gclass2 != null)
                        {
                            str = gclass2.vmethod_0();
                        }
                        else
                        {
                            str = "arg";
                        }
                    }
                    if (gclass.bool_0)
                    {
                        text = text + " <" + str + ">";
                    }
                    else
                    {
                        text = text + " (" + str + ")";
                    }
                }
                text += "[/param]";
            }
            return text;
        }

        public void method_1()
        {
            Foobar_GClass3538.smethod_4(this.vmethod_2(), new object[0]);
        }

        public string method_2()
        {
            bool flag = true;
            string text = "";
            foreach (string str in this.Commands)
            {
                if (!flag)
                {
                    text += " | ";
                }
                flag = false;
                text += str;
            }
            return text;
        }
    }

    // Foobar_GClass3351 - Console command execution wrapper
    public sealed class Foobar_GClass3351 : GClass3303
    {
        public Foobar_GClass3298 foobar_gclass3298_0;
        public List<object> list_0;
        private GClass3312 gclass3312_0;

        public override GClass3312 vmethod_1()
        {
            return this.gclass3312_0;
        }

        public Foobar_GClass3351(GClass3312 gclass3312_1, Foobar_GClass3298 foobar_gclass3298_1, List<object> list_1)
        {
            this.gclass3312_0 = gclass3312_1;
            this.foobar_gclass3298_0 = foobar_gclass3298_1;
            if (list_1 != null)
            {
                this.list_0 = new List<object>(list_1);
                return;
            }
            this.list_0 = new List<object>();
        }

        public override void vmethod_3(GClass1680 gclass1680_0)
        {
            if (this.foobar_gclass3298_0 != null)
            {
                try
                {
                    this.foobar_gclass3298_0.vmethod_1(this.list_0, base.method_0());
                }
                catch (Exception ex)
                {
                    Foobar_GClass3538.smethod_4("[error]Error occurred while executing command: {0}", new object[]
                    {
                        ex.Message
                    });
                    this.foobar_gclass3298_0.method_1();
                }
            }
        }
    }

    // Foobar_GClass3538 - Console manager (static utility class) - PART 1
    public static class Foobar_GClass3538
    {
        private static bool bool_0;
        private static Dictionary<string, Foobar_GClass3298> dictionary_0;
        private static Dictionary<Type, Foobar_GClass3283> dictionary_1;
        public static List<string> list_0 = new List<string>();
        public static readonly int int_0 = 20;
        private static readonly int int_1 = 50;
        private static GClass2643 gclass2643_0 = new GClass2643();
        private static GClass2643 gclass2643_1 = new GClass2643();
        private static int? nullable_0;
        public static readonly int int_2 = 10;
        private static Dictionary<string, GClass2642> dictionary_2;

        public static GClass2642 smethod_0()
        {
            return new GClass2642(Foobar_GClass3538.smethod_1(), Color.LightGray);
        }

        public static string smethod_1()
        {
            GClass3455 gclass = GClass3455.smethod_1();
            if (gclass.uiSize_0 != UiSize.Classic)
            {
                return gclass.string_11;
            }
            return GClass2641.string_28;
        }

        public static List<Foobar_GClass3298> smethod_2()
        {
            return Foobar_GClass3538.dictionary_0.Values.OrderBy(x => x.Commands.FirstOrDefault()).ToList();
        }

        public static GClass2643 smethod_3()
        {
            return Foobar_GClass3538.gclass2643_1;
        }

        public static void smethod_4(string string_0, params object[] object_0)
        {
            List<KeyValuePair<string[], string>> list = GClass1169.smethod_5(string.Format(string_0, object_0));
            GClass2644 gclass = new GClass2644();
            foreach (KeyValuePair<string[], string> keyValuePair in list)
            {
                if (!string.IsNullOrEmpty(keyValuePair.Value))
                {
                    GClass2642 gclass2 = null;
                    if (keyValuePair.Key != null && keyValuePair.Key.Length != 0)
                    {
                        for (int i = keyValuePair.Key.Length - 1; i >= 0; i--)
                        {
                            string key = keyValuePair.Key[i];
                            if (Foobar_GClass3538.dictionary_2.TryGetValue(key, out gclass2))
                            {
                                break;
                            }
                        }
                    }
                    if (gclass2 == null)
                    {
                        gclass2 = Foobar_GClass3538.smethod_0();
                    }
                    gclass2.string_0 = Foobar_GClass3538.smethod_1();
                    gclass.list_0.Add(new GClass2645(gclass2, keyValuePair.Value, null));
                }
            }
            Foobar_GClass3538.gclass2643_0.list_0.Add(gclass);
            if (Foobar_GClass3538.gclass2643_0.list_0.Count > Foobar_GClass3538.int_1)
            {
                Foobar_GClass3538.gclass2643_0.list_0.RemoveRange(0, Foobar_GClass3538.gclass2643_0.list_0.Count - Foobar_GClass3538.int_1);
            }
            GStruct4 gstruct = GClass1181.GetServiceOrThrow<GInterface26>().imethod_5();
            if (Foobar_GClass3538.nullable_0 != null)
            {
                int? num = Foobar_GClass3538.nullable_0;
                int num2 = gstruct.int_0 - 2 * Foobar_GClass3538.int_2;
                if (num.GetValueOrDefault() == num2 & num != null)
                {
                    GClass2643 gclass3 = new GClass2643
                    {
                        list_0 =
                        {
                            GClass1207.Clone<GClass2644>(gclass)
                        }
                    }.method_0(Foobar_GClass3538.nullable_0.Value, int.MaxValue).First<GClass2643>();
                    Foobar_GClass3538.gclass2643_1.list_0.AddRange(gclass3.list_0);
                    if (Foobar_GClass3538.gclass2643_1.list_0.Count > Foobar_GClass3538.int_1)
                    {
                        Foobar_GClass3538.gclass2643_1.list_0.RemoveRange(0, Foobar_GClass3538.gclass2643_1.list_0.Count - Foobar_GClass3538.int_1);
                    }
                    return;
                }
            }
            Foobar_GClass3538.nullable_0 = new int?(gstruct.int_0 - 2 * Foobar_GClass3538.int_2);
            Foobar_GClass3538.gclass2643_1 = GClass1207.Clone<GClass2643>(Foobar_GClass3538.gclass2643_0).method_0(Foobar_GClass3538.nullable_0.Value, int.MaxValue).First<GClass2643>();
        }

        public static void smethod_5()
        {
            if (!Foobar_GClass3538.bool_0)
            {
                Plugin.Log.LogWarning("smethod_5() - Starting console manager initialization");

                Foobar_GClass3538.bool_0 = true;
                Foobar_GClass3538.dictionary_2 = new Dictionary<string, GClass2642>();
                Foobar_GClass3538.dictionary_2["val"] = new GClass2642("f", Color.Cyan);
                Foobar_GClass3538.dictionary_2["value"] = Foobar_GClass3538.dictionary_2["val"];
                Foobar_GClass3538.dictionary_2["prop"] = new GClass2642("f", Color.Green);
                Foobar_GClass3538.dictionary_2["error"] = new GClass2642("f", Color.Red);
                Foobar_GClass3538.dictionary_2["param"] = new GClass2642("f", Color.Pink);
                Foobar_GClass3538.dictionary_2["cmd"] = new GClass2642("f", Color.Yellow);
                Foobar_GClass3538.dictionary_2["war"] = new GClass2642("f", Color.Orange);
                Foobar_GClass3538.dictionary_2["warning"] = Foobar_GClass3538.dictionary_2["war"];

                Foobar_GClass3538.dictionary_0 = new Dictionary<string, Foobar_GClass3298>();
                Foobar_GClass3538.dictionary_1 = new Dictionary<Type, Foobar_GClass3283>();

                Plugin.Log.LogWarning("smethod_5() - Calling smethod_13() to register game commands");
                Foobar_GClass3538.smethod_13();

                Plugin.Log.LogWarning("smethod_5() - Calling smethod_14() to register game arguments");
                Foobar_GClass3538.smethod_14();

                Plugin.Log.LogWarning($"smethod_5() - After game registration: {dictionary_0.Count} commands, {dictionary_1.Count} argument types");

                Plugin.Log.LogWarning("smethod_5() - Starting manual registration of plugin argument types");
                try
                {
                    // === ArgumentTypes.cs ===

                    // Int32 argument type (already exists, keeping for completeness)
                    dictionary_1[typeof(Foobar_GClass3295)] = new Foobar_GClass3295();
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3295 (int32)");

                    // Base Ability argument type
                    dictionary_1[typeof(Foobar_GClass3284)] = new Foobar_GClass3284();
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3284 (base ability)");

                    // Joblet argument type
                    dictionary_1[typeof(Foobar_GClass3286)] = new Foobar_GClass3286();
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3286 (joblet)");

                    // String argument type
                    dictionary_1[typeof(Foobar_GClass3287)] = new Foobar_GClass3287();
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3287 (string)");

                    // Capability argument type
                    dictionary_1[typeof(Foobar_GClass3289)] = new Foobar_GClass3289();
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3289 (capability)");

                    // Bool argument type
                    dictionary_1[typeof(Foobar_GClass3291)] = new Foobar_GClass3291();
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3291 (bool)");

                    // Cooldown argument type
                    dictionary_1[typeof(Foobar_GClass3293)] = new Foobar_GClass3293();
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3293 (cooldown)");

                    // Skill argument type
                    dictionary_1[typeof(Foobar_GClass3294)] = new Foobar_GClass3294();
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3294 (skill)");

                    // LocaleId argument type
                    dictionary_1[typeof(Foobar_GClass3297)] = new Foobar_GClass3297();
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3297 (localeId)");

                    // === ArgumentTypesComplex.cs ===

                    // Effect Name argument type
                    dictionary_1[typeof(Foobar_GClass3285)] = new Foobar_GClass3285();
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3285 (effectName)");

                    // Status Effect argument type
                    dictionary_1[typeof(Foobar_GClass3288)] = new Foobar_GClass3288();
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3288 (statusEffect)");

                    // Global Property argument type
                    dictionary_1[typeof(Foobar_GClass3290)] = new Foobar_GClass3290();
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3290 (globalProperty)");

                    // Item Definition Path argument type
                    dictionary_1[typeof(Foobar_GClass3292)] = new Foobar_GClass3292();
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3292 (itemDefinitionPath)");

                    // Entity Definition Path argument type
                    dictionary_1[typeof(Foobar_GClass3296)] = new Foobar_GClass3296();
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3296 (entityDefinitionPath)");
                }
                catch (Exception ex)
                {
                    Plugin.Log.LogError($"smethod_5() - Argument type registration failed: {ex.Message}");
                    Plugin.Log.LogError($"smethod_5() - Stack trace: {ex.StackTrace}");
                }
                // MANUAL REGISTRATION - Register plugin commands that the type scanner missed
                Plugin.Log.LogWarning("smethod_5() - Starting manual registration of plugin commands");
                try
                {
                    // Manually register runtime commands
                    var helpCommand = new Foobar_GClass3300();
                    foreach (string cmd in helpCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = helpCommand;
                        }
                    }

                    // Register playerGiveAllPsiAbilities command
                    var giveAllPsiCommand = new Foobar_GClass3301();
                    foreach (string cmd in giveAllPsiCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = giveAllPsiCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3301 (playerGiveAllPsiAbilities)");

                    // Register playerSetModel command
                    var setModelCommand = new Foobar_GClass3302();
                    foreach (string cmd in setModelCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = setModelCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3302 (playerSetModel)");

                    // Register playerExecuteJoblet command
                    var execJobletCommand = new Foobar_GClass3303();
                    foreach (string cmd in execJobletCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = execJobletCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3303 (playerExecuteJoblet)");

                    // Register playerKill command
                    var killCommand = new Foobar_GClass3304();
                    foreach (string cmd in killCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = killCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3304 (playerKill)");

                    // Register playerSetStatusEffect command
                    var setStatusEffectCommand = new Foobar_GClass3305();
                    foreach (string cmd in setStatusEffectCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = setStatusEffectCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3305 (playerSetStatusEffect)");

                    // Register playerRemoveCooldown command
                    var removeCooldownCommand = new Foobar_GClass3306();
                    foreach (string cmd in removeCooldownCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = removeCooldownCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3306 (playerRemoveCooldown)");

                    // Register writeGlobalProperty command
                    var writeGpCommand = new Foobar_GClass3307();
                    foreach (string cmd in writeGpCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = writeGpCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3307 (writeGlobalProperty)");

                    // Register recordTimes command
                    var recordTimesCommand = new Foobar_GClass3308();
                    foreach (string cmd in recordTimesCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = recordTimesCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3308 (recordTimes)");

                    // Register loadTestModel command
                    var loadTestModelCommand = new Foobar_GClass3309();
                    foreach (string cmd in loadTestModelCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = loadTestModelCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3309 (loadTestModel)");

                    // Register playerListCooldowns command
                    var listCooldownsCommand = new Foobar_GClass3310();
                    foreach (string cmd in listCooldownsCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = listCooldownsCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3310 (playerListCooldowns)");

                    // Register playerRemoveSpecialAttack command
                    var removeSpecialAttackCommand = new Foobar_GClass3311();
                    foreach (string cmd in removeSpecialAttackCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = removeSpecialAttackCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3311 (playerRemoveSpecialAttack)");

                    // Register playerRemoveSpecialAbility command
                    var removeSpecialAbilityCommand = new Foobar_GClass3312_Cmd();
                    foreach (string cmd in removeSpecialAbilityCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = removeSpecialAbilityCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3312_Cmd (playerRemoveSpecialAbility)");

                    // Register playerRemovePsiAbility command
                    var removePsiAbilityCommand = new Foobar_GClass3313();
                    foreach (string cmd in removePsiAbilityCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = removePsiAbilityCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3313 (playerRemovePsiAbility)");

                    // Register playerGivePsiAbility command
                    var givePsiAbilityCommand = new Foobar_GClass3314();
                    foreach (string cmd in givePsiAbilityCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = givePsiAbilityCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3314 (playerGivePsiAbility)");

                    // Register playerGiveSpecialAbility command
                    var giveSpecialAbilityCommand = new Foobar_GClass3315();
                    foreach (string cmd in giveSpecialAbilityCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = giveSpecialAbilityCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3315 (playerGiveSpecialAbility)");

                    // Register playerGiveSpecialAttack command
                    var giveSpecialAttackCommand = new Foobar_GClass3316();
                    foreach (string cmd in giveSpecialAttackCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = giveSpecialAttackCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3316 (playerGiveSpecialAttack)");

                    // Register listCommands command
                    var listCommandsCommand = new Foobar_GClass3317();
                    foreach (string cmd in listCommandsCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = listCommandsCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3317 (listCommands)");

                    // Register readGlobalProperty command
                    var readGpCommand = new Foobar_GClass3318();
                    foreach (string cmd in readGpCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = readGpCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3318 (readGlobalProperty)");

                    // Register playerGiveItem command
                    var giveItemCommand = new Foobar_GClass3319();
                    foreach (string cmd in giveItemCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = giveItemCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3319 (playerGiveItem)");

                    // Register playerGiveXp command
                    var giveXpCommand = new Foobar_GClass3320();
                    foreach (string cmd in giveXpCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = giveXpCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3320 (playerGiveXp)");

                    // Register resetBlueprintsLibrary command
                    var resetBlueprintsCommand = new Foobar_GClass3321();
                    foreach (string cmd in resetBlueprintsCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = resetBlueprintsCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3321 (resetBlueprintsLibrary)");

                    // Register resetAll command
                    var resetAllCommand = new Foobar_GClass3322();
                    foreach (string cmd in resetAllCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = resetAllCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3322 (resetAll)");

                    // Register resetKnowledgeManager command
                    var resetKnowledgeCommand = new Foobar_GClass3323();
                    foreach (string cmd in resetKnowledgeCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = resetKnowledgeCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3323 (resetKnowledgeManager)");

                    // Register reloadAudioBank command
                    var reloadAudioCommand = new Foobar_GClass3324();
                    foreach (string cmd in reloadAudioCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = reloadAudioCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3324 (reloadAudioBank)");

                    // Register resetIconManager command
                    var resetIconsCommand = new Foobar_GClass3325();
                    foreach (string cmd in resetIconsCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = resetIconsCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3325 (resetIconManager)");

                    // Register reloadAllResources command
                    var reloadResourcesCommand = new Foobar_GClass3326();
                    foreach (string cmd in reloadResourcesCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = reloadResourcesCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3326 (reloadAllResources)");

                    // Register revealGlobalMap command
                    var revealMapCommand = new Foobar_GClass3327();
                    foreach (string cmd in revealMapCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = revealMapCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3327 (revealGlobalMap)");

                    // Register playerSetBaseAbility command
                    var setBaseAbilityCommand = new Foobar_GClass3328();
                    foreach (string cmd in setBaseAbilityCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = setBaseAbilityCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3328 (playerSetBaseAbility)");

                    // Register playerSetSkill command
                    var setSkillCommand = new Foobar_GClass3329();
                    foreach (string cmd in setSkillCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = setSkillCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3329 (playerSetSkill)");

                    // Register spawnEffect command
                    var spawnEffectCommand = new Foobar_GClass3330();
                    foreach (string cmd in spawnEffectCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = spawnEffectCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3330 (spawnEffect)");

                    // Register exportItem command
                    var exportItemCommand = new Foobar_GClass3331();
                    foreach (string cmd in exportItemCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = exportItemCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3331 (exportItem)");

                    // Register the new spawn entity command
                    var spawnEntityCommand = new Foobar_GClass3332();
                    foreach (string cmd in spawnEntityCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = spawnEntityCommand;
                        }
                    }

                    // Register goto command
                    var gotoCommand = new Foobar_GClass3333();
                    foreach (string cmd in gotoCommand.Commands)
                    {
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            Foobar_GClass3538.dictionary_0[cmd.ToLowerInvariant()] = gotoCommand;
                        }
                    }
                    Plugin.Log.LogWarning("smethod_5() - Registered Foobar_GClass3333 (goto)");
                }
                catch (Exception ex)
                {
                    Plugin.Log.LogError($"smethod_5() - Manual registration failed: {ex.Message}");
                    Plugin.Log.LogError($"smethod_5() - Stack trace: {ex.StackTrace}");
                }

                Plugin.Log.LogWarning($"smethod_5() - Final registration: {dictionary_0.Count} commands, {dictionary_1.Count} argument types");

                if (dictionary_0.Count > 0)
                {
                    Plugin.Log.LogWarning($"smethod_5() - Available commands: {string.Join(", ", dictionary_0.Keys)}");
                }
            }
        }

        public static T GetArgument<T>() where T : Foobar_GClass3283
        {
            return Foobar_GClass3538.smethod_7(typeof(T)) as T;
        }

        public static Foobar_GClass3283 smethod_7(Type type_0)
        {
            Foobar_GClass3283 result;
            Foobar_GClass3538.dictionary_1.TryGetValue(type_0, out result);
            return result;
        }

        public static string smethod_8(string string_0)
        {
            List<string> list = Foobar_GClass3538.smethod_9(string_0, 1, true);
            if (list != null)
            {
                return list.FirstOrDefault<string>();
            }
            return null;
        }

        public static List<string> smethod_9(string string_0, int int_3 = 1, bool bool_1 = true)
        {
            if (string.IsNullOrWhiteSpace(string_0))
            {
                return null;
            }
            bool flag;
            List<string> list = Foobar_GClass3538.smethod_12(string_0, out flag);
            int num = Math.Max(0, list.Count - 1);
            if (list.Count > 0 && string_0.EndsWith(" ") && !flag)
            {
                num++;
            }
            if (num == 0)
            {
                string string_ = (list.Count > 0) ? list[0] : "";
                return Foobar_GClass3538.smethod_10(Foobar_GClass3538.dictionary_0.Keys, string_, int_3, bool_1);
            }
            Foobar_GClass3298 gclass;
            if (list.Count > 0 && Foobar_GClass3538.dictionary_0.TryGetValue(list[0].ToLowerInvariant(), out gclass) && gclass.Args.Count > num - 1)
            {
                Foobar_GClass3537 gclass2 = gclass.Args[num - 1];
                Foobar_GClass3283 gclass3;
                if (gclass2.type_0 != null && Foobar_GClass3538.dictionary_1.TryGetValue(gclass2.type_0, out gclass3))
                {
                    return Foobar_GClass3538.smethod_10(gclass3.method_0(), (list.Count > num) ? list[num] : "", int_3, bool_1);
                }
            }
            return null;
        }

        private static List<string> smethod_10(System.Collections.IEnumerable ienumerable_0, string string_0, int int_3 = 1, bool bool_1 = true)
        {
            SortedList<string, string> sortedList = new SortedList<string, string>();
            if (ienumerable_0 != null)
            {
                foreach (object obj in ienumerable_0)
                {
                    if (obj != null)
                    {
                        string text = obj.ToString();
                        if ((string_0 == "" || text.ToLowerInvariant().StartsWith(string_0.ToLowerInvariant())) && !sortedList.ContainsKey(text))
                        {
                            sortedList.Add(text, text);
                        }
                    }
                }
            }
            int num = 0;
            List<string> list = new List<string>();
            foreach (string text2 in sortedList.Keys)
            {
                if (bool_1)
                {
                    list.Add(text2.Substring(string_0.Length));
                }
                else
                {
                    list.Add(text2);
                }
                if (++num >= int_3)
                {
                    break;
                }
            }
            return list;
        }

        private static List<string> smethod_11(string string_0)
        {
            bool flag;
            return Foobar_GClass3538.smethod_12(string_0, out flag);
        }
    
        private static List<string> smethod_12(string string_0, out bool bool_1)
        {
            bool_1 = false;
            if (!string.IsNullOrWhiteSpace(string_0))
            {
                List<string> list = new List<string>();
                string text = string_0.TrimStart(new char[] { ' ' });
                while (!string.IsNullOrWhiteSpace(text))
                {
                    int num = text.IndexOf(' ');
                    int num2 = text.IndexOf('"');
                    if (num2 != -1 && (num == -1 || num2 < num))
                    {
                        int num3 = text.IndexOf('"', num2 + 1);
                        if (num3 == -1)
                        {
                            if (num2 < text.Length - 1)
                            {
                                string item = text.Substring(num2 + 1);
                                list.Add(item);
                            }
                            else
                            {
                                list.Add("");
                            }
                            bool_1 = true;
                            text = null;
                        }
                        else
                        {
                            if (num3 - num2 > 1)
                            {
                                string item2 = text.Substring(num2 + 1, num3 - num2 - 1);
                                list.Add(item2);
                            }
                            else
                            {
                                list.Add("");
                            }
                            if (num3 == text.Length - 1)
                            {
                                text = null;
                            }
                            else
                            {
                                text = text.Substring(num3 + 1);
                            }
                        }
                    }
                    else
                    {
                        if (num == -1)
                        {
                            list.Add(text);
                            return list;
                        }
                        string text2 = text.Substring(0, num);
                        if (!string.IsNullOrEmpty(text2))
                        {
                            list.Add(text2);
                        }
                        text = text.Substring(num).TrimStart(new char[] { ' ' });
                    }
                }
                return list;
            }
            return new List<string>();
        }

        public static void smethod_6(string string_0)
        {
            Plugin.Log.LogWarning($"smethod_6() - Command entered: '{string_0}'");

            Foobar_GClass3538.list_0.Insert(0, string_0);
            if (Foobar_GClass3538.list_0.Count > Foobar_GClass3538.int_0)
            {
                Foobar_GClass3538.list_0.RemoveRange(Foobar_GClass3538.int_0, Foobar_GClass3538.list_0.Count - Foobar_GClass3538.int_0);
            }

            if (!string.IsNullOrWhiteSpace(string_0))
            {
                List<string> list = Foobar_GClass3538.smethod_11(string_0);
                Plugin.Log.LogWarning($"smethod_6() - Parsed {list.Count} tokens from command");

                if (list.Count > 0)
                {
                    Plugin.Log.LogWarning($"smethod_6() - Command name: '{list[0]}'");
                }

                Foobar_GClass3298 gclass;
                if (list.Count > 0 && Foobar_GClass3538.dictionary_0.TryGetValue(list[0].ToLowerInvariant(), out gclass))
                {
                    Plugin.Log.LogWarning($"smethod_6() - Found command handler: {gclass.GetType().Name}");

                    List<object> list2 = new List<object>();
                    int i = 0;
                    while (i < gclass.Args.Count)
                    {
                        Foobar_GClass3537 gclass2 = gclass.Args[i];
                        if (gclass2.type_0 != null)
                        {
                            if (list.Count <= i + 1)
                            {
                                if (!gclass2.bool_0)
                                {
                                    gclass.method_1();
                                    return;
                                }
                                i++;
                                continue;
                            }
                            string string_ = list[i + 1];
                            Foobar_GClass3283 gclass3;
                            if (Foobar_GClass3538.dictionary_1.TryGetValue(gclass2.type_0, out gclass3))
                            {
                                try
                                {
                                    object item = gclass3.vmethod_3(string_);
                                    list2.Add(item);
                                    Plugin.Log.LogWarning($"smethod_6() - Parsed argument {i}: '{string_}' as {gclass2.type_0.Name}");
                                }
                                catch (Exception ex)
                                {
                                    Foobar_GClass3538.smethod_4("[error]Error occurred while parsing arg [val]'{0}'[/val]: {1}", new object[]
                                    {
                                gclass2.string_0 ?? gclass3.vmethod_0(),
                                ex.Message
                                    });
                                    return;
                                }
                            }
                            else
                            {
                                Foobar_GClass3538.smethod_4("[error]Argument definition not found [val]'{0}'", new object[]
                                {
                            gclass2.type_0.Name
                                });
                                return;
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(gclass2.string_0))
                            {
                                Foobar_GClass3538.smethod_4("[error]Argument type not set for [val]'{0}'", new object[]
                                {
                            gclass2.string_0
                                });
                                return;
                            }
                            Foobar_GClass3538.smethod_4("[error]Argument type not set'", new object[0]);
                            return;
                        }
                        i++;
                    }

                    Plugin.Log.LogWarning($"smethod_6() - Executing command with {list2.Count} arguments");

                    GClass3312 gclass4 = null;
                    try
                    {
                        gclass4 = gclass.vmethod_0(list2);
                        Plugin.Log.LogWarning("smethod_6() - Command executed successfully");
                    }
                    catch (Exception ex2)
                    {
                        Plugin.Log.LogWarning($"smethod_6() - Command execution failed: {ex2.Message}");
                        Foobar_GClass3538.smethod_4("[error]Error occurred while executing command: {0}", new object[]
                        {
                    ex2.Message
                        });
                        gclass.method_1();
                        return;
                    }
                    if (gclass4 != null)
                    {
                        if (gclass4 is GClass3351)
                        {
                            Foobar_GClass3538.smethod_4("Select tile...", new object[0]);
                        }
                        else if (gclass4 is GClass3319)
                        {
                            Foobar_GClass3538.smethod_4("Select entity...", new object[0]);
                        }
                        GInterface131 service = GClass1181.GetService<GInterface131>();
                        if (service != null)
                        {
                            if (service.imethod_0() != null)
                            {
                                service.imethod_4();
                            }
                            Foobar_GClass3351 gclass3303_ = new Foobar_GClass3351(gclass4, gclass, list2);
                            service.imethod_5(gclass3303_);
                        }
                    }
                }
                else
                {
                    Plugin.Log.LogWarning($"smethod_6() - Command not found in dictionary. Available commands: {string.Join(", ", dictionary_0.Keys)}");
                }
            }
        }

        private static void smethod_13()
        {
            Plugin.Log.LogWarning("smethod_13() - Starting command registration");

            foreach (Type type in GClass1181.GetServiceOrThrow<GInterface11>().imethod_0(t => typeof(Foobar_GClass3298).IsAssignableFrom(t)))
            {
                try
                {
                    if (type.IsClass && !type.IsAbstract)
                    {
                        Plugin.Log.LogWarning($"smethod_13() - Found command type: {type.Name}");

                        if (type.GetConstructor(Type.EmptyTypes) != null)
                        {
                            Foobar_GClass3298 gclass = (Foobar_GClass3298)Activator.CreateInstance(type);
                            if (gclass.Commands != null && gclass.Commands.Length != 0)
                            {
                                foreach (string text in gclass.Commands)
                                {
                                    if (!string.IsNullOrEmpty(text))
                                    {
                                        if (!Foobar_GClass3538.dictionary_0.ContainsKey(text.ToLowerInvariant()))
                                        {
                                            Foobar_GClass3538.dictionary_0[text.ToLowerInvariant()] = gclass;
                                            Plugin.Log.LogWarning($"smethod_13() - Registered command: '{text}'");
                                        }
                                        else
                                        {
                                            GClass2632.smethod_0(LogSeverity.Error, "ConsoleManager: Duplicate command string '{0}' found when processing command '{1}'.", new object[]
                                            {
                                        text,
                                        type.AssemblyQualifiedName
                                            });
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception exception_)
                {
                    GClass2632.smethod_1(LogSeverity.Error, exception_, "ConsoleManager: Failed to instantiate console command.", new object[0]);
                }
            }

            Plugin.Log.LogWarning($"smethod_13() - Command registration complete. Total commands: {dictionary_0.Count}");
        }

        private static void smethod_14()
        {
            Plugin.Log.LogWarning("smethod_14() - Starting argument type registration");

            foreach (Type type in GClass1181.GetServiceOrThrow<GInterface11>().imethod_0(t => typeof(Foobar_GClass3283).IsAssignableFrom(t)))
            {
                try
                {
                    if (type.IsClass && !type.IsAbstract)
                    {
                        Plugin.Log.LogWarning($"smethod_14() - Found argument type: {type.Name}");

                        if (type.GetConstructor(Type.EmptyTypes) != null)
                        {
                            Foobar_GClass3283 value = (Foobar_GClass3283)Activator.CreateInstance(type);
                            Foobar_GClass3538.dictionary_1[type] = value;
                            Plugin.Log.LogWarning($"smethod_14() - Registered argument type: {type.Name}");
                        }
                    }
                }
                catch (Exception exception_)
                {
                    GClass2632.smethod_1(LogSeverity.Error, exception_, "ConsoleManager: Failed to instantiate console arg.", new object[0]);
                }
            }

            Plugin.Log.LogWarning($"smethod_14() - Argument type registration complete. Total types: {dictionary_1.Count}");
        }
    }

    // ============================================================================
    // Foobar_GClass3295 - Int32 argument type for console commands
    // ============================================================================
    public sealed class Foobar_GClass3295 : Foobar_GClass3283
    {
        public override string vmethod_0()
        {
            return "int32";
        }

        public override object vmethod_3(string string_0)
        {
            int num;
            int.TryParse(string_0, out num);
            return num;
        }
    }

    // ============================================================================
    // EXTENSION TO ADD foobar() METHOD TO GClass1472
    // ============================================================================
    public static class GClass1472_Extensions
    {
        // Dictionary to store the foobar_gclass1578_0 instance for each GClass1472 instance
        private static Dictionary<GClass1472, Foobar_GClass1578> foobarInstances =
            new Dictionary<GClass1472, Foobar_GClass1578>();

        // Original foobar method
        public static void foobar(this GClass1472 instance)
        {
            // Access bool_21 field using reflection
            var bool21Field = AccessTools.Field(typeof(GClass1472), "bool_21");
            bool21Field.SetValue(instance, true);

            // Check if we already created a foobar instance for this GClass1472
            if (!foobarInstances.ContainsKey(instance))
            {
                GStruct4 gstruct = new GStruct4(1920, 810);

                // Access double_4 field
                var double4Field = AccessTools.Field(typeof(GClass1472), "double_4");
                double4Field.SetValue(instance, 0.0);

                // Create and store the Foobar_GClass1578 instance
                Foobar_GClass1578 foobarGclass = new Foobar_GClass1578(gstruct);
                foobarGclass.Location = new Point(0, -gstruct.int_1);

                // Store it in our dictionary (this acts as foobar_gclass1578_0)
                foobarInstances[instance] = foobarGclass;

                // Call vmethod_0 to add it to the control
                var vmethodInfo = AccessTools.Method(typeof(GClass1472), "vmethod_0");
                vmethodInfo.Invoke(instance, new object[] { foobarGclass });

                Plugin.Log.LogWarning("foobar() called - Created new Foobar_GClass1578 instance");
            }
            else
            {
                Plugin.Log.LogWarning("foobar() called - foobar_gclass1578_0 already exists");
            }
        }

        // NEW METHOD: foobar_method_142
        public static void foobar_method_142(this GClass1472 instance)
        {
            // Access bool_21 field using reflection
            var bool21Field = AccessTools.Field(typeof(GClass1472), "bool_21");
            bool21Field.SetValue(instance, false);

            // Check if foobar instance exists
            if (foobarInstances.ContainsKey(instance))
            {
                Foobar_GClass1578 foobarGclass = foobarInstances[instance];

                if (foobarGclass != null)
                {
                    // Call method_9 on the foobar instance
                    foobarGclass.method_9();

                    // Call vmethod_1 to remove it from the control
                    var vmethod1Info = AccessTools.Method(typeof(GClass1472), "vmethod_1");
                    vmethod1Info.Invoke(instance, new object[] { foobarGclass });

                    // Remove from dictionary (set to null equivalent)
                    foobarInstances.Remove(instance);

                    Plugin.Log.LogWarning("foobar_method_142() called - Removed Foobar_GClass1578 instance");
                }
            }
        }

        // NEW METHOD: foobar_method_143
        public static void foobar_method_143(this GClass1472 instance, GClass1236 gclass1236_0)
        {
            // Access bool_21 field using reflection
            var bool21Field = AccessTools.Field(typeof(GClass1472), "bool_21");
            bool bool_21 = (bool)bool21Field.GetValue(instance);

            // Access double_4 field using reflection
            var double4Field = AccessTools.Field(typeof(GClass1472), "double_4");
            double double_4 = (double)double4Field.GetValue(instance);

            bool flag = false;

            if (bool_21)
            {
                // Check if foobar instance exists
                if (foobarInstances.ContainsKey(instance))
                {
                    Foobar_GClass1578 foobarGclass = foobarInstances[instance];

                    if (foobarGclass != null)
                    {
                        foobarGclass.method_104();

                        if (double_4 < 1.0)
                        {
                            double_4 = Math.Min(1.0, double_4 + gclass1236_0.method_0().ElapsedGameTime.TotalMilliseconds * 0.003);
                            flag = true;
                        }
                    }
                }
            }
            else if (foobarInstances.ContainsKey(instance))
            {
                Foobar_GClass1578 foobarGclass = foobarInstances[instance];

                if (foobarGclass != null)
                {
                    foobarGclass.method_105();
                    double_4 -= gclass1236_0.method_0().ElapsedGameTime.TotalMilliseconds * 0.003;

                    if (double_4 <= 0.0)
                    {
                        // Call vmethod_1 to remove it from the control
                        var vmethod1Info = AccessTools.Method(typeof(GClass1472), "vmethod_1");
                        vmethod1Info.Invoke(instance, new object[] { foobarGclass });

                        // Remove from dictionary (set to null equivalent)
                        foobarInstances.Remove(instance);
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }

            // Update double_4 field
            double4Field.SetValue(instance, double_4);

            if (flag && foobarInstances.ContainsKey(instance))
            {
                Foobar_GClass1578 foobarGclass = foobarInstances[instance];

                if (foobarGclass != null)
                {
                    int y = Convert.ToInt32((double)foobarGclass.Size.int_1 * (-1.0 + double_4));
                    foobarGclass.Location = new Point(0, y);
                }
            }
        }

        // Helper method to retrieve the foobar instance if needed
        public static Foobar_GClass1578 GetFoobarInstance(this GClass1472 instance)
        {
            if (foobarInstances.TryGetValue(instance, out Foobar_GClass1578 result))
            {
                return result;
            }
            return null;
        }
    }

    // ============================================================================
    // HARMONY PATCH FOR vmethod_49 - Calls foobar_method_143
    // ============================================================================
    [HarmonyPatch(typeof(GClass1472), "vmethod_49")]
    public class GClass1472_vmethod_49_Patch
    {
        static void Prefix(GClass1472 __instance, GClass1236 gclass1236_0)
        {
            // Call our custom method after the original vmethod_49 executes
            __instance.foobar_method_143(gclass1236_0);
        }
    }

    [HarmonyPatch(typeof(GClass3553), MethodType.Constructor)]
    public class GClass3553_Constructor_Patch
    {
        static void Prefix()
        {
            // Initialize the console manager
            Foobar_GClass3538.smethod_5();

            Plugin.Log.LogWarning("GClass3553 constructor called - Console manager initialized");
        }
    }

    [HarmonyPatch(typeof(GClass3289), "imethod_52")]
    public class GClass3289_imethod_52_Patch
    {
        static void Prefix(GClass3289 __instance)
        {
            // Get the gclass1472_0 field from GClass3289
            var gclass1472Field = AccessTools.Field(typeof(GClass3289), "gclass1472_0");
            GClass1472 gclass1472 = (GClass1472)gclass1472Field.GetValue(__instance);
            
            if (gclass1472 != null)
            {
                // Call foobar_method_142 to close the console
                gclass1472.foobar_method_142();
                
                Plugin.Log.LogWarning("imethod_52 called - Console closed via foobar_method_142");
            }
        }
    }
}
