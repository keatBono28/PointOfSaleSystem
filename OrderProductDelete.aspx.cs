using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class MIS3200_FPkb619814_Orders_OrderProductDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // check to see if the expected querystring has "sid" AND make sure that we only do this when the page is initially loaded
        // so we don't unintentially laod the data again after making changes
        if (Request.QueryString["productcode"] != null && Request.QueryString["orderid"] != null && !Page.IsPostBack)
        {
            // the sid should be a number, so lets attempt to convert it to a number before storing it in a session variable
            // that we can use in this page (or outside of this page)
            try
            {
                Session["productCode"] = Convert.ToUInt32(Request.QueryString["productcode"]);
                Session["orderId"] = Convert.ToUInt32(Request.QueryString["orderid"]);

                // if it is a number greater than 0, go ahead and load the student data
                if (Convert.ToInt32(Session["productCode"]) > 0 && Convert.ToInt32(Session["orderId"]) > 0)
                    LoadData((Convert.ToInt32(Session["productCode"])), Convert.ToInt32((Session["orderId"])));
            }
            catch (Exception)
            {
                lblError.Text = " Bad Customer Id!";
                //throw;
            }
        }
    }

    protected void LoadData(int intProductCode, int intOrderId)
    {
        // This method will display the details of the order, such as: product, quantity, and allow for the removal of a product
        // this method will get the customer name based on the customer id 
        string strTemp = "";
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        // Now we need to write out the SQL command
        // This is in the sqlcommand object instance
        SqlCommand myCommand = new SqlCommand("SELECT * FROM OrderDetail WHERE orderId=@orderId AND productCode=@productCode", myConnection);
        myCommand.Parameters.Add("@orderId", SqlDbType.Int).Value = intOrderId;
        myCommand.Parameters.Add("@productCode", SqlDbType.Int).Value = intProductCode;
        try
        {
            // Now I need to open the data connection
            myConnection.Open();
            // Now, lets create an instance of the sqlDataReader object 
            SqlDataReader myReader = myCommand.ExecuteReader();
            // If the myReader has any data, we can read it
            while (myReader.Read()) // using the while loop we can read everything in the database table
            {
                lblDataToDelete.Text += "<li>" + "Order Number: " + Convert.ToInt32(myReader["orderId"]).ToString("00##") + "</li>";
                lblDataToDelete.Text += "<li>" + "Product:      " + GetProductDescription(Convert.ToInt32(myReader["productCode"])).ToString() + "</li>";

            }
            // Need to make sure we close the myReader
            myReader.Close();
        }
        catch (Exception ex)
        {
            lblError.Text = "<br /><br />LoadOrderDetailData()" + ex.ToString();
        }
        finally
        {
            // Need to clean up the garbage
            // Call the dispose method
            myCommand.Dispose();
            // Call the close method
            myConnection.Close();
            //throw;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        // create a session variable called "message" that we can use to see what happend to the data
        // once we send the user back to the "startingPage" application
        // note, whe we call the UpdateinstructorData method, it will return a message that will be assigned to Session["message"]
        Session["message"] = DeleteData((Convert.ToInt32(Session["productCode"])), Convert.ToInt32((Session["orderId"])));
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


    protected string DeleteData(int intProductCode, int intOrderId)
    {
        // This method will display the details of the order, such as: product, quantity, and allow for the removal of a product
        // this method will get the customer name based on the customer id 
        string strTemp = "";
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        // Now we need to write out the SQL command
        // This is in the sqlcommand object instance
        SqlCommand myCommand = new SqlCommand("DELETE FROM OrderDetail WHERE orderId=@orderId AND productCode=@productCode", myConnection);
        myCommand.Parameters.Add("@orderId", SqlDbType.Int).Value = intOrderId;
        myCommand.Parameters.Add("@productCode", SqlDbType.Int).Value = intProductCode;
        try
        {
            //let's open the database connection
            myConnection.Open();
            //execute the non-query, in this case a INSERT SQL command
            // if it INSERTS more than 0 records, this is an indication that it worked correctly
            if (myCommand.ExecuteNonQuery() > 0)
            {
                strTemp = "product was succesfully removed from order";
            }
            else
            {
                strTemp = "delete failed!";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "<br /><br />DeleteData()" + ex.ToString();
        }
        finally
        {
            // Need to clean up the garbage
            // Call the dispose method
            myCommand.Dispose();
            // Call the close method
            myConnection.Close();
            //throw;
        }
        return strTemp;
    }

    protected string GetProductDescription(int intProductCode)
    {
        // this method will get the customer name based on the customer id 
        string strTemp = "";
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        // Now we need to write out the SQL command
        // This is in the sqlcommand object instance
        SqlCommand myCommand = new SqlCommand("SELECT description FROM Product WHERE productCode=@productCode", myConnection);
        myCommand.Parameters.Add("@productCode", SqlDbType.Int).Value = intProductCode;
        try
        {
            // Now I need to open the data connection
            myConnection.Open();
            // Now, lets create an instance of the sqlDataReader object 
            SqlDataReader myReader = myCommand.ExecuteReader();
            // If the myReader has any data, we can read it
            while (myReader.Read()) // using the while loop we can read everything in the database table
            {
                strTemp = myReader["description"].ToString();
            }
            // Need to make sure we close the myReader
            myReader.Close();
        }
        catch (Exception ex)
        {
            lblError.Text = "<br /><br />GetProductDescription()" + ex.ToString();
        }
        finally
        {
            // Need to clean up the garbage
            // Call the dispose method
            myCommand.Dispose();
            // Call the close method
            myConnection.Close();
            //throw;
        }



        return strTemp;
    }


}