// <copyright file="SporeMine.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class SporeMine : Unit
    {
        public SporeMine()
        {
            this.Type = "Infantry";
            this.Name = "Spore Mine Cluster";
            this.ServerID = 12;
            this.UnitType = "Fast Attack";
            this.InitialPoints = 15;
            this.InitialSize = 3;
            this.MaxSize = 6;
            this.CostPerUnit = 5;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 0 },
                { "BS", 0 },
                { "S", 1 },
                { "T", 1 },
                { "W", 1 },
                { "I", 1 },
                { "A", 0 },
                { "Ld", 1 },
                { "Sv", 0 }
            };
            this.SpecialRules = new List<string>
            {
                "Deep Strike",
                "Fearless",
                "Floating Death",
                "Living Bomb"
            };
            this.InitialWargear = string.Empty;
            this.WargearUpgrades = new Dictionary<string, int> { };
            this.CurrentSize = 3;
            this.CanUpgradeWargear = false;
            this.RulesUpgrades = new Dictionary<string, int>();
            this.SelectedRuleUpgrades = new List<string> { };
            this.SelectedWargearUpgrades = new Dictionary<string, int> { };
        }
    }
}