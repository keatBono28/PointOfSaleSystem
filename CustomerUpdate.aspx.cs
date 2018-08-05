using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class MIS3200_FPkb619814_Customer_CustomerUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // check to see if the expected querystring has "sid" AND make sure that we only do this when the page is initially loaded
        // so we don't unintentially laod the data again after making changes
        if (Request.QueryString["customerid"] != null && !Page.IsPostBack)
        {
            // the sid should be a number, so lets attempt to convert it to a number before storing it in a session variable
            // that we can use in this page (or outside of this page)
            try
            {
                Session["customerId"] = Convert.ToUInt32(Request.QueryString["customerid"]);
                // if it is a number greater than 0, go ahead and load the student data
                if (Convert.ToInt32(Session["customerId"]) > 0)
                    LoadData();
            }
            catch (Exception)
            {
                lblError.Text = " Bad Customer Id!";
                //throw;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        // Checking to make sure the text boxes aren't empty, error handling, instead of using RFV's
        if (txtAddress.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && txtCity.Text != "" && txtState.Text != "" && txtZip.Text != "")
        {
            // create a session variable called "message" that we can use to see what happend to the data
            // once we send the user back to the "startingPage" application
            // note, whe we call the UpdateStudentData method, it will return a message that will be assigned to Session["message"]
            Session["message"] = UpdateData();
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


    protected void LoadData()
    {
        //create an instance of a SqlConnection object so that we know where to find our database that we want to work with
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        //create an instance of a SqlCommand object so that we know what SQL to execute against the database
        SqlCommand myCommand = new SqlCommand("SELECT * FROM Customer WHERE customerid=@customerId", myConnection);
        myCommand.Parameters.Add("@customerId", SqlDbType.Int).Value = Convert.ToInt32(Session["customerId"]);
        try
        {
            //let's open the database connection
            myConnection.Open();
            //create an instance of a SqlDataReader object so that we can read the data from the database
            SqlDataReader myReader = myCommand.ExecuteReader();
            //if the myReader has any data, which we determine by calling the myReader.Read() method, then we can read the data
            if (myReader.Read())
            {
                // This is where the database workd gets done...
                // read each attribute out and store it in the appropriate textbox
                txtFirstName.Text = myReader["customerFirstName"].ToString();
                txtLastName.Text = myReader["customerLastName"].ToString();
                txtAddress.Text = myReader["customerAddress"].ToString();
                txtCity.Text = myReader["customerCity"].ToString();
                txtState.Text = myReader["customerState"].ToString();
                txtZip.Text = myReader["customerZip"].ToString();
            }
            //close myReader
            myReader.Close();
        }
        catch (Exception ex)
        {
            lblError.Text = "<br /><br />LoadData: " + ex.ToString() + "<br />";
        }
        finally
        {
            //cleanup our garbage!
            //call the dispose method of the myCommand
            myCommand.Dispose();
            //call the close method of the myConnection - critical!!!
            myConnection.Close();
        }
    }


    protected string UpdateData()
    {
        string strDataThatWeWillReturn = "";

        //create an instance of a SqlConnection object so that we know where to find our database that we want to work with
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        //create an instance of a SqlCommand object so that we know what SQL to execute against the database
        SqlCommand myCommand = new SqlCommand("UPDATE Customer set customerFirstName=@customerFirstName,customerLastName=@customerLastName,customerAddress=@customerAddress,customerCity=@customerCity,customerState=@customerState,customerZip=@customerZip WHERE customerId=@customerId;", myConnection);
        myCommand.Parameters.Add("@customerFirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
        myCommand.Parameters.Add("@customerLastName", SqlDbType.VarChar).Value = txtLastName.Text;
        myCommand.Parameters.Add("@customerAddress", SqlDbType.VarChar).Value = txtAddress.Text;
        myCommand.Parameters.Add("@customerCity", SqlDbType.VarChar).Value = txtCity.Text;
        myCommand.Parameters.Add("@customerState", SqlDbType.VarChar).Value = txtState.Text;
        myCommand.Parameters.Add("@customerzip", SqlDbType.Int).Value = Convert.ToInt32(txtZip.Text);
        myCommand.Parameters.Add("@customerId", SqlDbType.Int).Value = Convert.ToInt32(Session["customerId"]);
        try
        {
            //let's open the database connection
            myConnection.Open();
            //execute the non-query, in this case a INSERT SQL command
            // if it INSERTS more than 0 records, this is an indication that it worked correctly
            if (myCommand.ExecuteNonQuery() > 0)
            {
                strDataThatWeWillReturn = "customer data was succesfully updated";
            }
            else
            {
                strDataThatWeWillReturn = "update failed!";
            }

        }
        catch (Exception ex)
        {
            strDataThatWeWillReturn = "Error in UpdateData: " + ex.ToString();
            
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