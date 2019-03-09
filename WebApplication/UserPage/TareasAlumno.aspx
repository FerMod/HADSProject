<%@ Page Title="Student Tasks" Language="C#" MasterPageFile="~/UserPage/UserTasks.master" AutoEventWireup="true" CodeBehind="TareasAlumno.aspx.cs" Inherits="WebApplication.UserPage.TareasAlumno" %>
<%@ MasterType VirtualPath="~/UserPage/UserTasks.master" %>

<asp:Content ID="StudentTasksContent" ContentPlaceHolderID="UserContent" runat="server">
	<div class="card-body">

		<div class="form-group">
			<asp:Label Font-Bold="True" runat="server" AssociatedControlID="DropDownCourses">Select course:</asp:Label>
			<asp:DropDownList ID="DropDownCourses" runat="server" TabIndex="1" />
		</div>

		<div class="form-group">
			<asp:GridView ID="GridViewTasks" runat="server" TabIndex="2" AutoGenerateColumns="False" OnSorting="GridViewTasks_Sorting">
				<Columns>
					<asp:ButtonField ButtonType="Button" Text="Instantiate" />
					<asp:BoundField HeaderText="Code" />
					<asp:BoundField HeaderText="Description" />
					<asp:BoundField HeaderText="Hours" />
					<asp:BoundField HeaderText="Type" />
				</Columns>
			</asp:GridView>
		</div>

	</div>
</asp:Content>
