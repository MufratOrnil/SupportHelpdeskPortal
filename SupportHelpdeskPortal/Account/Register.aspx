<%@ Page Title="Register" MasterPageFile="~/Master/Site.master"
    Language="C#" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs"
    Inherits="SupportHelpdeskPortal.Account.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Register</h2>

    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" /><br /><br />

    <asp:Label runat="server" Text="Username" /><br />
    <asp:TextBox ID="txtUsername" runat="server" Width="250" /><br /><br />

    <asp:Label runat="server" Text="Full Name" /><br />
    <asp:TextBox ID="txtFullName" runat="server" Width="250" /><br /><br />

    <asp:Label runat="server" Text="Password" /><br />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="250" /><br /><br />

    <asp:Button ID="btnRegister" runat="server"
        Text="Register" OnClick="btnRegister_Click" />
</asp:Content>
