<%@ Page Title="Student Home" Language="C#" MasterPageFile="~/UserPages/Student/Student.Master" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="WebApplication.UserPages.StudentHome" %>

<%@ MasterType VirtualPath="~/UserPages/Student/Student.Master" %>

<asp:Content ID="StudentTasksContent" ContentPlaceHolderID="StudentContent" runat="server">

    <div>

        <h4>Home</h4>
        <hr />

        <p>
            Students home page.
        </p>

        <asp:Timer ID="ConnectedUsersTimer" Interval="3000" runat="server" OnTick="ConnectedUsersTimer_Tick" />
        <asp:UpdatePanel ID="ConnectedUsersUpdatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="form-row">
                    <div class="col-6 mb-6">
                        <asp:Label ID="ConnectedStudentCount" for="ConnectedStudents" Text="0" runat="server" />
                        <asp:ListBox ID="ConnectedStudents" CssClass="form-control" runat="server" />
                    </div>
                    <div class="col-6 mb-6">
                        <asp:Label ID="ConnectedTeacherCount" for="ConnectedTeachers" Text="0" runat="server" />
                        <asp:ListBox ID="ConnectedTeachers" CssClass="form-control" runat="server" />
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ConnectedUsersTimer" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>

    </div>

</asp:Content>
