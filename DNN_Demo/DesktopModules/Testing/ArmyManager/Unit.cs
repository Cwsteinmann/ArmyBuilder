namespace Testing.Dnn.ArmyManager.ArmyManager
{
    using System.Collections.Generic;
    using System.Linq;

    public class Unit
    {
        /// <summary>
        /// The type of the unit (Eg. Infantry, Beasts, etc)
        /// </summary>
        public string Type;

        /// <summary>
        /// Unit title
        /// </summary>
        public string Name;

        /// <summary>
        /// Unit type (Eg. Troop, HQ, etc)
        /// </summary>
        public string UnitType;

        /// <summary>
        /// the initial points cost of the unit on initialization
        /// </summary>
        public int InitialPoints;

        /// <summary>
        /// the initial size of the unit on initialization
        /// </summary>
        public int InitialSize;

        /// <summary>
        /// Maximum size the unit can be
        /// </summary>
        public int MaxSize;

        /// <summary>
        /// cost associated with each individual in the unit
        /// </summary>
        public int CostPerUnit;

        /// <summary>
        /// List of the stats associated with the unit
        /// </summary>
        public Dictionary<string, int> Stats;

        /// <summary>
        /// List of special rules the unit has on initialization
        /// </summary>
        public List<string> SpecialRules;

        /// <summary>
        /// List of wargear the unit has on initialization
        /// </summary>
        public string InitialWargear;

        /// <summary>
        /// Potential wargear upgrades the unit has access to, in Name / Cost per Individual format
        /// </summary>
        public Dictionary<string, int> WargearUpgrades;

        /// <summary>
        /// Rules upgrades the unit has access to, in Name / Cost per individual format
        /// </summary>
        public Dictionary<string, int> RulesUpgrades;

        /// <summary>
        /// the current size of the unit
        /// </summary>
        public int CurrentSize;

        /// <summary>
        /// List of the upgrades that have actually been selected
        /// </summary>
        public List<string> SelectedRuleUpgrades;

        /// <summary>
        /// list of wargear upgrades selected, in wargear / amount format
        /// </summary>
        public Dictionary<string, int> SelectedWargearUpgrades;

        /// <summary>
        /// total calculated cost of the unit
        /// </summary>
        public int TotalCost;

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