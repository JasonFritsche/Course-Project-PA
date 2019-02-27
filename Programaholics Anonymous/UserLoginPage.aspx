<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PAMasterPage.master" CodeFile="UserLoginPage.aspx.cs" Inherits="UserLoginPage" %>

<%@ MasterType VirtualPath="~/PAMasterPage.master" %>


<asp:Content ID="ContentArea1" ContentPlaceHolderID="NavHeader" runat="server">
    <div>
        <h1 class="text-center mb-3 py-1">Programaholics Anonymous</h1>
        <h2 class="text-center mt-1 appParaText">Find your life outside of programming</h2>
    </div>
</asp:Content>

<asp:Content ID="ContentArea2" ContentPlaceHolderID="Area2" runat="server">
   
    <div class="col-8 mx-auto">
        <blockquote class="blockquote">
            <p class="mb-0">Log in with your username and password. If you are new, please enter a username, password, and click 'Create Account' to get started.</p>
        </blockquote>
    </div>
    <div class="container">
        <div class="form-group row mt-5">
            <label class="col-sm-2">User Name:</label>
            <div class="col-sm-8">
                <asp:TextBox class="form-control form-control-sm" ID="txtLoginUserName" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-sm-2">Password:</label>
            <div class="col-sm-8">
                <asp:TextBox class="form-control form-control-sm" ID="txtLoginPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="mx-auto mt-3">
                <asp:Button type="button" class="btn btn-info " ID="btnLogin" runat="server" Text="Login" data-toggle="tooltip" data-placement="top" title="Login to your Account" OnClick="btnLogin_Click"></asp:Button>
                <asp:Button type="button" class="btn btn-secondary" ID="btnCreateAccount" runat="server" Text="Create Account" data-toggle="tooltip" data-placement="top" title="Create an Account" OnClick="btnCreateAccount_Click" />
            </div>
        </div>
    </div>

</asp:Content>
