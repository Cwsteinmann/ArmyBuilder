// <copyright file="IViewArmyManagerView.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;

    using DotNetNuke.Web.Mvp;

    /// <summary>The contract of the main view</summary>
    public interface IViewArmyManagerView : IModuleView<ViewArmyManagerViewModel>
    {
        /// <summary>
        /// Event for setting rule upgrades
        /// </summary>
        event EventHandler<RuleUpgradeCheckedEventArgs> RuleUpgradeChecked;

        event EventHandler<ButtonNewUnitEventArgs> ButtonNewUnitClicked;

        /// <summary>
        /// event for setting size of unit
        /// </summary>
        event EventHandler<ButtonSubmitSizeEventArgs> ButtonSubmitClicked;

        /// <summary>
        /// event for creating a new army
        /// </summary>
        event EventHandler<ButtonNewArmyEventArgs> ButtonNewArmyClicked;
    }

}
