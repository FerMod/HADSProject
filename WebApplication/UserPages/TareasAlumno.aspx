<%@ Page Title="Student Tasks" Language="C#" MasterPageFile="~/UserPages/UserHome.Master" AutoEventWireup="true" CodeBehind="TareasAlumno.aspx.cs" Inherits="WebApplication.UserPages.TareasAlumno" %>

<%@ MasterType VirtualPath="~/UserPages/UserHome.Master" %>

<asp:Content ID="StudentTasksContent" ContentPlaceHolderID="StudentContent" runat="server">

    <div class="form-group">
        <asp:Label Font-Bold="True" runat="server" AssociatedControlID="DropDownSubjects">Select subject:</asp:Label>
        <asp:DropDownList ID="DropDownSubjects" runat="server" TabIndex="1" OnSelectedIndexChanged="DropDownSubjects_SelectedIndexChanged" AutoPostBack="True" />
    </div>

    <div class="form-group">
        <asp:GridView ID="GridViewTasks" CssClass="table table-responsive-md table-hover" runat="server" TabIndex="2" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" PageSize="10" OnSorting="GridViewTasks_Sorting" EmptyDataText="No tasks available." OnRowCommand="GridViewTasks_RowCommand">
            <HeaderStyle CssClass="table-striped thead-dark" />
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <%--                        <asp:Button ID="InstantiateButton" runat="server" CausesValidation="false" CommandName="Instantiate" Text="Instantiate" CommandArgument='<%# Eval("Codigo") %>' data-toggle="modal" data-target="#taskModal" />--%>
                        <asp:Button ID="InstantiateButton" CssClass="btn btn-primary btn-block" runat="server" CausesValidation="false" CommandName="Instantiate" Text="Instantiate" CommandArgument='<%# Eval("Codigo") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Code" DataField="Codigo" SortExpression="Codigo" />
                <asp:BoundField HeaderText="Description" DataField="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField HeaderText="Estimated Hours" DataField="HEstimadas" SortExpression="HEstimadas" />
                <asp:BoundField HeaderText="Type" DataField="TipoTarea" SortExpression="TipoTarea" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
