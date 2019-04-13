<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConnectedUsers.ascx.cs" Inherits="WebApplication.CustomControls.ConnectedUsers" %>

<asp:Panel ID="ConnectedUsersPanel" CssClass="alert fade show" role="alert" runat="server" Visible="false" ViewStateMode="Enabled">
    <asp:Timer ID="UpdateTimer" Interval="3000" runat="server" OnTick="UpdateTimer_Tick" />
    <asp:UpdatePanel ID="ConnectedUsersUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container">
                <asp:ListBox ID="StudentList" runat="server" />
                <asp:ListBox ID="TeacherList" runat="server" />
            </div>
            <div class="container">
                <asp:Label ID="StudentCount" Text="0" runat="server" />
                <asp:Label ID="TeacherCount" Text="0" runat="server" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="UpdateTimer" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Panel>
