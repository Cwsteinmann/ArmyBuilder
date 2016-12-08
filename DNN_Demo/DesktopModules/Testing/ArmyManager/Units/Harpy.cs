// <copyright file="Harpy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Harpy : Unit
    {
        public Harpy()
        {
            this.Type = "Flying Monstrous Creature";
            this.Name = "Harpy";
            this.ServerID = 10;
            this.UnitType = "Fast Attack";
            this.InitialPoints = 135;
            this.InitialSize = 1;
            this.MaxSize = 1;
            this.CostPerUnit = 135;
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
            this.InitialWargear = "Twin-linked Stranglethorn Cannon";
            this.SpecialRules = new List<string> { "Fearless", "Instinctive Behaviour (Hunt)", "Sonic Screech", "Spore Mine Cysts" };
            this.CanUpgradeWargear = true;
            this.WargearUpgrades = new Dictionary<string, int> { { "Twin-linked Stranglethorn Cannon", 0 }, { "Twin-linked Heavy Venom Cannon", 5 }, { "Stinger Salvo", 10 }, { "Cluster Spines", 15 } };
            this.RulesUpgrades = new Dictionary<string, int>
            {
                { "Toxin Sacs", 10 },
                { "Acid Blood", 15 },
                { "Adrenal Glands", 15 },
                { "Regeneration", 30 },
            };

            this.CurrentSize = 1;

            this.SelectedRuleUpgrades = new List<string> { };

            this.SelectedWargearUpgrades = new Dictionary<string, int> { { "Twin-linked Stranglethorn Cannon", 1 }, { "Twin-linked Heavy Venom Cannon", 0 }, { "Stinger Salvo", 0 }, { "Cluster Spines", 0 } };
        }

        public override void SetWargear(string weapon, int amount)
        {
            this.SelectedWargearUpgrades[weapon] = amount;
            this.UpdateWargear(weapon, amount);

        }

        public void UpdateWargear(string weapon, int amount)
        {
            var primaryCheck = this.SelectedWargearUpgrades["Twin-linked Stranglethorn Cannon"]
                               + this.SelectedWargearUpgrades["Twin-linked Heavy Venom Cannon"];
            var secondaryCheck = this.SelectedWargearUpgrades["Stinger Salvo"]
                                 + this.SelectedWargearUpgrades["Cluster Spines"];

            if (primaryCheck != 1)
            {
                this.SelectedWargearUpgrades["Twin-linked Stranglethorn Cannon"] = 0;
                this.SelectedWargearUpgrades["Twin-linked Heavy Venom Cannon"] = 0;
                if (weapon == "Twin-linked Heavy Venom Cannon" && amount != 0)
                {
                    this.SelectedWargearUpgrades[weapon] = 1;
                }
                else
                {
                    this.SelectedWargearUpgrades["Twin-linked Stranglethorn Cannon"] = 1;
                }
            }

            if ((weapon != "Stinger Salvo" && weapon != "Cluster Spines") || secondaryCheck == 1 || amount == 0)
            {
                return;
            }

            this.SelectedWargearUpgrades["Stinger Salvo"] = 0;
            this.SelectedWargearUpgrades["Cluster Spines"] = 0;
            this.SelectedWargearUpgrades[weapon] = 1;
        }
    }
}