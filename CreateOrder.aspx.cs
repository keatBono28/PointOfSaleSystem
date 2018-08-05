using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class MIS3200_FPkb619814_Orders_CreateOrder : System.Web.UI.Page
{
    // Global Variable Declarations
    int intOrderId = 0;
    int intOldOrderId = 0;
    DateTime dtDateTime = DateTime.Now;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        // I need to auto populate the dateTime and OrderId number
        LoadData();
        
    }

    protected void btnCreateOrder_Click(object sender, EventArgs e)
    {
        // Temp string for a message
        string strMessage = "";
        try
        {
            strMessage = InsertOrderData();
            if (strMessage == "order was succesfully created")
            {
                ddlCustomerList.Enabled = false;
                ddlProductList.Visible = true;
                ddlQuantity.Visible = true;
                lblSelectProduct.Visible = true;
                lblSelectQuantity.Visible = true;
                btnFinish.Visible = true;
                btnCreateOrder.Visible = false;
                lblMessage.Text = strMessage;
                btnAddProductToOrder.Visible = true;
            }
        }
        catch (Exception)
        {
            lblMessage.Text = strMessage;
            //throw;
        }
        

    }

    protected void btnAddProductToOrder_Click(object sender, EventArgs e)
    {
        string strMessage = "";
        try
        {
            strMessage = InsertOrderDetailData();
            if (strMessage == "product was added to the order")
            {
                ddlProductList.SelectedIndex = 0;
                ddlQuantity.SelectedIndex = 0;
                lblMessage.Text = strMessage;
            }
        }
        catch (Exception)
        {
            lblMessage.Text = strMessage;
            //throw;
        }
    }

    protected void btnFinish_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrdersDisplay.aspx");
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrdersDisplay.aspx");
    }

    protected void LoadData()
    {
        // this method will get the customer name based on the customer id 
        int intTemp = 0;
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        // Now we need to write out the SQL command
        // This is in the sqlcommand object instance
        SqlCommand myCommand = new SqlCommand("SELECT TOP 1 orderId FROM Orders ORDER BY orderId DESC", myConnection);
        try
        {
            // Now I need to open the data connection
            myConnection.Open();
            // Now, lets create an instance of the sqlDataReader object 
            SqlDataReader myReader = myCommand.ExecuteReader();
            // If the myReader has any data, we can read it
            while (myReader.Read()) // using the while loop we can read everything in the database table
            {
                intTemp = Convert.ToInt32(myReader["orderId"]);
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
        
        // Setting this orderid to the global variable to insert late
        intOrderId = intTemp;
        
        // Display the current dateTime to the label
        lblOrderDateTime.Text = dtDateTime.ToString();
    }

    protected string InsertOrderData()
    {
        string strTemp = "";
        //create an instance of a SqlConnection object so that we know where to find our database that we want to work with
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        //create an instance of a SqlCommand object so that we know what SQL to execute against the database
        SqlCommand myCommand = new SqlCommand("INSERT into Orders (orderDateTime,orderTotal,customerId) VALUES (@orderDateTime,@orderTotal,@customerId);", myConnection);
    
        myCommand.Parameters.Add("@orderDateTime", SqlDbType.DateTime).Value = dtDateTime;
        myCommand.Parameters.Add("@orderTotal", SqlDbType.Int).Value = 0; // Doing this for now, we arent allowed to use this variable
        myCommand.Parameters.Add("@customerId", SqlDbType.Int).Value = Convert.ToInt32(ddlCustomerList.SelectedValue);


        try
        {
            //let's open the database connection
            myConnection.Open();
            //execute the non-query, in this case a INSERT SQL command
            // if it INSERTS more than 0 records, this is an indication that it worked correctly
            if (myCommand.ExecuteNonQuery() > 0)
            {
                strTemp = "order was succesfully created";
            }
            else
            {
                strTemp = "order creation failed!";
            }

        }
        catch (Exception ex)
        {
            lblError.Text = "Error in InsertData: " + ex.ToString();
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


        // I need to display the current order id
        
        intOrderId++;

        return strTemp;
    }

    protected string InsertOrderDetailData()
    {
        string strDataThatWeWillReturn = "";

        //create an instance of a SqlConnection object so that we know where to find our database that we want to work with
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        //create an instance of a SqlCommand object so that we know what SQL to execute against the database
        SqlCommand myCommand = new SqlCommand("INSERT into OrderDetail (orderId,productCode,orderQuantiy) VALUES (@orderId,@productCode,@orderQuantiy);", myConnection);
        myCommand.Parameters.Add("@orderId", SqlDbType.Int).Value = intOrderId;
        myCommand.Parameters.Add("@productCode", SqlDbType.VarChar).Value = Convert.ToString(ddlProductList.SelectedValue);
        myCommand.Parameters.Add("@orderQuantiy", SqlDbType.SmallInt).Value = Convert.ToInt32(ddlQuantity.SelectedIndex);

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
            lblError.Text = "Error in InsertData: " + ex.ToString();
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