<%@ Page Title="WebAlertNotification" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebAlertNotification.aspx.cs" Inherits="WebApplication.WebAlertNotification" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register TagPrefix="web" TagName="Notification" Src="~/CustomControls/WebNotification.ascx" %>

<asp:Content ID="NotificationContent" ContentPlaceHolderID="NotificationContent" runat="server">

    <web:Notification ID="GlobalNotification" runat="server" />

</asp:Content>
