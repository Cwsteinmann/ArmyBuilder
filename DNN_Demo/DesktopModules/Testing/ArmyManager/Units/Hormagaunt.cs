// <copyright file="Hormagaunt.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Hormagaunt : Unit
    {
        public Hormagaunt()
        {
            this.Type = "Infantry";
            this.Name = "Hormagaunt Brood";
            this.ServerID = 17;
            this.UnitType = "Troops";
            this.InitialPoints = 50;
            this.InitialSize = 10;
            this.MaxSize = 30;
            this.CostPerUnit = 5;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 3 },
                { "BS", 3 },
                { "S", 3 },
                { "T", 3 },
                { "W", 1 },
                { "I", 5 },
                { "A", 2 },
                { "Ld", 6 },
                { "Sv", 6 }
            };
            this.InitialWargear = "Scything Talons";
            this.SpecialRules = new List<string> { "Move Through Cover", "Instinctive Behaviour (Feed)", "Bounding Leap", "Fleet" };
            this.CanUpgradeWargear = false;
            this.WargearUpgrades = new Dictionary<string, int>
            {
                { "Scything Talons", 0 },
            };

            this.RulesUpgrades = new Dictionary<string, int> { { "Adrenal Glands", 2 }, { "Toxin Sacs", 3 } };

            this.CurrentSize = 10;

            this.SelectedRuleUpgrades = new List<string> { };

            this.SelectedWargearUpgrades = new Dictionary<string, int>
            {
                { "Scything Talons", 10 }
            };
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