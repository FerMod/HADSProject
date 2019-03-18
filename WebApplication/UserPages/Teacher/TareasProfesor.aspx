<%@ Page Title="Student Tasks" Language="C#" MasterPageFile="~/UserPages/Teacher/Teacher.Master" AutoEventWireup="true" CodeBehind="TareasProfesor.aspx.cs" Inherits="WebApplication.UserPages.TareasProfesor" %>

<%@ MasterType VirtualPath="~/UserPages/Teacher/Teacher.Master" %>

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
						WHERE ([CodAsig] = @CodAsig)"
        DeleteCommand="DELETE FROM [TareasGenericas] 
						WHERE [Codigo] = @Codigo"
        InsertCommand="INSERT INTO [TareasGenericas] ([Codigo], [Descripcion], [CodAsig], [HEstimadas], [Explotacion], [TipoTarea]) 
						VALUES (@Codigo, @Descripcion, @CodAsig, @HEstimadas, @Explotacion, @TipoTarea)"
        UpdateCommand="UPDATE [TareasGenericas] SET [Descripcion] = @Descripcion, [CodAsig] = @CodAsig, [HEstimadas] = @HEstimadas, [Explotacion] = @Explotacion, [TipoTarea] = @TipoTarea 
						WHERE [Codigo] = @Codigo">
        <DeleteParameters>
            <asp:Parameter Name="Codigo" Type="String" />
        </DeleteParameters>
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
        <UpdateParameters>
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:ControlParameter ControlID="DropDownSubjects" Name="CodAsig" PropertyName="SelectedValue" Type="String" />
            <asp:Parameter Name="HEstimadas" Type="Int32" />
            <asp:Parameter Name="Explotacion" Type="Boolean" />
            <asp:Parameter Name="TipoTarea" Type="String" />
            <asp:Parameter Name="Codigo" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <div class="form-group">
        <asp:Button ID="NewTaskButton" PostBackUrl="/Teacher/Tasks/NewTask" CssClass="btn btn-primary" runat="server" Text="New Task" TabIndex="1" />
    </div>

    <div class="form-group">
        <asp:Label Font-Bold="True" runat="server" AssociatedControlID="DropDownSubjects">Select subject:</asp:Label>
        <asp:DropDownList ID="DropDownSubjects" CssClass="custom-select" runat="server" TabIndex="1" AutoPostBack="True" DataSourceID="TeacherSubjectsDataSource" DataTextField="codigoasig" DataValueField="codigoasig" />
    </div>

    <div class="form-group">
        <asp:GridView ID="GridViewTasks" ClientIDMode="Static" CssClass="table table-responsive-md table-hover" DataKeyNames="Codigo" AutoPostBack="True" runat="server" TabIndex="2" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" AllowSorting="True" EmptyDataText="No tasks available." DataSourceID="TeacherSubjectsTasksDataSource">
            <Columns>
                <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:ImageButton ID="EditButton" CssClass="icon icon-edit" runat="server" ImageUrl="~/img/open-iconic/svg/pencil.svg"
                            CommandName="Edit"
                            AlternateText="Edit" ToolTip="Edit task" />
                        <asp:ImageButton ID="DeleteButton" CssClass="icon icon-trash" runat="server" ImageUrl="~/img/open-iconic/svg/trash.svg"
                            CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this task?');"
                            AlternateText="Delete" ToolTip="Delete task" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ID="UpdateButton" CssClass="icon icon-accept" runat="server" ImageUrl="~/img/open-iconic/svg/check.svg"
                            CommandName="Update" OnClientClick="return confirm('Do you want to save the changes?');"
                            AlternateText="Save Changes" ToolTip="Save changes" />
                        <asp:ImageButton ID="CancelButton" CssClass="icon icon-cancel" runat="server" ImageUrl="~/img/open-iconic/svg/x.svg"
                            CommandName="Cancel"
                            AlternateText="Discard Changes" ToolTip="Discard changes" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Codigo" HeaderText="Code" SortExpression="Codigo" ReadOnly="True" />
                <asp:BoundField DataField="Descripcion" HeaderText="Description" SortExpression="Descripcion" />
                <asp:BoundField DataField="HEstimadas" HeaderText="Estimated Hours" SortExpression="HEstimadas" />
                <asp:BoundField DataField="TipoTarea" HeaderText="Task Type" SortExpression="TipoTarea" />
                <asp:CheckBoxField DataField="Explotacion" HeaderText="Active" SortExpression="Explotacion" />

            </Columns>
            <HeaderStyle CssClass="table-striped thead-dark" />
        </asp:GridView>
    </div>

</asp:Content>
