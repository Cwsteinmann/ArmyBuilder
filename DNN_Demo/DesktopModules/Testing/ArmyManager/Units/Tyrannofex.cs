// <copyright file="Tyrannofex.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Tyrannofex : Unit
    {
        public Tyrannofex()
        {
            this.Type = "Monstrous Creature";
            this.Name = "Tyrannofex";
            this.ServerID = 14;
            this.UnitType = "Heavy Support";
            this.InitialPoints = 175;
            this.InitialSize = 1;
            this.MaxSize = 1;
            this.CostPerUnit = 175;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 3 },
                { "BS", 3 },
                { "S", 6 },
                { "T", 6 },
                { "W", 6 },
                { "I", 2 },
                { "A", 3 },
                { "Ld", 8 },
                { "Sv", 2 }
            };
            this.InitialWargear = "Avid Spray";
            this.SpecialRules = new List<string> { "Fearless", "Instinctive Behaviour (Hunt)" };
            this.CanUpgradeWargear = true;
            this.WargearUpgrades = new Dictionary<string, int>
            {
                { "Acid Spray", 0 },
                { "Fleshborer Hive", 5 },
                { "Rupture Cannon", 30 },
                { "Electroshock Grubs", 10 },
                { "Dessicator Larvae", 10 },
                { "Shreddershard Beetles", 10 }
            };

            this.RulesUpgrades = new Dictionary<string, int>
            {
                { "Toxin Sacs", 10 },
                { "Acid Blood", 15 },
                { "Adrenal Glands", 15 },
                { "Regeneration", 30 }
            };

            this.CurrentSize = 1;

            this.SelectedRuleUpgrades = new List<string> { };

            this.SelectedWargearUpgrades = new Dictionary<string, int>
            {
                { "Acid Spray", 1 },
                { "Stinger Salvo", 1 },
                { "Fleshborer Hive", 0 },
                { "Rupture Cannon", 0 },
                { "Electroshock Grubs", 0 },
                { "Dessicator Larvae", 0 },
                { "Shreddershard Beetles", 0 }
            };
        }

        public override void SetWargear(string weapon, int amount)
        {
            this.SelectedWargearUpgrades[weapon] = amount;
            this.UpdateWargear(weapon);

        }

        public void UpdateWargear(string weapon)
        {
            var thoraxUpgrades = new List<string> { "Electroshock Grubs", "Dessicator Larvae", "Shreddershard Beetles" };
            var primaryWeapon = new List<string> { "Acid Spray", "Fleshborer Hive", "Rupture Cannon" };

            var sumPrimary = primaryWeapon.Sum(upgrade => this.SelectedWargearUpgrades[upgrade]);
            var sumThorax = thoraxUpgrades.Sum(upgrade => this.SelectedWargearUpgrades[upgrade]);
            if (sumPrimary == 1 && sumThorax < 2)
            {
                return;
            }

            if (sumPrimary > 1)
            {
                foreach (var weapons in primaryWeapon)
                {
                    this.SelectedWargearUpgrades[weapons] = 0;
                }

                this.SelectedWargearUpgrades[weapon] = 1;
            }
            else if (sumThorax > 1)
            {
                foreach (var upgrade in thoraxUpgrades)
                {
                    this.SelectedWargearUpgrades[upgrade] = 0;
                }

                this.SelectedWargearUpgrades[weapon] = 1;
            }
        }
    }
}