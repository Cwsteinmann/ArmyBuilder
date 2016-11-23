// <copyright file="ViewArmyManagerPresenter.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;
    using System.Globalization;

    using DotNetNuke.Services.Localization;
    using DotNetNuke.Web.Mvp;

    using WebFormsMvp;

    /// <summary>Acts as a presenter for <see cref="IViewArmyManagerView"/></summary>
    public sealed class ViewArmyManagerPresenter : ModulePresenter<IViewArmyManagerView, ViewArmyManagerViewModel>
    {
        /// <summary>Initializes a new instance of the <see cref="ViewArmyManagerPresenter"/> class.</summary>
        /// <param name="view">The view.</param>
        public ViewArmyManagerPresenter(IViewArmyManagerView view)
            : base(view)
        {
            this.View.Initialize += this.View_Initialize;
        }

        /// <summary>Gets the sample setting value.</summary>
        /// <value>The sample setting.</value>
        private string SampleSetting
        {
            get { return ArmyManagerSettings.SampleSetting.GetValueAsStringFor(FeaturesController.SettingsPrefix, this.ModuleContext.Configuration, ArmyManagerSettings.SampleSetting.DefaultValue); }
        }

        /// <summary>Handles the <see cref="IModuleViewBase.Initialize"/> event of the <see cref="Presenter{TView}.View"/>.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void View_Initialize(object sender, EventArgs e)
        {
            try
            {
                this.View.Model.SampleSettingMessage = string.Format(CultureInfo.CurrentCulture, Localization.GetString("SettingLabel.Format", this.LocalResourceFile), this.SampleSetting);
            }
            catch (Exception exc)
            {
                this.ProcessModuleLoadException(exc);
            }
        }
    }
}
