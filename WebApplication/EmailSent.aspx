<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailSent.aspx.cs" Inherits="WebApplication.EmailSent" MasterPageFile="~/Site.Master" Title="EmailSent" %>

<asp:Content ID="EmailSentBodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card">
        <div class="card-body">
            An email have been sent
            <asp:LinkButton Text="Resend email" runat="server" />
        </div>
    </div>

</asp:Content>
