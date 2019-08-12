﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace common.resources
{
    public enum TerrainType
    {
        None,
        Mountains,
        HighSand,
        HighPlains,
        HighForest,
        MidSand,
        MidPlains,
        MidForest,
        LowSand,
        LowPlains,
        LowForest,
        ShoreSand,
        ShorePlains
    }

    public enum TileRegion
    {
        None = 0,
        Spawn = 1,
        RealmPortals = 2,
        Store1 = 3,
        Store2 = 4,
        Store3 = 5,
        Store4 = 6,
        Store5 = 7,
        Store6 = 8,
        Vault = 9,
        Loot = 10,
        Defender = 11,
        Hallway = 12,
        Enemy = 13,
        Hallway1 = 14,
        Hallway2 = 15,
        Hallway3 = 16,
        Store7 = 17,
        Store8 = 18,
        Store9 = 19,
        GiftingChest = 20,
        Store10 = 21,
        Store11 = 22,
        Store12 = 23,
        Store13 = 24,
        Store14 = 26,
        Store15 = 27,
        Store16 = 28,
        Store17 = 29,
        Store18 = 30,
        Store19 = 31,
        Store20 = 32,
        Store21 = 33,
        Store22 = 34,
        Store23 = 35,
        Store24 = 36
    }

    public enum ActivateEffects
    {
        Create,
        Dye,
        Shoot,
        IncrementStat,
        Heal,
        Magic,
        HealNova,
        StatBoostSelf,
        StatBoostAura,
        BulletNova,
        ConditionEffectSelf,
        ConditionEffectAura,
        Teleport,
        PoisonGrenade,
        VampireBlast,
        Trap,
        StasisBlast,
        Pet,
        Decoy, 
        Lightning,
        UnlockPortal,
        MagicNova,
        ClearConditionEffectAura,
        RemoveNegativeConditions,
        ClearConditionEffectSelf,
        RemoveNegativeConditionsSelf,
        ShurikenAbility,
        DazeBlast,
        PermaPet
    }

    [Flags]
    public enum ConditionEffects : ulong
    {
        Dead = 1 << 0,
        Quiet = 1 << 1,
        Weak = 1 << 2,
        Slowed = 1 << 3,
        Sick = 1 << 4,
        Dazed = 1 << 5,
        Stunned = 1 << 6,
        Blind = 1 << 7,
        Hallucinating = 1 << 8,
        Drunk = 1 << 9,
        Confused = 1 << 10,
        StunImmune = 1 << 11,
        Invisible = 1 << 12,
        Paralyzed = 1 << 13,
        Speedy = 1 << 14,
        Bleeding = 1 << 15,
        NotUsed = 1 << 16,
        Healing = 1 << 17,
        Damaging = 1 << 18,
        Berserk = 1 << 19,
        Paused = 1 << 20,
        Stasis = 1 << 21,
        StasisImmune = 1 << 22,
        Invincible = 1 << 23,
        Invulnerable = 1 << 24,
        Armored = 1 << 25,
        ArmorBroken = 1 << 26,
        Hexed = 1 << 27,
        NinjaSpeedy = 1 << 28
    }

    public enum ConditionEffectIndex
    {
        Nothing = 0,
        Dead = 1,
        Quiet = 2,
        Weak = 3,
        Slowed = 4,
        Sick = 5,
        Dazed = 6,
        Stunned = 7,
        Blind = 8,
        Hallucinating = 9,
        Drunk = 10,
        Confused = 11,
        StunImmune = 12,
        Invisible = 13,
        Paralyzed = 14,
        Speedy = 15,
        Bleeding = 16,
        NotUsed = 17,
        Healing = 18,
        Damaging = 19,
        Berserk = 20,
        Paused = 21,
        Stasis = 22,
        StasisImmune = 23,
        Invincible = 24,
        Invulnerable = 25,
        Armored = 26,
        ArmorBroken = 27,
        Hexed = 28,
        NinjaSpeedy = 29
    }

    public class ObjectDesc
    {
        public readonly ushort ObjectType;
        public readonly string ObjectId;
        public readonly string DisplayId;
        public readonly string DisplayName;
        public readonly string Class;
        public readonly bool Static;
        public readonly bool OccupySquare;
        public readonly bool FullOccupy;
        public readonly bool EnemyOccupySquare;
        public readonly bool BlocksSight;
        public readonly bool Container;
        public readonly int[] SlotTypes;
        public readonly bool CanPutNormalObjects;
        public readonly bool CanPutSoulboundObjects;
        public readonly bool Loot;
        public readonly int Size;
        public readonly bool Enemy;
        public readonly int MaxHitPoints;
        public readonly int Defense;
        public readonly float XpMult;
        public readonly int MinSize;
        public readonly int MaxSize;
        public readonly int SizeStep;
        public readonly bool RandomSize;
        public readonly bool SpawnPoint;
        public readonly string Group;
        public readonly bool Quest;
        public readonly int Level;
        public readonly bool God;
        public readonly bool NoArticle;
        public readonly bool StasisImmune;
        public readonly bool StunImmune;
        public readonly bool Encounter;
        public readonly int PerRealmMax;
        public readonly bool Hero;
        public readonly bool Cube;
        public readonly bool Oryx;
        public readonly bool Player;
        public readonly bool KeepDamageRecord;

        public readonly TerrainType Terrain;
        public readonly float SpawnProb;
        public readonly SpawnCount Spawn;

        public ObjectDesc(ushort type, XElement e)
        {
            ObjectType = type;
            ObjectId = e.GetAttribute<string>("id");
            DisplayId = e.GetValue<string>("DisplayId");
            DisplayName = string.IsNullOrWhiteSpace(DisplayId) ? ObjectId : DisplayId;
            Class = e.GetValue<string>("Class");
            Static = e.HasElement("Static");
            OccupySquare = e.HasElement("OccupySquare");
            FullOccupy = e.HasElement("FullOccupy");
            EnemyOccupySquare = e.HasElement("EnemyOccupySquare");
            BlocksSight = e.HasElement("BlocksSight");
            Container = e.HasElement("Container");
            if (e.HasElement("SlotTypes"))
                SlotTypes = e.GetValue<string>("SlotTypes").CommaToArray<int>();
            CanPutNormalObjects = e.HasElement("CanPutNormalObjects");
            CanPutSoulboundObjects = e.HasElement("CanPutSoulboundObjects");
            Loot = e.HasElement("Loot");
            Size = e.GetValue<int>("Size", 100);
            Enemy = e.HasElement("Enemy");
            MaxHitPoints = e.GetValue<int>("MaxHitPoints");
            Defense = e.GetValue<int>("Defense");
            XpMult = e.GetValue<float>("XpMult", 1.0f);
            if (e.HasElement("MinSize") && e.HasElement("MaxSize"))
            {
                MinSize = e.GetValue<int>("MinSize");
                MaxSize = e.GetValue<int>("MaxSize");
                SizeStep = e.GetValue<int>("SizeStep", 1);
                RandomSize = true;
            }
            SpawnPoint = e.HasElement("SpawnPoint");
            Group = e.GetValue<string>("Group");
            Quest = e.HasElement("Quest");
            Level = e.GetValue<int>("Level");
            God = e.HasElement("God");
            NoArticle = e.HasElement("NoArticle");
            StasisImmune = e.HasElement("StasisImmune");
            StunImmune = e.HasElement("StunImmune");
            SpawnProb = e.GetValue<float>("SpawnProb");
            if (e.HasElement("Spawn"))
                Spawn = new SpawnCount(e.Element("Spawn"));
            Terrain = (TerrainType)Enum.Parse(typeof(TerrainType), e.GetValue<string>("Terrain", "None"));
            Encounter = e.HasElement("Encounter");
            PerRealmMax = e.GetValue<int>("PerRealmMax");
            Hero = e.HasElement("Hero");
            Cube = e.HasElement("Cube");
            Oryx = e.HasElement("Oryx");
            Player = e.HasElement("Player");
            KeepDamageRecord = e.HasElement("KeepDamageRecord");
        }
    }

    public class SpawnCount
    {
        public readonly int Mean;
        public readonly int StdDev;
        public readonly int Min;
        public readonly int Max;

        public SpawnCount(XElement e)
        {
            Mean = e.GetValue<int>("Mean");
            StdDev = e.GetValue<int>("StdDev");
            Min = e.GetValue<int>("Min");
            Max = e.GetValue<int>("Max");
        }
    }

    public class PortalDesc : ObjectDesc
    {
        public readonly string DungeonName;
        public readonly bool IntergamePortal;
        public readonly bool LockedPortal;

        public PortalDesc(ushort type, XElement e) : base(type, e)
        {
            DungeonName = e.GetValue<string>("DungeonName");
            IntergamePortal = e.HasElement("IntergamePortal");
            LockedPortal = e.HasElement("LockedPortal");
        }
    }

    public class PlayerDesc : ObjectDesc
    {
        public readonly ushort[] Equipment;
        public readonly Stat[] Stats;
        public readonly UnlockClass Unlock;

        public PlayerDesc(ushort type, XElement e) : base(type, e)
        {
            Equipment = e.GetValue<string>("Equipment").CommaToArray<ushort>();
            Stats = new Stat[8];
            for (var i = 0; i < Stats.Length; i++)
                Stats[i] = new Stat(i, e);
            if (e.HasElement("UnlockLevel") || e.HasElement("UnlockCost"))
                Unlock = new UnlockClass(e);
        }
    }

    public class Stat
    {
        public readonly string Type;
        public readonly int MaxValue;
        public readonly int StartingValue;
        public readonly int MinIncrease;
        public readonly int MaxIncrease;

        public Stat(int index, XElement e)
        {
            Type = StatIndexToName(index);
            var x = e.Element(Type);
            if (x != null)
            {
                StartingValue = int.Parse(x.Value);
                MaxValue = e.GetAttribute<int>("max");
            }

            var y = e.Elements("LevelIncrease");
            foreach (var k in y)
                if (k.Value == Type)
                {
                    MinIncrease = k.GetAttribute<int>("min");
                    MaxIncrease = k.GetAttribute<int>("max");
                    break;
                }
        }

        private static string StatIndexToName(int index)
        {
            switch (index)
            {
                case 0: return "MaxHitPoints";
                case 1: return "MaxMagicPoints";
                case 2: return "Attack";
                case 3: return "Defense";
                case 4: return "Speed";
                case 5: return "Dexterity";
                case 6: return "HpRegen";
                case 7: return "MpRegen";
            }
            return null;
        }
    }

    public class UnlockClass
    {
        public readonly ushort? Type;
        public readonly ushort? Level;
        public readonly uint? Cost;

        public UnlockClass(XElement e)
        {
            var n = e.Element("UnlockLevel");
            if(n != null && n.HasAttribute("type") && n.HasAttribute("level"))
            {
                Type = n.GetAttribute<ushort>("type");
                Level = n.GetAttribute<ushort>("level");
            }

            n = e.Element("UnlockCost");
            if (n != null)
            {
                Cost = (uint)int.Parse(n.Value);
            }
        }
    }

    public class SkinDesc
    {
        public readonly ushort ObjectType;
        public readonly string ObjectId;
        public readonly ushort ClassType;
        public readonly int UnlockLevel;

        public SkinDesc(ushort type, XElement e)
        {
            ObjectType = type;
            ObjectId = e.GetAttribute<string>("id");
            ClassType = e.GetValue<ushort>("PlayerClassType");
            UnlockLevel = e.GetValue<int>("UnlockLevel");
        }
    }

    public class Item
    {
        public readonly ushort Type;
        public readonly string Id;
        public readonly string Class;
        public readonly string DisplayId;
        public readonly string DisplayName;
        public readonly int Tex1;
        public readonly int Tex2;
        public readonly int SlotType;
        public readonly string Description;
        public readonly bool Consumable;
        public readonly bool Soulbound;
        public readonly bool Potion;
        public readonly bool Usable;
        public readonly bool Resurrects;
        public readonly float RateOfFire;
        public readonly int? Tier;
        public readonly int BagType;
        public readonly int FameBonus;
        public readonly int NumProjectiles;
        public readonly float ArcGap;
        public readonly int MpCost;
        public readonly float Cooldown;
        public readonly int Doses;
        public readonly string SuccessorId;
        public readonly bool Backpack;

        public readonly KeyValuePair<int, int>[] StatsBoost;
        public readonly ActivateEffect[] ActivateEffects;
        public readonly ProjectileDesc[] Projectiles;

        public Item(ushort type, XElement e)
        {
            Type = type;
            Id = e.GetAttribute<string>("id");
            Class = e.GetValue<string>("Class");
            DisplayId = e.GetValue<string>("DisplayId");
            DisplayName = string.IsNullOrWhiteSpace(DisplayId) ? Id : DisplayId;
            Tex1 = e.GetValue<int>("Tex1");
            Tex2 = e.GetValue<int>("Tex2");
            SlotType = e.GetValue<int>("SlotType");
            Description = e.GetValue<string>("Description");
            Consumable = e.HasElement("Consumable");
            Soulbound = e.HasElement("Soulbound");
            Potion = e.HasElement("Potion");
            Usable = e.HasElement("Usable");
            Resurrects = e.HasElement("Resurrects");
            RateOfFire = e.GetValue<float>("RateOfFire");
            if (e.HasElement("Tier"))
                Tier = e.GetValue<int>("Tier");
            BagType = e.GetValue<int>("BagType");
            FameBonus = e.GetValue<int>("FameBonus");
            NumProjectiles = e.GetValue<int>("NumProjectiles");
            ArcGap = e.GetValue<float>("ArcGap");
            MpCost = e.GetValue<int>("MpCost");
            Cooldown = e.GetValue<float>("Cooldown", 0.5f);
            Doses = e.GetValue<int>("Doses");
            SuccessorId = e.GetValue<string>("SuccessorId");
            Backpack = e.HasElement("Backpack");

            var stats = new List<KeyValuePair<int, int>>();
            foreach (XElement i in e.Elements("ActivateOnEquip"))
                stats.Add(new KeyValuePair<int, int>(
                    i.GetAttribute<int>("stat"),
                    i.GetAttribute<int>("amount")));
            StatsBoost = stats.ToArray();

            var activate = new List<ActivateEffect>();
            foreach (var i in e.Elements("Activate"))
                activate.Add(new ActivateEffect(i));
            ActivateEffects = activate.ToArray();

            var projs = new List<ProjectileDesc>();
            foreach (var i in e.Elements("Projectile"))
                projs.Add(new ProjectileDesc(i));
            Projectiles = projs.ToArray();
        }
    }

    public class ProjectileDesc
    {
        public readonly float Speed;
        public readonly int MinDamage;
        public readonly int MaxDamage;
        public readonly float LifetimeMs;
        public readonly bool MultiHit;
        public readonly bool PassesCover;
        public readonly bool Parametric;
        public readonly bool Boomerang;
        public readonly bool ArmorPiercing;
        public readonly bool Wavy;

        public readonly ConditionEffect[] Effects;

        public readonly float Amplitude;
        public readonly float Frequency;
        public readonly float Magnitude;

        public ProjectileDesc(XElement e)
        {
            LifetimeMs = e.GetValue<float>("LifetimeMS");
            Speed = e.GetValue<float>("Speed", 100);

            var dmg = e.Element("Damage");
            if (dmg != null)
                MinDamage = MaxDamage = e.GetValue<int>("Damage");
            else
            {
                MinDamage = e.GetValue<int>("MinDamage");
                MaxDamage = e.GetValue<int>("MaxDamage");
            }

            List<ConditionEffect> effects = new List<ConditionEffect>();
            foreach (var i in e.Elements("ConditionEffect"))
                effects.Add(new ConditionEffect(i));
            Effects = effects.ToArray();

            MultiHit = e.HasElement("MultiHit");
            PassesCover = e.HasElement("PassesCover");
            ArmorPiercing = e.HasElement("ArmorPiercing");
            Wavy = e.HasElement("Wavy");
            Parametric = e.HasElement("Parametric");
            Boomerang = e.HasElement("Boomerang");

            Amplitude = e.GetValue<float>("Amplitude", 0);
            Frequency = e.GetValue<float>("Frequency", 1);
            Magnitude = e.GetValue<float>("Magnitude", 3);
        }
    }

    public class ConditionEffect
    {
        public readonly ConditionEffectIndex Effect;
        public readonly float Duration;

        public ConditionEffect(XElement e)
        {
            Effect = Utils.GetEffect(e.Value);
            Duration = e.GetAttribute<float>("duration");
        }
    }

    public class ActivateEffect
    {
        public readonly ActivateEffects Effect;
        public readonly ConditionEffectIndex? ConditionEffect;
        public readonly ConditionEffectIndex? CheckExistingEffect;

        public readonly int TotalDamage;
        public readonly float Radius;
        public readonly float CondDuration;
        public readonly float Duration;
        public readonly int Amount;
        public readonly float Range;
        public readonly float MaxDistance;
        public readonly string ObjectId;
        public readonly string Id;
        public readonly int MaxTargets;
        public readonly uint? Color;
        public readonly int Stat;
        public readonly float Cooldown;
        public readonly bool RemoveSelf;

        public ActivateEffect(XElement e)
        {
            Effect = (ActivateEffects)Enum.Parse(typeof(ActivateEffects), e.Value);

            if (e.HasAttribute("effect"))
                ConditionEffect = Utils.GetEffect(e.GetAttribute<string>("effect"));

            if (e.HasAttribute("condEffect"))
                ConditionEffect = Utils.GetEffect(e.GetAttribute<string>("condEffect"));

            if (e.HasAttribute("checkExistingEffect"))
                CheckExistingEffect = Utils.GetEffect(e.GetAttribute<string>("checkExistingEffect"));

            if (e.HasAttribute("color"))
            {
                Color = e.GetAttribute<uint>("color");
            }

            TotalDamage = e.GetAttribute<int>("totalDamage");
            Radius = e.GetAttribute<float>("radius");
            CondDuration = e.GetAttribute<float>("condDuration");
            Duration = e.GetAttribute<float>("duration");
            Amount = e.GetAttribute<int>("amount");
            Range = e.GetAttribute<float>("range");
            ObjectId = e.GetAttribute<string>("objectId");
            Id = e.GetAttribute<string>("id");
            MaxDistance = e.GetAttribute<float>("maxDistance");
            MaxTargets = e.GetAttribute<int>("maxTargets");
            Stat = e.GetAttribute<int>("stat");
            Cooldown = e.GetAttribute<float>("cooldown");
            RemoveSelf = e.GetAttribute<bool>("removeSelf");
        }
    }

    public class TileDesc
    {
        public readonly ushort ObjectType;
        public readonly string ObjectId;
        public readonly bool NoWalk;
        public readonly bool Damaging;
        public readonly int MinDamage;
        public readonly int MaxDamage;
        public readonly float Speed;
        public readonly bool Push;
        public readonly float PushX;
        public readonly float PushY;
        public readonly bool Sink;
        public readonly bool Sinking;

        public TileDesc(ushort type, XElement e)
        {
            ObjectType = type;
            ObjectId = e.GetAttribute<string>("id");
            NoWalk = e.HasElement("NoWalk");

            if (e.HasElement("MinDamage"))
            {
                MinDamage = e.GetValue<int>("MinDamage");
                Damaging = true;
            }

            if (e.HasElement("MaxDamage"))
            {
                MaxDamage = e.GetValue<int>("MaxDamage");
                Damaging = true;
            }

            Sink = e.HasElement("Sink");
            Sinking = e.HasElement("Sinking");

            Speed = e.GetValue<float>("Speed", 1.0f);
            Push = e.HasElement("Push");
            if (Push)
            {
                var anim = e.Element("Animate");
                if (anim.HasAttribute("dx"))
                    PushX = anim.GetAttribute<float>("dx");
                if (anim.HasAttribute("dy"))
                    PushY = anim.GetAttribute<float>("dy");
            }
        }
    }
}