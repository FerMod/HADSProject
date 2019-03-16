<%@ Page Title="Student Tasks" Language="C#" MasterPageFile="~/UserPages/UserHome.Master" AutoEventWireup="true" CodeBehind="TareasProfesor.aspx.cs" Inherits="WebApplication.UserPages.TareasProfesor" %>

<%@ MasterType VirtualPath="~/UserPages/UserHome.Master" %>

<asp:Content ID="TeacherTasksContent" ContentPlaceHolderID="TeacherContent" runat="server">

    <asp:SqlDataSource ID="TeacherSubjectsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HADS18-DB %>" 
		SelectCommand="SELECT DISTINCT(GC.codigoasig)
						FROM GruposClase GC
						JOIN  ProfesoresGrupo PG
						ON PG.codigogrupo = GC.codigo
						WHERE PG.email = @email">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="" Name="email" SessionField="Email" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="TeacherSubjectsTasksDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HADS18-DB %>" 
		SelectCommand="SELECT [Codigo], [Descripcion], [CodAsig], [HEstimadas], [Explotacion], [TipoTarea] FROM [TareasGenericas] WHERE ([CodAsig] = @CodAsig)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownSubjects" Name="CodAsig" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <div class="form-group">
        <asp:Label Font-Bold="True" runat="server" AssociatedControlID="DropDownSubjects">Select subject:</asp:Label>
        <asp:DropDownList ID="DropDownSubjects" runat="server" TabIndex="1" AutoPostBack="True" DataSourceID="TeacherSubjectsDataSource" DataTextField="codigoasig" DataValueField="codigoasig" />
    </div>

    <div class="form-group">
        <asp:GridView ID="GridViewTasks" CssClass="table table-responsive-md table-hover" runat="server" TabIndex="2" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" OnSorting="GridViewTasks_Sorting" EmptyDataText="No tasks available." OnRowCommand="GridViewTasks_RowCommand" DataSourceID="TeacherSubjectsTasksDataSource">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Codigo" HeaderText="Code" SortExpression="Codigo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Description" SortExpression="Descripcion" />
                <asp:BoundField DataField="HEstimadas" HeaderText="Estimated Hours" SortExpression="HEstimadas" />
                <asp:BoundField DataField="TipoTarea" HeaderText="Type" SortExpression="TipoTarea" />
                <asp:CheckBoxField DataField="Explotacion" HeaderText="Active" SortExpression="Explotacion" />
            </Columns>
            <HeaderStyle CssClass="table-striped thead-dark" />
        </asp:GridView>
    </div>

</asp:Content>
