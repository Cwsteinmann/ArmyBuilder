// <copyright file="Gargoyle.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Gargoyle : Unit
    {
        public Gargoyle()
        {
            this.Type = "Jump Infantry";
            this.Name = "Gargoyle Brood";
            this.ServerID = 9;
            this.UnitType = "Fast Attack";
            this.InitialPoints = 60;
            this.InitialSize = 10;
            this.MaxSize = 30;
            this.CostPerUnit = 6;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 3 },
                { "BS", 3 },
                { "S", 3 },
                { "T", 3 },
                { "W", 1 },
                { "I", 4 },
                { "A", 1 },
                { "Ld", 6 },
                { "Sv", 6 }
            };
            this.SpecialRules = new List<string>
            {
                "Instinctive Behaviour (Hunt)",
                "Blinding Venom",
            };
            this.InitialWargear = "Fleshborer";
            this.WargearUpgrades = new Dictionary<string, int> { { "Fleshborer", 0 } };
            this.CurrentSize = 10;
            this.CanUpgradeWargear = false;
            this.RulesUpgrades = new Dictionary<string, int> { { "Adrenal Glands", 2 }, { "Toxin Sacs", 2 } };
            this.SelectedRuleUpgrades = new List<string> { };
            this.CanUpgradeWargear = false;
            this.SelectedWargearUpgrades = new Dictionary<string, int> { { "Fleshborer", 10 } };
        }

        public override void SetWargear(string weapon, int amount)
        {
            foreach (var wargear in this.SelectedWargearUpgrades.Keys.ToArray())
            {
                this.SelectedWargearUpgrades[wargear] = this.CurrentSize;
            }
        }
    }
}