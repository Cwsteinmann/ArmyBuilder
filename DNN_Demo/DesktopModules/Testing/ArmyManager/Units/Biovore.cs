﻿// <copyright file="Biovore.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Biovore : Unit
    {
        public Biovore()
        {
            this.Type = "Infantry";
            this.Name = "Biovore Brood";
            this.ServerID = 13;
            this.UnitType = "Heavy Support";
            this.InitialPoints = 40;
            this.InitialSize = 1;
            this.MaxSize = 3;
            this.CostPerUnit = 40;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 3 },
                { "BS", 3 },
                { "S", 4 },
                { "T", 4 },
                { "W", 3 },
                { "I", 2 },
                { "A", 2 },
                { "Ld", 6 },
                { "Sv", 4 }
            };
            this.SpecialRules = new List<string>
            {
                "Very Bulky",
                "Instinctive Behaviour (Hunt)",
            };
            this.InitialWargear = "Spore Mine Launcher";
            this.WargearUpgrades = new Dictionary<string, int> { { "Spore Mine Launcher", 0 } };
            this.CurrentSize = 1;
            this.CanUpgradeWargear = false;
            this.RulesUpgrades = new Dictionary<string, int>();
            this.SelectedRuleUpgrades = new List<string> { };
            this.SelectedWargearUpgrades = new Dictionary<string, int> { { "Spore Mine Launcher", 1 } };
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