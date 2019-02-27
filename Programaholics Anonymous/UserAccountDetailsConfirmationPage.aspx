<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PAMasterPage.master" CodeFile="UserAccountDetailsConfirmationPage.aspx.cs" Inherits="UserAccountDetailsConfirmationPage" %>

<%@ PreviousPageType VirtualPath="~/UserAccountDetailsPage.aspx" %>

<%@ MasterType VirtualPath="~/PAMasterPage.master" %>

<asp:Content ID="ContentArea1" ContentPlaceHolderID="NavHeader" runat="server">
    <div class="text-center mb-5">
        <h1 class="text-center">User Account Confirmation</h1>
    </div>
</asp:Content>
<asp:Content ID="ContentArea2" ContentPlaceHolderID="Area2" runat="server">
    <div class="row ">
        <div class="col-6 text-center mx-auto">
            <h1>Your Account</h1>
            <p>Please review your information. Click Submit to update, or Go Back to Edit your information.</p>
        </div>
    </div>
    <div class="form-group row mt-5">
        <label class="col-sm-2">
            User Name:
        </label>
        <div class="col-sm-4">
            <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>
        </div>
        <label class="col-sm-2">Favorite Language:</label>
        <div class="col-sm-4">
            <asp:Label ID="lblFavoriteLanguage" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
    <div class="form-group row">
        <label class="col-sm-2">City:</label>
        <div class="col-sm-4">
            <asp:Label ID="lblCity" runat="server" Text="Label"></asp:Label>
        </div>
        <label class="col-sm-2">State:</label>
        <div class="col-sm-4">
            <asp:Label ID="lblState" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
    <div class="form-group row">
        <label class="col-sm-2">Date Last Program Completed:</label>
        <div class="col-sm-3">
            <asp:Label ID="lblDateLastProgram" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
    <div class="form-group row">
        <label class="col-sm-2">User ID:</label>
        <div class="col-sm-3">
            <asp:Label ID="lblUserID" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
    <div class="form-group row">
        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    </div>
    <div class="mt-3">
        <asp:Button type="button" class="btn btn-info mr-2" ID="btnSubmitAccount" runat="server" Text="Submit" OnClick="btnSubmitAccount_Click" />
        <asp:Button type="button" class="btn btn-secondary mr-2" ID="btnEditAccount" runat="server" Text="Go Back and Edit" PostBackUrl="~/UserAccountDetailsPage.aspx" />
        <br />
        <hr />
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Area3" runat="server">
    <div class="container mb-5">
        <div class="row mt-3">
            <div class="col mb-2">
                <h1 class="text-center te">Add A Completed Application</h1>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-sm-3">Application Name:</label>
            <div class="col-sm-6 mb-3">
                <asp:TextBox class="form-control form-control-sm" ID="txtApplicationName" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-sm-3">Date Completed (MM/DD/YYYY):</label>
            <div class="col-sm-6">
                <asp:TextBox class="form-control form-control-sm" ID="txtDateCompleted" runat="server" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegExDateValidator" runat="server" ErrorMessage="Use Format mm/dd/yyyy" ValidationExpression="^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$" ControlToValidate="txtDateCompleted" />
            </div>
        </div>
        <div class="form-group row">
            <label class="col-sm-3">Programming Language:</label>
            <div class="col-sm-6">
                <asp:TextBox class="form-control form-control-sm" ID="txtProgrammingLanguage" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-5 mx-auto">
            <asp:Button type="button" class="btn btn-success btn-lg btn-block" ID="btnAddApplication" runat="server" Text="Add Application" OnClick="btnAddApplication_Click" />
                </div>
            </div>
    </div>

</asp:Content>

