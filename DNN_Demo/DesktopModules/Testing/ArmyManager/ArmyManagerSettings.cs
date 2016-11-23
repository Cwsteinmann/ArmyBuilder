// <copyright file="ArmyManagerSettings.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System.Diagnostics.CodeAnalysis;

    using Engage.Dnn.Framework;

    /// <summary>A collection of the <see cref="Setting{T}"/>s for this module</summary>
    public static class ArmyManagerSettings
    {
        /// <summary>A sample setting for this module</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "Setting<T> is immutable")]
        public static readonly Setting<string> SampleSetting = new Setting<string>("SampleSetting", SettingScope.TabModule, "Default Value");
    }
}
