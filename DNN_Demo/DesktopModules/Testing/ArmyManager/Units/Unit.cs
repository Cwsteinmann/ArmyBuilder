﻿// <copyright file="Unit.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The base unit class to be extended towards specific individuals
    /// </summary>
    public class Unit
    {
        /// <summary>The current size</summary>
        private int currentSize;

        /// <summary>Initializes a new instance of the <see cref="Unit"/> class.</summary>
        public Unit()
        {
        }

        /// <summary>
        /// Gets or sets the Unit ID to be set by the server
        /// </summary>
        public int UnitID { get; set; }

        /// <summary>
        /// Gets or sets the ID the server uses in place of unit name
        /// </summary>
        public int ServerID { get; set; }

        /// <summary>
        /// Gets or sets the type of the unit
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the unit title
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Unit type (Eg. Troop, HQ, etc)
        /// </summary>
        public string UnitType { get; set; }

        /// <summary>
        /// Gets or sets the initial points cost of the unit on initialization
        /// </summary>
        public int InitialPoints { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance can upgrade wargear.</summary>
        /// <value>
        /// <c>true</c> if this instance can upgrade wargear; otherwise, <c>false</c>.
        /// </value>
        public bool CanUpgradeWargear { get; set; }

        /// <summary>
        /// Gets or sets the initial size of the unit on initialization
        /// </summary>
        public int InitialSize { get; set; }

        /// <summary>
        /// Gets or sets the maximum size the unit can be
        /// </summary>
        public int MaxSize { get; set; }

        /// <summary>
        /// Gets or sets cost associated with each individual in the unit
        /// </summary>
        public int CostPerUnit { get; set; }

        /// <summary>
        /// Gets or sets list of the stats associated with the unit
        /// </summary>
        public Dictionary<string, int> Stats { get; set; }

        /// <summary>
        /// Gets or sets list of special rules the unit has on initialization
        /// </summary>
        public List<string> SpecialRules { get; set; }

        /// <summary>
        /// Gets or sets list of wargear the unit has on initialization
        /// </summary>
        public string InitialWargear { get; set; }

        /// <summary>Gets or sets the initial wargear second arms.</summary>
        /// <value>The initial wargear second arms.</value>
        public string InitialWargearSecondArms { get; set; }

        /// <summary>
        /// Gets or sets potential wargear upgrades the unit has access to, in Name / Cost per Individual format
        /// </summary>
        public Dictionary<string, int> WargearUpgrades { get; set; }

        /// <summary>
        /// Gets or sets the rules upgrades the unit has access to, in Name / Cost per individual format
        /// </summary>
        public Dictionary<string, int> RulesUpgrades { get; set; }

        /// <summary>
        /// Gets or sets the current size of the unit
        /// </summary>
        public int CurrentSize
        {
            get
            {
                return this.currentSize;
            }

            set
            {
                if (value > this.MaxSize)
                {
                    this.currentSize = this.MaxSize;
                }
                else if (value < this.InitialSize)
                {
                    this.currentSize = this.InitialSize;
                }
                else
                {
                    this.currentSize = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the list of the upgrades that have actually been selected
        /// </summary>
        public List<string> SelectedRuleUpgrades { get; set; }

        /// <summary>
        /// Gets or sets the list of Wargear upgrades selected, in Wargear / amount format
        /// </summary>
        public Dictionary<string, int> SelectedWargearUpgrades { get; set; }

        /// <summary>
        /// Gets total calculated cost of the unit
        /// </summary>
        public int TotalCost
        {
            get
            {
                var cost = 0;
                cost += this.CurrentSize * this.CostPerUnit;
                cost += this.GetUpgradePrice();
                cost += this.GetWargearPrice();
                return cost;
            }
        }

        /// <summary>Sets the wargear.</summary>
        /// <param name="weapon">The weapon.</param>
        /// <param name="amount">The amount.</param>
        public virtual void SetWargear(string weapon, int amount)
        {
            this.SelectedWargearUpgrades[weapon] = amount;

            this.UpdateWargear();
        }

        /// <summary>Updates the wargear.</summary>
        public virtual void UpdateWargear()
        {
            this.SelectedWargearUpgrades[this.InitialWargear] =
                this.CurrentSize - (from entry in this.SelectedWargearUpgrades
                                    where entry.Key != this.InitialWargear
                                    select entry.Value).Sum();
        }

        /// <summary>
        /// Adds or removes rule upgrades to the unit, recalculates unit total cost
        /// </summary>
        /// <param name="upgradeKey">Key associated with an upgrade</param>
        public virtual void SetUpgrade(string upgradeKey)
        {
            var adding = !this.SelectedRuleUpgrades.Contains(upgradeKey);

            if (adding)
            {
                this.SelectedRuleUpgrades.Add(upgradeKey);
            }
            else
            {
                this.SelectedRuleUpgrades.Remove(upgradeKey);
            }
        }

        /// <summary>
        /// gets the cost associated with wargear upgrades for the unit
        /// </summary>
        /// <returns>cost of the wargear</returns>
        private int GetWargearPrice()
        {
            var cost = (from selected in this.SelectedWargearUpgrades
                        from wargear in this.WargearUpgrades
                        where selected.Key == wargear.Key
                        select selected.Value * wargear.Value).Sum();

            return cost;
        }

        /// <summary>
        /// gets the cost associated with the rule ugprades for the unit
        /// </summary>
        /// <returns>cost of the rule upgrades</returns>
        private int GetUpgradePrice()
        {
            var cost = (from upgrade in this.SelectedRuleUpgrades
                        from entry in this.RulesUpgrades
                        where upgrade == entry.Key
                        select entry.Value * this.CurrentSize).Sum();

            return cost;
        }
    }
}