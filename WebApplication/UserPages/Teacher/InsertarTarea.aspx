<%@ Page Title="Student Tasks" Language="C#" MasterPageFile="~/UserPages/Teacher/Teacher.Master" AutoEventWireup="true" CodeBehind="InsertarTarea.aspx.cs" Inherits="WebApplication.UserPages.InsertarTarea" %>

<%@ MasterType VirtualPath="~/UserPages/Teacher/Teacher.Master" %>

<asp:Content ID="TeacherTasksContent" ContentPlaceHolderID="TeacherContent" runat="server">

    <%--
    <div class="modal fade" id="taskModal" tabindex="-1" role="dialog" aria-labelledby="taskModalTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="taskModalTitle">Instantiate Task</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
    --%>

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

    <asp:SqlDataSource ID="GenericTasksSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HADS18-DB %>" DeleteCommand="DELETE FROM [TareasGenericas] WHERE [Codigo] = @Codigo" InsertCommand="INSERT INTO [TareasGenericas] ([Descripcion], [CodAsig], [HEstimadas], [Explotacion], [TipoTarea], [Codigo]) VALUES (@Descripcion, @CodAsig, @HEstimadas, @Explotacion, @TipoTarea, @Codigo)" SelectCommand="SELECT [Descripcion], [CodAsig], [HEstimadas], [Explotacion], [TipoTarea], [Codigo] FROM [TareasGenericas]" UpdateCommand="UPDATE [TareasGenericas] SET [Descripcion] = @Descripcion, [CodAsig] = @CodAsig, [HEstimadas] = @HEstimadas, [Explotacion] = @Explotacion, [TipoTarea] = @TipoTarea WHERE [Codigo] = @Codigo">
        <DeleteParameters>
            <asp:Parameter Name="Codigo" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="CodAsig" Type="String" />
            <asp:Parameter Name="HEstimadas" Type="Int32" />
            <asp:Parameter Name="Explotacion" Type="Boolean" />
            <asp:Parameter Name="TipoTarea" Type="String" />
            <asp:Parameter Name="Codigo" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="CodAsig" Type="String" />
            <asp:Parameter Name="HEstimadas" Type="Int32" />
            <asp:Parameter Name="Explotacion" Type="Boolean" />
            <asp:Parameter Name="TipoTarea" Type="String" />
            <asp:Parameter Name="Codigo" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <h4>Insert New Task</h4>
    <hr />

    <div class="form-group">
        <asp:Label Font-Bold="True" runat="server" AssociatedControlID="SubjectsDropDown">Select subject:</asp:Label>
        <asp:DropDownList ID="SubjectsDropDown" CssClass="custom-select" runat="server" TabIndex="1" DataSourceID="TeacherSubjectsDataSource" DataTextField="codigoasig" DataValueField="codigoasig" />
    </div>

    <div class="form-group">
        <asp:Label Font-Bold="True" runat="server" AssociatedControlID="CodeTextBox">Task code:</asp:Label>
        <asp:TextBox ID="CodeTextBox" CssClass="form-control" placeholder="Task code..." TabIndex="2" autocomplete="off" runat="server" />
        <asp:RequiredFieldValidator ID="CodeRequiredFieldValidator" runat="server" CssClass="invalid-feedback" Text="Required field" ControlToValidate="CodeTextBox" Font-Bold="True" Display="Dynamic" SetFocusOnError="True" />
    </div>

    <div class="form-group">
        <asp:Label Font-Bold="True" runat="server" AssociatedControlID="EstimatedHoursTextBox">Estimated hours:</asp:Label>
        <asp:TextBox ID="EstimatedHoursTextBox" CssClass="form-control" placeholder="Enter the hours estimation" autocomplete="off" runat="server" TabIndex="3" TextMode="Number" value="0" min="0" />
        <asp:CompareValidator ID="EstimatedHoursIntegerValidator" CssClass="invalid-feedback" Type="Integer" Operator="DataTypeCheck" Font-Bold="True" Display="Dynamic" SetFocusOnError="True" runat="server" ErrorMessage="The field must have a numeric value" ControlToValidate="EstimatedHoursTextBox" />
        <asp:RequiredFieldValidator ID="EstimatedHoursRequiredFieldValidator" runat="server" CssClass="invalid-feedback" ControlToValidate="EstimatedHoursTextBox" ErrorMessage="Required field" Font-Bold="True" Display="Dynamic" SetFocusOnError="True" />
    </div>

    <div class="form-group">
        <asp:Label Font-Bold="True" runat="server" AssociatedControlID="DescriptionTextBox">Task description:</asp:Label>
        <asp:TextBox ID="DescriptionTextBox" placeholder="Task brief description..." CssClass="form-control" TextMode="MultiLine" runat="server" MaxLength="50" />
    </div>

    <div class="form-group">
        <asp:Label Font-Bold="True" runat="server" AssociatedControlID="TaskType">Task type:</asp:Label>
        <asp:TextBox ID="TaskType" CssClass="form-control" runat="server" autocomplete="on" TabIndex="4" />
    </div>

    <div class="form-group custom-control custom-checkbox">
        <input type="checkbox" class="custom-control-input" id="ActiveCheckBox" tabindex="5" runat="server" />
        <asp:Label CssClass="custom-control-label" AssociatedControlID="ActiveCheckBox" runat="server">Task active</asp:Label>
    </div>

    <div class="form-group float-right">
        <asp:Button ID="CancelButton" CssClass="btn btn-secondary" CausesValidation="false" runat="server" Text="Cancel" OnClick="CancelButton_Click" TabIndex="7" />
        <asp:Button ID="AddTaskButton" CssClass="btn btn-primary" CausesValidation="true" OnClick="AddTaskButton_Click" runat="server" Text="Add Task" TabIndex="6" />
    </div>

    <%--
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                    <button type="button" class="btn btn-primary">Save Changes</button>
                </div>
            </div>
        </div>
    </div>
    --%>
</asp:Content>
