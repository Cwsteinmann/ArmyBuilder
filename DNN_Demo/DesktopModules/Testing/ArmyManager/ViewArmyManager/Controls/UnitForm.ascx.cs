// <copyright file="UnitForm.ascx.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Engage.Util;

    using Unit = Testing.Dnn.ArmyManager.ArmyManager.Unit;

    /// <summary>
    /// Unit forms
    /// </summary>
    public partial class UnitForm : UserControl
    {
        private ViewArmyManagerViewModel.UnitViewModel displayUnit;


        public event EventHandler<RuleUpgradeCheckedEventArgs> RuleUpgradesSelectedIndexChanged;
        /// <summary>
        /// Get size button clicked
        /// </summary>
        public event EventHandler<ButtonSetSizeEventArgs> ButtonSetSizeClicked;

        public event EventHandler<ButtonDeleteUnitEventArgs> ButtonDeleteUnitClicked;

        public event EventHandler<ButtonWargearEventArgs> ButtonWargearClicked;

        /// <summary>
        /// Display Unit creation
        /// </summary>
        public ViewArmyManagerViewModel.UnitViewModel DisplayUnit
        {
            get
            {
                return this.displayUnit;
            }

            set
            {
                this.displayUnit = value;
            }
        }

        /// <summary>Handles the OnSelectedIndexChanged event of the RuleUpgradesCheckBoxList control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void RuleUpgradesCheckBoxList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValues = this.RuleUpgradesCheckBoxList.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value);
            var unitId = int.Parse(this.UnitIdHiddenField.Value);
            this.RuleUpgradesSelectedIndexChanged?.Invoke(this, new RuleUpgradeCheckedEventArgs(unitId, selectedValues));
        }

        protected void ButtonSetSize_Click(object sender, EventArgs e)
        {
            var currentSize = int.Parse(this.SizeInput.Text);
            var unitId = int.Parse(this.UnitIdHiddenField.Value);
            this.ButtonSetSizeClicked?.Invoke(this, new ButtonSetSizeEventArgs(currentSize, unitId));
        }

        protected void ButtonDeleteUnit_Click(object sender, EventArgs e)
        {
            var unitId = int.Parse(this.UnitIdHiddenField.Value);
            this.ButtonDeleteUnitClicked?.Invoke(this, new ButtonDeleteUnitEventArgs(unitId));
        }

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
                              join option in this.DisplayUnit.RuleOptions on item.Value equals option.Name
                              select new { item, option.IsSelected, })
            {
                x.item.Selected = x.IsSelected;
            }
        }
    }

    public class ButtonDeleteUnitEventArgs : EventArgs
    {
        public ButtonDeleteUnitEventArgs(int unitID)
        {
            this.UnitId = unitID;
        }

        public int UnitId { get; set; }
    }

    /// <summary>
    /// Rule Upgrade Event Handler
    /// </summary>
    public class RuleUpgradeCheckedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuleUpgradeCheckedEventArgs" /> class.
        /// Set selected values of Rules
        /// </summary>
        /// <param name="unitId">The unit identifier.</param>
        /// <param name="selectedValues">the selected values</param>
        public RuleUpgradeCheckedEventArgs(int unitId, IEnumerable<string> selectedValues)
        {
            this.UnitId = unitId;
            this.SelectedValues = selectedValues;
        }

        public int UnitId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> SelectedValues { get; private set; }
    }

    /// <summary>
    /// Unit Size Button Handler
    /// </summary>
    public class ButtonSetSizeEventArgs : EventArgs
    {
        public ButtonSetSizeEventArgs(int size, int unitID)
        {
            this.Size = size;
            this.UnitID = unitID;
        }

        public int Size { get; private set; }

        public int UnitID { get; private set; }
    }

    public class ButtonWargearEventArgs : EventArgs
    {
        public ButtonWargearEventArgs(Dictionary<string, int> wargear, int unitID)
        {
            this.Wargear = wargear;
            this.UnitID = unitID;
        }

        public Dictionary<string, int> Wargear;

        public int UnitID { get; private set; }
    }
}
