<%@ Page Title="Student Tasks" Language="C#" MasterPageFile="~/UserPages/Student/Student.Master" AutoEventWireup="true" CodeBehind="InstanciarTarea.aspx.cs" Inherits="WebApplication.UserPages.InstanciarTarea" %>

<%@ MasterType VirtualPath="~/UserPages/Student/Student.Master" %>

<asp:Content ID="StudentTasksContent" ContentPlaceHolderID="StudentContent" runat="server">

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

    <h4>Instantiate Task</h4>
	<hr />

    <div class="form-group">
        <asp:Label Font-Bold="True" runat="server" AssociatedControlID="EmailTextBox">Email:</asp:Label>
        <asp:TextBox ID="EmailTextBox" CssClass="form-control" runat="server" autocomplete="off" ReadOnly="true"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label Font-Bold="True" runat="server" AssociatedControlID="CodTareaTextBox">Task code:</asp:Label>
        <asp:TextBox ID="CodTareaTextBox" CssClass="form-control" runat="server" autocomplete="off" ReadOnly="true"></asp:TextBox>
    </div>

    <div class="form-row">

        <div class="form-group col-md-6">
            <asp:Label Font-Bold="True" runat="server" AssociatedControlID="HEstimadasTextBox">Estimated hours:</asp:Label>
            <asp:TextBox ID="HEstimadasTextBox" CssClass="form-control" runat="server" autocomplete="off" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group col-md-6">
            <asp:Label Font-Bold="True" runat="server" AssociatedControlID="HRealesTextBox">Real hours:</asp:Label>
            <asp:TextBox ID="HRealesTextBox" CssClass="form-control" placeholder="Enter the real hours" autocomplete="off" CausesValidation="true" runat="server" TabIndex="1" TextMode="Number" value="0" min="0" />
            <asp:CompareValidator ID="HRealesIntegerValidator" CssClass="invalid-feedback" Type="Integer" Operator="DataTypeCheck" Font-Bold="True" Display="Dynamic" SetFocusOnError="True" runat="server" ErrorMessage="The field must have a numeric value" ControlToValidate="HRealesTextBox" />
            <asp:RequiredFieldValidator ID="HRealesRequiredFieldValidator" runat="server" CssClass="invalid-feedback" ControlToValidate="HRealesTextBox" ErrorMessage="Required field" Font-Bold="True" Display="Dynamic" SetFocusOnError="True" />
        </div>

    </div>

    <div class="form-group float-right">
        <asp:Button ID="CancelButton" CssClass="btn btn-secondary" runat="server" Text="Cancel" OnClick="CancelButton_Click" TabIndex="2" />
        <button type="button" class="btn btn-primary" tabindex="3" data-toggle="modal" data-target="#taskModal">Save Changes</button>
    </div>

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
                    Save the made changes?<br />
                    Those changes will be made permanent, and cannot be edited after the submit.
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                    <asp:Button ID="SaveChangesButton" CssClass="btn btn-primary" OnClick="SaveChangesButton_Click" runat="server" Text="Save Changes" />
                </div>
            </div>
        </div>
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
