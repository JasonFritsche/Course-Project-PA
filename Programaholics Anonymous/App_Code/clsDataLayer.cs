using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsDataLayer
/// </summary>
public class clsDataLayer
{

    OleDbConnection dbConnection;

    public clsDataLayer(string Path)
    {
        dbConnection = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path);
    }

    public dsAccounts FindUser(string UserName)
    {
        string sqlStatement = "select * from tblUsers where UserName like '" + UserName + "'";
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStatement, dbConnection);

        dsAccounts storedDataSet = new dsAccounts();
        sqlDataAdapter.Fill(storedDataSet.tblUsers);

        return storedDataSet;
    }

    public void DeleteAccount(string UserName, string id)
    {
        dbConnection.Open();
        
        // delete user from tblUsers
        string sqlStatement1 = "DELETE FROM tblUsers WHERE UserName like '" + UserName + "'";
        OleDbCommand dbCommand1 = new OleDbCommand(sqlStatement1, dbConnection);
        dbCommand1.ExecuteNonQuery();

        // delete the user's applications from tblCompletedApplications
        string sqlStatement2 = "DELETE FROM tblCompletedApplications WHERE UserID like '" + id + "'";
        OleDbCommand dbCommand2 = new OleDbCommand(sqlStatement2, dbConnection);
        dbCommand2.ExecuteNonQuery();

        dbConnection.Close();
    }

    public void AddAccount(string username, string password)
    {
        dbConnection.Open();

        string sqlStatement = "INSERT INTO tblUsers(UserName, FavLanguage, City, State, DateLastProgram, [Password]) ";
        sqlStatement += "VALUES(@username, @favlanguage, @city, @state, @date, @password)";

        OleDbCommand dbCommand = new OleDbCommand(sqlStatement, dbConnection);

        OleDbParameter param = new OleDbParameter("@username", username);
        dbCommand.Parameters.Add(param);

        dbCommand.Parameters.Add(new OleDbParameter("@favlanguage", ""));
        dbCommand.Parameters.Add(new OleDbParameter("@city", ""));
        dbCommand.Parameters.Add(new OleDbParameter("@state", ""));
        dbCommand.Parameters.Add(new OleDbParameter("@date", ""));
        dbCommand.Parameters.Add(new OleDbParameter("@password", password));

        dbCommand.ExecuteNonQuery();

        dbConnection.Close();
    }


    public void UpdateAccount(string UserName, string FavLanguage, string City, string State, string DateLastProgram, int UserID)
    {
        dbConnection.Open();


        string sqlStatement = "UPDATE tblUsers SET UserName = @username, " +
            "FavLanguage = @favlanguage, " + "City = @city, " + "State = @state, " + 
            "DateLastProgram = @datelastprogram " + "WHERE (tblUsers.UserID = @id)";

        OleDbCommand dbCommand = new OleDbCommand(sqlStatement, dbConnection);

        dbCommand.Parameters.Add(new OleDbParameter("@username", UserName));
        dbCommand.Parameters.Add(new OleDbParameter("favlanguage", FavLanguage));
        dbCommand.Parameters.Add(new OleDbParameter("city", City));
        dbCommand.Parameters.Add(new OleDbParameter("state", State));
        dbCommand.Parameters.Add(new OleDbParameter("datelastprogram", DateLastProgram));
        dbCommand.Parameters.Add(new OleDbParameter("@id", UserID));

        dbCommand.ExecuteNonQuery();

        dbConnection.Close();

    }

    // method for completed application gridview dataset
    public dsAccounts GetCompletedApplications(int ID)
    {
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter("Select * from tblCompletedApplications WHERE UserID like '" + ID + "';", dbConnection);

        dsAccounts storedData = new dsAccounts();
        sqlDataAdapter.Fill(storedData.tblCompletedApplications);

        return storedData;
    }

    public void AddApplication(int ID, string appName, string dateCompleted, string language)
    {
        dbConnection.Open();

        string sqlStatement = "INSERT INTO tblCompletedApplications(UserID, ApplicationName, DateCompleted, ProgrammingLanguage) ";
        sqlStatement += "VALUES(@id, @app, @date, @lang)";

        OleDbCommand dbCommand = new OleDbCommand(sqlStatement, dbConnection);

        dbCommand.Parameters.Add(new OleDbParameter("@id", ID.ToString()));
        dbCommand.Parameters.Add(new OleDbParameter("@app", appName));
        dbCommand.Parameters.Add(new OleDbParameter("@date", dateCompleted));
        dbCommand.Parameters.Add(new OleDbParameter("@lang", language));
        

        dbCommand.ExecuteNonQuery();

        dbConnection.Close();
    }

    public dsAccounts GetCompletedApplications()
    {
        string sqlStatement = "Select * from tblCompletedApplications;";
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStatement, dbConnection);

        dsAccounts storedData = new dsAccounts();
        sqlDataAdapter.Fill(storedData.tblCompletedApplications);

        return storedData;
    }

    public bool ValidateUser(string username, string password)
    {
        dbConnection.Open();

        string sqlStatement = "SELECT * FROM tblUsers WHERE UserName = @username AND Password = @password";

        OleDbCommand dbCommand = new OleDbCommand(sqlStatement, dbConnection);

        dbCommand.Parameters.Add(new OleDbParameter("@username", username));
        dbCommand.Parameters.Add(new OleDbParameter("@password", password));

        OleDbDataReader dataReader = dbCommand.ExecuteReader();

        Boolean isValidAccount = dataReader.Read();

        dbConnection.Close();

        return isValidAccount;
    }

    public void LockAccount(string username)
    {
        dbConnection.Open();

        string sqlStatement = "UPDATE tblUsers SET Locked = True WHERE UserName = @username";

        OleDbCommand dbCommand = new OleDbCommand(sqlStatement, dbConnection);

        dbCommand.Parameters.Add(new OleDbParameter("@username", username));

        dbCommand.ExecuteNonQuery();

        dbConnection.Close();
    }

}

