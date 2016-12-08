// <copyright file="Venomthrope.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Venomthrope : Unit
    {
        public Venomthrope()
        {
            this.Type = "Infantry";
            this.Name = "Venomthrope Brood";
            this.ServerID = 6;
            this.UnitType = "Elites";
            this.InitialPoints = 45;
            this.InitialSize = 1;
            this.MaxSize = 3;
            this.CostPerUnit = 45;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 3 },
                { "BS", 3 },
                { "S", 4 },
                { "T", 4 },
                { "W", 2 },
                { "I", 3 },
                { "A", 2 },
                { "Ld", 6 },
                { "Sv", 5 }
            };
            this.SpecialRules = new List<string>
            {
                "Instinctive Behaviour (Lurk)",
                "Poisoned (2+)",
                "Shrouded",
                "Spore Cloud",
                "Very Bulky",
            };
            this.InitialWargear = "Lash Whips";
            this.WargearUpgrades = new Dictionary<string, int> { { "Lash Whips", 0 }, { "Toxic Miasma", 0 } };
            this.CurrentSize = 1;
            this.CanUpgradeWargear = false;
            this.RulesUpgrades = new Dictionary<string, int>();
            this.SelectedRuleUpgrades = new List<string> { };

            this.SelectedWargearUpgrades = new Dictionary<string, int> { { "Lash Whips", 0 }, { "Toxic Miasma", 0 } };
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