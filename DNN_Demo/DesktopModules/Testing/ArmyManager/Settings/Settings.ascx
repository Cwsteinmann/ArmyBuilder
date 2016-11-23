<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="Settings.ascx.cs" Inherits="Testing.Dnn.ArmyManager.Settings" %>
<asp:Label runat="server" ResourceKey="SampleSettingName" />
<asp:TextBox ID="SampleSettingTextBox" runat="server" CssClass="NormalTextBox" Text='<%# Model.SampleSetting %>' />
