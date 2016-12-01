<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ViewArmyManager.ascx.cs" Inherits="Testing.Dnn.ArmyManager.ViewArmyManager" %>
<%@ Import Namespace="Testing.Dnn.ArmyManager" %>
<%@ Register TagPrefix="Testing" TagName="UnitForm" Src="./Controls/UnitForm.ascx" %>

<div>
    <asp:Panel runat="server" Visible="<%# (this.Model.IsLoading == false ) %>">
        <asp:Label runat="server">Army Name: </asp:Label><asp:TextBox runat="server" ID="NewArmyName"></asp:TextBox>
        <asp:Label runat="server">Points Limit: </asp:Label><asp:TextBox runat="server" ID="NewArmyPointsLimit"></asp:TextBox>
        <asp:Button runat="server" Text="New Army" OnClick="OnButtonNewArmyClicked"/>
        <asp:Button runat="server" Text="Load Army" />
        <!-- TODO: Add Button events -->
    </asp:Panel>
    
    <asp:Panel runat="server" Visible="<%# this.Model.IsLoading %>">
        <!-- TODO: Add loading army table -->

    </asp:Panel>
    
    <asp:Panel runat="server" Visible="<%# (this.Model.IsLoading == true) %>">
        <h2><%#: this.Model.Name %></h2>
        <asp:Repeater runat="server" DataSource="<%# this.HQUnits %>" ItemType="Testing.Dnn.ArmyManager.ViewArmyManagerViewModel.UnitViewModel">
            <HeaderTemplate>
                <h4>HQ choices</h4>
                <hr />
            </HeaderTemplate>
            <ItemTemplate>
                <Testing:UnitForm runat="server" DisplayUnit="<%# Item %>"/>
            </ItemTemplate>
        </asp:Repeater>
        
        <asp:Repeater runat="server" DataSource="<%# this.TroopUnits %>" ItemType="Testing.Dnn.ArmyManager.ViewArmyManagerViewModel.UnitViewModel">
            <HeaderTemplate>
                <h4>Troop choices</h4>
                <hr />
            </HeaderTemplate>
            <ItemTemplate>
                <Testing:UnitForm runat="server" DisplayUnit="<%# Item %>"/>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
</div>

<script runat="server">

    public IEnumerable<ViewArmyManagerViewModel.UnitViewModel> HQUnits {
        get
        {
            return this.Model.Army.Where(unit => unit.UnitData.SlotType == "HQ");
        }
    }

    public IEnumerable<ViewArmyManagerViewModel.UnitViewModel> TroopUnits {
        get
        {
            return this.Model.Army.Where(unit => unit.UnitData.SlotType == "Troops");
        }
    }
</script>
