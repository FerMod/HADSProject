<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebNotification.ascx.cs" Inherits="WebApplication.CustomControls.WebNotification" %>

<asp:Panel ID="Alert" CssClass="alert fade show" role="alert" runat="server" Visible="false" ViewStateMode="Enabled">
    <asp:Label ID="AlertTitle" CssClass="h4 alert-heading" Text="" runat="server" />
    <p class="mb-0">
        <asp:Label ID="AlertBody" Text="" runat="server" />
    </p>
    <asp:LinkButton ID="AlertCloseButton" CssClass="close" data-dismiss="Alert" aria-label="close" Visible="false" OnClick="AlertCloseButton_Click" runat="server" CausesValidation="False">
        <span aria-hidden="true">&times;</span>
    </asp:LinkButton>
</asp:Panel>
