<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebApplication.Registro" MasterPageFile="~/Account.master" Title="Registro" %>

<asp:Content ID="CardBodyContent" ContentPlaceHolderID="AccountCardBodyContent" runat="server">
    <div class="form-group">
        <asp:Label Style="vertical-align: central;" runat="server" Font-Bold="True">Email:</asp:Label>
        <asp:TextBox ID="textBoxEmail" CssClass="form-control" placeholder="Enter email" runat="server" autocomplete="off"></asp:TextBox>
        <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" CssClass="invalid-feedback" Font-Bold="True" runat="server" Display="Dynamic" ControlToValidate="textBoxEmail" ErrorMessage="Required field"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="invalid-feedback" Font-Bold="True" runat="server" Display="Dynamic" ErrorMessage="Formato del correo no valido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="textBoxEmail"></asp:RegularExpressionValidator>
    </div>
    <div class="form-group">
        <asp:Label Font-Bold="True" runat="server">Password:</asp:Label>
        <asp:TextBox ID="textBoxPassword1" CssClass="form-control" placeholder="Enter password" TextMode="Password" autocomplete="off" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" Font-Bold="True" CssClass="invalid-feedback" runat="server" ControlToValidate="textBoxPassword1" ErrorMessage="Required field" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <asp:Label Style="vertical-align: central;" runat="server" Font-Bold="True">Repeat password:</asp:Label>
        <asp:TextBox ID="textBoxPassword2" CssClass="form-control" placeholder="Repeat password" TextMode="Password" runat="server" autocomplete="off"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="invalid-feedback" Font-Bold="True" runat="server" ControlToValidate="textBoxPassword2" ErrorMessage="Required field" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="PasswordCompareValidator" CssClass="invalid-feedback" Font-Bold="True" runat="server" ControlToValidate="textBoxPassword1" ErrorMessage="Passwords does not match" Display="Dynamic" Operator="NotEqual"></asp:CompareValidator>
    </div>
    <div class="form-group">
        <asp:Label runat="server" Font-Bold="True">Tipo de usuario:</asp:Label>
        <asp:DropDownList ID="dropDownRol" CssClass="form-control dropdown" placeholder="Select option" runat="server"></asp:DropDownList>
    </div>
    <div class="form-group">
        <asp:Button ID="buttonCreateAccount" CssClass="btn btn-primary" runat="server" Text="Create Account" OnClick="ButtonCreateAccount_Click" TabIndex="3" />
    </div>
</asp:Content>
