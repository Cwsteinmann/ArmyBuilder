// <copyright file="RipperSwarm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class RipperSwarm : Unit
    {
        public RipperSwarm()
        {
            this.Type = "Infantry";
            this.Name = "Ripper Swarm Brood";
            this.ServerID = 18;
            this.UnitType = "Troops";
            this.InitialPoints = 39;
            this.InitialSize = 3;
            this.MaxSize = 9;
            this.CostPerUnit = 13;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 2 },
                { "BS", 2 },
                { "S", 3 },
                { "T", 3 },
                { "W", 3 },
                { "I", 2 },
                { "A", 4 },
                { "Ld", 5 },
                { "Sv", 6 }
            };
            this.InitialWargear = string.Empty;
            this.SpecialRules = new List<string> { "Fearless", "Instinctive Behaviour (Feed)", "Swarms" };
            this.CanUpgradeWargear = true;
            this.WargearUpgrades = new Dictionary<string, int>
            {
                { "Spinefists", 4 },
            };

            this.RulesUpgrades = new Dictionary<string, int> { { "Adrenal Glands", 4 }, { "Toxin Sacs", 6 } };

            this.CurrentSize = 3;

            this.SelectedRuleUpgrades = new List<string> { };

            this.SelectedWargearUpgrades = new Dictionary<string, int>
            {
                { "Spinefists", 0 }
            };
        }

        public override void SetWargear(string weapon, int amount)
        {
            if (amount > 0)
            {
                this.SelectedWargearUpgrades[weapon] = this.CurrentSize;
            }
        }
    }
}