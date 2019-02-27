<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserAccountUpdated.aspx.cs" MasterPageFile="~/PAMasterPage.master" Inherits="UserAccountUpdated" %>

<asp:Content ID="ContentArea1" ContentPlaceHolderID="NavHeader" runat="server">
    <h1 class="text-center">Success</h1>
</asp:Content>

<asp:Content ID="ContentArea2" ContentPlaceHolderID="Area2" runat="server">
    <h1>Account Updated Successfully.</h1>
    <div class="form-group row">
        
        <div class="col">
             <asp:Button type="button" class="btn btn-secondary mt-3" ID="btnLogOut" runat="server" Text="Log Out" data-toggle="tooltip" data-placement="top" title="Thanks for Updating Yor Account" OnClick="btnLogOut_Click" />
            <asp:Button type="button" class="btn btn-success mr-2 mt-3" ID="btnAccount" runat="server" Text="Back to Account" PostBackUrl="~/UserAccountDetailsPage.aspx" data-toggle="tooltip" data-placement="top" title="Go Back to Your Account"  />
        </div>
        <div class="col">
            
        </div>
       
    </div>
</asp:Content>


