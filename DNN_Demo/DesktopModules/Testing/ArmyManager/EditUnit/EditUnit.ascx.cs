// <copyright file="ViewArmyManager.ascx.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Web.UI.WebControls;

    using DotNetNuke.Entities.Modules;
    using DotNetNuke.Web.Mvp;

    using WebFormsMvp;

    [PresenterBinding(typeof(EditUnitPresenter))]
    public partial class EditUnit : ModuleView<EditUnitViewModel>, IEditUnitView
    {
    }
}
