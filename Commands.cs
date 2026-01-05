using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace underrail
{
    // ============================================================================
    // Foobar_GClass3300 - playerSetHealth console command
    // ============================================================================
    public sealed class Foobar_GClass3300 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playersethealth",
                    "psethp"
                };
            }
        }

        public Foobar_GClass3300()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3295), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            Plugin.Log.LogWarning($"Foobar_GClass3300.vmethod_0() - Called with {(list_1 != null ? list_1.Count : 0)} arguments");

            if (list_1 != null && list_1.Count == 1)
            {
                int num = (int)list_1[0];
                Plugin.Log.LogWarning($"Foobar_GClass3300.vmethod_0() - Setting health to: {num}");

                GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();

                if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null)
                {
                    Plugin.Log.LogWarning("Foobar_GClass3300.vmethod_0() - Player character found, setting health");
                    serviceOrThrow.imethod_2().method_0().Defense.method_21().imethod_5((float)num);

                    Foobar_GClass3538.smethod_4("Player health set to {0}", new object[]
                    {
                        serviceOrThrow.imethod_2().method_0().Defense.method_21().imethod_4()
                    });
                }
                else
                {
                    Plugin.Log.LogWarning("Foobar_GClass3300.vmethod_0() - Player character NOT found");
                    Foobar_GClass3538.smethod_4("[error]Could not find player character", new object[0]);
                }
                return null;
            }

            Plugin.Log.LogWarning("Foobar_GClass3300.vmethod_0() - Invalid arguments, showing usage");
            base.method_1();
            return null;
        }
    }

    // Foobar_GClass3332 - Spawn Entity Command
    public sealed class Foobar_GClass3332 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "spawnEntity",
                    "se"
                };
            }
        }

        public Foobar_GClass3332()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3296), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count > 0)
            {
                // Note: You'll need to provide proper parameters for GClass3351
                // The original code doesn't show what parameters it needs
                return new GClass3351();
            }
            return null;
        }

        public override void vmethod_1(List<object> list_1, object object_0)
        {
            GClass1618 gclass = object_0 as GClass1618;
            if (gclass != null)
            {
                string text = list_1[0] as string;
                if (text != null)
                {
                    if (text.StartsWith("!"))
                    {
                        string string_ = text.Substring(1);
                        Foobar_GClass3296 argument = Foobar_GClass3538.GetArgument<Foobar_GClass3296>();
                        if (argument != null)
                        {
                            text = argument.method_1(string_);
                        }
                    }
                    if (!string.IsNullOrEmpty(text))
                    {
                        GClass1682 gclass2 = GClass4547.smethod_2(text, gclass.Zone, new GClass1760(gclass.Area.Name, gclass.Location.smethod_2()), false);
                        if (gclass2 != null)
                        {
                            Foobar_GClass3538.smethod_4("Spawned entity [val]'{0}'[/val] from definition [val]'{1}'[/val] at [val]'{2}'[/val]", new object[]
                            {
                                gclass2.Name,
                                text,
                                gclass.Location
                            });
                            return;
                        }
                        Foobar_GClass3538.smethod_4("[error]Failed to spawn entity from definition [val]'{0}'", new object[]
                        {
                            text
                        });
                    }
                }
            }
        }
    }

    // ============================================================================
    // Foobar_GClass3301 - playerGiveAllPsiAbilities console command
    // ============================================================================
    public sealed class Foobar_GClass3301 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerGiveAllPsiAbilities",
                    "pgiveallpsi"
                };
            }
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count != 0)
            {
                base.method_1();
                return null;
            }
            GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
            if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null)
            {
                foreach (GClass0 gclass in GClass6402.smethod_0())
                {
                    if (!serviceOrThrow.imethod_2().method_0().PsiAbilities.method_4(gclass) && (gclass is GClass239 || gclass is GClass20))
                    {
                        serviceOrThrow.imethod_2().method_0().PsiAbilities.method_2(gclass);
                        Foobar_GClass3538.smethod_4("Player gains [prop]{0}[/prop] psionic ability", new object[]
                        {
                            gclass.Name
                        });
                    }
                }
            }
            else
            {
                Foobar_GClass3538.smethod_4("[error]Could not find player character", new object[0]);
            }
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3302 - playerSetModel console command
    // ============================================================================
    public sealed class Foobar_GClass3302 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerSetModel",
                    "psetmodel"
                };
            }
        }

        public Foobar_GClass3302()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3287), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count >= 1)
            {
                string text = list_1[0] as string;
                if (!string.IsNullOrWhiteSpace(text))
                {
                    GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                    if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null)
                    {
                        GClass1682 gclass = serviceOrThrow.imethod_2().method_0().method_98() as GClass1682;
                        if (gclass != null && gclass.quickAspectAccessor_0.gparam_0 != null)
                        {
                            gclass.quickAspectAccessor_0.gparam_0.method_9(text);
                            Foobar_GClass3538.smethod_4("Player model set to [val]{0}[/val]", new object[]
                            {
                                text
                            });
                            return null;
                        }
                        Foobar_GClass3538.smethod_4("[error]Could not change player model[/error]", new object[0]);
                        return null;
                    }
                }
            }
            else
            {
                base.method_1();
            }
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3303 - playerExecuteJoblet console command
    // ============================================================================
    public sealed class Foobar_GClass3303 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerExecuteJoblet",
                    "pexecjoblet"
                };
            }
        }

        public Foobar_GClass3303()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3286), null, false));
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3291), "asInitiator", true));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count >= 1)
            {
                string text = list_1[0] as string;
                if (!string.IsNullOrWhiteSpace(text))
                {
                    GDelegate2 gdelegate = GClass4511.smethod_1(text);
                    if (gdelegate == null)
                    {
                        Foobar_GClass3538.smethod_4("[error]Could not find joblet '{0}'", new object[]
                        {
                            text
                        });
                        return null;
                    }
                    bool flag = false;
                    if (list_1.Count > 1)
                    {
                        object obj = list_1[1];
                        if (obj is bool)
                        {
                            flag = (bool)obj;
                        }
                    }
                    GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                    if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null)
                    {
                        GClass1682 gclass = serviceOrThrow.imethod_2().method_0().method_98() as GClass1682;
                        if (gclass != null)
                        {
                            if (flag)
                            {
                                gdelegate(gclass, null, new Dictionary<string, object>());
                            }
                            else
                            {
                                gdelegate(null, gclass, new Dictionary<string, object>());
                            }
                            string text2 = "Joblet '{0}' executed on player entity";
                            if (flag)
                            {
                                text2 += " as initiator";
                            }
                            Foobar_GClass3538.smethod_4(text2, new object[]
                            {
                                text
                            });
                            return null;
                        }
                    }
                    Foobar_GClass3538.smethod_4("[error]Could not find player character", new object[0]);
                    return null;
                }
            }
            base.method_1();
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3304 - playerKill console command
    // ============================================================================
    public sealed class Foobar_GClass3304 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerKill",
                    "pkill",
                    "pk"
                };
            }
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count != 0)
            {
                base.method_1();
            }
            else
            {
                GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null)
                {
                    serviceOrThrow.imethod_2().method_0().method_19(null, null, false);
                }
            }
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3305 - playerSetStatusEffect console command
    // ============================================================================
    public sealed class Foobar_GClass3305 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerSetStatusEffect",
                    "psetse"
                };
            }
        }

        public Foobar_GClass3305()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3288), null, false));
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3295), "duration", true));
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3295), "stacks", true));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count >= 1)
            {
                GClass4262 gclass = list_1[0] as GClass4262;
                if (gclass != null)
                {
                    if (list_1.Count > 1)
                    {
                        object obj = list_1[1];
                        if (obj is int)
                        {
                            int duration = (int)obj;
                            gclass.Duration = duration;
                        }
                    }
                    if (list_1.Count > 2)
                    {
                        object obj2 = list_1[2];
                        if (obj2 is int)
                        {
                            int stacks = (int)obj2;
                            gclass.Stacks = stacks;
                        }
                    }
                    GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                    if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null)
                    {
                        serviceOrThrow.imethod_2().method_0().StatusEffects.method_12(gclass, false, false, false);
                        Foobar_GClass3538.smethod_4("Player gains [prop]{0}[/prop] status effect for {1}", new object[]
                        {
                            gclass.Name,
                            (gclass.Duration > 0) ? gclass.Duration.ToString() : "ever"
                        });
                    }
                    else
                    {
                        Foobar_GClass3538.smethod_4("[error]Could not find player character", new object[0]);
                    }
                }
                return null;
            }
            base.method_1();
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3306 - playerRemoveCooldown console command
    // ============================================================================
    public sealed class Foobar_GClass3306 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerRemoveCooldown",
                    "prmcd"
                };
            }
        }

        public Foobar_GClass3306()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3293), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count == 1)
            {
                string text = list_1[0] as string;
                if (text != null)
                {
                    GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                    if (serviceOrThrow.imethod_2() == null || serviceOrThrow.imethod_2().method_0() == null)
                    {
                        base.method_0("[error]Could not find player character", new object[0]);
                        return null;
                    }
                    GClass6400 gclass = serviceOrThrow.imethod_2().method_0().Cooldowns.method_6(text);
                    if (gclass != null)
                    {
                        serviceOrThrow.imethod_2().method_0().Cooldowns.method_8(text);
                        base.method_0("Cooldown '[val]{0}[/val]' removed at [val]{1}[/val]", new object[]
                        {
                            text,
                            gclass.double_0
                        });
                        return null;
                    }
                    base.method_0("[warning]Cooldown not found.", new object[0]);
                    return null;
                }
            }
            base.method_1();
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3307 - writeGlobalProperty console command
    // ============================================================================
    public sealed class Foobar_GClass3307 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "writeGlobalProperty",
                    "writegp",
                    "write"
                };
            }
        }

        public Foobar_GClass3307()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3287), null, false));
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3291), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count == 2)
            {
                GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                if (serviceOrThrow.imethod_2() == null)
                {
                    base.method_0("[error]Current game not found", new object[0]);
                    return null;
                }
                string text = list_1[0] as string;
                if (string.IsNullOrEmpty(text))
                {
                    base.method_1();
                    return null;
                }
                serviceOrThrow.imethod_2().method_8()[text] = list_1[1];
            }
            else
            {
                base.method_1();
            }
            return null;
        }

        private void method_3(GInterface114 ginterface114_0, string string_0)
        {
            if (!string.IsNullOrWhiteSpace(string_0))
            {
                object propertyValue = ginterface114_0.imethod_2().method_8().GetPropertyValue(string_0);
                string text;
                if (propertyValue == null)
                {
                    text = "null";
                }
                else
                {
                    text = propertyValue.ToString();
                }
                base.method_0("[prop]{0}[/prop] = [val]'{1}'[/val]", new object[]
                {
                    string_0,
                    text
                });
            }
        }
    }

    // ============================================================================
    // Foobar_GClass3308 - recordTimes console command
    // ============================================================================
    public sealed class Foobar_GClass3308 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "recordTimes",
                    "rec"
                };
            }
        }

        public Foobar_GClass3308()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3291), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count == 0)
            {
                Foobar_GClass3538.smethod_4("Recording times: " + (GClass2623.bool_0 ? "on" : "off"), new object[0]);
                return null;
            }
            if (list_1 != null && list_1.Count == 1)
            {
                object obj = list_1[0];
                if (obj is bool)
                {
                    GClass2623.bool_0 = (bool)obj;
                    Foobar_GClass3538.smethod_4("Recording times: " + (GClass2623.bool_0 ? "on (0)" : "off (1)"), new object[0]);
                    return null;
                }
            }
            base.method_1();
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3309 - loadTestModel console command
    // ============================================================================
    public sealed class Foobar_GClass3309 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "loadTestModel"
                };
            }
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count == 0)
            {
                Model resource = GClass1181.GetService<GInterface30>().GetResource<Model>("Locale\\Models\\test", null);
                new GClass1637("test", resource);
                if (resource != null)
                {
                    base.method_0("Loaded", new object[0]);
                }
                else
                {
                    base.method_0("Not found.", new object[0]);
                }
            }
            else
            {
                base.method_1();
            }
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3310 - playerListCooldowns console command
    // ============================================================================
    public sealed class Foobar_GClass3310 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerListCooldowns",
                    "plistcd"
                };
            }
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
            if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null)
            {
                base.method_0("Player cooldowns:", new object[0]);
                if (serviceOrThrow.imethod_2().method_0().Cooldowns.method_0().Count > 0)
                {
                    foreach (KeyValuePair<string, GClass6400> keyValuePair in serviceOrThrow.imethod_2().method_0().Cooldowns.method_0())
                    {
                        base.method_0("[prop]{0}[/prop]: [val]{1}[/val] / [val]{2}[/val]", new object[]
                        {
                            keyValuePair.Key,
                            keyValuePair.Value.double_0,
                            keyValuePair.Value.double_1
                        });
                    }
                }
                else
                {
                    base.method_0("[warning]none", new object[0]);
                }
            }
            else
            {
                base.method_0("[error]Could not find player character", new object[0]);
            }
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3311 - playerRemoveSpecialAttack console command
    // ============================================================================
    public sealed class Foobar_GClass3311 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerRemoveSpecialAttack",
                    "premsatt"
                };
            }
        }

        public Foobar_GClass3311()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3289), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count == 1)
            {
                GClass0 gclass = list_1[0] as GClass0;
                GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null && gclass != null)
                {
                    serviceOrThrow.imethod_2().method_0().SpecialAttacks.method_3(gclass);
                    Foobar_GClass3538.smethod_4("Player loses [prop]{0}[/prop] special attack", new object[]
                    {
                        gclass.Name
                    });
                }
                else
                {
                    Foobar_GClass3538.smethod_4("[error]Could not find player character", new object[0]);
                }
                return null;
            }
            base.method_1();
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3312_Cmd - playerRemoveSpecialAbility console command
    // (Renamed to avoid conflict with game's GClass3312)
    // ============================================================================
    public sealed class Foobar_GClass3312_Cmd : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerRemoveSpecialAbility",
                    "premsab"
                };
            }
        }

        public Foobar_GClass3312_Cmd()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3289), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count == 1)
            {
                GClass0 gclass = list_1[0] as GClass0;
                GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null && gclass != null)
                {
                    serviceOrThrow.imethod_2().method_0().SpecialAbilities.method_3(gclass);
                    Foobar_GClass3538.smethod_4("Player loses [prop]{0}[/prop] special ability", new object[]
                    {
                        gclass.Name
                    });
                }
                else
                {
                    Foobar_GClass3538.smethod_4("[error]Could not find player character", new object[0]);
                }
                return null;
            }
            base.method_1();
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3313 - playerRemovePsiAbility console command
    // ============================================================================
    public sealed class Foobar_GClass3313 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerRemovePsiAbility",
                    "prempsi"
                };
            }
        }

        public Foobar_GClass3313()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3289), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count == 1)
            {
                GClass0 gclass = list_1[0] as GClass0;
                GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null && gclass != null)
                {
                    serviceOrThrow.imethod_2().method_0().PsiAbilities.method_3(gclass);
                    Foobar_GClass3538.smethod_4("Player loses [prop]{0}[/prop] psionic ability", new object[]
                    {
                        gclass.Name
                    });
                }
                else
                {
                    Foobar_GClass3538.smethod_4("[error]Could not find player character", new object[0]);
                }
                return null;
            }
            base.method_1();
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3314 - playerGivePsiAbility console command
    // ============================================================================
    public sealed class Foobar_GClass3314 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerGivePsiAbility",
                    "pgivepsi"
                };
            }
        }

        public Foobar_GClass3314()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3289), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count == 1)
            {
                GClass0 gclass = list_1[0] as GClass0;
                GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null && gclass != null)
                {
                    serviceOrThrow.imethod_2().method_0().PsiAbilities.method_2(gclass);
                    Foobar_GClass3538.smethod_4("Player gains [prop]{0}[/prop] psionic ability", new object[]
                    {
                        gclass.Name
                    });
                }
                else
                {
                    Foobar_GClass3538.smethod_4("[error]Could not find player character", new object[0]);
                }
                return null;
            }
            base.method_1();
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3315 - playerGiveSpecialAbility console command
    // ============================================================================
    public sealed class Foobar_GClass3315 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerGiveSpecialAbility",
                    "pgivesab"
                };
            }
        }

        public Foobar_GClass3315()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3289), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count == 1)
            {
                GClass0 gclass = list_1[0] as GClass0;
                GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null && gclass != null)
                {
                    serviceOrThrow.imethod_2().method_0().SpecialAbilities.method_2(gclass);
                    Foobar_GClass3538.smethod_4("Player gains [prop]{0}[/prop] special ability", new object[]
                    {
                        gclass.Name
                    });
                }
                else
                {
                    Foobar_GClass3538.smethod_4("[error]Could not find player character", new object[0]);
                }
                return null;
            }
            base.method_1();
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3316 - playerGiveSpecialAttack console command
    // ============================================================================
    public sealed class Foobar_GClass3316 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerGiveSpecialAttack",
                    "pgivesatt"
                };
            }
        }

        public Foobar_GClass3316()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3289), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count == 1)
            {
                GClass0 gclass = list_1[0] as GClass0;
                GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null && gclass != null)
                {
                    serviceOrThrow.imethod_2().method_0().SpecialAttacks.method_2(gclass);
                    Foobar_GClass3538.smethod_4("Player gains [prop]{0}[/prop] special attack", new object[]
                    {
                        gclass.Name
                    });
                }
                else
                {
                    Foobar_GClass3538.smethod_4("[error]Could not find player character", new object[0]);
                }
                return null;
            }
            base.method_1();
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3317 - listCommands console command
    // ============================================================================
    public sealed class Foobar_GClass3317 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "listCommands",
                    "list",
                    "lst"
                };
            }
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            List<Foobar_GClass3298> list = Foobar_GClass3538.smethod_2();
            bool flag = true;
            string text = "All available commands: ";
            foreach (Foobar_GClass3298 gclass in list)
            {
                if (!flag)
                {
                    text += " // ";
                }
                text += string.Format("[cmd]{0}[/cmd]", gclass.method_2());
                flag = false;
            }
            base.method_0(text, new object[0]);
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3318 - readGlobalProperty console command
    // ============================================================================
    public sealed class Foobar_GClass3318 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "readGlobalProperty",
                    "readgp",
                    "read"
                };
            }
        }

        public Foobar_GClass3318()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3290), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count == 1)
            {
                GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                if (serviceOrThrow.imethod_2() == null)
                {
                    base.method_0("[error]Current game not found", new object[0]);
                    return null;
                }
                List<string> list = list_1[0] as List<string>;
                if (list != null)
                {
                    if (list.Count > 0)
                    {
                        foreach (string string_ in list)
                        {
                            this.method_3(serviceOrThrow, string_);
                        }
                    }
                    else
                    {
                        base.method_0("[warning]No matching global properties found", new object[0]);
                    }
                    return null;
                }
                string text = list_1[0] as string;
                if (!string.IsNullOrWhiteSpace(text))
                {
                    this.method_3(serviceOrThrow, text);
                }
                else
                {
                    base.method_1();
                }
            }
            else
            {
                base.method_1();
            }
            return null;
        }

        private void method_3(GInterface114 ginterface114_0, string string_0)
        {
            if (!string.IsNullOrWhiteSpace(string_0))
            {
                object propertyValue = ginterface114_0.imethod_2().method_8().GetPropertyValue(string_0);
                string text;
                if (propertyValue == null)
                {
                    text = "null";
                }
                else
                {
                    text = propertyValue.ToString();
                }
                base.method_0("[prop]{0}[/prop] = [val]'{1}'[/val]", new object[]
                {
                    string_0,
                    text
                });
            }
        }
    }

    // ============================================================================
    // Foobar_GClass3319 - playerGiveItem console command
    // ============================================================================
    public sealed class Foobar_GClass3319 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerGiveItem",
                    "pgiveitem"
                };
            }
        }

        public Foobar_GClass3319()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3292), null, false));
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3295), "stacks", true));
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3295), "quality", true));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count >= 1)
            {
                string text = list_1[0] as string;
                if (text != null)
                {
                    GClass691 gclass = GClass5457.smethod_3(text);
                    if (gclass == null)
                    {
                        Foobar_GClass3538.smethod_4("[error]Failed to load item from path [val]{0}", new object[]
                        {
                            text
                        });
                        return null;
                    }
                    if (list_1.Count >= 2)
                    {
                        int stacks = (int)list_1[1];
                        gclass.Stacks = stacks;
                    }
                    if (list_1.Count >= 3)
                    {
                        int qualityLevel = (int)list_1[2];
                        GClass694 gclass2 = gclass as GClass694;
                        if (gclass2 == null)
                        {
                            Foobar_GClass3538.smethod_4("[error]Cannot set quality on non-component item", new object[0]);
                            return null;
                        }
                        gclass2.QualityLevel = qualityLevel;
                    }
                    GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                    if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null)
                    {
                        serviceOrThrow.imethod_2().method_0().Bag.imethod_9(gclass, true);
                        string text2 = "Player is given [val]{0}[/val]";
                        if (gclass.Stacks > 1)
                        {
                            text2 += " x [val]{1}[/val]";
                        }
                        Foobar_GClass3538.smethod_4(text2, new object[]
                        {
                            gclass.Definition.method_0(),
                            gclass.Stacks
                        });
                        return null;
                    }
                    return null;
                }
            }
            base.method_1();
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3320 - playerGiveXp console command
    // ============================================================================
    public sealed class Foobar_GClass3320 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerGiveXp",
                    "pgivexp",
                    "givexp"
                };
            }
        }

        public Foobar_GClass3320()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3295), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count == 1)
            {
                int num = (int)list_1[0];
                GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null)
                {
                    serviceOrThrow.imethod_2().method_0().method_87(num);
                    Foobar_GClass3538.smethod_4("Player gains [prop]{0}[/prop] experience points", new object[]
                    {
                        num
                    });
                }
                else
                {
                    Foobar_GClass3538.smethod_4("[error]Could not find player character", new object[0]);
                }
                return null;
            }
            base.method_1();
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3321 - resetBlueprintsLibrary console command
    // ============================================================================
    public sealed class Foobar_GClass3321 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "resetBlueprintsLibrary",
                    "reblue"
                };
            }
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            GInterface72 service = GClass1181.GetService<GInterface72>();
            if (service != null)
            {
                service.imethod_0().method_11();
                Foobar_GClass3538.smethod_4("Blueprints library reinitialized", new object[0]);
            }
            else
            {
                Foobar_GClass3538.smethod_4("[error]Playfield manager not found", new object[0]);
            }
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3322 - resetAll console command
    // ============================================================================
    public sealed class Foobar_GClass3322 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "resetAll",
                    "rall"
                };
            }
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            new Foobar_GClass3326().vmethod_0(list_1);
            new Foobar_GClass3324().vmethod_0(list_1);
            new Foobar_GClass3321().vmethod_0(list_1);
            new Foobar_GClass3325().vmethod_0(list_1);
            new Foobar_GClass3323().vmethod_0(list_1);
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3323 - resetKnowledgeManager console command
    // ============================================================================
    public sealed class Foobar_GClass3323 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "resetKnowledgeManager",
                    "rknow"
                };
            }
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            GClass5437.smethod_2();
            Foobar_GClass3538.smethod_4("Knowledge Manager reset", new object[0]);
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3324 - reloadAudioBank console command
    // ============================================================================
    public sealed class Foobar_GClass3324 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "reloadAudioBank",
                    "raudio"
                };
            }
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            GClass1181.GetService<GInterface5>().imethod_15(System.IO.Path.Combine(GClass1232.smethod_1().imethod_17(), GClass2640.string_90));
            Foobar_GClass3538.smethod_4("Audio bank reloaded", new object[0]);
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3325 - resetIconManager console command
    // ============================================================================
    public sealed class Foobar_GClass3325 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "resetIconManager",
                    "riconmng",
                    "ricons"
                };
            }
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            GClass6422.smethod_6();
            Foobar_GClass3538.smethod_4("Icon manager reinitialized", new object[0]);
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3326 - reloadAllResources console command
    // ============================================================================
    public sealed class Foobar_GClass3326 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "reloadAllResources",
                    "rallres"
                };
            }
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            GClass1181.GetServiceOrThrow<GInterface30>().imethod_6();
            Foobar_GClass3538.smethod_4("All resources reloaded", new object[0]);
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3327 - revealGlobalMap console command
    // ============================================================================
    public sealed class Foobar_GClass3327 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "revealGlobalMap",
                    "revglobm"
                };
            }
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            GClass1181.GetServiceOrThrow<GInterface111>().imethod_15();
            Foobar_GClass3538.smethod_4("Global map revealed", new object[0]);
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3328 - playerSetBaseAbility console command
    // ============================================================================
    public sealed class Foobar_GClass3328 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerSetBaseAbility",
                    "psetstat"
                };
            }
        }

        public Foobar_GClass3328()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3284), null, false));
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3295), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count >= 2)
            {
                string text = list_1[0] as string;
                int num = (int)list_1[1];
                GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null)
                {
                    GClass361 gclass = serviceOrThrow.imethod_2().method_0().BaseAbilities.method_7(text);
                    if (gclass != null)
                    {
                        gclass.method_3(num);
                        serviceOrThrow.imethod_2().method_0().method_7();
                        Foobar_GClass3538.smethod_4("Player [prop]{0}[/prop] base ability set to [val]{1}[/val]", new object[]
                        {
                            gclass.Name,
                            num
                        });
                        return null;
                    }
                    Foobar_GClass3538.smethod_4("[error]Cannot find base ability [prop]'{0}'[/prop][/error]", new object[]
                    {
                        text
                    });
                    return null;
                }
            }
            else
            {
                base.method_1();
            }
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3329 - playerSetSkill console command
    // ============================================================================
    public sealed class Foobar_GClass3329 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "playerSetSkill",
                    "psetskill"
                };
            }
        }

        public Foobar_GClass3329()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3294), null, false));
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3295), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count >= 2)
            {
                string text = list_1[0] as string;
                int num = (int)list_1[1];
                GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                if (serviceOrThrow.imethod_2() != null && serviceOrThrow.imethod_2().method_0() != null)
                {
                    GClass370 gclass = serviceOrThrow.imethod_2().method_0().Skills.method_7(text);
                    if (gclass != null)
                    {
                        gclass.method_3(num);
                        serviceOrThrow.imethod_2().method_0().method_7();
                        Foobar_GClass3538.smethod_4("Player [prop]{0}[/prop] skill set to [val]{1}[/val]", new object[]
                        {
                            gclass.Name,
                            num
                        });
                        return null;
                    }
                    Foobar_GClass3538.smethod_4("[error]Cannot find skill [prop]'{0}'[/prop][/error]", new object[]
                    {
                        text
                    });
                    return null;
                }
            }
            else
            {
                base.method_1();
            }
            return null;
        }
    }

    // ============================================================================
    // Foobar_GClass3330 - spawnEffect console command
    // ============================================================================
    public sealed class Foobar_GClass3330 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "spawnEffect",
                    "spawnVisualEffect",
                    "svx"
                };
            }
        }

        public Foobar_GClass3330()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3285), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count > 0)
            {
                return new GClass3351();
            }
            return null;
        }

        public override void vmethod_1(List<object> list_1, object object_0)
        {
            GClass1618 gclass = object_0 as GClass1618;
            if (gclass != null && gclass.Area != null)
            {
                string text = list_1[0] as string;
                if (text != null)
                {
                    if (text.StartsWith("!"))
                    {
                        text = text.Substring(1);
                    }
                    GClass4582.smethod_1(gclass.Area, gclass.Location.smethod_2() + new Vector3(0f, 0f, 0.5f), null, text, 1, double.MaxValue, null, null, null, null);
                }
            }
        }
    }

    // ============================================================================
    // Foobar_GClass3331 - exportItem console command
    // ============================================================================
    public sealed class Foobar_GClass3331 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "exportItem",
                    "exi"
                };
            }
        }

        public Foobar_GClass3331()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3287), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count > 0)
            {
                return new GClass3362();
            }
            return null;
        }

        public override void vmethod_1(List<object> list_1, object object_0)
        {
            GClass691 gclass = object_0 as GClass691;
            if (gclass != null)
            {
                string text = list_1[0] as string;
                if (!string.IsNullOrEmpty(text))
                {
                    string text2 = System.IO.Path.Combine(GClass2626.smethod_22(), text);
                    text2 = System.IO.Path.ChangeExtension(text2, "item");
                    gclass.Definition.method_41(text2);
                }
            }
        }
    }

    // ============================================================================
    // Foobar_GClass3333 - goto console command
    // ============================================================================
    public sealed class Foobar_GClass3333 : Foobar_GClass3298
    {
        public override string[] Commands
        {
            get
            {
                return new string[]
                {
                    "go",
                    "goto"
                };
            }
        }

        public Foobar_GClass3333()
        {
            base.Args.Add(new Foobar_GClass3537(typeof(Foobar_GClass3297), null, false));
        }

        public override GClass3312 vmethod_0(List<object> list_1)
        {
            if (list_1 != null && list_1.Count > 0)
            {
                GClass3445 gclass = list_1[0] as GClass3445;
                if (gclass != null)
                {
                    GInterface114 serviceOrThrow = GClass1181.GetServiceOrThrow<GInterface114>();
                    bool flag = false;
                    foreach (GClass3444 locale in serviceOrThrow.imethod_9().method_0())
                    {
                        if (string.Equals(locale.Id, gclass.method_0(), StringComparison.OrdinalIgnoreCase))
                        {
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        Foobar_GClass3538.smethod_4("Teleporting to locale [val]'{0}'[/val]", new object[]
                        {
                            gclass.method_0()
                        });

                        // Close the console before teleporting
                        // Since imethod_96 was removed from GInterface122, we access GClass3289 directly
                        GClass3289 gameManager = GClass1181.GetService<GInterface122>() as GClass3289;
                        if (gameManager != null)
                        {
                            var gclass1472Field = HarmonyLib.AccessTools.Field(typeof(GClass3289), "gclass1472_0");
                            if (gclass1472Field != null)
                            {
                                GClass1472 gclass1472 = (GClass1472)gclass1472Field.GetValue(gameManager);
                                if (gclass1472 != null)
                                {
                                    gclass1472.foobar_method_142();
                                }
                            }
                        }

                        GClass4510.smethod_4(gclass);
                        return null;
                    }
                    Foobar_GClass3538.smethod_4("[error]Locale [val]'{0}'[/val] not found[/error]", new object[]
                    {
                        gclass.method_0()
                    });
                    return null;
                }
            }
            base.method_1();
            return null;
        }
    }
}
