// <copyright file="IViewArmyManagerView.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;
    using System.Web.UI.WebControls;

    using DotNetNuke.Web.Mvp;

    using Testing.Dnn.ArmyManager.ArmyManager.ViewArmyManager;

    /// <summary>
    /// The contract of the main view
    /// </summary>
    public interface IViewArmyManagerView : IModuleView<ViewArmyManagerViewModel>
    {
        /// <summary>
        /// Occurs when [button new unit clicked].
        /// </summary>
        event EventHandler<ButtonNewUnitEventArgs> ButtonNewUnitClicked;

        /// <summary>
        /// Occurs when [button delete unit clicked].
        /// </summary>
        event EventHandler<ButtonDeleteUnitEventArgs> ButtonDeleteUnitClicked;

        /// <summary>
        /// Occurs when [button load army clicked].
        /// </summary>
        event EventHandler<EventArgs> ButtonLoadArmyClicked;

        /// <summary>
        /// Occurs when [button select army clicked].
        /// </summary>
        event EventHandler<ButtonSelectArmyEventArgs> ButtonSelectArmyClicked;

        /// <summary>
        /// event for creating a new army
        /// </summary>
        event EventHandler<ButtonNewArmyEventArgs> ButtonNewArmyClicked;

        event EventHandler<ServerValidateEventArgs> ServerValidate;
    }
}
