// <copyright file="Haruspex.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Haruspex : Unit
    {
        public Haruspex()
        {
            this.Type = "Monstrous Creature";
            this.Name = "Haruspex";
            this.ServerID = 7;
            this.UnitType = "Elites";
            this.InitialPoints = 160;
            this.InitialSize = 1;
            this.MaxSize = 1;
            this.CostPerUnit = 160;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 3 },
                { "BS", 3 },
                { "S", 6 },
                { "T", 6 },
                { "W", 5 },
                { "I", 3 },
                { "A", 3 },
                { "Ld", 7 },
                { "Sv", 3 }
            };
            this.InitialWargear = "Crushing Claws";
            this.SpecialRules = new List<string> { "Fearless", "Instinctive Behaviour (Feed)", "Feeder-Beast", "Rapacious Hunger", "Grasping Tongue", "Acid Blood" };
            this.WargearUpgrades = new Dictionary<string, int> { };
            this.CanUpgradeWargear = false;
            this.RulesUpgrades = new Dictionary<string, int>
            {
                { "Toxin Sacs", 10 },
                { "Acid Blood", 15 },
                { "Adrenal Glands", 15 },
                { "Regeneration", 30 },
                { "Thresher Scythe", 10 }
            };

            this.CurrentSize = 1;

            this.SelectedRuleUpgrades = new List<string> { };

            this.SelectedWargearUpgrades = new Dictionary<string, int> { };
        }
    }
}