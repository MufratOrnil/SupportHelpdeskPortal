<%@ Page Title="Tickets" MasterPageFile="~/Master/Site.master"
    Language="C#" AutoEventWireup="true"
    CodeBehind="TicketList.aspx.cs"
    Inherits="SupportHelpdeskPortal.Support.TicketList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Support Tickets</h2>

    <a href="TicketCreate.aspx">Create New Ticket</a><br />
    <br />

    <asp:Label ID="lblStatus" runat="server" Text="Status" />
    <asp:DropDownList ID="ddlFilterStatus" runat="server">
        <asp:ListItem Text="-- All --" Value="" />
        <asp:ListItem Text="Open" Value="Open" />
        <asp:ListItem Text="Pending" Value="Pending" />
        <asp:ListItem Text="Closed" Value="Closed" />
    </asp:DropDownList>

    &nbsp;From:
    <asp:TextBox ID="txtFromDate" runat="server" Width="100" />
    &nbsp;To:
    <asp:TextBox ID="txtToDate" runat="server" Width="100" />

    <asp:Button ID="btnSearch" runat="server"
        Text="Search" OnClick="btnSearch_Click" /><br />
    <br />

    <asp:GridView ID="gvTickets" runat="server" AutoGenerateColumns="False"
        CssClass="table" OnRowDataBound="gvTickets_RowDataBound">
        <Columns>
            <asp:BoundField DataField="TicketId" HeaderText="ID" />

            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <asp:HyperLink ID="lnkTitle" runat="server"
                        Text='<%# Eval("Title") %>'
                        NavigateUrl='<%# "~/Support/TicketDetails.aspx?id=" + Eval("TicketId") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:BoundField DataField="CreatedDate" HeaderText="Created"
                DataFormatString="{0:yyyy-MM-dd HH:mm}" />
            <asp:TemplateField HeaderText="Attachment">
                <ItemTemplate>
                    <asp:HyperLink ID="lnkAttachment" runat="server"
                        Text="Download"
                        NavigateUrl='<%# Eval("AttachmentPath") %>'
                        Visible='<%# !string.IsNullOrEmpty(Eval("AttachmentPath") as string) %>' />
                </ItemTemplate>
            </asp:TemplateField>


            <asp:BoundField DataField="CreatedBy" HeaderText="Created By" />
            <asp:BoundField DataField="AssignedUser" HeaderText="Assigned To" />
        </Columns>
    </asp:GridView>

</asp:Content>
