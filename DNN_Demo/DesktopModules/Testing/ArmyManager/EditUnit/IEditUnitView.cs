// <copyright file="IEditUnitView.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;

    using DotNetNuke.Web.Mvp;

    using Testing.Dnn.ArmyManager.ArmyManager.EditUnit;

    /// <summary>
    /// The contract of the edit view
    /// </summary>
    public interface IEditUnitView : IModuleView<EditUnitViewModel>
    {
        /// <summary>Occurs when [button set size clicked].</summary>
        event EventHandler<ButtonSetSizeEventArgs> ButtonSetSizeClicked;

        /// <summary>Occurs when [button wargear clicked].</summary>
        event EventHandler<ButtonWargearEventArgs> ButtonWargearClicked;

        /// <summary>Occurs when [rule upgrades selected index changed].</summary>
        event EventHandler<RuleUpgradeCheckedEventArgs> RuleUpgradesSelectedIndexChanged;
    }
}
