// <copyright file="ViewArmyManagerPresenter.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;
    using System.Web.UI.WebControls;

    using DotNetNuke.Collections;
    using DotNetNuke.Common;
    using DotNetNuke.Services.Localization;
    using DotNetNuke.UI.WebControls;
    using DotNetNuke.Web.Mvp;

    using Engage.Dnn.Framework.EngageLicensing;
    using Engage.Util;

    using Testing.Dnn.ArmyManager.ArmyManager;

    using WebFormsMvp;

    using Unit = Testing.Dnn.ArmyManager.ArmyManager.Unit;

    /// <summary>Acts as a presenter for <see cref="IViewArmyManagerView"/></summary>
    public sealed class ViewArmyManagerPresenter : ModulePresenter<IViewArmyManagerView, ViewArmyManagerViewModel>
    {
        /// <summary>Initializes a new instance of the <see cref="ViewArmyManagerPresenter"/> class.</summary>
        /// <param name="view">The view.</param>
        public ViewArmyManagerPresenter(IViewArmyManagerView view)
            : base(view)
        {
            this.View.Initialize += this.View_Initialize;
            this.View.ButtonSetSizeClicked += this.UpdateSize;
            this.View.ButtonNewArmyClicked += this.MakeArmy;
            this.View.ButtonNewUnitClicked += this.AddNewUnit;
            this.View.ButtonDeleteUnitClicked += this.DeleteUnit;
            this.View.RuleUpgradesSelectedIndexChanged += this.UpdateRules;
            this.View.ButtonWargearClicked += this.UpdateWargear;
            this.View.ButtonLoadArmyClicked += this.LoadArmies;
            this.View.ButtonSelectArmyClicked += this.SelectArmy;
        }

        /// <summary>Handles the <see cref="IModuleViewBase.Initialize"/> event of the <see cref="Presenter{TView}.View"/>.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void View_Initialize(object sender, EventArgs e)
        {
            this.RefreshView();
        }

        private void RefreshView()
        {
            try
            {
                var armyId = this.Request.QueryString.GetValueOrDefault("ArmyId", 0);

                if (armyId != 0)
                {
                    using (var context = new ArmyDataContext())
                    {
                        var army = context.Engage_Armies.Single(a => a.ArmyID == armyId);
                        this.View.Model.Name = army.ArmyName;
                        this.View.Model.MaxPoints = army.MaxPoints;

                        this.View.Model.Army = (from unit in army.Units
                                                select this.MakeUnitFromServerData(unit.UnitType, unit.Size, unit.UnitId, context))
                                                .ToArray();
                    }

                    this.View.Model.ArmyID = (int)armyId;
                }
            }
            catch (Exception exc)
            {
                this.ProcessModuleLoadException(exc);
            }
        }

        private void SelectArmy(object sender, ButtonSelectArmyEventArgs e)
        {
            this.View.Model.ArmyID = e.ArmyID;
            this.View.Model.IsLoading = false;

            this.Response.Redirect(Globals.NavigateURL(this.TabId, string.Empty, "ArmyId=" + this.View.Model.ArmyID.ToString(CultureInfo.InvariantCulture)));

            this.RefreshView();
        }

        private void LoadArmies(object sender, EventArgs e)
        {
            using (var context = new ArmyDataContext())
            {
                var myArmies =
                    (from armies in context.Engage_Armies
                     select new { armies.ArmyID, armies.ArmyName })
                     .ToDictionary( a => a.ArmyID, a => a.ArmyName);

                this.View.Model.ArmiesToLoad = myArmies;
            }

            this.View.Model.IsLoading = true;
        }

        private void DeleteUnit(object sender, ButtonDeleteUnitEventArgs e)
        {
            using (var context = new ArmyDataContext())
            {
                var myUnit =
                    ( from unit in context.Engage_Units
                      where unit.UnitId == e.UnitId
                      where unit.ArmyId == this.View.Model.ArmyID
                      select unit
                    ).SingleOrDefault();

                var myRules = from unitRules in context.Engage_Unit_Rules
                              where unitRules.UnitID == e.UnitId
                              select unitRules;

                var myWargear = from unitWargear in context.Engage_Unit_Wargears
                                where unitWargear.UnitID == e.UnitId
                                select unitWargear;

                context.Engage_Unit_Rules.DeleteAllOnSubmit(myRules);
                context.Engage_Unit_Wargears.DeleteAllOnSubmit(myWargear);
                context.Engage_Units.DeleteOnSubmit(myUnit);
                context.SubmitChanges();
            }

            this.RefreshView();
        }

        private void MakeArmy(object sender, ButtonNewArmyEventArgs e)
        {
            using (var context = new ArmyDataContext())
            {
                var newArmy = new Engage_Army();
                newArmy.ArmyName = e.ArmyName;
                newArmy.MaxPoints = e.Points;

                context.Engage_Armies.InsertOnSubmit(newArmy);
                context.SubmitChanges();
                this.View.Model.MaxPoints = newArmy.MaxPoints;
                this.View.Model.Name = newArmy.ArmyName;
                this.View.Model.ArmyID = newArmy.ArmyID;
            }

            this.Response.Redirect(Globals.NavigateURL(this.TabId, string.Empty, "ArmyId=" + this.View.Model.ArmyID.ToString(CultureInfo.InvariantCulture)));
        }

        private void UpdateWargear(object sender, ButtonWargearEventArgs e)
        {
            var checkUnit = this.View.Model.Army.SingleOrDefault(unit => unit.UnitData.UnitID == e.UnitID);
            var newWargearValues = e.Wargear;

            foreach (var upgrade in newWargearValues)
            {
                checkUnit.Unit.SetWargear(upgrade.Key, upgrade.Value);
            }

            using (var context = new ArmyDataContext())
            {
                var myUnit = context.Engage_Units.SingleOrDefault(unit => unit.UnitId == e.UnitID);

                foreach (var wargear in checkUnit.Unit.SelectedWargearUpgrades)
                {
                    var myWargear = (from wargearTable in myUnit.Engage_Unit_Wargears
                                    join wargearNames in context.Engage_WargearUpgrades on wargearTable.WargearID equals wargearNames.WargearID
                                    where wargearNames.Wargear == wargear.Key
                                    select wargearTable).SingleOrDefault();

                    myWargear.Amount = wargear.Value;
                }

                context.SubmitChanges();
            }

            this.RefreshView();
        }

        private void UpdateRules(object sender, RuleUpgradeCheckedEventArgs e)
        {
            var checkUnit = this.View.Model.Army.SingleOrDefault(unit => unit.UnitData.UnitID == e.UnitId);

            var newRules = e.SelectedValues.Except(checkUnit.Unit.SelectedRuleUpgrades);
            var deletedRules = checkUnit.Unit.SelectedRuleUpgrades.Except(e.SelectedValues);

            using (var context = new ArmyDataContext())
            {
                var myUnit = context.Engage_Units.SingleOrDefault(unit => unit.UnitId == e.UnitId);

                var rules = (from rule in context.Engage_RulesUpgrades
                             where newRules.Contains(rule.RuleName)
                             select new { rule.RuleID, UnitID = myUnit.UnitId, })
                            .AsEnumerable()
                            .Select(rule => new Engage_Unit_Rule { RuleID = rule.RuleID, UnitID = rule.UnitID, });

                var deleteRules = from rule in context.Engage_Unit_Rules
                                  join ruleName in context.Engage_RulesUpgrades on rule.RuleID equals ruleName.RuleID
                                  where rule.UnitID == myUnit.UnitId
                                  where deletedRules.Contains(ruleName.RuleName)
                                  select rule;

                context.Engage_Unit_Rules.DeleteAllOnSubmit(deleteRules);
                context.Engage_Unit_Rules.InsertAllOnSubmit(rules);

                context.SubmitChanges();
            }

            this.RefreshView();
        }

        private void UpdateSize(object sender, ButtonSetSizeEventArgs e)
        {
            var checkUnit = this.View.Model.Army.SingleOrDefault(unit => unit.UnitData.UnitID == e.UnitID);
            checkUnit.Unit.CurrentSize = e.Size;
            var size = checkUnit.Unit.CurrentSize;

            using (var context = new ArmyDataContext())
            {
                var myUnit = context.Engage_Units.SingleOrDefault(unit => unit.UnitId == e.UnitID);

                if (myUnit == null)
                {
                    throw new InvalidOperationException("Cannot update a unit that does not exist.");
                }

                myUnit.Size = size;
                context.SubmitChanges();

            }

            this.RefreshView();
        }

        public Unit MakeUnitFromString(string name)
        {
            Unit newUnit;
            switch (name)
            {
                case "Termagant":
                    newUnit = new Termagant();
                    break;
                default:
                    // TODO: make better default
                    newUnit = new Termagant();
                    break;
            }

            return newUnit;
        }

        private void AddNewUnit(object sender, ButtonNewUnitEventArgs e)
        {
            Unit myUnit = this.MakeUnitFromString(e.UnitName);
            using (var context = new ArmyDataContext())
            {
                var newUnit = new Engage_Unit();
                newUnit.ArmyId = this.View.Model.ArmyID;
                newUnit.Size = myUnit.InitialSize;
                newUnit.UnitType = myUnit.ServerID;
                newUnit.Squad = null;

                context.Engage_Units.InsertOnSubmit(newUnit);
                context.SubmitChanges();

                var newWargear = from wargear in myUnit.SelectedWargearUpgrades
                                 join wargearName in context.Engage_WargearUpgrades on wargear.Key equals wargearName.Wargear
                                 select new Engage_Unit_Wargear { UnitID = newUnit.UnitId, WargearID = wargearName.WargearID, Amount = wargear.Value };

                context.Engage_Unit_Wargears.InsertAllOnSubmit(newWargear);
                context.SubmitChanges();

                var insertUnit = new ViewArmyManagerViewModel.UnitViewModel(myUnit);
                this.View.Model.Army.Append(insertUnit);
            }

            this.RefreshView();
        }

        private ViewArmyManagerViewModel.UnitViewModel MakeUnitFromServerData(int unitType, int size, int unitID, ArmyDataContext context)
        {
            ViewArmyManagerViewModel.UnitViewModel newUnitModel;
            Unit newUnit;
            switch (unitType)
            {
                case 1:
                    newUnit = new Termagant();
                    break;
                default:
                    // TODO: make better default
                    newUnit = new Termagant();
                    break;
            }

            newUnit.CurrentSize = size;
            newUnit.UnitID = unitID;

            var listWargear = (from wargear in context.Engage_Unit_Wargears
                               join names in context.Engage_WargearUpgrades on wargear.WargearID equals names.WargearID
                               where wargear.UnitID == unitID
                               select new { wargear.Amount, names.Wargear})
                               .ToDictionary(a => a.Wargear, a => a.Amount);

            foreach (var wargear in listWargear)
            {
                newUnit.SetWargear(wargear.Key, wargear.Value);
            }

            var listRules = from rules in context.Engage_Unit_Rules
                            join names in context.Engage_RulesUpgrades on rules.RuleID equals names.RuleID
                            where rules.UnitID == unitID
                            select names.RuleName;

            foreach (string rule in listRules)
            {
                newUnit.SetUpgrade(rule);
            }

            newUnit.UpdateWargear();

            newUnitModel = new ViewArmyManagerViewModel.UnitViewModel(newUnit);

            return newUnitModel;
        }
    }
}
