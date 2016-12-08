// <copyright file="ViewArmyManagerPresenter.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.UI.WebControls;

    using DotNetNuke.Collections;
    using DotNetNuke.Common;
    using DotNetNuke.Web.Mvp;

    using Engage.Util;

    using Testing.Dnn.ArmyManager.ArmyManager;
    using Testing.Dnn.ArmyManager.ArmyManager.Units;
    using Testing.Dnn.ArmyManager.ArmyManager.ViewArmyManager;

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
            this.View.ButtonNewArmyClicked += this.MakeArmy;
            this.View.ButtonNewUnitClicked += this.AddNewUnit;
            this.View.ButtonDeleteUnitClicked += this.DeleteUnit;
            this.View.ButtonLoadArmyClicked += this.LoadArmies;
            this.View.ButtonSelectArmyClicked += this.SelectArmy;
            this.View.ServerValidate += this.ValidateUnitType;
        }

        /// <summary>Makes the unit from string.</summary>
        /// <param name="name">The name.</param>
        /// <returns><see cref="Unit"/></returns>
        public static Unit MakeUnitFromString(string name)
        {
            Unit newUnit;
            switch (name)
            {
                case "Termagant Brood":
                    newUnit = new Termagant();
                    break;
                case "Hive Tyrant":
                    newUnit = new HiveTyrant();
                    break;
                case "Hive Guard":
                    newUnit = new HiveGuard();
                    break;
                case "Lictor Brood":
                    newUnit = new Lictor();
                    break;
                case "Zoanthrope Brood":
                    newUnit = new Zoanthrope();
                    break;
                case "Venomthrope Brood":
                    newUnit = new Venomthrope();
                    break;
                case "Haruspex":
                    newUnit = new Haruspex();
                    break;
                case "Pyrovore Brood":
                    newUnit = new Pyrovore();
                    break;
                case "Gargoyle Brood":
                    newUnit = new Gargoyle();
                    break;
                case "Harpy":
                    newUnit = new Harpy();
                    break;
                case "Hive Crone":
                    newUnit = new HiveCrone();
                    break;
                case "Spore Mine Cluster":
                    newUnit = new SporeMine();
                    break;
                case "Biovore Brood":
                    newUnit = new Biovore();
                    break;
                case "Tyrannofex":
                    newUnit = new Tyrannofex();
                    break;
                case "Deathleaper":
                    newUnit = new Deathleaper();
                    break;
                case "Old One Eye":
                    newUnit = new OldOneEye();
                    break;
                case "Hormagaunt Brood":
                    newUnit = new Hormagaunt();
                    break;
                case "Ripper Swarm Brood":
                    newUnit = new RipperSwarm();
                    break;
                default:
                    // TODO: make better default
                    newUnit = new Termagant();
                    break;
            }

            return newUnit;
        }

        /// <summary>Makes the unit from server data.</summary>
        /// <param name="unitType">Type of the unit.</param>
        /// <param name="size">The size.</param>
        /// <param name="unitID">The unit identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns>A <see cref="EditUnitViewModel"/></returns>
        public ViewArmyManagerViewModel.UnitViewModel MakeUnitFromServerData(int unitType, int size, int unitID, ArmyDataContext context)
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

            var newUnitModel = new ViewArmyManagerViewModel.UnitViewModel(newUnit, editUrl);

            return newUnitModel;
        }

        /// <summary>Handles the <see cref="IModuleViewBase.Initialize"/> event of the <see cref="Presenter{TView}.View"/>.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void View_Initialize(object sender, EventArgs e)
        {
            this.RefreshView();
        }

        /// <summary>Refreshes the view.</summary>
        private void RefreshView()
        {
            try
            {
                var armyId = this.Request.QueryString.GetValueOrDefault("ArmyId", 0);

                if (armyId == 0)
                {
                    return;
                }

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
            catch (Exception exc)
            {
                this.ProcessModuleLoadException(exc);
            }
        }

        /// <summary>Selects the army.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ButtonSelectArmyEventArgs"/> instance containing the event data.</param>
        private void SelectArmy(object sender, ButtonSelectArmyEventArgs e)
        {
            this.View.Model.ArmyID = e.ArmyID;
            this.View.Model.IsLoading = false;

            this.Response.Redirect(Globals.NavigateURL(this.TabId, string.Empty, "ArmyId=" + this.View.Model.ArmyID.ToString(CultureInfo.InvariantCulture)));

            this.RefreshView();
        }

        /// <summary>Loads the armies.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LoadArmies(object sender, EventArgs e)
        {
            using (var context = new ArmyDataContext())
            {
                var myArmies =
                    (from armies in context.Engage_Armies
                     select new { armies.ArmyID, armies.ArmyName })
                     .ToDictionary(a => a.ArmyID, a => a.ArmyName);

                this.View.Model.ArmiesToLoad = myArmies;
            }

            this.View.Model.IsLoading = true;
        }

        /// <summary>Deletes the unit.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ButtonDeleteUnitEventArgs"/> instance containing the event data.</param>
        private void DeleteUnit(object sender, ButtonDeleteUnitEventArgs e)
        {
            using (var context = new ArmyDataContext())
            {
                var myUnit =
                    (from unit in context.Engage_Units
                      where unit.UnitId == e.UnitId
                      where unit.ArmyId == this.View.Model.ArmyID
                      select unit).SingleOrDefault();

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

        /// <summary>Makes the army.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ButtonNewArmyEventArgs"/> instance containing the event data.</param>
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

        /// <summary>Adds the new unit.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ButtonNewUnitEventArgs"/> instance containing the event data.</param>
        private void AddNewUnit(object sender, ButtonNewUnitEventArgs e)
        {
            var myUnit = MakeUnitFromString(e.UnitName);
            using (var context = new ArmyDataContext())
            {
                var newUnit = new Engage_Unit
                              {
                                    ArmyId = this.View.Model.ArmyID,
                                    Size = myUnit.InitialSize,
                                    UnitType = myUnit.ServerID,
                                    Squad = null
                              };

                context.Engage_Units.InsertOnSubmit(newUnit);
                context.SubmitChanges();

                var newWargear = from wargear in myUnit.SelectedWargearUpgrades
                                 join wargearName in context.Engage_WargearUpgrades on wargear.Key equals wargearName.Wargear
                                 select new Engage_Unit_Wargear { UnitID = newUnit.UnitId, WargearID = wargearName.WargearID, Amount = wargear.Value };

                context.Engage_Unit_Wargears.InsertAllOnSubmit(newWargear);
                context.SubmitChanges();

                var editUrl = this.ModuleContext.EditUrl("UnitId", newUnit.UnitId.ToString(CultureInfo.InvariantCulture), "EditUnit");
                var insertUnit = new ViewArmyManagerViewModel.UnitViewModel(myUnit, editUrl);
                this.View.Model.Army.Append(insertUnit);
            }

            this.RefreshView();
        }

        private static readonly Dictionary<string, int> Max = new Dictionary<string, int>
        {
            { "HQ", 2 },
            { "Troops", 6 },
            { "Elites", 3 },
            { "Fast Attack", 3 },
            { "Heavy Support", 3 }
       };

        private void ValidateUnitType(object source, ServerValidateEventArgs e)
        {
            int max;
            if (Max.TryGetValue(e.Value, out max))
            {
                if (this.View.Model.Army.Count(unit => unit.Unit.UnitType == e.Value) < max)
                {
                    e.IsValid = true;
                    return;
                }

                this.View.Model.ErrorMessage = this.LocalizeString("Too Many " + e.Value + ".Error");
                e.IsValid = false;
            }
        }
    }
}
