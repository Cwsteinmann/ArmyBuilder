<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="UnitForm.ascx.cs" Inherits="Testing.Dnn.ArmyManager.UnitForm" %>
<%@ Import Namespace="System.Globalization" %>

<div>
    <h3><%: this.DisplayUnit.name %></h3>
    <h4><%: this.DisplayUnit.totalCost %> points</h4>
    <span>
        <h5><%: string.Format("{0} ({1}/{2})", this.DisplayUnit.currentSize, this.DisplayUnit.initialSize, this.DisplayUnit.maxSize) %> </h5>
        <asp:TextBox runat="server" ID="sizeInput" />
        <%--
        <asp:Button runat="server" ID="btnSize" OnClick="submitSize" Text="Set Unit Size" />
        --%>
    </span>
    <table>
        <thead>
            <th>WS</th>
            <th>BS</th>
            <th>S</th>
            <th>T</th>
            <th>W</th>
            <th>I</th>
            <th>A</th>
            <th>Ld</th>
            <th>Sv</th>
        </thead>
        <tbody>
            <td><%: this.DisplayUnit.ws %></td>
            <td><%: this.DisplayUnit.bs %></td>
            <td><%: this.DisplayUnit.s %></td>
            <td><%: this.DisplayUnit.t %></td>
            <td><%: this.DisplayUnit.w %></td>
            <td><%: this.DisplayUnit.i %></td>
            <td><%: this.DisplayUnit.a %></td>
            <td><%: this.DisplayUnit.ld %></td>
            <td><%: this.DisplayUnit.sv %></td>
        </tbody>
    </table>
    <p>Unit Type: <%: this.DisplayUnit.unitType %></p>
    
    <h4>Special Rules:</h4>
    <ul ID="rulesList">
        <% foreach (var rule in this.DisplayUnit.specialRules) { %>
            <li><%: rule %></li>
        <% } %>
    </ul>
    
    <asp:CheckBoxList runat="server" 
                      ID="RuleUpgradesCheckBoxList"
                      DataSource="<%#RulesUpgrades %>"
                      DataTextField="Item1"
                      DataValueField="Item2"
                      RepeatLayout="UnorderedList"
                      AutoPostBack="True"
                      OnSelectedIndexChanged="RuleUpgradesCheckBoxList_OnSelectedIndexChanged" />
</div>

<script runat="server">

    IEnumerable<Tuple<string, string>> RulesUpgrades {
        get {
            return from upgrade in this.DisplayUnit.rulesUpgrades
                   let displayText = string.Format(CultureInfo.CurrentCulture, "{0} — {1} pts/model", upgrade.Key, upgrade.Value)
                   select Tuple.Create(displayText, upgrade.Key);
        }
    } 
</script>