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

    using Unit = Testing.Dnn.ArmyManager.ArmyManager.Unit;

    public partial class UnitForm : UserControl
    {
        public event EventHandler<RuleUpgradeCheckedEventArgs> RuleUpgradeChecked;

        public Unit DisplayUnit { get; set; }

        protected void RuleUpgradesCheckBoxList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValues = this.RuleUpgradesCheckBoxList.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value);
            this.RuleUpgradeChecked?.Invoke(this, new RuleUpgradeCheckedEventArgs(selectedValues));
        }
    }

    public class RuleUpgradeCheckedEventArgs : EventArgs
    {
        public RuleUpgradeCheckedEventArgs(IEnumerable<string> selectedValues)
        {
            this.SelectedValues = selectedValues;
        }

        public IEnumerable<string> SelectedValues { get; private set; }
    }
}
