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

    using DotNetNuke.Collections;
    using DotNetNuke.Common;
    using DotNetNuke.Services.Localization;
    using DotNetNuke.UI.WebControls;
    using DotNetNuke.Web.Mvp;

    using Engage.Dnn.Framework.EngageLicensing;
    using Engage.Util;

    using Testing.Dnn.ArmyManager.ArmyManager;

    using WebFormsMvp;

    /// <summary>Acts as a presenter for <see cref="IViewArmyManagerView"/></summary>
    public sealed class ViewArmyManagerPresenter : ModulePresenter<IViewArmyManagerView, ViewArmyManagerViewModel>
    {
        /// <summary>Initializes a new instance of the <see cref="ViewArmyManagerPresenter"/> class.</summary>
        /// <param name="view">The view.</param>
        public ViewArmyManagerPresenter(IViewArmyManagerView view)
            : base(view)
        {
            this.View.Initialize += this.View_Initialize;
            this.View.RuleUpgradeChecked += this.View_RoleUpgradeChecked;
            this.View.ButtonSubmitClicked += this.View_ButtonSubmitClicked;
            this.View.ButtonNewArmyClicked += this.MakeArmy;
            this.View.ButtonNewUnitClicked += this.AddNewUnit;
        }

        /// <summary>Handles the <see cref="IModuleViewBase.Initialize"/> event of the <see cref="Presenter{TView}.View"/>.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void View_Initialize(object sender, EventArgs e)
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

        private void View_RoleUpgradeChecked(object sender, RuleUpgradeCheckedEventArgs e)
        {
            try
            {
                foreach (var upgrade in e.SelectedValues)
                {
                    //this.View.Model.DisplayUnit.SetUpgrade(upgrade);
                }
            }
            catch (Exception exc)
            {
                this.ProcessModuleLoadException(exc);
            }
        }

        private void View_ButtonSubmitClicked(object sender, ButtonSubmitSizeEventArgs e)
        {
            try
            {
                //this.View.Model.DisplayUnit.SetUnits(e.Amount);
            }
            catch (Exception exc)
            {
                this.ProcessModuleLoadException(exc);
            }
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

                var insertUnit = new ViewArmyManagerViewModel.UnitViewModel(myUnit);
                this.View.Model.Army.Append(insertUnit);
            }
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

           newUnitModel = new ViewArmyManagerViewModel.UnitViewModel(newUnit);

            return newUnitModel;
        }
    }
}
