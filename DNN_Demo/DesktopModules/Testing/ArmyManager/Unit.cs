namespace Testing.Dnn.ArmyManager.ArmyManager
{
    using System.Collections.Generic;
    using System.Linq;

    public class Unit
    {
        public int unitSquadType;

        public string name;

        public string unitType;

        public int initialPoints;

        public int initialSize;

        public int maxSize;

        public int costPerUnit;

        public int ws;

        public int bs;

        public int s;

        public int t;

        public int i;

        public int w;

        public int a;

        public int ld;

        public int sv;

        public List<string> specialRules;

        public string initialWargear;

        public Dictionary<string, int> wargearUpgrades;

        public Dictionary<string, int> rulesUpgrades;

        public int currentSize;

        public List<string> selectedRuleUpgrades;

        public Dictionary<string, int> selectedWargearUpgrades;

        public int totalCost;

        public void SetTotalCost()
        {
            var cost = 0;
            cost += (this.currentSize * this.costPerUnit);
            cost += this.GetUpgradePrice();
            cost += this.GetWargearPrice();
            this.totalCost = cost;
        }

        public int GetWargearPrice()
        {
            var cost = (from selected in this.selectedWargearUpgrades
                        from wargear in this.wargearUpgrades
                        where selected.Key == wargear.Key
                        select selected.Value * wargear.Value).Sum();

            return cost;
        }

        public int GetUpgradePrice()
        {
            var cost = (from upgrade in this.selectedRuleUpgrades
                        from entry in this.rulesUpgrades
                        where upgrade == entry.Key
                        select entry.Value * this.currentSize).Sum();

            return cost;
        }

        public void SetUnits(int size)
        {
            if (size > this.maxSize || size < this.initialSize)
            {
                //TODO: error message, perhaps?
            }
            else
            {
                this.currentSize = size;
            }
            this.SetTotalCost();
        }

        public void SetUpgrade(string upgradeKey)
        {
            bool adding = true;
            foreach (string key in this.selectedRuleUpgrades)
            {
                if (key == upgradeKey)
                {
                    adding = false;
                }
            }
            if (adding)
            {
                this.selectedRuleUpgrades.Add(upgradeKey);
            }
            else
            {
                this.selectedRuleUpgrades.Remove(upgradeKey);
            }
            this.SetTotalCost();
        }


    }
}