// <copyright file="ButtonDeleteUnitEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.ViewArmyManager
{
    using System;

    /// <summary>
    /// button delete event args
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ButtonDeleteUnitEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="ButtonDeleteUnitEventArgs"/> class.</summary>
        /// <param name="unitID">The unit identifier.</param>
        public ButtonDeleteUnitEventArgs(int unitID)
        {
            this.UnitId = unitID;
        }

        /// <summary>Gets or sets the unit identifier.</summary>
        /// <value>The unit identifier.</value>
        public int UnitId { get; set; }
    }
}