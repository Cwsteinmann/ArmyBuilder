// <copyright file="EditUnitPresenter.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;
    using System.Globalization;
    using System.Linq;

    using DotNetNuke.Collections;
    using DotNetNuke.Web.Mvp;

    using Testing.Dnn.ArmyManager.ArmyManager;
    using Testing.Dnn.ArmyManager.ArmyManager.EditUnit;
    using Testing.Dnn.ArmyManager.ArmyManager.Units;

    using WebFormsMvp;

    /// <summary>Acts as a presenter for <see cref="IEditUnitView" /></summary>
    public sealed class EditUnitPresenter : ModulePresenter<IEditUnitView, EditUnitViewModel>
    {
        /// <summary>Initializes a new instance of the <see cref="EditUnitPresenter" /> class.</summary>
        /// <param name="view">The view.</param>
        public EditUnitPresenter(IEditUnitView view)
            : base(view)
        {
            this.View.Initialize += this.View_Initialize;
            this.View.RuleUpgradesSelectedIndexChanged += this.UpdateRules;
            this.View.ButtonWargearClicked += this.UpdateWargear;
            this.View.ButtonSetSizeClicked += this.UpdateSize;
        }

        /// <summary>Makes the unit from server data.</summary>
        /// <param name="unitType">Type of the unit.</param>
        /// <param name="size">The size.</param>
        /// <param name="unitID">The unit identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns>A UnitViewModel</returns>
        public EditUnitViewModel.UnitViewModel MakeUnitFromServerData(int unitType, int size, int unitID, ArmyDataContext context)
        {
            Unit newUnit;
            switch (unitType)
            {
                case 1:
                    newUnit = new Termagant();
                    break;
                case 2:
                    newUnit = new HiveTyrant();
                    break;
                case 3:
                    newUnit = new HiveGuard();
                    break;
                case 4:
                    newUnit = new Lictor();
                    break;
                case 5:
                    newUnit = new Zoanthrope();
                    break;
                case 6:
                    newUnit = new Venomthrope();
                    break;
                case 7:
                    newUnit = new Haruspex();
                    break;
                case 8:
                    newUnit = new Pyrovore();
                    break;
                case 9:
                    newUnit = new Gargoyle();
                    break;
                case 10:
                    newUnit = new Harpy();
                    break;
                case 11:
                    newUnit = new HiveCrone();
                    break;
                case 12:
                    newUnit = new SporeMine();
                    break;
                case 13:
                    newUnit = new Biovore();
                    break;
                case 14:
                    newUnit = new Tyrannofex();
                    break;
                case 15:
                    newUnit = new Deathleaper();
                    break;
                case 16:
                    newUnit = new OldOneEye();
                    break;
                case 17:
                    newUnit = new Hormagaunt();
                    break;
                case 18:
                    newUnit = new RipperSwarm();
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
                               select new { wargear.Amount, names.Wargear })
                               .ToDictionary(a => a.Wargear, a => a.Amount);

            foreach (var wargear in listWargear)
            {
                newUnit.SetWargear(wargear.Key, wargear.Value);
            }

            var listRules = from rules in context.Engage_Unit_Rules
                            join names in context.Engage_RulesUpgrades on rules.RuleID equals names.RuleID
                            where rules.UnitID == unitID
                            select names.RuleName;

            foreach (var rule in listRules)
            {
                newUnit.SetUpgrade(rule);
            }

            var editUrl = this.ModuleContext.EditUrl(
                "UnitId",
                unitID.ToString(CultureInfo.InvariantCulture),
                "EditUnit");

            var newUnitModel = new EditUnitViewModel.UnitViewModel(newUnit, editUrl);

            return newUnitModel;
        }

        /// <summary>Handles the <see cref="IModuleViewBase.Initialize" /> event of the <see cref="Presenter{TView}.View" />.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void View_Initialize(object sender, EventArgs e)
        {
            this.RefreshEditView();
        }

        /// <summary>Refreshes the edit view.</summary>
        private void RefreshEditView()
        {
            var unitId = this.Request.QueryString.GetValueOrDefault("UnitId", 0);
            using (var context = new ArmyDataContext())
            {
                var myUnit = (from unit in context.Engage_Units where unit.UnitId == unitId select unit).FirstOrDefault();

                this.View.Model.DisplayUnit = this.MakeUnitFromServerData(myUnit.UnitType, myUnit.Size, myUnit.UnitId, context);
            }
        }

        /// <summary>Updates the wargear.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ButtonWargearEventArgs"/> instance containing the event data.</param>
        private void UpdateWargear(object sender, ButtonWargearEventArgs e)
        {
            var checkUnit = this.View.Model.DisplayUnit;
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

            this.RefreshEditView();
        }

        /// <summary>Updates the rules.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RuleUpgradeCheckedEventArgs"/> instance containing the event data.</param>
        private void UpdateRules(object sender, RuleUpgradeCheckedEventArgs e)
        {
            var checkUnit = this.View.Model.DisplayUnit;

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

            this.RefreshEditView();
        }

        /// <summary>Updates the size.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ButtonSetSizeEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.InvalidOperationException">Cannot update a unit that does not exist.</exception>
        private void UpdateSize(object sender, ButtonSetSizeEventArgs e)
        {
            var checkUnit = this.View.Model.DisplayUnit;
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

            this.RefreshEditView();
        }
    }
}
