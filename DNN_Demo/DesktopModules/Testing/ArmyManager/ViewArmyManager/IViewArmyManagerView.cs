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
        event EventHandler<ButtonNewUnitEventArgs> ButtonNewUnitClicked;

        event EventHandler<ButtonDeleteUnitEventArgs> ButtonDeleteUnitClicked;

        event EventHandler<RuleUpgradeCheckedEventArgs> RuleUpgradesSelectedIndexChanged;

        event EventHandler<EventArgs> ButtonLoadArmyClicked;

        event EventHandler<ButtonSelectArmyEventArgs> ButtonSelectArmyClicked;

        /// <summary>
        /// event for creating a new army
        /// </summary>
        event EventHandler<ButtonNewArmyEventArgs> ButtonNewArmyClicked;

        event EventHandler<ButtonSetSizeEventArgs> ButtonSetSizeClicked;

        event EventHandler<ButtonWargearEventArgs> ButtonWargearClicked;
    }

}
