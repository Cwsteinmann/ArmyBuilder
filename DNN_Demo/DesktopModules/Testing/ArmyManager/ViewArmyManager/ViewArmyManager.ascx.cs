// <copyright file="ViewArmyManager.ascx.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Web.UI.WebControls;

    using DotNetNuke.Web.Mvp;

    using WebFormsMvp;

    /// <summary>Displays Army Manager.</summary>
    [PresenterBinding(typeof(ViewArmyManagerPresenter))]
    public partial class ViewArmyManager : ModuleView<ViewArmyManagerViewModel>, IViewArmyManagerView
    {
        public event EventHandler<EventArgs> ButtonLoadArmyClicked;

        /// <summary>
        /// Event which creates a new army
        /// </summary>
        public event EventHandler<ButtonNewArmyEventArgs> ButtonNewArmyClicked;

        /// <summary>
        /// Event which adds a new unit to the army
        /// </summary>
        public event EventHandler<ButtonNewUnitEventArgs> ButtonNewUnitClicked;

        /// <summary>
        /// Event which deletes a select unit from the army
        /// </summary>
        public event EventHandler<ButtonDeleteUnitEventArgs> ButtonDeleteUnitClicked;

        /// <summary>
        /// Event which updates the selected upgrades for a select unit in the army
        /// </summary>
        public event EventHandler<RuleUpgradeCheckedEventArgs> RuleUpgradesSelectedIndexChanged;

        /// <summary>
        /// Event which updates the selected wargear for a select unit in the army
        /// </summary>
        public event EventHandler<ButtonWargearEventArgs> ButtonWargearClicked;

        public event EventHandler<ButtonSelectArmyEventArgs> ButtonSelectArmyClicked;

        /// <summary>
        /// Event to update the size of a unit in the army
        /// </summary>
        public event EventHandler<ButtonSetSizeEventArgs> ButtonSetSizeClicked;

        protected void OnButtonLoadArmyClicked(object sender, EventArgs e)
        {
            this.ButtonLoadArmyClicked?.Invoke(this, e);
        }

        public void OnButtonSelectArmyClicked(object sender, RepeaterCommandEventArgs e)
        {
            var armyID = int.Parse(((Button)e.CommandSource).CommandArgument);

            this.ButtonSelectArmyClicked?.Invoke(this, new ButtonSelectArmyEventArgs(armyID));
        }

        /// <summary>Called when <see cref="ButtonNewArmyClicked"> occurs</see>.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void OnButtonNewArmyClicked(object sender, EventArgs e)
        {
            this.ButtonNewArmyClicked?.Invoke(this, new ButtonNewArmyEventArgs(this.NewArmyName.Text, int.Parse(this.NewArmyPointsLimit.Text)));
        }

        /// <summary>Called when <see cref="ButtonNewUnitClicked"> occurs.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void OnButtonAddNewUnitClicked(object sender, EventArgs e)
        {
            this.ButtonNewUnitClicked?.Invoke(this, new ButtonNewUnitEventArgs(this.NewUnitDDL.SelectedValue));
        }

        /// <summary>Called when <see cref="ButtonSetSizeClicked"> occurs.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ButtonSetSizeEventArgs"/> instance containing the event data.</param>
        protected void OnButtonSetSizeClicked(object sender, ButtonSetSizeEventArgs e)
        {
            this.ButtonSetSizeClicked?.Invoke(this, e);
        }

        protected void OnButtonDeleteUnitClicked(object sender, ButtonDeleteUnitEventArgs e)
        {
            this.ButtonDeleteUnitClicked?.Invoke(this, e);
        }

        protected void OnRuleUpgradesSelectedIndexChanged(object sender, RuleUpgradeCheckedEventArgs e)
        {
            this.RuleUpgradesSelectedIndexChanged?.Invoke(this, e);
        }

        protected void OnButtonWargearClicked(object sender, ButtonWargearEventArgs e)
        {
            this.ButtonWargearClicked?.Invoke(this, e);
        }

    }

    public class ButtonNewUnitEventArgs : EventArgs
    {
        public ButtonNewUnitEventArgs(string name)
        {
            this.UnitName = name;
        }

        public string UnitName;
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

    public class ButtonSelectArmyEventArgs : EventArgs
    {
        public ButtonSelectArmyEventArgs(int armyID)
        {
            this.ArmyID = armyID;
        }

        public int ArmyID;
    }
}
