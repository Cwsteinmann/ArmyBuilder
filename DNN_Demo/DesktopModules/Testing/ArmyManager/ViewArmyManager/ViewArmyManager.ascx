<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ViewArmyManager.ascx.cs" Inherits="Testing.Dnn.ArmyManager.ViewArmyManager" %>
<%@ Register TagPrefix="Testing" TagName="UnitForm" Src="./Controls/UnitForm.ascx" %>

<div>
    <Testing:UnitForm runat="server" ID="t1Form" DisplayUnit="<%#this.Model.DisplayUnit %>" />
</div>
