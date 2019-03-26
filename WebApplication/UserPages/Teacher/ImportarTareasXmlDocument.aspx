<%@ Page Title="Import Tasks" Language="C#" MasterPageFile="~/UserPages/Teacher/Teacher.Master" AutoEventWireup="true" CodeBehind="ImportarTareasXmlDocument.aspx.cs" Inherits="WebApplication.UserPages.ImportarTareasXmlDocument" %>

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

    <div class="form-group form-row">
        <div class="input-group col-md-6">
            <asp:DropDownList ID="DropDownSubjects" CssClass="custom-select" runat="server" TabIndex="1" AutoPostBack="True" DataSourceID="TeacherSubjectsDataSource" DataTextField="codigoasig" DataValueField="codigoasig" OnDataBound="DropDownSubjects_DataBound" OnSelectedIndexChanged="DropDownSubjects_SelectedIndexChanged" />
            <div class="input-group-append">
                <asp:Button ID="ImportTasksButton" CssClass="btn btn-primary" Text="Import Tasks" TabIndex="2" OnClick="ImportTasks_Click" CausesValidation="False" Enabled="true" runat="server" UseSubmitBehavior="False" />
            </div>
        </div>
    </div>

    <div class="form-group">
        <asp:Xml ID="XmlData" runat="server"></asp:Xml>
    </div>

    <web:Notification ID="ImportNotification" Dismissible="true" runat="server" />

</asp:Content>
