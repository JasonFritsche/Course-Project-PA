using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserAccountDetailsPage : System.Web.UI.Page
{
    clsBusinessLayer myBusinessLayer;

    protected void Page_Load(object sender, EventArgs e)
    {
        myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));
        //BindXMLGridView();
        btnExportXML.Visible = false;
        // page previous page username text

        string username = Session["UserName"].ToString();
        if (!Page.IsPostBack)
        {
            loadUserData(username);
        }
            
    }

    public TextBox UserName
    { get { return txtUserName; } }

    public TextBox FavoriteLanguage
    { get { return txtFavoriteLanguage; } }

    public TextBox City
    { get { return txtCity; } }

    public TextBox State
    { get { return txtState; } }

    public TextBox DateLastProgram
    { get { return txtDateLastProgram; } }

    public TextBox UserID
    { get { return userID; } }

    protected void loadUserData(string username)
    {
        bool error = false;

        dsAccounts dsFindAccount;

        string tempPath = Server.MapPath("~/App_Data/Accounts.mdb");
        clsDataLayer dataLayerObject = new clsDataLayer(tempPath);

        try
        {
            dsFindAccount = dataLayerObject.FindUser(username);

            if (dsFindAccount.tblUsers.Rows.Count > 0)
            {
                txtUserName.Text = dsFindAccount.tblUsers[0].UserName;
                txtFavoriteLanguage.Text = dsFindAccount.tblUsers[0].FavLanguage;
                txtCity.Text = dsFindAccount.tblUsers[0].City;
                txtState.Text = dsFindAccount.tblUsers[0].State;
                txtDateLastProgram.Text = dsFindAccount.tblUsers[0].DateLastProgram;
                userID.Text = dsFindAccount.tblUsers[0].UserID.ToString();
                CompletedApplicationsHeader.InnerText = "Completed Applications";
                btnExportXML.Visible = true;
            }

            else
            {
                error = true;
                Master.MasterMessage.Text = "Unable to find that account...";
            }
        }
        catch (Exception ex)
        {
            string message = "Uh oh, something went wrong, here are the details - ";
            Master.MasterMessage.Text = message + ex.Message;
        }

        if (error == false)
        {
            BindApplicationsGridView();
        }
    }

    private void ClearInputs(ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            if (control is TextBox)
                ((TextBox)control).Text = string.Empty;
            else if (control is GridView)
            {
                ((GridView)control).DataSource = null;
                ((GridView)control).DataBind();
            }
            else
                ClearInputs(control.Controls);
        }

        Master.MasterMessage.Text = "";
        userID.Text = "";
        CompletedApplicationsHeader.InnerHtml = "";
        btnExportXML.Visible = false;

    }

    protected void btnClearInputs_Click(object sender, EventArgs e)
    {
        ClearInputs(Page.Controls);
    }

    protected void btnUpdateAccount_Click(object sender, EventArgs e)
    {

    
    }

    protected void btnDeleteAccount_Click(object sender, EventArgs e)
    {
        bool error = false;

        string tempPath = Server.MapPath("~/App_Data/Accounts.mdb");
        clsDataLayer dataLayerObject = new clsDataLayer(tempPath);

        try
        {
            dataLayerObject.DeleteAccount(txtUserName.Text, userID.Text);

        }
        catch (Exception ex)
        {
            error = true;
            string message = "An error occured...Unable to delete that customer. Error details - ";
            Master.MasterMessage.Text = message + ex.Message;
        }

        if (!error)
        {
            Master.MasterMessage.Text = "User Account Deleted...redirecting to login page";

            Response.Redirect("~/UserLoginPage.aspx");

        }
    }

    private dsAccounts BindApplicationsGridView()
    {
        string tempPath = Server.MapPath("~/App_Data/Accounts.mdb");
        clsDataLayer dataLayerObject = new clsDataLayer(tempPath);

        dsAccounts completedApplications = dataLayerObject.GetCompletedApplications(Convert.ToInt32(userID.Text));

        CompletedApplicationGridView.DataSource = completedApplications.tblCompletedApplications;

        CompletedApplicationGridView.DataBind();
        Cache.Insert("ApplicationsDataSet", completedApplications);

        return completedApplications;
    }

    public void BindXMLGridView()
    {
        CompletedApplicationGridView.DataSource = myBusinessLayer.GetAccountXMLFile();
        CompletedApplicationGridView.DataBind();
    }

    public void btnExportXML_Click(object sender, EventArgs e)
    {
        CompletedApplicationGridView.DataSource = myBusinessLayer.WriteAccountXMLFile(Cache);
        CompletedApplicationGridView.DataBind();
        ClearInputs(Page.Controls);
        ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + "Data Successfully Exported" + "');", true);

    }


    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserLoginPage.aspx");
    }


}