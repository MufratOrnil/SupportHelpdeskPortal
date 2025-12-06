<%@ Page Title="Dashboard" MasterPageFile="~/Master/Site.master"
    Language="C#" AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs"
    Inherits="SupportHelpdeskPortal.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Admin Dashboard</h2>

    <div class="stats-box">
        <p>Total Tickets: <asp:Label ID="lblTotalTickets" runat="server" /></p>
        <p>Open Tickets: <asp:Label ID="lblOpenTickets" runat="server" /></p>
        <p>Total Users: <asp:Label ID="lblUsers" runat="server" /></p>
    </div>

    <h3>Navigation</h3>
    <ul>
        <li><asp:HyperLink ID="lnkCategories" runat="server"
            NavigateUrl="~/Admin/Inventory/Categories.aspx"
            Text="Manage Categories" /></li>
        <li><asp:HyperLink ID="lnkProducts" runat="server"
            NavigateUrl="~/Admin/Inventory/Products.aspx"
            Text="Manage Products" /></li>
        <li><asp:HyperLink ID="lnkTickets" runat="server"
            NavigateUrl="~/Support/TicketList.aspx"
            Text="View Support Tickets" /></li>
    </ul>
</asp:Content>
