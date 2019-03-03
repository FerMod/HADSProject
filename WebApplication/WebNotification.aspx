<%@ Page Title="WebNotification" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebNotification.aspx.cs" Inherits="WebApplication.WebNotification" %>

<asp:Content ID="NotificationContent" ContentPlaceHolderID="NotificationContent" runat="server">

    <asp:Panel ID="Alert" CssClass="alert" role="alert" Visible="false" runat="server">
        <asp:Label ID="AlertTitle" CssClass="h4 alert-heading" Text="" runat="server" />
        <p class="mb-0">
            <asp:Label ID="AlertBody" Text="" runat="server" />
        </p>
        <asp:LinkButton ID="AlertCloseButton" CssClass="close" data-dismiss="alert" aria-label="Close" Visible="false" runat="server">
            <span aria-hidden="true">&times;</span>
        </asp:LinkButton>
    </asp:Panel>

</asp:Content>
