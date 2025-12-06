<%@ Page Title="Create Ticket" MasterPageFile="~/Master/Site.master"
    Language="C#" AutoEventWireup="true"
    CodeBehind="TicketCreate.aspx.cs"
    Inherits="SupportHelpdeskPortal.Support.TicketCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create Support Ticket</h2>

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" /><br /><br />

    <asp:Label runat="server" Text="Title" /><br />
    <asp:TextBox ID="txtTitle" runat="server" Width="400" />
    <asp:RequiredFieldValidator ID="rfvTitle" runat="server"
        ControlToValidate="txtTitle"
        ErrorMessage="Title is required." ForeColor="Red" Display="Dynamic" /><br /><br />

    <asp:Label runat="server" Text="Description" /><br />
    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"
        Rows="5" Width="400" />
    <asp:RequiredFieldValidator ID="rfvDesc" runat="server"
        ControlToValidate="txtDescription"
        ErrorMessage="Description is required." ForeColor="Red" Display="Dynamic" /><br /><br />

    <asp:Label runat="server" Text="Status" /><br />
    <asp:DropDownList ID="ddlStatus" runat="server">
        <asp:ListItem Text="Open" Value="Open" />
        <asp:ListItem Text="Pending" Value="Pending" />
        <asp:ListItem Text="Closed" Value="Closed" />
    </asp:DropDownList><br /><br />

    <asp:Label runat="server" Text="Assign To (optional)" /><br />
    <asp:DropDownList ID="ddlAssignTo" runat="server" AppendDataBoundItems="true">
        <asp:ListItem Text="-- Not Assigned --" Value="" />
    </asp:DropDownList><br /><br />

    <asp:Label runat="server" Text="Attachment (optional)" /><br />
    <asp:FileUpload ID="fuAttachment" runat="server" /><br /><br />

    <asp:Button ID="btnSave" runat="server" Text="Save Ticket" OnClick="btnSave_Click" />
</asp:Content>
