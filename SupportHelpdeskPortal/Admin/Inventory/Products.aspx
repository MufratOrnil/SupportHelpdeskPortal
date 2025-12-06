<%@ Page Title="Products" MasterPageFile="~/Master/Site.master"
    Language="C#" AutoEventWireup="true"
    CodeBehind="Products.aspx.cs"
    Inherits="SupportHelpdeskPortal.Admin.Inventory.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Products</h2>

    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" /><br />

    <asp:HiddenField ID="hfProductId" runat="server" />

    <asp:Label runat="server" Text="Product Name" /><br />
    <asp:TextBox ID="txtProductName" runat="server" Width="250" /><br /><br />

    <asp:Label runat="server" Text="Category" /><br />
    <asp:DropDownList ID="ddlCategory" runat="server" /><br /><br />

    <asp:Label runat="server" Text="Unit Price" /><br />
    <asp:TextBox ID="txtUnitPrice" runat="server" Width="100" /><br /><br />

    <asp:Label runat="server" Text="Stock Quantity" /><br />
    <asp:TextBox ID="txtStock" runat="server" Width="100" /><br /><br />

    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /><br /><br />

    <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False"
        DataKeyNames="ProductId" AllowPaging="true" PageSize="10"
        OnPageIndexChanging="gvProducts_PageIndexChanging"
        OnRowCommand="gvProducts_RowCommand">
        <Columns>
            <BoundField DataField="ProductId" HeaderText="ID" />
            <BoundField DataField="ProductName" HeaderText="Product" />
            <BoundField DataField="CategoryName" HeaderText="Category" />
            <BoundField DataField="UnitPrice" HeaderText="Price"
                DataFormatString="{0:F2}" />
            <BoundField DataField="StockQuantity" HeaderText="Stock" />
            <TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit"
                        CommandName="EditRow"
                        CommandArgument='<%# Eval("ProductId") %>' />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete"
                        CommandName="DeleteRow"
                        CommandArgument='<%# Eval("ProductId") %>' />
                </ItemTemplate>
            </TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
