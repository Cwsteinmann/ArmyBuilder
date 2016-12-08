// <copyright file="ButtonWargearEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.EditUnit
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Event for changing a units wargear
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ButtonWargearEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="ButtonWargearEventArgs"/> class.</summary>
        /// <param name="wargear">The wargear.</param>
        /// <param name="unitID">The unit identifier.</param>
        public ButtonWargearEventArgs(Dictionary<string, int> wargear, int unitID)
        {
            this.Wargear = wargear;
            this.UnitID = unitID;
        }

        /// <summary> Gets or sets the wargear</summary>
        public Dictionary<string, int> Wargear { get; set; }

        /// <summary>Gets the unit identifier.</summary>
        /// <value>The unit identifier.</value>
        public int UnitID { get; private set; }
    }
}