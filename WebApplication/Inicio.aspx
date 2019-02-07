<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebApplication.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div style="margin: 5px; padding: 5px">
			<asp:Label Style="vertical-align: central;" runat="server" Font-Bold="True">Email:</asp:Label>
			<br />
			<asp:TextBox ID="textBoxEmail" runat="server" autocomplete="off" Style="vertical-align: central; margin: 5px 5px 5px 0px;" Height="18px" Width="190px"></asp:TextBox>
			<asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ControlToValidate="textBoxEmail" ErrorMessage="Required field" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
		</div>
		<div style="margin: 5px; padding: 5px">
			<asp:Label Style="vertical-align: central;" runat="server" Font-Bold="True">Password:</asp:Label>
			<br />
			<asp:TextBox ID="textBoxPassword" TextMode="Password" runat="server" autocomplete="off" Style="vertical-align: central; margin: 5px 5px 5px 0px;" Height="18px" Width="190px"></asp:TextBox>
			<asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ControlToValidate="textBoxPassword" ErrorMessage="Required field" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
		</div>
		<%--		<div style="margin: 5px; padding: 5px">
			<asp:Label Style="vertical-align: central;" runat="server" Font-Bold="True">Tipo de usuario:</asp:Label>
			<br />
			<asp:DropDownList ID="dropDownListRol" runat="server" Style="vertical-align: middle; margin: 5px 5px 5px 0px;" Height="20px" Width="130px" />
		</div>--%>
		<div style="margin: 5px; padding: 5px">
			<asp:Button ID="buttonLogin" runat="server" Text="Log In" OnClick="ButtonLogin_Click" Width="89px" />
		</div>
	</form>
</body>
</html>
