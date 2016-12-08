// <copyright file="ButtonSetSizeEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>


namespace Testing.Dnn.ArmyManager.ArmyManager.EditUnit
{

    using System.Linq;
    using global::System;

    /// <summary>Unit Size Button Handler</summary>
    /// <seealso cref="System.EventArgs" />
    public class ButtonSetSizeEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="ButtonSetSizeEventArgs"/> class.</summary>
        /// <param name="size">The size.</param>
        /// <param name="unitID">The unit identifier.</param>
        public ButtonSetSizeEventArgs(int size, int unitID)
        {
            this.Size = size;
            this.UnitID = unitID;
        }

        /// <summary>Gets the size.</summary>
        /// <value>The size.</value>
        public int Size { get; private set; }

        /// <summary>Gets the unit identifier.</summary>
        /// <value>The unit identifier.</value>
        public int UnitID { get; private set; }
    }
}