<%@ Page Title="Teacher Tasks" Language="C#" MasterPageFile="~/UserPages/Teacher/Teacher.Master" AutoEventWireup="true" CodeBehind="Coordinador.aspx.cs" Inherits="WebApplication.UserPages.Coordinador" %>

<%@ MasterType VirtualPath="~/UserPages/Teacher/Teacher.Master" %>

<asp:Content ID="TeacherTasksContent" ContentPlaceHolderID="TeacherContent" runat="server">

	<asp:SqlDataSource ID="SubjectsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HADS18-DB %>"
		SelectCommand="SELECT codigo 
						FROM Asignaturas">
	</asp:SqlDataSource>

	<div class="form-group">
		<asp:Label Font-Bold="True" runat="server" AssociatedControlID="DropDownSubjects">Select subject:</asp:Label>
		<asp:DropDownList ID="DropDownSubjects" CssClass="custom-select" runat="server" TabIndex="1" AutoPostBack="True" DataSourceID="SubjectsDataSource" DataTextField="codigoasig" DataValueField="codigoasig" />
	</div>

	<div class="form-group">
		<asp:GridView ID="GridViewTasksMeans" ClientIDMode="Static" CssClass="table table-sm table-bordered table-responsive-md table-hover table-row-middle" DataKeyNames="CodAsig" AutoPostBack="True" runat="server" TabIndex="2" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" AllowSorting="True" EmptyDataText="No tasks found." DataSourceID="SubjectsDataSource">
			<Columns>
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" ReadOnly="True" />
				<asp:BoundField DataField="MediaHReales" HeaderText="Tasks Mean" SortExpression="MediaHReales" ReadOnly="True" />
			</Columns>
			<HeaderStyle CssClass="thead-dark" />
		</asp:GridView>
	</div>

</asp:Content>
