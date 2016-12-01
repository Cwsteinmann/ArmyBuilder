// <copyright file="ViewArmyManagerViewModel.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System.Collections.Generic;
    using System.EnterpriseServices;
    using System.Linq;
    using System.Web.UI.WebControls;

    using DotNetNuke.UI.WebControls;

    using Army =Testing.Dnn.ArmyManager.ArmyManager.ViewArmyManager.Army;
    using Unit = Testing.Dnn.ArmyManager.ArmyManager.Unit;

    /// <summary>The view model for the Army Manager, to be displayed by <see cref="IViewArmyManagerView"/></summary>
    public class ViewArmyManagerViewModel
    {
        /// <summary>Initializes a new instance of the <see cref="ViewArmyManagerViewModel"/> class.</summary>
        public ViewArmyManagerViewModel()
        {
            this.IsLoading = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewArmyManagerViewModel"/> class.
        /// ViewArmyManagerViewModel Constructor
        /// </summary>
        /// <param name="points">Max points cost for the army</param>
        /// <param name="name">Name of the army</param>
        /// <param name="id">The army ID determined by the server</param>
        public ViewArmyManagerViewModel(int points, string name, int id)
        {
            this.MaxPoints = points;
            this.Name = name;
            this.ArmyID = id;
        }

        /// <summary>Flag for if the user is loading an existing army</summary>
        public bool IsLoading;

        /// <summary>Gets or sets the unit to display.</summary>
        public UnitViewModel DisplayUnit { get; set; }

        /// <summary>
        /// The list of units that comprises the army
        /// </summary>
        public IEnumerable<UnitViewModel> Army = Enumerable.Empty<UnitViewModel>();

        /// <summary>
        /// The max points for the army
        /// </summary>
        public int MaxPoints;

        /// <summary>
        /// The user-determined name of the army
        /// </summary>
        public string Name;

        /// <summary>
        /// The server-determined army ID
        /// </summary>
        public int ArmyID;

        /// <summary>
        /// View Model on a Unit level
        /// </summary>
        public class UnitViewModel
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="UnitViewModel" /> class.
            /// Unit View Model initializer
            /// </summary>
            /// <param name="unit">an instance of the <see cref="Unit" /> class. </param>
            public UnitViewModel(Unit unit)
            {
                this.Wargear = from wargear in unit.WargearUpgrades
                               join selectedWargear in unit.SelectedWargearUpgrades on wargear.Key equals selectedWargear.Key
                               select new WarGearViewModel(selectedWargear.Value, wargear.Key, wargear.Value);

                this.RuleOptions = from options in unit.RulesUpgrades
                                   select new RuleUpgradeViewModel(options.Key, options.Value, unit.SelectedRuleUpgrades.Contains(options.Key));

                this.Rules = from rules in unit.SpecialRules select new InitialRulesViewModel(rules);

                this.SizeData = new SizeDataViewModel(unit.InitialSize, unit.MaxSize, unit.CurrentSize, unit.CostPerUnit);

                this.UnitData = new UnitDataViewModel(unit.Stats, unit.Name, unit.Type, unit.UnitType, unit.TotalCost);
            }

            /// <summary>
            /// Gets the unit data associated with the unit
            /// </summary>
            public UnitDataViewModel UnitData { get; private set; }

            /// <summary>
            /// Gets the size data associated with the unit
            /// </summary>
            public SizeDataViewModel SizeData { get; private set; }

            /// <summary>Gets a sequence of applied Wargear</summary>
            public IEnumerable<WarGearViewModel> Wargear { get; private set; }

            /// <summary>
            /// Gets a sequence of the initial rules
            /// </summary>
            public IEnumerable<InitialRulesViewModel> Rules { get; private set; }

            /// <summary>
            /// Gets a sequence of potential upgrades
            /// </summary>
            public IEnumerable<RuleUpgradeViewModel> RuleOptions { get; private set; }
        }

        /// <summary>
        /// Model for the basic data of the unit
        /// </summary>
        public class UnitDataViewModel
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="UnitDataViewModel"/> class.
            /// </summary>
            /// <param name="stats">The stats of the unit</param>
            /// <param name="name">The name of the unit</param>
            /// <param name="type">The type of the unit</param>
            /// <param name="slotType">The type in the overall army the unit belongs to</param>
            /// <param name="cost">The overall cost of the unit</param>
            public UnitDataViewModel(Dictionary<string, int> stats, string name, string type, string slotType, int cost)
            {
                this.Stats = stats;
                this.Name = name;
                this.Type = type;
                this.SlotType = slotType;
                this.Cost = cost;
            }

            /// <summary>
            /// Gets the stats of the unit
            /// </summary>
            public Dictionary<string, int> Stats { get; private set; }

            /// <summary>
            /// Gets the name of the unit
            /// </summary>
            public string Name { get; private set; }

            /// <summary>
            /// Gets the type of the unit
            /// </summary>
            public string Type { get; private set; }

            /// <summary>
            /// Gets the slot type of the unit
            /// </summary>
            public string SlotType { get; private set; }

            /// <summary>
            /// Gets the total cost of the unit
            /// </summary>
            public int Cost { get; private set; }
        }

        /// <summary>
        /// Model for the size data of the unit
        /// </summary>
        public class SizeDataViewModel
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SizeDataViewModel"/> class.
            /// </summary>
            /// <param name="initial">The initial size of the unit</param>
            /// <param name="max">the maximum size of the unit</param>
            /// <param name="current">the current size of the unit</param>
            /// <param name="cost">the cost associated with each individual in the unit</param>
            public SizeDataViewModel(int initial, int max, int current, int cost)
            {
                this.InitialSize = initial;
                this.MaxSize = max;
                this.CurrentSize = current;
                this.CostPerUnit = cost;
                this.SizeCost = current * cost;
            }

            /// <summary>
            /// Gets the initial size of the unit
            /// </summary>
            public int InitialSize { get; private set; }

            /// <summary>
            /// Gets the max size of the unit
            /// </summary>
            public int MaxSize { get; private set; }

            /// <summary>
            /// Gets the current size of the unit
            /// </summary>
            public int CurrentSize { get; private set; }

            /// <summary>
            /// Gets the cost associated with each individual
            /// </summary>
            public int CostPerUnit { get; private set; }


            /// <summary>
            /// Gets the total cost of the size of the unit
            /// </summary>
            public int SizeCost { get; private set; }
        }

        /// <summary>
        /// Model for rules the unit comes with
        /// </summary>
        public class InitialRulesViewModel
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="InitialRulesViewModel"/> class.
            /// </summary>
            /// <param name="name">The name of the rule</param>
            public InitialRulesViewModel(string name)
            {
                this.Name = name;
            }

            /// <summary>
            /// Gets the name of the rule
            /// </summary>
            public string Name { get; private set; }
        }

        /// <summary>
        /// Model for rules that may be upgraded
        /// </summary>
        public class RuleUpgradeViewModel
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="RuleUpgradeViewModel"/> class.
            /// </summary>
            /// <param name="name">Name of the upgrade</param>
            /// <param name="points">Cost associated with the upgrade</param>
            /// <param name="selected">Whether it has already been selected</param>
            public RuleUpgradeViewModel(string name, int points, bool selected)
            {
                this.Name = name;
                this.Points = points;
                this.IsSelected = selected;
                this.DisplayString = $"{name} - {points} pts/model";
            }

            /// <summary>
            /// Gets the name of the upgrade
            /// </summary>
            public string Name { get; private set; }

            /// <summary>
            /// Gets the cost associated with the upgrade
            /// </summary>
            public int Points { get; private set; }

            /// <summary>
            /// Gets a value indicating whether the upgrade has been selected or not
            /// </summary>
            public bool IsSelected { get; private set; }

            /// <summary>
            /// Gets the display string for the upgrade
            /// </summary>
            public string DisplayString { get; private set; }
        }

        /// <summary>Wargear model</summary>
        public class WarGearViewModel
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="WarGearViewModel"/> class.
            /// wargear Model initializer
            /// </summary>
            /// <param name="numberOfThings">number of selected wargear</param>
            /// <param name="name">name of the selected wargear</param>
            /// <param name="points">points associated with selected wargear</param>
            public WarGearViewModel(int numberOfThings, string name, int points)
            {
                this.NumberOfThings = numberOfThings;
                this.Name = name;
                this.Points = points;
                this.DisplayString = $"{name} - {points} pts/model";
            }

            /// <summary>
            /// Gets number of selected wargear
            /// </summary>
            public int NumberOfThings { get; private set; }

            /// <summary>
            /// Gets the display string for the view model
            /// </summary>
            public string DisplayString { get; private set; }

            /// <summary>
            /// Gets name of the selected wargear
            /// </summary>
            public string Name { get; private set; }

            /// <summary>
            /// Gets points associated with selected wargear
            /// </summary>
            public int Points { get; private set; }

        }
    }
}
