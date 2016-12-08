// <copyright file="Zoanthrope.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Zoanthrope : Unit
    {
        public Zoanthrope()
        {
            this.Type = "Infantry";
            this.Name = "Zoanthrope Brood";
            this.ServerID = 5;
            this.UnitType = "Elites";
            this.InitialPoints = 50;
            this.InitialSize = 1;
            this.MaxSize = 3;
            this.CostPerUnit = 50;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 3 },
                { "BS", 4 },
                { "S", 4 },
                { "T", 4 },
                { "W", 2 },
                { "I", 3 },
                { "A", 1 },
                { "Ld", 10 },
                { "Sv", 5 }
            };
            this.SpecialRules = new List<string>
            {
                "Brotherhood of Psykers",
                "Psychic Brood",
                "Shadow in the Warp",
                "Synapse Creature",
                "Very Bulky",
                "Warp Field",
            };
            this.InitialWargear = string.Empty;
            this.WargearUpgrades = new Dictionary<string, int> { };
            this.CurrentSize = 1;
            this.CanUpgradeWargear = false;
            this.RulesUpgrades = new Dictionary<string, int>();
            this.SelectedRuleUpgrades = new List<string> { };

            this.SelectedWargearUpgrades = new Dictionary<string, int> { };
        }
    }
}