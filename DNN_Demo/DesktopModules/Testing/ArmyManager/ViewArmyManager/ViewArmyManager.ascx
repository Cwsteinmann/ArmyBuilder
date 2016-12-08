<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ViewArmyManager.ascx.cs" Inherits="Testing.Dnn.ArmyManager.ViewArmyManager" %>
<%@ Import Namespace="Testing.Dnn.ArmyManager" %>
<%@ Register TagPrefix="Testing" TagName="UnitForm" Src="./Controls/UnitForm.ascx" %>

<div>
    <asp:Panel runat="server" Visible="<%# (this.Model.IsLoading == false && this.Model.ArmyID == 0) %>">
        <asp:Label runat="server"> <%: this.LocalizeString("Army Name.Text") %> </asp:Label><asp:TextBox runat="server" ID="NewArmyName"></asp:TextBox>
        <asp:Label runat="server"> <%: this.LocalizeString("Points Limit.Text") %></asp:Label><asp:TextBox runat="server" ID="NewArmyPointsLimit"></asp:TextBox>
        <asp:Button runat="server" Text='<%#: this.LocalizeString("New Army.Text") %>' OnClick="OnButtonNewArmyClicked" class="dnnSecondaryAction" />
        <asp:Button runat="server" Text='<%#: this.LocalizeString("Load Army.Text") %>' OnClick="OnButtonLoadArmyClicked" class="dnnSecondaryAction" />
        
    </asp:Panel>
    
    <asp:Panel runat="server" Visible="<%# this.Model.IsLoading %>">
        <table class="dnnGrid">
            <thead>
                <tr class="dnnGridHeader">
                    <th><%: this.LocalizeString("Army Name.Text") %></th>
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
                        <td><asp:Button runat="server" ID="ButtonSelectArmy" Text="Select Army" CommandArgument="<%# Item.Key %>" class="dnnSecondaryAction"/></td>
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
            <asp:ListItem Value="Hive Tyrant" >Hive Tyrant</asp:ListItem>
            <asp:ListItem Value="Hive Guard">Hive Guard</asp:ListItem>
            <asp:ListItem Value="Lictor Brood">Lictor Brood</asp:ListItem>
            <asp:ListItem Value="Zoanthrope Brood">Zoanthrope Brood</asp:ListItem>
            <asp:ListItem Value="Venomthrope Brood">Venomthrope Brood</asp:ListItem>
        </asp:DropDownList>
        <asp:Button runat="server" Text="Add New Unit" OnClick="OnButtonAddNewUnitClicked" Class="dnnSecondaryAction" />
        
        
                <asp:Repeater runat="server" DataSource="<%# this.HQUnits %>" OnItemCommand="OnButtonDeleteUnitClicked" ItemType="Testing.Dnn.ArmyManager.ViewArmyManagerViewModel.UnitViewModel">
                    <HeaderTemplate>
                
                        <h4><%: this.LocalizeString("HQ Choices.Text") %></h4>
                        <hr />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <p><%#: Item.UnitData.Name %> : <%#: Item.UnitData.Cost %></p>
                        <a href="<%#:Item.EditUrl %>" class="dnnSecondaryAction">Edit Unit</a>
                        <asp:Button runat="server" ID="ButtonDeleteUnit" Text="Delete Unit" CommandArgument="<%# Item.Unit.UnitID %>" class="dnnSecondaryAction" />
                        <hr/>
                    </ItemTemplate>
                </asp:Repeater>
        
                <asp:Repeater runat="server" OnItemCommand="OnButtonDeleteUnitClicked" DataSource="<%# this.TroopUnits %>" ItemType="Testing.Dnn.ArmyManager.ViewArmyManagerViewModel.UnitViewModel">
                    <HeaderTemplate>
                        <h4><%: this.LocalizeString("Troops Choices.Text") %></h4>
                        <hr />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <p><%#: Item.UnitData.Name %> : <%#: Item.UnitData.Cost %></p>
                        <a href="<%#:Item.EditUrl %>" class="dnnSecondaryAction">Edit Unit</a>
                        <asp:Button runat="server" ID="ButtonDeleteUnit" Text="Delete Unit" CommandArgument="<%# Item.Unit.UnitID %>" class="dnnSecondaryAction" />
                        <hr/>
                    </ItemTemplate>
                </asp:Repeater>
          
                <asp:Repeater runat="server" OnItemCommand="OnButtonDeleteUnitClicked" DataSource="<%# this.ElitesUnits %>" ItemType="Testing.Dnn.ArmyManager.ViewArmyManagerViewModel.UnitViewModel">
                    <HeaderTemplate>
                        <h4><%: this.LocalizeString("Elites Choices.Text") %></h4>
                        <hr />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <p><%#: Item.UnitData.Name %> : <%#: Item.UnitData.Cost %></p>
                        <a href="<%#:Item.EditUrl %>" class="dnnSecondaryAction">Edit Unit</a>
                        <asp:Button runat="server" ID="ButtonDeleteUnit" Text="Delete Unit" CommandArgument="<%# Item.Unit.UnitID %>" class="dnnSecondaryAction" />
                        <hr/>
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

    public IEnumerable<ViewArmyManagerViewModel.UnitViewModel> ElitesUnits {
        get
        {
            return this.Model.Army.Where(unit => unit.UnitData.SlotType == "Elites");
        }
    }
</script>


