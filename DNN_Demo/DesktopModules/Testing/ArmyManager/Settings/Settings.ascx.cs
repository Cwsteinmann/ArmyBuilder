// <copyright file="Settings.ascx.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;

    using DotNetNuke.UI.Modules;
    using DotNetNuke.Web.Mvp;

    using WebFormsMvp;

    /// <summary>Displays the module's settings</summary>
    [PresenterBinding(typeof(SettingsPresenter))]
    public partial class Settings : ModuleView<SettingsViewModel>, ISettingsView, ISettingsControl
    {
        /// <summary>Occurs when <see cref="ISettingsControl.LoadSettings"/> is called.</summary>
        public event EventHandler<EventArgs> LoadingSettings;

        /// <summary>Occurs when <see cref="ISettingsControl.UpdateSettings"/> is called.</summary>
        public event EventHandler<UpdatingSettingsEventArgs> UpdatingSettings;

        /// <summary>Loads the settings.</summary>
        public void LoadSettings()
        {
            this.LoadingSettings?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>Updates the settings.</summary>
        public void UpdateSettings()
        {
            this.UpdatingSettings?.Invoke(this, new UpdatingSettingsEventArgs(this.SampleSettingTextBox.Text));
        }
    }
}
