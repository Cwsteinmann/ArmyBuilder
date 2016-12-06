// <copyright file="ViewArmyManagerPresenter.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;
    using System.Linq;

    using DotNetNuke.Web.Mvp;

    using WebFormsMvp;

    /// <summary>Acts as a presenter for <see cref="IEditUnitView"/></summary>
    public sealed class EditUnitPresenter : ModulePresenter<IEditUnitView, EditUnitViewModel>
    {
        /// <summary>Initializes a new instance of the <see cref="EditUnitPresenter"/> class.</summary>
        /// <param name="view">The view.</param>
        public EditUnitPresenter(IEditUnitView view)
            : base(view)
        {
            this.View.Initialize += this.View_Initialize;
        }

        /// <summary>Handles the <see cref="IModuleViewBase.Initialize"/> event of the <see cref="Presenter{TView}.View"/>.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void View_Initialize(object sender, EventArgs e)
        {
        }
    }
}
