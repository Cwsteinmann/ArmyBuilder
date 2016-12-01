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
    using System.Runtime.Remoting.Contexts;

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
        }

        /// <summary>Handles the <see cref="IModuleViewBase.Initialize"/> event of the <see cref="Presenter{TView}.View"/>.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void View_Initialize(object sender, EventArgs e)
        {
            try
            {
                this.View.Model.DisplayUnit = new ViewArmyManagerViewModel.UnitViewModel(new Termagant());
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
                //this.View.Model = new ViewArmyManagerViewModel(newArmy.MaxPoints, newArmy.ArmyName, newArmy.ArmyID);
                this.View.Model.MaxPoints = newArmy.MaxPoints;
                this.View.Model.Name = newArmy.ArmyName;
                this.View.Model.ArmyID = newArmy.ArmyID;
                this.View.Model.IsLoading = true;
            }
        }
    }
}
