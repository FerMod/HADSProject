<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebApplication.Registro" MasterPageFile="~/Account.Master" Title="Registro" %>
<%@ MasterType VirtualPath="~/Account.Master" %>

<asp:Content ID="RegisterContent" ContentPlaceHolderID="AccountCardBodyContent" runat="server">

    <div id="register" class="auth-form-body">

        <div class="form-group form-row">
            <div class="col">
                <asp:Label runat="server" Font-Bold="True" AssociatedControlID="textBoxName">Name:</asp:Label>
                <asp:TextBox ID="textBoxName" CssClass="form-control" TabIndex="1" placeholder="Enter name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldName" CssClass="invalid-feedback" Font-Bold="True" runat="server" Display="Dynamic" ControlToValidate="textBoxName" ErrorMessage="Required field"></asp:RequiredFieldValidator>
            </div>
            <div class="col">
                <asp:Label runat="server" Font-Bold="True" AssociatedControlID="textBoxLastName">Last Name:</asp:Label>
                <asp:TextBox ID="textBoxLastName" CssClass="form-control" placeholder="Enter last name" runat="server" TabIndex="2"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldLastName" CssClass="invalid-feedback" Font-Bold="True" runat="server" Display="Dynamic" ControlToValidate="textBoxLastName" ErrorMessage="Required field"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Font-Bold="True" AssociatedControlID="textBoxEmail">Email:</asp:Label>
            <asp:TextBox ID="textBoxEmail" CssClass="form-control" TabIndex="3" placeholder="Enter email" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldEmail" CssClass="invalid-feedback" Font-Bold="True" runat="server" Display="Dynamic" ControlToValidate="textBoxEmail" ErrorMessage="Required field"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="EmailRegExpr" CssClass="invalid-feedback" Font-Bold="True" runat="server" Display="Dynamic" ErrorMessage="Formato del correo no valido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="textBoxEmail"></asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Font-Bold="True" AssociatedControlID="textBoxPassword">Password:</asp:Label>
            <asp:TextBox ID="textBoxPassword" CssClass="form-control" TabIndex="4" placeholder="Enter password" TextMode="Password" autocomplete="off" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldPassword" Font-Bold="True" CssClass="invalid-feedback" runat="server" ControlToValidate="textBoxPassword" ErrorMessage="Required field" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Font-Bold="True" AssociatedControlID="RequiredFieldPassword">Repeat password:</asp:Label>
            <asp:TextBox ID="textBoxRepeatPassword" CssClass="form-control" TabIndex="5" placeholder="Repeat password" TextMode="Password" runat="server" autocomplete="off"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldRepeatPassword" CssClass="invalid-feedback" Font-Bold="True" runat="server" ControlToValidate="textBoxRepeatPassword" ErrorMessage="Required field" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareRepeatPassword" CssClass="invalid-feedback" Font-Bold="True" runat="server" ControlToValidate="textBoxRepeatPassword" ErrorMessage="Passwords does not match" Display="Dynamic" Operator="Equal" ControlToCompare="textBoxPassword"></asp:CompareValidator>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Font-Bold="True" AssociatedControlID="dropDownRol">Tipo de usuario:</asp:Label>
            <asp:DropDownList ID="dropDownRol" CssClass="form-control dropdown dropdown-toggle" runat="server" TabIndex="6">
                <asp:ListItem Value="Alumno"></asp:ListItem>
                <asp:ListItem Value="Profesor"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Button ID="buttonCreateAccount" CssClass="btn btn-primary btn-block" runat="server" Text="Create Account" OnClick="ButtonCreateAccount_Click" TabIndex="7" />
        </div>

    </div>

</asp:Content>
