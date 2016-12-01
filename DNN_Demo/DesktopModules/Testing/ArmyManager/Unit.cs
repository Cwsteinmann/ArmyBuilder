namespace Testing.Dnn.ArmyManager.ArmyManager
{
    using System.Collections.Generic;
    using System.Linq;

    public class Unit
    {

        /// <summary>
        /// Gets or sets the Unit ID to be set by the server
        /// </summary>
        public int UnitID { get; set; }

        /// <summary>
        /// Gets or sets the type of the unit (Eg. Infantry, Beasts, etc)
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
        public int CurrentSize { get; set; }

        /// <summary>
        /// Gets or sets the list of the upgrades that have actually been selected
        /// </summary>
        public List<string> SelectedRuleUpgrades { get; set; }

        /// <summary>
        /// Gets or sets the list of wargear upgrades selected, in wargear / amount format
        /// </summary>
        public Dictionary<string, int> SelectedWargearUpgrades { get; set; }

        /// <summary>
        /// Gets or sets total calculated cost of the unit
        /// </summary>
        public int TotalCost { get; set; }

        /// <summary>
        /// calculate total cost of the unit - by size, selected wargear upgrades, and selected rule upgrades
        /// </summary>
        public void SetTotalCost()
        {
            var cost = 0;
            cost += this.CurrentSize * this.CostPerUnit;
            cost += this.GetUpgradePrice();
            cost += this.GetWargearPrice();
            this.TotalCost = cost;
        }

        /// <summary>
        /// gets the cost associated with wargear upgrades for the unit
        /// </summary>
        /// <returns>cost of the wargear</returns>
        public int GetWargearPrice()
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
        public int GetUpgradePrice()
        {
            var cost = (from upgrade in this.SelectedRuleUpgrades
                        from entry in this.RulesUpgrades
                        where upgrade == entry.Key
                        select entry.Value * this.CurrentSize).Sum();

            return cost;
        }

        /// <summary>
        /// Sets the size of the unit, recalculates unit total cost
        /// </summary>
        /// <param name="size">user input for unit size</param>
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

            this.SetTotalCost();
        }

        /// <summary>
        /// Adds or removes rule upgrades to the unit, recalculates unit total cost
        /// </summary>
        /// <param name="upgradeKey">Key associated with an upgrade</param>
        public void SetUpgrade(string upgradeKey)
        {
            var adding = true;
            foreach (var key in this.SelectedRuleUpgrades)
            {
                if (key == upgradeKey)
                {
                    adding = false;
                }
            }

            if (adding)
            {
                this.SelectedRuleUpgrades.Add(upgradeKey);
            }
            else
            {
                this.SelectedRuleUpgrades.Remove(upgradeKey);
            }

            this.SetTotalCost();
        }
    }
}