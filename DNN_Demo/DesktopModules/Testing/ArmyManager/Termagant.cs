using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testing.Dnn.ArmyManager.ArmyManager
{
    /// <summary>
    /// Termagant Unit (Troop)
    /// </summary>
    public class Termagant : Unit

    {
        public Termagant()
        {
            this.unitSquadType = 1;
            this.name = "Termagant";
            this.unitType = "Infantry";
            this.initialPoints = 40;
            this.initialSize = 10;
            this.maxSize = 30;
            this.costPerUnit = 4;
            this.ws = 3;
            this.bs = 3;
            this.s = 3;
            this.t = 3;
            this.i = 5;
            this.w = 1;
            this.a = 1;
            this.ld = 6;
            this.sv = 6;
            this.initialWargear = "Fleshborer";
            this.specialRules = new List<string> { "Move Through Cover", "Instinctive Behaviour(Lurk)" };

            this.wargearUpgrades = new Dictionary<string, int>
            {
                { "Fleshborer", 0 },
                { "Devourer", 4 },
                { "Spinefists", 0 },
                { "Spike Rifle", 0 },
                { "StrangleWeb", 5 },
            };

            this.rulesUpgrades = new Dictionary<string, int> { { "Adrenal Glands", 2 }, { "Toxin Sacs", 2 } };

            this.currentSize = 10;

            this.selectedRuleUpgrades = new List<string> { };

            this.selectedWargearUpgrades = new Dictionary<string, int> { { "FleshBorer", 10 } };

            this.totalCost = 40;

        }

        public void SetWargear(string weapon, int amount)
        {
            if (this.selectedWargearUpgrades.ContainsKey(weapon))
            {
                this.selectedWargearUpgrades[weapon] = amount;

            }
            else
            {
                this.selectedWargearUpgrades.Add(weapon, amount);
            }
            this.selectedWargearUpgrades[this.initialWargear] =
                (this.currentSize - (from entry in this.selectedWargearUpgrades
                                     where entry.Key != this.initialWargear
                                     select entry.Value).Sum());
            this.SetTotalCost();
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
            this.selectedWargearUpgrades[this.initialWargear] =
                (this.currentSize - (from entry in this.selectedWargearUpgrades
                                     where entry.Key != this.initialWargear
                                     select entry.Value).Sum());
            this.SetTotalCost();
        }
    }
}