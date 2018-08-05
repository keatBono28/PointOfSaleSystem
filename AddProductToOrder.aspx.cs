using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class MIS3200_FPkb619814_Orders_AddProductToOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // check to see if the expected querystring has "sid" AND make sure that we only do this when the page is initially loaded
        // so we don't unintentially laod the data again after making changes
        if (Request.QueryString["orderid"] != null && !Page.IsPostBack)
        {
            // the sid should be a number, so lets attempt to convert it to a number before storing it in a session variable
            // that we can use in this page (or outside of this page)
            try
            {
                
                Session["orderId"] = Convert.ToUInt32(Request.QueryString["orderid"]);

                // if it is a number greater than 0, go ahead and load the student data
                //if (Convert.ToInt32(Session["orderId"]) > 0)
                    //LoadData((Convert.ToInt32(Session["productCode"])), Convert.ToInt32((Session["orderId"])));
            }
            catch (Exception)
            {
                lblError.Text = " Bad Order Id!";
                //throw;
            }
            lblOrderId.Text = Convert.ToInt32(Session["orderId"]).ToString("00##");
            lblOrderId0.Text = Convert.ToInt32(Session["orderId"]).ToString("00##");
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        // create a session variable called "message" that we can use to see what happend to the data
        // once we send the user back to the "startingPage" application
        // note, whe we call the UpdateinstructorData method, it will return a message that will be assigned to Session["message"]
        Session["message"] = InsertData(Convert.ToInt32(Session["orderId"]), Convert.ToString(ddlProducts.SelectedValue), ddlQuantity.SelectedIndex);
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


    protected string InsertData(int intOrderId, string intProductcode, int intQuantity)
    {
        string strDataThatWeWillReturn = "";

        //create an instance of a SqlConnection object so that we know where to find our database that we want to work with
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        //create an instance of a SqlCommand object so that we know what SQL to execute against the database
        SqlCommand myCommand = new SqlCommand("INSERT into OrderDetail (orderId,productCode,orderQuantiy) VALUES (@orderId,@productCode,@orderQuantiy);", myConnection);
        myCommand.Parameters.Add("@orderId", SqlDbType.Int).Value = intOrderId;
        myCommand.Parameters.Add("@productCode", SqlDbType.VarChar).Value = Convert.ToString(intProductcode);
        myCommand.Parameters.Add("@orderQuantiy", SqlDbType.SmallInt).Value = intQuantity;
        
        try
        {
            //let's open the database connection
            myConnection.Open();
            //execute the non-query, in this case a INSERT SQL command
            // if it INSERTS more than 0 records, this is an indication that it worked correctly
            if (myCommand.ExecuteNonQuery() > 0)
            {
                strDataThatWeWillReturn = "product was added to the order";
            }
            else
            {
                strDataThatWeWillReturn = "product not added to the order!";
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