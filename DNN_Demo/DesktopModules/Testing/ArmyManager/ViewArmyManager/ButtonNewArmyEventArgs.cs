// <copyright file="ButtonNewArmyEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Testing.Dnn.ArmyManager.ArmyManager.ViewArmyManager
{
    using System;
    using System.Linq;

    /// <summary>Button for new army eventargs</summary>
    /// <seealso cref="System.EventArgs" />
    public class ButtonNewArmyEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="ButtonNewArmyEventArgs"/> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="points">The points.</param>
        public ButtonNewArmyEventArgs(string name, int points)
        {
            this.ArmyName = name;
            this.Points = points;
        }

        /// <summary> Gets or sets the army name</summary>
        public string ArmyName { get; set; }

        /// <summary> Gets or sets the points</summary>
        public int Points { get; set; }
    }
}