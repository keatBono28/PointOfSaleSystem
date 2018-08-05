using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class MIS3200_FPkb619814_Customer_CustomerInsert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        // Checking to make sure the text boxes aren't empty, error handling, instead of using RFV's
        if (txtAddress.Text != "" && txtFirstName.Text != "" && txtLastName.Text != ""  && txtCity.Text != "" && txtState.Text != "" && txtZip.Text != "")
        {
            // create a session variable called "message" that we can use to see what happend to the data
            // once we send the user back to the "startingPage" application
            // note, whe we call the InsertStudentData method, it will return a message that will be assigned to Session["message"]
            Session["message"] = InsertData();
            try
            {
                // we created a "startingPage" session variable in the Page_load method of the initial application
                // we can call "Response.Redirect" to send the user to any url,
                // in this case, let's send the use back t the application that was described in the session["startingPage"]
                Response.Redirect(Session["startingPage"].ToString());
            }
            catch (Exception)
            {
                // if the user waits too long, the session["startingPage"] variable may no longer be available, in which case,
                // give them a message about what to do
                lblError.Text = "Please click on the link above to navigate back to the appropriate application";
                //throw;
            }
        }
        else
        {
            // Telling the user to enter information so that its not blank
            lblError.Text = "Please enter data into the fields";
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            // we created a "startingPage" session variable in the Page_load method of the initial application
            // we can call "Response.Redirect" to send the user to any url,
            // in this case, let's send the use back t the application that was described in the session["startingPage"]
            Response.Redirect(Session["startingPage"].ToString());
        }
        catch (Exception)
        {
            // if the user waits too long, the session["startingPage"] variable may no longer be available, in which case,
            // give them a message about what to do
            lblError.Text = "Please click on the link above to navigate back to the appropriate application";
            //throw;
        }
    }

    protected string InsertData()
    {
        string strDataThatWeWillReturn = "";

        //create an instance of a SqlConnection object so that we know where to find our database that we want to work with
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        //create an instance of a SqlCommand object so that we know what SQL to execute against the database
        SqlCommand myCommand = new SqlCommand("INSERT into Customer (customerFirstName,customerLastName,customerAddress,customerCity,customerState,customerZip) VALUES (@customerFirstName,@customerLastName,@customerAddress,@customerCity,@customerState,@customerZip);", myConnection);
        myCommand.Parameters.Add("@customerFirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
        myCommand.Parameters.Add("@customerLastName", SqlDbType.VarChar).Value = txtLastName.Text;
        myCommand.Parameters.Add("@customerAddress", SqlDbType.VarChar).Value = txtAddress.Text;
        myCommand.Parameters.Add("@customerCity", SqlDbType.VarChar).Value = txtCity.Text;
        myCommand.Parameters.Add("@customerState", SqlDbType.VarChar).Value = txtState.Text;
        myCommand.Parameters.Add("@customerzip", SqlDbType.Int).Value = Convert.ToInt32(txtZip.Text);

        try
        {
            //let's open the database connection
            myConnection.Open();
            //execute the non-query, in this case a INSERT SQL command
            // if it INSERTS more than 0 records, this is an indication that it worked correctly
            if (myCommand.ExecuteNonQuery() > 0)
            {
                strDataThatWeWillReturn = "customer data was succesfully created";
            }
            else
            {
                strDataThatWeWillReturn = "inserted failed!";
            }

        }
        catch (Exception ex)
        {
            strDataThatWeWillReturn = "Error in InsertData: " + ex.ToString();
            //lblError.Text = "<br /><br />GetTheRowDataForAllStudentsV1: " + ex.ToString() + "<br />";
        }
        finally
        {
            //cleanup our garbage!
            //call the dispose method of the myCommand
            myCommand.Dispose();
            //call the close method of the myConnection - critical!!!
            myConnection.Close();
        }

        return strDataThatWeWillReturn;
    }



}