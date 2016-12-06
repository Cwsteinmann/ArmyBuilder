// <copyright file="IViewArmyManagerView.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;

    using DotNetNuke.Web.Mvp;

    public interface IEditUnitView : IModuleView<EditUnitViewModel>
    {
        event EventHandler<ButtonSetSizeEventArgs> ButtonSetSizeClicked;

        event EventHandler<ButtonWargearEventArgs> ButtonWargearClicked;

        event EventHandler<RuleUpgradeCheckedEventArgs> RuleUpgradesSelectedIndexChanged;
    }

}
