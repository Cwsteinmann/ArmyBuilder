// <copyright file="RuleUpgradeCheckedEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.EditUnit
{
    using System;
    using System.Collections.Generic;

    /// <summary>Rule Upgrade Event Handler</summary>
    /// <seealso cref="System.EventArgs" />
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

        /// <summary>Gets the unit identifier.</summary>
        /// <value>The unit identifier.</value>
        public int UnitId { get; private set; }

        /// <summary>Gets the selected values.</summary>
        /// <value>The selected values.</value>
        public IEnumerable<string> SelectedValues { get; private set; }
    }
}