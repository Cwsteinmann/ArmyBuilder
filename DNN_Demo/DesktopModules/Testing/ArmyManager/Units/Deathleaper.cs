// <copyright file="Deathleaper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Deathleaper : Unit
    {
        public Deathleaper()
        {
            this.Type = "Infantry";
            this.Name = "Deathleaper";
            this.ServerID = 15;
            this.UnitType = "HQ";
            this.InitialPoints = 130;
            this.InitialSize = 1;
            this.MaxSize = 1;
            this.CostPerUnit = 130;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 9},
                { "BS", 3 },
                { "S", 6 },
                { "T", 4 },
                { "W", 3 },
                { "I", 7 },
                { "A", 4 },
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
                "Flesh Hooks",
                "Mind Eater",
                "\'It\'s After Me!\'",
                "\'Where is it?\'",
            };
            this.InitialWargear = "Rending Claws";
            this.WargearUpgrades = new Dictionary<string, int> { { "Rending Claws", 0 }, { "Scything Talons", 0 }, };
            this.CurrentSize = 1;
            this.CanUpgradeWargear = false;
            this.RulesUpgrades = new Dictionary<string, int>();
            this.SelectedRuleUpgrades = new List<string> { };

            this.SelectedWargearUpgrades = new Dictionary<string, int> { { "Rending Claws", 1 }, { "Scything Talons", 1 }, };
        }
    }
}