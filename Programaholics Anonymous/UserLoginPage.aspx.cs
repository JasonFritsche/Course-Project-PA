using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserLoginPage : System.Web.UI.Page
{
    clsBusinessLayer myBusinessLayer;
    public TextBox UserName { get { return txtLoginUserName; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));
    }

    protected void btnLogin_Click(object sender, EventArgs e)

    {
        if (txtLoginUserName.Text != "" && txtLoginPassword.Text != "")
        {

            bool isVerifiedUser = myBusinessLayer.CheckUSerCredentials(Session, txtLoginUserName.Text, txtLoginPassword.Text);

            if (isVerifiedUser)
            {
                Session["UserName"] = txtLoginUserName.Text;
                Response.Redirect("~/UserAccountDetailsPage.aspx");
            }
            else if (Convert.ToBoolean(Session["LockedSession"]))
            {
                Master.MasterMessage.Text = "Too many invalid attempts. This account is now locked.";
                btnLogin.Visible = false;
            }
            else
            {
                Master.MasterMessage.Text = "Invalid credentials. Please try again.";
            }
        }
        else
        {
            Master.MasterMessage.Text = "We can't create an account without a username and password.";
        }
    }

    protected void btnCreateAccount_Click(object sender, EventArgs e)
    {
        if (txtLoginUserName.Text != "" && txtLoginPassword.Text != "")
        {
            myBusinessLayer.AddAccount(txtLoginUserName.Text, txtLoginPassword.Text);
            Session["UserName"] = txtLoginUserName.Text;
            Response.Redirect("~/UserAccountDetailsPage.aspx");

        }
        else
        {
            Master.MasterMessage.Text = "We can't create an account without a username and password.";
        }
    }
}