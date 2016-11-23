// <copyright file="ViewArmyManagerViewModel.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using Testing.Dnn.ArmyManager.ArmyManager;

    /// <summary>The view model for the Army Manager, to be displayed by <see cref="IViewArmyManagerView"/></summary>
    public class ViewArmyManagerViewModel
    {
        /// <summary>Gets or sets the unit to display.</summary>
        public Unit DisplayUnit { get; set; }
    }
}
