<%@ Page Title="Teacher Home" Language="C#" MasterPageFile="~/UserPages/Teacher/Teacher.Master" AutoEventWireup="true" CodeBehind="TeacherHome.aspx.cs" Inherits="WebApplication.UserPages.TeacherHome" %>

<%@ MasterType VirtualPath="~/UserPages/Teacher/Teacher.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="TeacherTasksContent" ContentPlaceHolderID="TeacherContent" runat="server">

    <div>

        <h4>Home</h4>
        <hr />

        <p>
            Teachers home page.
        </p>

        <asp:Timer ID="ConnectedUsersTimer" Interval="3000" runat="server" OnTick="ConnectedUsersTimer_Tick" />
        <asp:UpdatePanel ID="ConnectedUsersUpdatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="form-row">
                    <div class="col-6 mb-6">
                        <asp:Label ID="ConnectedStudentCount" for="ConnectedStudents" Text="Connected students (0):" runat="server" />
                        <asp:ListBox ID="ConnectedStudents" CssClass="form-control" runat="server" Enabled="False" TabIndex="-1" />
                    </div>
                    <div class="col-6 mb-6">
                        <asp:Label ID="ConnectedTeacherCount" for="ConnectedTeachers" Text="Connected teachers (0):" runat="server" />
                        <asp:ListBox ID="ConnectedTeachers" CssClass="form-control" runat="server" Enabled="False" TabIndex="-1" />
                    </div>
                </div>
                <div class="form-row">
                    <ajaxtoolkit:BarChart ID="OnlineUsersChart" CssClass="col-md-4 col-md-offset-4" runat="server" BorderWidth="0" DisplayValues="True" ChartHeight="300"  ChartWidth="400"
						ChartTitle="Online Users" ChartType="Column" >
						<series>
							<ajaxToolkit:BarChartSeries Name="Students" />
							<ajaxToolkit:BarChartSeries Name="Teachers" />
						</series>
					</ajaxtoolkit:BarChart>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ConnectedUsersTimer" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>


    </div>

</asp:Content>
