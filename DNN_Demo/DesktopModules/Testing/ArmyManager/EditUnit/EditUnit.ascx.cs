// <copyright file="EditUnit.ascx.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Web.UI.WebControls;

    using DotNetNuke.Entities.Modules;
    using DotNetNuke.Web.Mvp;

    using Testing.Dnn.ArmyManager.ArmyManager.EditUnit;

    using WebFormsMvp;

    /// <summary>
    /// Model for editing units
    /// </summary>
    /// <seealso cref="Testing.Dnn.ArmyManager.IEditUnitView" />
    [PresenterBinding(typeof(EditUnitPresenter))]
    public partial class EditUnit : ModuleView<EditUnitViewModel>, IEditUnitView
    {
        /// <summary>
        /// Occurs when [rule upgrades selected index changed].
        /// </summary>
        public event EventHandler<RuleUpgradeCheckedEventArgs> RuleUpgradesSelectedIndexChanged;

        /// <summary>
        /// Get size button clicked
        /// </summary>
        public event EventHandler<ButtonSetSizeEventArgs> ButtonSetSizeClicked;

        /// <summary>
        /// Occurs when [button wargear clicked].
        /// </summary>
        public event EventHandler<ButtonWargearEventArgs> ButtonWargearClicked;

        /// <summary>Handles the OnSelectedIndexChanged event of the RuleUpgradesCheckBoxList control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void RuleUpgradesCheckBoxList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValues = this.RuleUpgradesCheckBoxList.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value);
            var unitId = int.Parse(this.UnitIdHiddenField.Value);
            this.RuleUpgradesSelectedIndexChanged?.Invoke(this, new RuleUpgradeCheckedEventArgs(unitId, selectedValues));
        }

        /// <summary>Handles the Click event of the ButtonSetSize control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ButtonSetSize_Click(object sender, EventArgs e)
        {
            var currentSize = int.Parse(this.SizeInput.Text);
            var unitId = int.Parse(this.UnitIdHiddenField.Value);
            this.ButtonSetSizeClicked?.Invoke(this, new ButtonSetSizeEventArgs(currentSize, unitId));
        }

        /// <summary>Handles the Click event of the ButtonWargear control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ButtonWargear_Click(object sender, EventArgs e)
        {
            var wargearDict = (from RepeaterItem item in this.WargearRepeater.Items
                               let textbox = (TextBox)item.FindControl("WargearInput")
                               let wargearName = (HiddenField)item.FindControl("WargearHiddenField")
                               select new { wargearName.Value, textbox.Text, })
                               .ToDictionary(unknown => unknown.Value, unknown => int.Parse(unknown.Text));

            var unitID = int.Parse(this.UnitIdHiddenField.Value);

            this.ButtonWargearClicked?.Invoke(this, new ButtonWargearEventArgs(wargearDict, unitID));
        }

        /// <summary>Handles the OnDataBound event of the RuleUpgradesCheckBoxList control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void RuleUpgradesCheckBoxList_OnDataBound(object sender, EventArgs e)
        {
            foreach (var x in from ListItem item in this.RuleUpgradesCheckBoxList.Items
                              join option in this.Model.DisplayUnit.RuleOptions on item.Value equals option.Name
                              select new { item, option.IsSelected, })
            {
                x.item.Selected = x.IsSelected;
            }
        }
    }
}