<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebApplication.Inicio" Title="Inicio" MasterPageFile="~/Account.master" %>

<asp:Content ID="LogInContent" ContentPlaceHolderID="AccountCardBodyContent" runat="server">

    <div id="login" class="auth-form-body">

        <div class="form-group">
            <asp:Label Font-Bold="True" runat="server" AssociatedControlID="textBoxEmail">Email:</asp:Label>
            <asp:TextBox ID="textBoxEmail" CssClass="form-control" placeholder="Enter email" runat="server" autocomplete="off" TabIndex="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldEmail" CssClass="invalid-feedback" runat="server" ControlToValidate="textBoxEmail" ErrorMessage="Required field" Font-Bold="True" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label Font-Bold="True" runat="server" AssociatedControlID="textBoxPassword">Password:</asp:Label><asp:HyperLink CssClass="label-link" NavigateUrl="/CambiarPassword" runat="server">Forgot password?</asp:HyperLink>
            <asp:TextBox ID="textBoxPassword" CssClass="form-control" placeholder="Enter password" TextMode="Password" runat="server" autocomplete="off" TabIndex="2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldPassword" CssClass="invalid-feedback" runat="server" ControlToValidate="textBoxPassword" ErrorMessage="Required field" Font-Bold="True" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Button ID="buttonLogin" CssClass="btn btn-primary btn-block" runat="server" Text="Log In" OnClick="ButtonLogin_Click" TabIndex="3" />
        </div>

    </div>

</asp:Content>
