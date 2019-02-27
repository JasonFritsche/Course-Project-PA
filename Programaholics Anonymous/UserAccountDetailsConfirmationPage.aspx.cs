using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserAccountDetailsConfirmationPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (PreviousPage.IsCrossPagePostBack)
            {
                lblUserName.Text = PreviousPage.UserName.Text;
                lblFavoriteLanguage.Text = PreviousPage.FavoriteLanguage.Text;
                lblCity.Text = PreviousPage.City.Text;
                lblState.Text = PreviousPage.State.Text;
                lblDateLastProgram.Text = PreviousPage.DateLastProgram.Text;
                lblUserID.Text = PreviousPage.UserID.Text;
                
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Something went wrong...Here is the message: " + ex.Message;
        }
    }

    protected void btnSubmitAccount_Click(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
        //    sendData();
        //}
        sendData();

    }

    protected void sendData()
    {
        bool error = false;

        string tempPath = Server.MapPath("~/App_Data/Accounts.mdb");
        clsDataLayer dataLayerObject = new clsDataLayer(tempPath);

        try
        {
            dataLayerObject.UpdateAccount(lblUserName.Text, lblFavoriteLanguage.Text, lblCity.Text, lblState.Text, lblDateLastProgram.Text, Convert.ToInt32(lblUserID.Text));
                //dataLayerObject.UpdateAccount(UserName.ToString(), FavoriteLanguage.ToString(), City.ToString(), State.ToString(), DateLastProgram.ToString(), Convert.ToInt32(userID.Text));
            
        }
        catch (Exception ex)
        {
            error = true;
            string message = "An error occured...Please ensure all fields are properly filled out. Error details - ";
            Master.MasterMessage.Text = message + ex.Message;
        }

        if (!error)
        {
            Master.MasterMessage.Text = "User Account Updated.";
            Response.Redirect("~/UserAccountUpdated.aspx");
        }
    }

    protected void btnAddApplication_Click(object sender, EventArgs e)
    {
        bool error = false;
        string tempPath = Server.MapPath("~/App_Data/Accounts.mdb");
        clsDataLayer dataLayerObject = new clsDataLayer(tempPath);

        try
        {
            dataLayerObject.AddApplication(Convert.ToInt32(lblUserID.Text), txtApplicationName.Text, txtDateCompleted.Text, txtProgrammingLanguage.Text);
        }
        catch (Exception ex)
        {
            error = true;
            string message = "An error occured...Please ensure all fields are properly filled out. Error details - ";
            Master.MasterMessage.Text = message + ex.Message;
        }

        if (!error)
        {
            Response.Redirect("~/UserAccountDetailsPage.aspx");
            
        }

    }

}