<%@ Page Title="Ticket Details" MasterPageFile="~/Master/Site.master"
    Language="C#" AutoEventWireup="true"
    CodeBehind="TicketDetails.aspx.cs"
    Inherits="SupportHelpdeskPortal.Support.TicketDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Ticket Details</h2>

    <asp:DetailsView ID="dvTicket" runat="server" AutoGenerateRows="false">
        <Fields>
            <asp:BoundField DataField="TicketId" HeaderText="ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
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
        </Fields>
    </asp:DetailsView>
</asp:Content>
