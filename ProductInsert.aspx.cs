using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class MIS3200_FPkb619814_Product_ProductInsert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetProductCode();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtDescription.Text != "" && txtPrice.Text != "")
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


    // I need a method to auto populate the text box for the productCode
    private void GetProductCode()
    {
        // Need a temp int for the product code
        int tempCode = 0000;
        //create an instance of a SqlConnection object so that we know where to find our database that we want to work with
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        //create an instance of a SqlCommand object so that we know what SQL to execute against the database
        SqlCommand myCommand = new SqlCommand("SELECT TOP 1 productCode FROM Product ORDER BY productCode DESC", myConnection);
        
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
                tempCode = Convert.ToInt32(myReader["productCode"]);
                tempCode = tempCode + 1; // This is adding one to the product code to create the next number available
                txtProductCode.Text = tempCode.ToString("00##"); 
               
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




    protected string InsertData()
    {
        string strDataThatWeWillReturn = "";

        //create an instance of a SqlConnection object so that we know where to find our database that we want to work with
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        //create an instance of a SqlCommand object so that we know what SQL to execute against the database
        SqlCommand myCommand = new SqlCommand("INSERT into Product (productCode,description,currentPrice) VALUES (@productCode,@description,@currentPrice);", myConnection);
        myCommand.Parameters.Add("@productCode", SqlDbType.Int).Value = Convert.ToInt32(txtProductCode.Text);
        myCommand.Parameters.Add("@description", SqlDbType.VarChar).Value = txtDescription.Text;
        myCommand.Parameters.Add("@currentPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPrice.Text);


        try
        {
            //let's open the database connection
            myConnection.Open();
            //execute the non-query, in this case a INSERT SQL command
            // if it INSERTS more than 0 records, this is an indication that it worked correctly
            if (myCommand.ExecuteNonQuery() > 0)
            {
                strDataThatWeWillReturn = "product data was succesfully created";
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
