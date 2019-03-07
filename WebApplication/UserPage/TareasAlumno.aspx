<%@ Page Title="Student Tasks" Language="C#" MasterPageFile="~/UserPage/UserTasks.master" AutoEventWireup="true" CodeBehind="TareasAlumno.aspx.cs" Inherits="WebApplication.UserPage.TareasAlumno" %>

<asp:Content ID="StudentTasksContent" ContentPlaceHolderID="UserContent" runat="server">
	<div id="tasks" class="card-body">
		<asp:DropDownList ID="DropDownCourses" runat="server">

		</asp:DropDownList>
	</div>
</asp:Content>
