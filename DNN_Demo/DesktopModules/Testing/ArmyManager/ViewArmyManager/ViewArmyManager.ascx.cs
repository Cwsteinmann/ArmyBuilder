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

    using Testing.Dnn.ArmyManager.ArmyManager.ViewArmyManager;

    using WebFormsMvp;

    /// <summary>Displays Army Manager.</summary>
    [PresenterBinding(typeof(ViewArmyManagerPresenter))]
    public partial class ViewArmyManager : ModuleView<ViewArmyManagerViewModel>, IViewArmyManagerView
    {
        /// <summary>Occurs when [button load army clicked].</summary>
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
        /// Even where army is selected
        /// </summary>
        public event EventHandler<ButtonSelectArmyEventArgs> ButtonSelectArmyClicked;

        /// <summary>Select an Army on click</summary>
        /// <param name="sender">sender</param>
        /// <param name="e">The <see cref="RepeaterCommandEventArgs" /> instance containing the event data.</param>
        public void OnButtonSelectArmyClicked(object sender, RepeaterCommandEventArgs e)
        {
            var armyID = int.Parse(((Button)e.CommandSource).CommandArgument);

            this.ButtonSelectArmyClicked?.Invoke(this, new ButtonSelectArmyEventArgs(armyID));
        }

        /// <summary>Load an Army that has been clicked</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <name>sender</name>
        protected void OnButtonLoadArmyClicked(object sender, EventArgs e)
        {
            this.ButtonLoadArmyClicked?.Invoke(this, e);
        }

        /// <summary>Called when <see cref="ButtonNewArmyClicked"> occurs</see>.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void OnButtonNewArmyClicked(object sender, EventArgs e)
        {
            this.ButtonNewArmyClicked?.Invoke(this, new ButtonNewArmyEventArgs(this.NewArmyName.Text, int.Parse(this.NewArmyPointsLimit.Text)));
        }

        /// <summary>Called when [button add new unit clicked].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// Create a new unit click
        /// <see cref="ButtonNewUnitClicked" /> occurs.
        protected void OnButtonAddNewUnitClicked(object sender, EventArgs e)
        {
            this.ButtonNewUnitClicked?.Invoke(this, new ButtonNewUnitEventArgs(this.NewUnitDDL.SelectedValue));
        }

        /// <summary>Called when [button delete unit clicked].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RepeaterCommandEventArgs"/> instance containing the event data.</param>
        protected void OnButtonDeleteUnitClicked(object sender, RepeaterCommandEventArgs e)
        {
            var unitId = int.Parse(((Button)e.CommandSource).CommandArgument);
            this.ButtonDeleteUnitClicked?.Invoke(this, new ButtonDeleteUnitEventArgs(unitId));
        }
    }
}
