<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebApplicationOld.Inicio" Title="Inicio" MasterPageFile="~/Account.master" %>

<asp:Content ID="CardBodyContent" ContentPlaceHolderID="AccountCardBodyContent" runat="server">
    <div class="form-group">
        <asp:Label Font-Bold="True" runat="server">Email:</asp:Label>
        <asp:TextBox ID="textBoxEmail" CssClass="form-control" placeholder="Enter email" runat="server" autocomplete="off" TabIndex="1"></asp:TextBox>
        <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" CssClass="invalid-feedback" runat="server" ControlToValidate="textBoxEmail" ErrorMessage="Required field" Font-Bold="True" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <asp:Label Font-Bold="True" runat="server">Password:</asp:Label>
        <asp:TextBox ID="textBoxPassword" CssClass="form-control" placeholder="Enter password" TextMode="Password" runat="server" autocomplete="off" TabIndex="2"></asp:TextBox>
        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" CssClass="invalid-feedback" runat="server" ControlToValidate="textBoxPassword" ErrorMessage="Required field" Font-Bold="True" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <asp:Button ID="buttonLogin" CssClass="btn btn-primary" runat="server" Text="Log In" OnClick="ButtonLogin_Click" TabIndex="3" />
            </div>
        </div>
        <div class="col-md-6 text-right">
            <asp:HyperLink ID="HyperLinkCreateAccount" runat="server" NavigateUrl="~/CambiarPassword.aspx" TabIndex="4">Forgot password?</asp:HyperLink>
        </div>
    </div>
</asp:Content>
