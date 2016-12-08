// <copyright file="ButtonSelectArmyEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.ViewArmyManager
{
    using System;

    /// <summary>Button for select army EventArgs</summary>
    /// <seealso cref="System.EventArgs" />
    public class ButtonSelectArmyEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonSelectArmyEventArgs" /> class.
        /// Select army EventArgs constructor
        /// </summary>
        /// <param name="armyID">The army identifier.</param>
        public ButtonSelectArmyEventArgs(int armyID)
        {
            this.ArmyID = armyID;
        }

        /// <summary> Gets or sets the army id</summary>
        public int ArmyID { get; set; }
    }
}