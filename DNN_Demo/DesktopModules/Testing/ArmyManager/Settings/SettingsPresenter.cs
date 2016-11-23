// <copyright file="SettingsPresenter.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;
    using System.Linq;

    using DotNetNuke.Web.Mvp;

    using WebFormsMvp;

    /// <summary>Acts as a presenter for <see cref="ISettingsView"/></summary>
    public class SettingsPresenter : ModulePresenter<ISettingsView, SettingsViewModel>
    {
        /// <summary>Initializes a new instance of the <see cref="SettingsPresenter"/> class.</summary>
        /// <param name="view">The view.</param>
        public SettingsPresenter(ISettingsView view)
            : base(view)
        {
            this.View.Initialize += this.View_Initialize;
            this.View.UpdatingSettings += this.View_UpdatingSettings;
        }

        /// <summary>Handles the <see cref="IModuleViewBase.Initialize"/> event of the <see cref="Presenter{TView}.View"/> control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void View_Initialize(object sender, EventArgs e)
        {
            try
            {
                this.View.Model.SampleSetting = ArmyManagerSettings.SampleSetting.GetValueAsStringFor(FeaturesController.SettingsPrefix, this.ModuleContext.Configuration, ArmyManagerSettings.SampleSetting.DefaultValue);
            }
            catch (Exception exc)
            {
                this.ProcessModuleLoadException(exc);
            }
        }

        /// <summary>Handles the <see cref="ISettingsView.UpdatingSettings"/> event of the <see cref="Presenter{TView}.View"/> control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="UpdatingSettingsEventArgs"/> instance containing the event data.</param>
        private void View_UpdatingSettings(object sender, UpdatingSettingsEventArgs e)
        {
            try
            {
                ArmyManagerSettings.SampleSetting.Set(FeaturesController.SettingsPrefix, this.ModuleContext.Configuration, e.SampleSetting);
            }
            catch (Exception exc)
            {
                this.ProcessModuleLoadException(exc);
            }
        }
    }
}
