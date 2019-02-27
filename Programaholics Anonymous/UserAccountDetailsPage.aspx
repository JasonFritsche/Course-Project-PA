<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PAMasterPage.master" CodeFile="UserAccountDetailsPage.aspx.cs" Inherits="UserAccountDetailsPage" %>

<%@ MasterType VirtualPath="~/PAMasterPage.master" %>
<%@ PreviousPageType VirtualPath="~/UserLoginPage.aspx" %>


<asp:Content ID="ContentArea1" ContentPlaceHolderID="NavHeader" runat="server">
    <div>
        <h1 class="text-center">User Account Details</h1>
    </div>
</asp:Content>
<asp:Content ID="ContentArea2" ContentPlaceHolderID="Area2" runat="server">
        <div class="mb-3">
        <div class="text-center">
            <asp:Button type="button" class="btn btn-warning mt-3" ID="btnUpdateAccount" runat="server" Text="Update Account Info" data-toggle="tooltip" data-placement="top" title="Click Here to Update Account Data" OnClick="btnUpdateAccount_Click" PostBackUrl="~/UserAccountDetailsConfirmationPage.aspx" />
            <asp:Button type="button" class="btn btn-secondary mt-3" ID="btnClearInputs" runat="server" Text="Clear Screen" data-toggle="tooltip" data-placement="top" title="Clear All Fields" OnClick="btnClearInputs_Click" />
            <asp:Button type="button" class="btn btn-danger mt-3" ID="btnDeleteAccount" runat="server" Text="Delete Account" data-toggle="tooltip" data-placement="top" title="Permanently Delete" OnClick="btnDeleteAccount_Click" OnClientClick="return confirm('Are you sure you want to delete this record?');"/>
            <asp:Button type="button" class="btn btn-primary mt-3" ID="btnExportXML" runat="server" Text="Export Stats" data-toggle="tooltip" data-placement="top" title="Export to XML" OnClick="btnExportXML_Click" />
            <asp:Button type="button" class="btn btn-dark mt-3" ID="btnLogOut" runat="server" Text="Log Out" data-toggle="tooltip" data-placement="top" title="Log Out of Your Account" OnClick="btnLogOut_Click" />
        </div>
    </div>
    <div class="form-group row">
        <label class="col-sm-1">User Name:</label>
        <div class="col-sm-4">
            <asp:TextBox class="form-control form-control-sm" ID="txtUserName" runat="server"></asp:TextBox>
        </div>
        <label class="col-sm-2">Favorite Language:</label>
        <div class="col-sm-4">
            <asp:TextBox class="form-control form-control-sm" ID="txtFavoriteLanguage" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label class="col-sm-1">City:</label>
        <div class="col-sm-4">
            <asp:TextBox class="form-control form-control-sm" ID="txtCity" runat="server"></asp:TextBox>
        </div>
        <label class="col-sm-2">State:</label>
        <div class="col-sm-4">
            <asp:TextBox class="form-control form-control-sm" ID="txtState" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label class="col-sm-2">Date Last Program Completed:</label>
        <div class="col-sm-3">
            <asp:TextBox class="form-control form-control-sm" ID="txtDateLastProgram" runat="server"></asp:TextBox>
        </div>
        <asp:Label CssClass="col-sm-2" ID="lblUserID" runat="server" Text="User ID: "></asp:Label>
        <div class="col-sm-4">
            <asp:TextBox class="form-control form-control-sm" ID="userID" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Area3" runat="server">
    <div class="container">
        <h1 class="text-center" id="CompletedApplicationsHeader" runat="server"></h1>
        <asp:GridView ID="CompletedApplicationGridView" runat="server" CellPadding="6"
            CssClass="table table-striped table-bordered table-condensed table-hover table-dark">
        </asp:GridView>
    </div>

    
</asp:Content>


