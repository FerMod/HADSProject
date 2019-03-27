<%@ Page Title="Export Tasks" Language="C#" MasterPageFile="~/UserPages/Teacher/Teacher.Master" AutoEventWireup="true" CodeBehind="ExportarTareas.aspx.cs" Inherits="WebApplication.UserPages.ExportarTareas" %>

<%@ MasterType VirtualPath="~/UserPages/Teacher/Teacher.Master" %>
<%@ Register TagPrefix="web" TagName="Notification" Src="~/CustomControls/WebNotification.ascx" %>

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
        SelectCommand="SELECT [Codigo], [Descripcion], [CodAsig], [HEstimadas], [Explotacion], [TipoTarea] 
						FROM [TareasGenericas] 
						WHERE ([CodAsig] = @CodAsig)">
        <InsertParameters>
            <asp:Parameter Name="Codigo" Type="String" />
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:ControlParameter ControlID="DropDownSubjects" Name="CodAsig" PropertyName="SelectedValue" Type="String" />
            <asp:Parameter Name="HEstimadas" Type="Int32" />
            <asp:Parameter Name="Explotacion" Type="Boolean" />
            <asp:Parameter Name="TipoTarea" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownSubjects" Name="CodAsig" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <div class="form-group form-row">
        <div class="col-md-4">
            <asp:Label Font-Bold="True" AssociatedControlID="FileFormatDropDown" runat="server">Select file format:</asp:Label>
            <asp:DropDownList ID="FileFormatDropDown" CssClass="custom-select" runat="server" TabIndex="1" AutoPostBack="True" OnLoad="FileFormatDropDown_Load" OnSelectedIndexChanged="FileFormatDropDown_SelectedIndexChanged">
                <asp:ListItem Selected="True">Xml</asp:ListItem>
                <asp:ListItem>Json</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="form-group form-row">
        <div class="input-group col-md-4">
            <asp:DropDownList ID="DropDownSubjects" CssClass="custom-select" runat="server" TabIndex="2" AutoPostBack="True" DataSourceID="TeacherSubjectsDataSource" DataTextField="codigoasig" DataValueField="codigoasig" />
            <div class="input-group-append">
                <asp:Label ID="FileExtensionLabel" CssClass="input-group-text" runat="server"></asp:Label>
            </div>
            <div class="input-group-append">
                <asp:Button ID="ExportTasksButton" CssClass="btn btn-primary" Text="Export Tasks" TabIndex="3" OnClick="ExportTasks_Click" CausesValidation="False" Enabled="true" runat="server" UseSubmitBehavior="False" />
            </div>
        </div>
    </div>

    <div class="form-group">
        <asp:GridView ID="GridViewTasks" ClientIDMode="Static" CssClass="table table-sm table-bordered table-responsive-md table-hover table-row-middle" DataKeyNames="Codigo" AutoPostBack="True" runat="server" TabIndex="0" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" AllowSorting="True" EmptyDataText="No tasks available." DataSourceID="TeacherSubjectsTasksDataSource" OnDataBound="GridViewTasks_DataBound">
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Code" SortExpression="Codigo" ReadOnly="True" />
                <asp:BoundField DataField="Descripcion" HeaderText="Description" SortExpression="Descripcion" />
                <asp:BoundField DataField="HEstimadas" HeaderText="Estimated Hours" SortExpression="HEstimadas" />
                <asp:BoundField DataField="TipoTarea" HeaderText="Task Type" SortExpression="TipoTarea" />
                <asp:CheckBoxField DataField="Explotacion" HeaderText="Active" SortExpression="Explotacion" ItemStyle-HorizontalAlign="Center" />
            </Columns>
            <HeaderStyle CssClass="thead-dark" />
        </asp:GridView>
    </div>

    <web:Notification ID="ExportNotification" Dismissible="true" runat="server" />

</asp:Content>
