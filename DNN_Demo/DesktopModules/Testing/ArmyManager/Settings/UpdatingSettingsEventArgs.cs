// <copyright file="UpdatingSettingsEventArgs.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;

    /// <summary>Contains data about the settings that have been updated by <see cref="ISettingsView"/></summary>
    public class UpdatingSettingsEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="UpdatingSettingsEventArgs"/> class.</summary>
        public UpdatingSettingsEventArgs()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="UpdatingSettingsEventArgs"/> class.</summary>
        /// <param name="sampleSetting">The value of the sample setting.</param>
        public UpdatingSettingsEventArgs(string sampleSetting)
        {
            this.SampleSetting = sampleSetting;
        }

        /// <summary>Gets the sample setting.</summary>
        public string SampleSetting { get; private set; }
    }
}
