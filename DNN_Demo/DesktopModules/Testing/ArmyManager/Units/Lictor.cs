// <copyright file="Lictor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Lictor : Unit
    {
        public Lictor()
        {
            this.Type = "Infantry";
            this.Name = "Lictor Brood";
            this.ServerID = 4;
            this.UnitType = "Elites";
            this.InitialPoints = 50;
            this.InitialSize = 1;
            this.MaxSize = 3;
            this.CostPerUnit = 50;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 6 },
                { "BS", 3 },
                { "S", 6 },
                { "T", 4 },
                { "W", 3 },
                { "I", 6 },
                { "A", 3 },
                { "Ld", 10 },
                { "Sv", 5 }
            };
            this.SpecialRules = new List<string>
            {
                "Very Bulky",
                "Instinctive Behaviour (Lurk)",
                "Chameleonic Skin",
                "Deep Strike",
                "Fear",
                "Fleet",
                "Hit & Run",
                "Infiltrate",
                "Move Through Cover",
                "Pheromone Trail",
                "Stealth",
                "Flesh Hooks"
            };
            this.InitialWargear = "Rending Claws";
            this.WargearUpgrades = new Dictionary<string, int> { { "Rending Claws", 0 }, { "Scything Talons", 0 }, };
            this.CurrentSize = 1;
            this.CanUpgradeWargear = false;
            this.RulesUpgrades = new Dictionary<string, int>();
            this.SelectedRuleUpgrades = new List<string> { };

            this.SelectedWargearUpgrades = new Dictionary<string, int> { { "Rending Claws", 1 }, { "Scything Talons", 1 }, };
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