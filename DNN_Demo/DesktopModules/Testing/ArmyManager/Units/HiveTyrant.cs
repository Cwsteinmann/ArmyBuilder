// <copyright file="HiveTyrant.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Engage.Annotations;

    public class HiveTyrant : Unit
    {
        public HiveTyrant()
        {
            this.Type = "Monstrous Creature";
            this.Name = "Hive Tyrant";
            this.ServerID = 2;
            this.UnitType = "HQ";
            this.InitialPoints = 165;
            this.InitialSize = 1;
            this.MaxSize = 1;
            this.CostPerUnit = 165;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 8 },
                { "BS", 4 },
                { "S", 6 },
                { "T", 6 },
                { "W", 4 },
                { "I", 5 },
                { "A", 4 },
                { "Ld", 10 },
                { "Sv", 3 }
            };
            this.InitialWargear = "Scything Talons";
            this.InitialWargearSecondArms = "Scything Talons";
            this.SpecialRules = new List<string> { "Psyker (Mastery Level 2)", "Shadow in the Warp", "Synapse Creature" };
            this.CanUpgradeWargear = true;
            this.WargearUpgrades = new Dictionary<string, int>
            {
                { "Scything Talons", 0 },
                { "Rending Claws", 5 },
                { "Boneswords", 15 },
                { "Lash Whip and Bonesword", 20 },
                { "Twin-linked Devourer with Brainleech Worms", 15 },
                { "Twin-linked Deathspitter", 5 },
                { "Stranglethorn Cannon", 15 },
                { "Heavy Venom Cannon", 20 },
                { "The Maw-claws of Thyrax", 10 },
                { "The Miasma Cannon", 25 },
                { "The Reaper of Obliterax", 45 },
                { "Electroshock Grubs", 10 },
                { "Dessicator Larvae", 10 },
                { "Shreddershard Beetles", 10 }
            };

            this.RulesUpgrades = new Dictionary<string, int>
            {
                { "Wings", 35 },
                { "Prehensile Pincer", 10 },
                { "Indescribable Horror", 10 },
                { "Old Adversary", 15 },
                { "Hive Commander", 20 },
                { "Toxin Sacs", 10 },
                { "Acid Blood", 15 },
                { "Adrenal Glands", 15 },
                { "Regeneration", 30 }
            };

            this.CurrentSize = 1;

            this.SelectedRuleUpgrades = new List<string> { };

            this.SelectedWargearUpgrades = new Dictionary<string, int>
            {
                { "Scything Talons", 2 },
                { "Rending Claws", 0 },
                { "Boneswords", 0 },
                { "Lash Whip and Bonesword", 0 },
                { "Twin-linked Devourer with Brainleech Worms", 0 },
                { "Twin-linked Deathspitter", 0 },
                { "Stranglethorn Cannon", 0 },
                { "Heavy Venom Cannon", 0 },
                { "The Maw-claws of Thyrax", 0 },
                { "The Miasma Cannon", 0 },
                { "The Reaper of Obliterax", 0 },
                { "Electroshock Grubs", 0 },
                { "Dessicator Larvae", 0 },
                { "Shreddershard Beetles", 0 }
            };
        }

        public override void SetWargear(string weapon, int amount)
        {
            this.SelectedWargearUpgrades["Scything Talons"] = 0;
            this.SelectedWargearUpgrades[weapon] = amount;
            this.UpdateWargear(weapon);

        }

        public void UpdateWargear(string weapon)
        {
            var thoraxUpgrades = new List<string> { "Electroshock Grubs", "Dessicator Larvae", "Shreddershard Beetles" };
            var wargearUpgrades = this.WargearUpgrades.Keys.ToList();
            foreach (var upgrade in thoraxUpgrades)
            {
                wargearUpgrades.Remove(upgrade);
            }

            var sumWargear = wargearUpgrades.Sum(upgrade => this.SelectedWargearUpgrades[upgrade]);
            if (sumWargear > 2)
            {
                foreach (var upgrade in wargearUpgrades)
                {
                    this.SelectedWargearUpgrades[upgrade] = 0;
                }

                this.SelectedWargearUpgrades["Scything Talons"] = 2;
            }
            else
            {
                this.SelectedWargearUpgrades["Scything Talons"] += 2 - sumWargear;
            }

            if (weapon != "Electroshock Grubs" && weapon != "Dessicator Larvae" && weapon != "Shreddershard Beetles")
            {
                return;
            }

            var sumThorax = thoraxUpgrades.Sum(upgrade => this.SelectedWargearUpgrades[upgrade]);
            if (sumThorax > 1)
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