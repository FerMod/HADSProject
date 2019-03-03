<%@ Page Title="WebNotification" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebNotification.aspx.cs" Inherits="WebApplication.WebNotification" %>

<asp:Content ID="Notification" ContentPlaceHolderID="NotificationContent" runat="server">

    <asp:Panel ID="alert" CssClass="alert" role="alert" Visible="false" runat="server">
        <asp:Label ID="title" CssClass="h4 alert-heading" Text="Notification Title" Visible="false" runat="server" />
        <p class="mb-0">
            <asp:Label ID="body" runat="server" Text="Notification body" />
        </p>
        <asp:LinkButton ID="close" CssClass="close" data-dismiss="alert" aria-label="Close" Visible="false" runat="server">
            <span aria-hidden="true">&times;</span>
        </asp:LinkButton>
    </asp:Panel>

</asp:Content>
