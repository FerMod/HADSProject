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

    <div class="form-group">
        <asp:Label Font-Bold="True" runat="server" AssociatedControlID="DropDownSubjects">Select subject:</asp:Label>
        <asp:DropDownList ID="DropDownSubjects" CssClass="custom-select" runat="server" TabIndex="1" AutoPostBack="True" DataSourceID="TeacherSubjectsDataSource" DataTextField="codigoasig" DataValueField="codigoasig" OnDataBound="DropDownSubjects_DataBound" OnSelectedIndexChanged="DropDownSubjects_SelectedIndexChanged" />
    </div>

    <div class="form-group">
        <asp:Xml ID="XmlData" runat="server"></asp:Xml>
        <web:Notification ID="ImportNotification" runat="server" />
    </div>

    <div class="form-group">
        <asp:Button ID="ImportTasks" CssClass="btn btn-primary" runat="server" Text="Import Tasks" TabIndex="2" OnClick="ImportTasks_Click" />
    </div>

</asp:Content>
