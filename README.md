# Course-Project-PA

 ## WEB460 Course Project
 
This is my completed course project for Web460. Each student is assigned the same guidelines for what to include in the project, and how it should function. The TLDR is that the project is a fictional website for people who are addicted to programming. The user can log in, update their account info, and view a list of projects they completed. I added a few features that were not part of the project requirements, but I felt enhanced the project. Those features are that the user can add additional projects to their list of projects(this was optional), and I added the UserAccountUpdated.aspx page. 

---
# Project Structure

## App_Code folder

### clsBusinessLayer.cs
Business layer logic. 
This file contains methods to read and write to the "accounts.xml" file, add an account, add an application, and check a user's credentials. The CheckUserCredentials method will lock a user out of their account if they try to log in with an invalid password more than 3 times. 

### clsDataLayer.cs
This file contains all methods that interact with the database. 

### dsAccounts.xsd
This file contains the two table adapters for connecting to the two tables in the database.

## App_Data folder

### Accounts.mdb
This is the Access database file which contains the two tables for the project. tblUsers contains all user account information. tblCompletedApplications contains all completed applications for all users.

### accounts.xml
This file is created when a user chooses to export their completed projects. 

## ASPX Files

### UserLoginPage.aspx
This page allows a user to login with their credentials(user name and password). A new account can easily be created from this page by entering a user name, password, and clicking the "Create Account" button.

### UserAccountDetailsPage.aspx
This file displays the user's account details including user name, favorite language, city, state, date last program completed, and a table displaying all of the user's completed projects. In this file the user can Update Account Info by clicking the "Update Account Info" button, which contains a postback to UserAccountDetailsConfirmationPage.aspx. The user can also clear the screen, which doesn't really make sense but it was a requirement in the course project instructions. The user can choose to delete the account. The user can also export their list of projects to an XML file by clicking the "Export Stats" button.

### UserAccountDetailsConfirmationPage.aspx
In this file the user can review the information that was updated in the UserAccountDetailsPage.aspx page. The user can submit the changes by clicking the "submit" button which will update the tblUsers table in the Accounts.mdb database file. The user can also go back to UserAccountDetailsPage.aspx to edit an item by clicking the "Go Back and Edit" button. Below this section, the user can add additional projects to their list of projects. When the user clicks "Add Application" the submitted application/project details will be added to the tblCompletedApplications table in the Accounts.mdb database file.

### UserAccountUpdated.aspx
The user will be directed to this page after submitting changes to their account in the UserAccountDetailsConfirmationPage.aspx. From here the user can choose to Log Out, or go back to their account.

### PAMasterPage.master
This file contains elements that are used by all .aspx files in the project.

