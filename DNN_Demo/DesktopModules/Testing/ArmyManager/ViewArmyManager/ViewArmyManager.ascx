<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ViewArmyManager.ascx.cs" Inherits="Testing.Dnn.ArmyManager.ViewArmyManager" %>
<%@ Import Namespace="Testing.Dnn.ArmyManager" %>
<%@ Register TagPrefix="Testing" TagName="UnitForm" Src="./Controls/UnitForm.ascx" %>

<div>
    <asp:Panel runat="server" Visible="<%# (this.Model.IsLoading == false && this.Model.ArmyID == 0) %>">
        <asp:Label runat="server">Army Name: </asp:Label><asp:TextBox runat="server" ID="NewArmyName"></asp:TextBox>
        <asp:Label runat="server">Points Limit: </asp:Label><asp:TextBox runat="server" ID="NewArmyPointsLimit"></asp:TextBox>
        <asp:Button runat="server" Text="New Army" OnClick="OnButtonNewArmyClicked"/>
        <asp:Button runat="server" Text="Load Army" OnClick="OnButtonLoadArmyClicked"/>
        <!-- TODO: Add Button events -->
    </asp:Panel>
    
    <asp:Panel runat="server" Visible="<%# this.Model.IsLoading %>">
        <table class="dnnGrid">
            <thead>
                <tr class="dnnGridHeader">
                    <th>Army Name</th>
                    <th></th>
                </tr>
            </thead>
    
           
            <asp:Repeater runat="server" ID="SelectArmyRepeater" OnItemCommand="OnButtonSelectArmyClicked" DataSource=" <%# this.Model.ArmiesToLoad %> " ItemType="System.Collections.Generic.KeyValuePair`2[System.Int32, System.String]">
                <HeaderTemplate>
                    <tbody>
                </HeaderTemplate>   
                <ItemTemplate>
                    
                    <tr class="dnnGridItem">
                        <td><%#: Item.Value %></td>
                        <td><asp:Button runat="server" ID="ButtonSelectArmy" Text="Select Army" CommandArgument="<%# Item.Key %>"/></td>
                    </tr> 
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>  
                </FooterTemplate>
            </asp:Repeater>
        </table>

    </asp:Panel>
    
    <asp:Panel runat="server" Visible="<%# (this.Model.ArmyID != 0) %>">
        <h2><%#: this.Model.Name %></h2>
        
        <!-- TODO: Put DDL in a repeater -->
        <asp:DropDownList runat="server" ID="NewUnitDDL">
            <asp:ListItem Value="Termagant" Selected="True">Termagant</asp:ListItem>
        </asp:DropDownList>
        <asp:Button runat="server" Text="Add New Unit" OnClick="OnButtonAddNewUnitClicked"/>
        
        
        <div class="dnnForm" id="panels-demo">
            <div class="dnnFormExpandContent"><a href="">Expand All</a></div>
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
                        <Testing:UnitForm runat="server" DisplayUnit="<%# Item %>" OnButtonSetSizeClicked="OnButtonSetSizeClicked" OnButtonDeleteUnitClicked="OnButtonDeleteUnitClicked" OnRuleUpgradesSelectedIndexChanged="OnRuleUpgradesSelectedIndexChanged" OnButtonWargearClicked="OnButtonWargearClicked"/>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        
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

<script type="text/javascript">
    
    jQuery(function ($) {
        var setupModule = function () {
            $('#panels-demo').dnnPanels();
            $('#panels-demo .dnnFormExpandContent a').dnnExpandAll({
                targetArea: '#panels-demo'
            });
        };
        setupModule();
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            setupModule();
        });
    });

</script>
