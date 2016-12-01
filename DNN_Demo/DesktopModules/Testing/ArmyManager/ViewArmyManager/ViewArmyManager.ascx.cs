// <copyright file="ViewArmyManager.ascx.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;
    using System.Web.UI.WebControls;

    using DotNetNuke.Web.Mvp;

    using WebFormsMvp;

    /// <summary>Displays Army Manager.</summary>
    [PresenterBinding(typeof(ViewArmyManagerPresenter))]
    public partial class ViewArmyManager : ModuleView<ViewArmyManagerViewModel>, IViewArmyManagerView
    {
        public event EventHandler<ButtonNewArmyEventArgs> ButtonNewArmyClicked;

        /// <summary>
        /// Rule Checked
        /// </summary>
        public event EventHandler<RuleUpgradeCheckedEventArgs> RuleUpgradeChecked;

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
            this.RuleUpgradeChecked?.Invoke(this, e);
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

        /// <summary>Called when [button new army clicked].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void OnButtonNewArmyClicked(object sender, EventArgs e)
        {
            this.ButtonNewArmyClicked?.Invoke(this, new ButtonNewArmyEventArgs(this.NewArmyName.Text, int.Parse(this.NewArmyPointsLimit.Text)));
        }
    }

    /// <summary>
    /// Herp Derp I am JordAn!!!!
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ButtonNewArmyEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="ButtonNewArmyEventArgs"/> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="points">The points.</param>
        public ButtonNewArmyEventArgs(string name, int points)
        {
            this.ArmyName = name;
            this.Points = points;
        }

        public string ArmyName;

        public int Points;
    }
}
