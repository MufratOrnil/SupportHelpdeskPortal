<%@ Page Title="Login" MasterPageFile="~/Master/Site.master"
    Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="SupportHelpdeskPortal.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Login</h2>

    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" /><br /><br />

    <asp:TextBox ID="txtUsername" runat="server"
        Placeholder="Username" Width="250" /><br /><br />

    <asp:TextBox ID="txtPassword" runat="server"
        TextMode="Password" Placeholder="Password" Width="250" /><br /><br />

    <asp:Button ID="btnLogin" runat="server"
        CssClass="btn-primary"
        Text="Login"
        OnClick="btnLogin_Click" />

    <asp:HyperLink ID="lnkRegister" runat="server"
        CssClass="btn-link"
        NavigateUrl="~/Account/Register.aspx"
        Text="Register" />
</asp:Content>
