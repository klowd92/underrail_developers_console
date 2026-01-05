using System;
using System.Collections.Generic;
using System.Linq;
using TimelapseVertigo.Rules.Characters;
using Ouroboros.Common.Data;

namespace underrail
{
    // ============================================================================
    // Foobar_GClass3284 - Base Ability argument type
    // ============================================================================
    public sealed class Foobar_GClass3284 : Foobar_GClass3283
    {
        public override string vmethod_0()
        {
            return "base ability";
        }

        public override object vmethod_3(string string_0)
        {
            return string_0;
        }

        protected override List<object> vmethod_2()
        {
            List<object> list = new List<object>();
            foreach (object obj in Enum.GetValues(typeof(BaseAbilityEnum)))
            {
                list.Add(((BaseAbilityEnum)obj).ToString().smethod_3());
            }
            return list;
        }
    }

    // ============================================================================
    // Foobar_GClass3286 - Joblet argument type
    // ============================================================================
    public sealed class Foobar_GClass3286 : Foobar_GClass3283
    {
        public override string vmethod_0()
        {
            return "joblet";
        }

        public override object vmethod_3(string string_0)
        {
            if (string_0 != null)
            {
                return string_0.Trim();
            }
            return null;
        }

        protected override List<object> vmethod_2()
        {
            List<object> list = new List<object>();
            foreach (string item in GClass4511.smethod_2().Keys)
            {
                list.Add(item);
            }
            return list;
        }
    }

    // ============================================================================
    // Foobar_GClass3287 - String argument type
    // ============================================================================
    public sealed class Foobar_GClass3287 : Foobar_GClass3283
    {
        public override string vmethod_0()
        {
            return "string";
        }

        public override object vmethod_3(string string_0)
        {
            return string_0;
        }
    }

    // ============================================================================
    // Foobar_GClass3289 - Capability argument type
    // ============================================================================
    public sealed class Foobar_GClass3289 : Foobar_GClass3283
    {
        public override string vmethod_0()
        {
            return "capability";
        }

        public override object vmethod_3(string string_0)
        {
            return GClass6402.smethod_2(string_0);
        }

        protected override List<object> vmethod_2()
        {
            List<object> list = new List<object>();
            foreach (GClass0 gclass in GClass6402.smethod_0())
            {
                GAttribute29 gattribute = gclass.GetType().GetCustomAttributes(typeof(GAttribute29), false).FirstOrDefault<object>() as GAttribute29;
                list.Add(gattribute.method_0());
            }
            return list;
        }
    }

    // ============================================================================
    // Foobar_GClass3291 - Bool argument type
    // ============================================================================
    public sealed class Foobar_GClass3291 : Foobar_GClass3283
    {
        public override string vmethod_0()
        {
            return "bool";
        }

        public override object vmethod_3(string string_0)
        {
            if (string_0 == null)
            {
                return false;
            }
            if (!string.Equals(string_0, "y", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(string_0, "yes", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(string_0, "on", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(string_0, "1", StringComparison.OrdinalIgnoreCase))
            {
                bool flag;
                bool.TryParse(string_0, out flag);
                return flag;
            }
            return true;
        }
    }

    // ============================================================================
    // Foobar_GClass3293 - Cooldown argument type
    // ============================================================================
    public sealed class Foobar_GClass3293 : Foobar_GClass3283
    {
        public override string vmethod_0()
        {
            return "cooldown";
        }

        public override object vmethod_3(string string_0)
        {
            return string_0;
        }

        protected override List<object> vmethod_2()
        {
            List<object> list = new List<object>();
            GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
            if (serviceOrThrow.imethod_2() != null &&
                serviceOrThrow.imethod_2().method_0() != null &&
                serviceOrThrow.imethod_2().method_0().Cooldowns.method_0().Count > 0)
            {
                foreach (KeyValuePair<string, GClass6400> keyValuePair in serviceOrThrow.imethod_2().method_0().Cooldowns.method_0())
                {
                    list.Add(keyValuePair.Key);
                }
            }
            return list;
        }
    }

    // ============================================================================
    // Foobar_GClass3294 - Skill argument type
    // ============================================================================
    public sealed class Foobar_GClass3294 : Foobar_GClass3283
    {
        public override string vmethod_0()
        {
            return "skill";
        }

        public override object vmethod_3(string string_0)
        {
            return string_0;
        }

        protected override List<object> vmethod_2()
        {
            List<object> list = new List<object>();
            foreach (object obj in Enum.GetValues(typeof(SkillEnum)))
            {
                list.Add(((SkillEnum)obj).ToString().smethod_3());
            }
            return list;
        }
    }

    // ============================================================================
    // Foobar_GClass3297 - LocaleId argument type
    // ============================================================================
    public sealed class Foobar_GClass3297 : Foobar_GClass3283
    {
        public override string vmethod_0()
        {
            return "localeId";
        }

        public override object vmethod_3(string string_0)
        {
            if (string_0 != null)
            {
                return GClass3445.smethod_0(string_0);
            }
            return null;
        }

        protected override List<object> vmethod_2()
        {
            List<object> list = new List<object>();
            foreach (GClass3444 gclass in GClass1181.GetServiceOrThrow<GInterface114>().imethod_9().method_0())
            {
                list.Add(gclass.Id.ToLowerInvariant());
            }
            return list;
        }
    }
}