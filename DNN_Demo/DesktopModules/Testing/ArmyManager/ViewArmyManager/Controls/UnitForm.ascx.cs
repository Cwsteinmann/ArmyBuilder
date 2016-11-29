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
        /// <summary>
        /// Get checked Rule Upgrades
        /// </summary>
        public event EventHandler<RuleUpgradeCheckedEventArgs> RuleUpgradeChecked;

        /// <summary>
        /// Get size button clicked
        /// </summary>
        public event EventHandler<ButtonSubmitSizeEventArgs> SizeButtonClicked;

        /// <summary>
        /// Display Unit creation
        /// </summary>
        public ViewArmyManagerViewModel.UnitViewModel DisplayUnit { get; set; }
        
        
        /// <summary>Handles the OnSelectedIndexChanged event of the RuleUpgradesCheckBoxList control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void RuleUpgradesCheckBoxList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValues = this.RuleUpgradesCheckBoxList.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value);
            this.RuleUpgradeChecked?.Invoke(this, new RuleUpgradeCheckedEventArgs(selectedValues));
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

    /// <summary>
    /// Rule Upgrade Event Handler
    /// </summary>
    public class RuleUpgradeCheckedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuleUpgradeCheckedEventArgs"/> class.
        /// Set selected values of Rules
        /// </summary>
        /// <param name="selectedValues" >the selected values</param>
        public RuleUpgradeCheckedEventArgs(IEnumerable<string> selectedValues)
        {
            this.SelectedValues = selectedValues;
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> SelectedValues { get; private set; }
    }

    /// <summary>
    /// Unit Size Button Handler
    /// </summary>
    public class ButtonSubmitSizeEventArgs : EventArgs
    {
        public ButtonSubmitSizeEventArgs(int amount)
        {
            this.Amount = amount;
        }

        public int Amount { get; private set; }
    }
}
