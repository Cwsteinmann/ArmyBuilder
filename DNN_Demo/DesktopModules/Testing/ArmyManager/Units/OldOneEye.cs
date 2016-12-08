// <copyright file="OldOneEye.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class OldOneEye : Unit
    {
        public OldOneEye()
        {
            this.Type = "Infantry";
            this.Name = "Old One Eye";
            this.ServerID = 16;
            this.UnitType = "HQ";
            this.InitialPoints = 220;
            this.InitialSize = 1;
            this.MaxSize = 1;
            this.CostPerUnit = 220;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 3},
                { "BS", 3 },
                { "S", 10 },
                { "T", 6 },
                { "W", 4 },
                { "I", 2 },
                { "A", 4 },
                { "Ld", 8 },
                { "Sv", 3 }
            };
            this.SpecialRules = new List<string>
            {
                "Adaptive Biology",
                "Alpha Leader",
                "Berserk Rampage",
                "Fearless",
                "Instinctive Behaviour (Feed)",
                "Living Battering Ram",
                "Regeneration",
                "Thresher Scythe"
            };
            this.InitialWargear = "Crushing Claws";
            this.WargearUpgrades = new Dictionary<string, int> { { "Crushing Claws", 0 }, { "Scything Talons", 0 }, };
            this.CurrentSize = 1;
            this.CanUpgradeWargear = false;
            this.RulesUpgrades = new Dictionary<string, int>();
            this.SelectedRuleUpgrades = new List<string> { };

            this.SelectedWargearUpgrades = new Dictionary<string, int> { { "Crushing Claws", 1 }, { "Scything Talons", 1 }, };
        }
    }
}