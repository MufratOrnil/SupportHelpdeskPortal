<%@ Page Title="Profile" MasterPageFile="~/Master/Site.master"
    Language="C#" AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs"
    Inherits="SupportHelpdeskPortal.Account.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>My Profile</h2>
    <div class="profile-card">
        <asp:DetailsView ID="dvProfile" runat="server" AutoGenerateRows="false">
            <Fields>
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                <asp:BoundField DataField="RoleName" HeaderText="Role" />
                <asp:BoundField DataField="CreatedDate" HeaderText="Member Since"
                    DataFormatString="{0:yyyy-MM-dd}" />
            </Fields>
        </asp:DetailsView>
    </div>
</asp:Content>
