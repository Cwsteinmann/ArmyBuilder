<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="UnitForm.ascx.cs" Inherits="Testing.Dnn.ArmyManager.UnitForm" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Runtime.CompilerServices" %>

<div>
    <h5> <%#:this.DisplayUnit.UnitData.Name %>  <span ID="SmallerHeader" style="font-size: 16px">Size: <%#: this.DisplayUnit.SizeData.InitialSize %> - <%#: this.DisplayUnit.SizeData.MaxSize %></span></h5>
    
    <p>Type : <%#: this.DisplayUnit.UnitData.Type%> &nbsp;&nbsp;&nbsp; Slot Type : <%#: this.DisplayUnit.UnitData.SlotType %></p>
   
    <p>Total Cost : <%#:this.DisplayUnit.UnitData.Cost %></p>
    
    <table class="dnnGrid">
        <thead>
            <tr class="dnnGridHeader">
            <% foreach (var key in this.DisplayUnit.UnitData.Stats.Keys) { %>
                <th><%: key %></th>
                <% } %>
            </tr>
        </thead>
    
        <tbody>
            <tr class="dnnGridItem"><% foreach (var value in this.DisplayUnit.UnitData.Stats.Values) { %>
            <td><%: value %></td>
            <% } %>
            </tr> 
        </tbody>
        </table>
    
    <div>
        <asp:Label runat="server" >Size: </asp:Label>
        <asp:TextBox runat="server" ID="SizeInput" Text="<%#:this.DisplayUnit.SizeData.CurrentSize %>" Style="text-align:right; width:75px;"/>
        <asp:Button runat="server" ID="ButtonSetSize" Text="Set Unit Size"/>
    </div>

    <div ID="UnitRulesDiv">
        <h4>Special Rules:</h4>
        <ul ID="rulesList">
            <% foreach (var rule in this.DisplayUnit.Rules) { %>
                <li><%: rule.Name %></li>
            <% } %>
        </ul>
    
        <asp:CheckBoxList runat="server" 
                          ID="RuleUpgradesCheckBoxList"
                          DataSource="<%# this.DisplayUnit.RuleOptions %>"
                          ItemType="Testing.Dnn.ArmyManager.ViewArmyManagerViewModel.RuleUpgradeViewModel"
                          DataTextField="DisplayString"
                          DataValueField="Name"
                          RepeatLayout="UnorderedList"
                          AutoPostBack="True"
                          OnSelectedIndexChanged="RuleUpgradesCheckBoxList_OnSelectedIndexChanged"
                          OnDataBound="RuleUpgradesCheckBoxList_OnDataBound"/>
    </div>
        
    <div ID="UnitWargearDiv">
        <asp:Repeater runat="server" ID="WargearRepeater" DataSource="<%#this.DisplayUnit.Wargear %>" ItemType="Testing.Dnn.ArmyManager.ViewArmyManagerViewModel.WarGearViewModel">
            <HeaderTemplate>
                <ul style="margin-left: 0;"> 
            </HeaderTemplate>
            <ItemTemplate>
                <li style="list-style-type: none;">
                    <asp:TextBox runat="server" ID="WargearInput" Text="<%#:Item.NumberOfThings %>" Style="text-align:right; width:50px;"/>
                    <asp:Label runat="server" ID="WargearLabel" AssociatedControlID="WargearInput">
                        <span><%#: Item.DisplayString %></span>
                    </asp:Label>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
                <asp:Button runat="server" Text="Set Wargear"/>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>

<script runat="server">
    
    


</script>