<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="EditUnit.ascx.cs" Inherits="Testing.Dnn.ArmyManager.EditUnit" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Runtime.CompilerServices" %>

<div>
    
    <h2> <%#:this.Model.DisplayUnit.UnitData.Name %></h2>
    
    <asp:HiddenField runat="server" ID="UnitIdHiddenField" Value="<%#:this.Model.DisplayUnit.Unit.UnitID %>"/>
    <p><%: this.LocalizeString("Size.Text") %> <%#: this.Model.DisplayUnit.SizeData.InitialSize %> - <%#: this.Model.DisplayUnit.SizeData.MaxSize %></p>
    <p><%: this.LocalizeString("Type.Text") %> <%#: this.Model.DisplayUnit.UnitData.Type%> &nbsp;&nbsp;&nbsp; <%: this.LocalizeString("Slot Type.Text") %> <%#: this.Model.DisplayUnit.UnitData.SlotType %></p>
   
    <p><%: this.LocalizeString("Total Cost.Text") %> <%#:this.Model.DisplayUnit.UnitData.Cost %></p>
    
    <table class="dnnGrid">
        <thead>
            <tr class="dnnGridHeader">
            <% foreach (var key in this.Model.DisplayUnit.UnitData.Stats.Keys) { %>
                <th><%: key %></th>
                <% } %>
            </tr>
        </thead>
    
        <tbody>
            <tr class="dnnGridItem"><% foreach (var value in this.Model.DisplayUnit.UnitData.Stats.Values) { %>
            <td><%: value %></td>
            <% } %>
            </tr> 
        </tbody>
        </table>
    
    <div>
        <asp:Label runat="server" ><%: this.LocalizeString("Size.Text") %> </asp:Label>
        <asp:TextBox runat="server" ID="SizeInput" Text="<%#:this.Model.DisplayUnit.SizeData.CurrentSize %>" Style="text-align:right; width:75px;"/>
        <asp:Button runat="server" ID="ButtonSetSize" class="dnnSecondaryAction" Text='<%#: this.LocalizeString("Set Unit Size.Text") %>' OnClick="ButtonSetSize_Click"/>
    </div>

    <div ID="UnitRulesDiv" class="dnnLeft">
        <h4><%: this.LocalizeString("Special Rules.Text") %></h4>
        <ul ID="rulesList">
            <% foreach (var rule in this.Model.DisplayUnit.Rules) { %>
                <li><%: rule.Name %></li>
            <% } %>
        </ul>
    
        <asp:CheckBoxList runat="server" 
                          ID="RuleUpgradesCheckBoxList"
                          DataSource="<%# this.Model.DisplayUnit.RuleOptions %>"
                          ItemType="Testing.Dnn.ArmyManager.ViewArmyManagerViewModel.RuleUpgradeViewModel"
                          DataTextField="DisplayString"
                          DataValueField="Name"
                          RepeatLayout="UnorderedList"
                          AutoPostBack="True"
                          OnSelectedIndexChanged="RuleUpgradesCheckBoxList_OnSelectedIndexChanged"
                          OnDataBound="RuleUpgradesCheckBoxList_OnDataBound"/>
    </div>

    <asp:Panel runat="server" class="dnnLeft" Style="margin-left:50px;" ID="UnitWargearPanel" Visible="<%# !string.IsNullOrEmpty(this.Model.DisplayUnit.Unit.InitialWargear) %>">
        <div ID="WargearUpgades" >
        <h4><%: this.LocalizeString("Wargear.Text") %></h4>
        <asp:Repeater runat="server" ID="WargearRepeater" DataSource="<%#this.Model.DisplayUnit.Wargear %>" ItemType="Testing.Dnn.ArmyManager.ViewArmyManagerViewModel.WarGearViewModel" Visible="<%# (this.Model.DisplayUnit.Unit.CanUpgradeWargear) %>">
            <HeaderTemplate>
                <ul style="margin-left: 0;"> 
            </HeaderTemplate>
            <ItemTemplate>
                <li style="list-style-type: none;">
                    <asp:TextBox runat="server" ID="WargearInput" Text="<%#:Item.NumberOfThings %>" Style="text-align:right; width:50px;"/>
                    <asp:Label runat="server" ID="WargearLabel" AssociatedControlID="WargearInput">
                        <span><%#: Item.DisplayString %></span>
                    </asp:Label>
                     <asp:HiddenField runat="server" ID="WargearHiddenField" Value="<%#:Item.Name %>"/>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
                <asp:Button runat="server" Text='<%#: this.LocalizeString("Set Wargear.Text") %>' OnClick="ButtonWargear_Click" ID="ButtonWargear" class="dnnSecondaryAction"/>
            </FooterTemplate>
        </asp:Repeater>
        </div>
        
        <div ID="SelectedWargear" >
            <asp:Repeater runat="server" ID="SelectedWargearRepeater" DataSource="<%# this.Model.DisplayUnit.Unit.SelectedWargearUpgrades %>" ItemType="System.Collections.Generic.KeyValuePair`2[System.String, System.Int32]"> 
                <HeaderTemplate>
                    <h4>Selected Wargear</h4>
                    <ul ID="WargearList">
                </HeaderTemplate>
                <ItemTemplate>
                    <li runat="server" Visible="<%# Item.Value > 0 %>"> <%#: Item.Value %>  <%#: Item.Key %></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
         </div>
    </asp:Panel>
    
</div>
