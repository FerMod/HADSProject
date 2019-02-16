<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="WebApplication.CambiarPassword" MasterPageFile="~/Site.Master" Title="Change Password" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <div class="card-body">
            <asp:Label runat="server" CssClass="card-title h4 mb-4 mt-6" Font-Bold="True">Change Password</asp:Label>
            <hr />
            <div class="form-group">
                <asp:Label Font-Bold="True" runat="server">New Password:</asp:Label>
                <asp:TextBox ID="textBoxPassword1" CssClass="form-control" placeholder="Enter password" TextMode="Password" autocomplete="off" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" Font-Bold="True" CssClass="invalid-feedback" runat="server" ControlToValidate="textBoxPassword1" ErrorMessage="Required field" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label Style="vertical-align: central;" runat="server" Font-Bold="True">Repeat new password:</asp:Label>
                <asp:TextBox ID="textBoxPassword2" CssClass="form-control" placeholder="Repeat password" TextMode="Password" runat="server" autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="invalid-feedback" Font-Bold="True" runat="server" ControlToValidate="textBoxPassword2" ErrorMessage="Required field" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="PasswordCompareValidator" CssClass="invalid-feedback" Font-Bold="True" runat="server" ControlToValidate="textBoxPassword2" ErrorMessage="Passwords does not match" Display="Dynamic" Operator="Equal" ControlToCompare="textBoxPassword1"></asp:CompareValidator>
            </div>
            <div class="form-group">
                <asp:Button ID="buttonChangePassword" CssClass="btn btn-primary" runat="server" Text="Change Password" OnClick="ButtonChangePassword_Click" TabIndex="3" />
            </div>
        </div>
    </div>
</asp:Content>
