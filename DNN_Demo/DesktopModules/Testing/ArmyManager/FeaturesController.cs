// <copyright file="FeaturesController.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System.Diagnostics.CodeAnalysis;

    using Engage.Annotations;

    /// <summary>Contains basic information about the module and exposes which DNN integration points the module implements</summary>
    [UsedImplicitly]
    [SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors", Justification = "DNN instantiates this class via reflection, so it needs an accessible constructor")]
    public class FeaturesController
    {
        /// <summary>The prefix to use for settings names</summary>
        public const string SettingsPrefix = "Army Manager";
    }
}
