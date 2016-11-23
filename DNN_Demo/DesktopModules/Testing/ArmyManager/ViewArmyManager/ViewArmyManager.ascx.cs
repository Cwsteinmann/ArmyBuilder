// <copyright file="ViewArmyManager.ascx.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;

    using DotNetNuke.Web.Mvp;

    using WebFormsMvp;

    /// <summary>Displays Army Manager.</summary>
    [PresenterBinding(typeof(ViewArmyManagerPresenter))]
    public partial class ViewArmyManager : ModuleView<ViewArmyManagerViewModel>, IViewArmyManagerView
    {
        public event EventHandler<RuleUpgradeCheckedEventArgs> RoleUpgradeChecked;

        protected void t1Form_OnRuleUpgradeChecked(object sender, RuleUpgradeCheckedEventArgs e)
        {
            this.RoleUpgradeChecked?.Invoke(this, new RuleUpgradeCheckedEventArgs(e.SelectedValues));
        }
    }
}
