using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.SessionState;

/// <summary>
/// Summary description for clsBusinessLayer
/// </summary>
public class clsBusinessLayer
{

    // path on the server to the App_Data directory where XML File will be stored
    string dataPath;

    clsDataLayer myDataLayer;

    public clsBusinessLayer(string serverMappedPath)
    {
        dataPath = serverMappedPath;
        myDataLayer = new clsDataLayer(dataPath + "Accounts.mdb");
    }

    public DataSet GetAccountXMLFile()
    {
        DataSet xmlDataSet = new DataSet();

        try
        {
            xmlDataSet.ReadXml(dataPath + "accounts.xml");
        }
        catch(System.IO.FileNotFoundException)
        {
            dsAccounts accountListing = myDataLayer.GetCompletedApplications();
            accountListing.tblCompletedApplications.WriteXml(dataPath + "accounts.xml");
            xmlDataSet.ReadXml(dataPath + "accounts.xml");
        }

        return xmlDataSet;
    }

    public DataSet WriteAccountXMLFile(System.Web.Caching.Cache appCache)
    {
        DataSet xmlDataSet = (DataSet)appCache["ApplicationsDataSet"];

        xmlDataSet.WriteXml(dataPath + "accounts.xml");

        return xmlDataSet;
    }

    public bool CheckUSerCredentials(HttpSessionState currentSession, string username, string password)
    {
        currentSession["LockedSession"] = false;

        int totalAttempts = Convert.ToInt32(currentSession["AttemptCount"]) + 1;
        currentSession["AttemptCount"] = totalAttempts;

        int userAttempts = Convert.ToInt32(currentSession[username]) + 1;
        currentSession[username] = userAttempts;

        if((userAttempts > 3) || (totalAttempts > 6))
        {
            currentSession["LockedSession"] = true;
            myDataLayer.LockAccount(username);
        }
        return myDataLayer.ValidateUser(username, password);
    }

    public string AddAccount(string username, string password)
    {
        string resultMessage = "Your Account has been created!";

        try
        {
            myDataLayer.AddAccount(username, password);
        }
        catch(Exception ex)
        {
            resultMessage = "An error occurred. Please try again. Error message: " + ex.Message;
        }

        return resultMessage;
    }

    public string AddApplication(int ID, string appName, string date, string language)
    {
        string resultMessage = "Application added successfully";

        try
        {
            myDataLayer.AddApplication(ID, appName, date, language);
        }
        catch(Exception ex)
        {
            resultMessage = "An error occurred. Please try again. Error message: " + ex.Message;
        }

        return resultMessage;
    }
}