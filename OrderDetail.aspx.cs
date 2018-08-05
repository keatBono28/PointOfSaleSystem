using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class MIS3200_FPkb619814_Orders_OrderDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Lets delcare a session varibale called "starting page" that will us temporarily move data to toher applications on our web server
        // in the case, let's store the name of our application so that we can send the user
        // back to the page once they comelte tasks using other applications
        Session["orderdetails"] = "OrdersDetial.aspx";
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
                if (Convert.ToInt32(Session["orderId"]) > 0)
                    LoadData(Convert.ToInt32(Session["orderId"]));
                    LoadOrderDetailData(Convert.ToInt32(Session["orderId"]));
                    lblAddProduct.Text = "<a href=AddProductToOrder.aspx?orderid=" + (Convert.ToInt32(Session["orderId"])) + ">Add a product to the order</a>";

            }
            catch (Exception)
            {
                lblError.Text = " Bad Order Id!";
                //throw;
            }
        }
        // This will be a session variable created within other applications that will allow us to dispaly the message that occurs within n other applications
        // First we will check to see if it is null, which indicates it does NOT exist
        if (Session["message"] != null)
        {
            // if the message is not null, mean that is DOES exist, then convert the session
            // variable to a string and read the "message" out fo the variable and assign it to the label
            lblMessage.Text = Session["message"].ToString();
            // after we do this, we dont want to see the session variable dispaled again, so we can NULL it out by assigning null to the varibale
            Session["message"] = null;
        }
    }

    protected void LoadData(int intOrderId)
    {
        
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        // Now we need to write out the SQL command
        // This is in the sqlcommand object instance
        SqlCommand myCommand = new SqlCommand("SELECT orderId, orderDateTime, customerId FROM Orders WHERE orderId=@orderId", myConnection);
        myCommand.Parameters.Add("@orderId", SqlDbType.Int).Value = intOrderId;
        try
        {
            // Now I need to open the data connection
            myConnection.Open();
            // Now, lets create an instance of the sqlDataReader object 
            SqlDataReader myReader = myCommand.ExecuteReader();
            // If the myReader has any data, we can read it
            while (myReader.Read()) // using the while loop we can read everything in the database table
            {
                lblOrderDateTime.Text = myReader["orderDateTime"].ToString();
                lblOrderId.Text = Convert.ToInt32(myReader["orderId"]).ToString("00##");
                lblCustomerId.Text = Convert.ToInt32(myReader["customerId"]).ToString("00##");
                lblCustomerName.Text = GetCustomerName(Convert.ToInt32(myReader["customerId"]));
            }
            // Need to make sure we close the myReader
            myReader.Close();
        }
        catch (Exception ex)
        {
            lblError.Text = "<br /><br />LoadData()" + ex.ToString();
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
    protected string GetCustomerName(int intCustomerId)
    {
        // this method will get the customer name based on the customer id 
        string strTemp = "";
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        // Now we need to write out the SQL command
        // This is in the sqlcommand object instance
        SqlCommand myCommand = new SqlCommand("SELECT customerFirstName, customerLastName FROM Customer WHERE customerId=@customerId", myConnection);
        myCommand.Parameters.Add("@customerId", SqlDbType.Int).Value = intCustomerId;
        try
        {
            // Now I need to open the data connection
            myConnection.Open();
            // Now, lets create an instance of the sqlDataReader object 
            SqlDataReader myReader = myCommand.ExecuteReader();
            // If the myReader has any data, we can read it
            while (myReader.Read()) // using the while loop we can read everything in the database table
            {
                strTemp = myReader["customerLastName"].ToString() + ", " + myReader["customerFirstName"].ToString();
            }
            // Need to make sure we close the myReader
            myReader.Close();
        }
        catch (Exception ex)
        {
            lblError.Text = "<br /><br />GetCustomerName()" + ex.ToString();
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
    
    protected void LoadOrderDetailData(int intOrderId)
    {
        // This method will display the details of the order, such as: product, quantity, and allow for the removal of a product
        // this method will get the customer name based on the customer id 
        string strTemp = "";
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        // Now we need to write out the SQL command
        // This is in the sqlcommand object instance
        SqlCommand myCommand = new SqlCommand("SELECT * FROM OrderDetail WHERE orderId=@orderId", myConnection);
        myCommand.Parameters.Add("@orderId", SqlDbType.Int).Value = intOrderId;
        try
        {
            // Now I need to open the data connection
            myConnection.Open();
            // Now, lets create an instance of the sqlDataReader object 
            SqlDataReader myReader = myCommand.ExecuteReader();
            // If the myReader has any data, we can read it
            while (myReader.Read()) // using the while loop we can read everything in the database table
            {
                lblOrderInfo.Text += "<li>" + "- " + GetProductDescription(Convert.ToInt32(myReader["productCode"])).ToString() + "    " +  "  (Quantity: " + myReader["orderQuantiy"].ToString() + ")" + "<a href=OrderProductDelete.aspx?productcode=" + Convert.ToInt32(myReader["productCode"]).ToString("00##") + "&orderid=" + myReader["orderId"] +">Remove product from order </a>" + "</li>";
                
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



    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrdersDisplay.aspx");
    }

    protected void btnDeleteOrder_Click(object sender, EventArgs e)
    {
        
        Session["DeleteThisOrderId"] = Session["orderid"];
        Response.Redirect("OrderDelete.aspx");
    }
}