<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="WebApplication.CambiarPassword" MasterPageFile="~/Site.Master" Title="Change Password" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="auth-form card">

        <div class="auth-form-header card-header">
            <asp:Label runat="server" CssClass="h4" Font-Bold="True">Change Password</asp:Label>
        </div>

        <div class="auth-form-body">

            <div class="form-group">
                <asp:Label Font-Bold="True" runat="server" AssociatedControlID="textBoxNewPassword">New Password:</asp:Label>
                <asp:TextBox ID="textBoxNewPassword" CssClass="form-control" placeholder="Enter password" TextMode="Password" autocomplete="off" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordFieldRequired" Font-Bold="True" CssClass="invalid-feedback" runat="server" ControlToValidate="textBoxNewPassword" ErrorMessage="Required field" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label Style="vertical-align: central;" runat="server" Font-Bold="True" AssociatedControlID="textBoxRepeatNewPassword">Repeat new password:</asp:Label>
                <asp:TextBox ID="textBoxRepeatNewPassword" CssClass="form-control" placeholder="Repeat password" TextMode="Password" runat="server" autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NewPasswordFieldRequired" CssClass="invalid-feedback" Font-Bold="True" runat="server" ControlToValidate="textBoxRepeatNewPassword" ErrorMessage="Required field" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="ComparePassword" CssClass="invalid-feedback" Font-Bold="True" runat="server" ControlToValidate="textBoxRepeatNewPassword" ErrorMessage="Passwords does not match" Display="Dynamic" Operator="Equal" ControlToCompare="textBoxNewPassword"></asp:CompareValidator>
            </div>

            <div class="form-group">
                <asp:Button ID="buttonChangePassword" CssClass="btn btn-primary btn-block" runat="server" Text="Change Password" OnClick="ButtonChangePassword_Click" TabIndex="3" />
            </div>

        </div>
    </div>

</asp:Content>
