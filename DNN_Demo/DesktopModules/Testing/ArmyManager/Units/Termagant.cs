// <copyright file="Termagant.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Termagant Unit (Troop)
    /// </summary>
    public class Termagant : Unit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Termagant"/> class.
        /// </summary>
        public Termagant()
        {
            this.Type = "Infantry";
            this.Name = "Termagant";
            this.ServerID = 1;
            this.UnitType = "Troops";
            this.InitialPoints = 40;
            this.InitialSize = 10;
            this.MaxSize = 30;
            this.CostPerUnit = 4;
            this.Stats = new Dictionary<string, int>
            {
                { "WS", 3 },
                { "BS", 3 },
                { "S", 3 },
                { "T", 3 },
                { "W", 1 },
                { "I", 4 },
                { "A", 1 },
                { "Ld", 6 },
                { "Sv", 6 }
            };
            this.InitialWargear = "Fleshborer";
            this.SpecialRules = new List<string> { "Move Through Cover", "Instinctive Behaviour(Lurk)" };
            this.CanUpgradeWargear = true;
            this.WargearUpgrades = new Dictionary<string, int>
            {
                { "Fleshborer", 0 },
                { "Devourer", 4 },
                { "Spinefists", 0 },
                { "Spike Rifle", 0 },
                { "Strangleweb", 5 },
            };

            this.RulesUpgrades = new Dictionary<string, int> { { "Adrenal Glands", 2 }, { "Toxin Sacs", 2 } };

            this.CurrentSize = 10;

            this.SelectedRuleUpgrades = new List<string> { };

            this.SelectedWargearUpgrades = new Dictionary<string, int>
            {
                { "Fleshborer", 10 },
                { "Devourer", 0 },
                { "Spinefists", 0 },
                { "Spike Rifle", 0 },
                { "Strangleweb", 0 },
            };
    }

        /// <summary>
        /// Sets the selected wargear of the unit by weapon name and amount, and recalculates cost
        /// </summary>
        /// <param name="weapon">The key associated with the selected weapon upgrade</param>
        /// <param name="amount">the amount of that key that the unit contains</param>
        public new void SetWargear(string weapon, int amount)
        {
            this.SelectedWargearUpgrades.Add(weapon, amount);

            this.SelectedWargearUpgrades[this.InitialWargear] =
                this.CurrentSize - (from entry in this.SelectedWargearUpgrades
                                     where entry.Key != this.InitialWargear
                                     select entry.Value).Sum();
        }

        /// <summary>
        /// Sets the size of the unit
        /// </summary>
        /// <param name="size">user input for how many individuals the unit should have</param>
        public void SetUnits(int size)
        {
            if (size > this.MaxSize)
            {
                this.CurrentSize = this.MaxSize;
            }
            else if (size < this.InitialSize)
            {
                this.CurrentSize = this.InitialSize;
            }
            else
            {
                this.CurrentSize = size;
            }

            this.SelectedWargearUpgrades[this.InitialWargear] =
                this.CurrentSize - (from entry in this.SelectedWargearUpgrades
                                     where entry.Key != this.InitialWargear
                                     select entry.Value).Sum();
        }
    }
}