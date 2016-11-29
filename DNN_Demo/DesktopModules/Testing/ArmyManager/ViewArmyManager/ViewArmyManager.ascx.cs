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
        /// <summary>
        /// Rule Checked
        /// </summary>
        public event EventHandler<RuleUpgradeCheckedEventArgs> RoleUpgradeChecked;

        /// <summary>
        /// Button Submit
        /// </summary>
        public event EventHandler<ButtonSubmitSizeEventArgs> ButtonSubmitClicked;

        /// <summary>
        /// Action for checkboxes in unit view
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">event arguments</param>
        protected void T1Form_OnRuleUpgradeChecked(object sender, RuleUpgradeCheckedEventArgs e)
        {
            this.RoleUpgradeChecked?.Invoke(this, new RuleUpgradeCheckedEventArgs(e.SelectedValues));
        }

        /// <summary>
        /// Action to change unit size
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">event arguments</param>
        protected void T1Form_OnButtonSubmitSizeClicked(object sender, ButtonSubmitSizeEventArgs e)
        {
            this.ButtonSubmitClicked?.Invoke(this, new ButtonSubmitSizeEventArgs(e.Amount));
        }
    }
}
