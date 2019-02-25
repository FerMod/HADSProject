<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebNotification.aspx.cs" Inherits="WebApplication.WebNotification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<div class="alert alert-info" role="alert">
		<asp:Label ID="title" CssClass="h3 alert-heading" runat="server" Text="Notification Title" />
		<hr>
		<p class="mb-0">
			<asp:Label ID="body" runat="server" Text="Notification body" />
		</p>
	</div>

</asp:Content>
