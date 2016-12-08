// <copyright file="HiveGuard.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class HiveGuard : Unit
    {
        public HiveGuard()
        {
            this.Type = "Infantry";
            this.Name = "Hive Guard";
            this.ServerID = 3;
            this.UnitType = "Elites";
            this.InitialPoints = 55;
            this.InitialSize = 1;
            this.MaxSize = 3;
            this.CostPerUnit = 55;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 4 },
                { "BS", 3 },
                { "S", 5 },
                { "T", 6 },
                { "W", 2 },
                { "I", 2 },
                { "A", 2 },
                { "Ld", 7 },
                { "Sv", 4 }
            };
            this.InitialWargear = "Impaler Cannon";
            this.SpecialRules = new List<string> { "Very Bulky", "Instinctive Behaviour (Hunt)" };
            this.CanUpgradeWargear = true;
            this.WargearUpgrades = new Dictionary<string, int>
            {
                { "Impaler Cannon", 0 },
                { "Shock Cannon", 5 },
            };

            this.RulesUpgrades = new Dictionary<string, int>
            {
                { "Toxin Sacs", 3 },
                { "Adrenal Glands", 5 },
            };

            this.CurrentSize = 1;

            this.SelectedRuleUpgrades = new List<string> { };

            this.SelectedWargearUpgrades = new Dictionary<string, int>
            {
                { "Impaler Cannon", 1 },
                { "Shock Cannon", 0 },
            };
        }
    }
}