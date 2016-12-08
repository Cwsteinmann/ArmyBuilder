// <copyright file="HiveCrone.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class HiveCrone : Unit
    {
        public HiveCrone()
        {
            this.Type = "Flying Monstrous Creature";
            this.Name = "Hive Crone";
            this.ServerID = 11;
            this.UnitType = "Fast Attack";
            this.InitialPoints = 155;
            this.InitialSize = 1;
            this.MaxSize = 1;
            this.CostPerUnit = 155;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 3 },
                { "BS", 3 },
                { "S", 5 },
                { "T", 5 },
                { "W", 5 },
                { "I", 5 },
                { "A", 3 },
                { "Ld", 10 },
                { "Sv", 4 }
            };
            this.InitialWargear = "Drool Cannon";
            this.SpecialRules = new List<string> { "Fearless", "Instinctive Behaviour (Feed)", "Raking Strike" };
            this.CanUpgradeWargear = true;
            this.WargearUpgrades = new Dictionary<string, int> { { "Stinger Salvo", 10 }, { "Cluster Spines", 15 } };
            this.RulesUpgrades = new Dictionary<string, int>
            {
                { "Toxin Sacs", 10 },
                { "Acid Blood", 15 },
                { "Adrenal Glands", 15 },
                { "Regeneration", 30 },
            };

            this.CurrentSize = 1;

            this.SelectedRuleUpgrades = new List<string> { };

            this.SelectedWargearUpgrades = new Dictionary<string, int> { { "Drool Cannon", 1 }, { "Tentaclids", 4 }, { "Scything Talons", 1 }, { "Stinger Salvo", 0 }, { "Cluster Spines", 0 } };
        }

        public override void SetWargear(string weapon, int amount)
        {
            this.SelectedWargearUpgrades[weapon] = amount;
            this.UpdateWargear(weapon, amount);

        }

        public void UpdateWargear(string weapon, int amount)
        {
            var secondaryCheck = this.SelectedWargearUpgrades["Stinger Salvo"]
                                 + this.SelectedWargearUpgrades["Cluster Spines"];

            if ( secondaryCheck == 1 || amount == 0)
            {
                return;
            }

            this.SelectedWargearUpgrades["Stinger Salvo"] = 0;
            this.SelectedWargearUpgrades["Cluster Spines"] = 0;
            this.SelectedWargearUpgrades[weapon] = 1;
        }
    }
}