// <copyright file="ButtonNewUnitEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.ViewArmyManager
{
    using System;

    /// <summary>Button New unit eventargs</summary>
    /// <seealso cref="System.EventArgs" />
    public class ButtonNewUnitEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonNewUnitEventArgs" /> class.
        /// constructor for new unit eventargs
        /// </summary>
        /// <param name="name">The name.</param>
        /// <name>name</name>
        public ButtonNewUnitEventArgs(string name)
        {
            this.UnitName = name;
        }

        /// <summary> Gets or sets the unit name</summary>
        public string UnitName { get; set; }
    }
}