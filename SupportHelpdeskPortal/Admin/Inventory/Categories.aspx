<%@ Page Title="Categories" MasterPageFile="~/Master/Site.master"
    Language="C#" AutoEventWireup="true"
    CodeBehind="Categories.aspx.cs"
    Inherits="SupportHelpdeskPortal.Admin.Inventory.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Categories</h2>

    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" /><br />

    <asp:HiddenField ID="hfCategoryId" runat="server" />

    <asp:TextBox ID="txtCategoryName" runat="server" Width="250"
        Placeholder="Category Name" />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /><br /><br />

    <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False"
        DataKeyNames="CategoryId" OnRowCommand="gvCategories_RowCommand">
        <Columns>
            <BoundField DataField="CategoryId" HeaderText="ID" />
            <BoundField DataField="CategoryName" HeaderText="Category Name" />
            <TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit"
                        CommandName="EditRow"
                        CommandArgument='<%# Eval("CategoryId") %>' />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete"
                        CommandName="DeleteRow"
                        CommandArgument='<%# Eval("CategoryId") %>' />
                </ItemTemplate>
            </TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
