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
        <h3><%#: this.Model.GetCurrentCost %> / <%#: this.Model.MaxPoints %> Points</h3>
        <asp:Label runat="server" ID="PointsValidationLabel" Visible="False" ></asp:Label>
        <asp:DropDownList runat="server" ID="UnitTypeDDL" DataSource="<%#this.ListOfTypes %>" AutoPostBack="true" OnSelectedIndexChanged="UnitTypeDDL_OnSelectedIndexChanged" CausesValidation="True" ValidationGroup="ArmyManager"/>
        <asp:CustomValidator runat="server" ControlToValidate="UnitTypeDDL" ValidationGroup="ArmyManager" OnServerValidate="OnServerValidate" ID="UnitTypeValidator" ErrorMessage='<%#: this.Model.ErrorMessage %>'/>
        <asp:DropDownList runat="server" ID="NewUnitDDL" Visible="False"></asp:DropDownList>
        <asp:Button runat="server" ID="SelectUnitButton" Text="Add New Unit" OnClick="OnButtonAddNewUnitClicked" Class="dnnSecondaryAction" Visible="false"/>
        
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
                
                 <asp:Repeater runat="server" OnItemCommand="OnButtonDeleteUnitClicked" DataSource="<%# this.FAUnits %>" ItemType="Testing.Dnn.ArmyManager.ViewArmyManagerViewModel.UnitViewModel">
                    <HeaderTemplate>
                        <h4><%: this.LocalizeString("Fast Attack Choices.Text") %></h4>
                        <hr />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <p><%#: Item.UnitData.Name %> : <%#: Item.UnitData.Cost %></p>
                        <a href="<%#:Item.EditUrl %>" class="dnnSecondaryAction">Edit Unit</a>
                        <asp:Button runat="server" ID="ButtonDeleteUnit" Text="Delete Unit" CommandArgument="<%# Item.Unit.UnitID %>" class="dnnSecondaryAction" />
                        <hr/>
                    </ItemTemplate>
                </asp:Repeater>
        
                <asp:Repeater runat="server" OnItemCommand="OnButtonDeleteUnitClicked" DataSource="<%# this.HSUnits %>" ItemType="Testing.Dnn.ArmyManager.ViewArmyManagerViewModel.UnitViewModel">
                    <HeaderTemplate>
                        <h4><%: this.LocalizeString("Heavy Support Choices.Text") %></h4>
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

    public List<string> ListOfTypes = new List<string> { "Select a Unit Type", "HQ", "Troops", "Elites", "Fast Attack", "Heavy Support" };

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

    public IEnumerable<ViewArmyManagerViewModel.UnitViewModel> FAUnits {
        get
        {
            return this.Model.Army.Where(unit => unit.UnitData.SlotType == "Fast Attack");
        }
    }

    public IEnumerable<ViewArmyManagerViewModel.UnitViewModel> HSUnits {
        get
        {
            return this.Model.Army.Where(unit => unit.UnitData.SlotType == "Heavy Support");
        }
    }
</script>


