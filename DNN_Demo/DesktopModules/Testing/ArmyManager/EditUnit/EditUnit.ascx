<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="EditUnit.ascx.cs" Inherits="Testing.Dnn.ArmyManager.EditUnit" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Runtime.CompilerServices" %>

<div>
    
    <h2> <%#:this.Model.DisplayUnit.UnitData.Name %></h2>
    
    <asp:HiddenField runat="server" ID="UnitIdHiddenField" Value="<%#:this.Model.DisplayUnit.Unit.UnitID %>"/>
    <p> Size: <%#: this.Model.DisplayUnit.SizeData.InitialSize %> - <%#: this.Model.DisplayUnit.SizeData.MaxSize %></p>
    <p>Type : <%#: this.Model.DisplayUnit.UnitData.Type%> &nbsp;&nbsp;&nbsp; Slot Type : <%#: this.Model.DisplayUnit.UnitData.SlotType %></p>
   
    <p>Total Cost : <%#:this.Model.DisplayUnit.UnitData.Cost %></p>
    
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
        <asp:Label runat="server" >Size: </asp:Label>
        <asp:TextBox runat="server" ID="SizeInput" Text="<%#:this.Model.DisplayUnit.SizeData.CurrentSize %>" Style="text-align:right; width:75px;"/>
        <asp:Button runat="server" ID="ButtonSetSize" Text="Set Unit Size" OnClick="ButtonSetSize_Click"/>
    </div>

    <div ID="UnitRulesDiv">
        <h4>Special Rules:</h4>
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
        
    <div ID="UnitWargearDiv">
        <asp:Repeater runat="server" ID="WargearRepeater" DataSource="<%#this.Model.DisplayUnit.Wargear %>" ItemType="Testing.Dnn.ArmyManager.ViewArmyManagerViewModel.WarGearViewModel">
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
                <asp:Button runat="server" Text="Set Wargear" OnClick="ButtonWargear_Click" ID="ButtonWargear"/>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    
</div>
