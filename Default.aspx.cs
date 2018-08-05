using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class MIS3200_FPkb619814_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CountCustomers();
        CountProducts();
        CountOrders();
    }

    //Building a method to count the number of customers in the system
    protected void CountCustomers()
    {
        // Temp Variables
        string strData = "";
        int intCounter = 0;
        //create an instance of a SqlConnection object so that we know where to find our database that we want to work with
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        //create an instance of a SqlCommand object so that we know what SQL to execute against the database
        SqlCommand myCommand = new SqlCommand("SELECT DISTINCT customerId FROM Customer", myConnection);
        try
        {
            //let's open the database connection
            myConnection.Open();
            //create an instance of a SqlDataReader object so that we can read the data from the database
            SqlDataReader myReader = myCommand.ExecuteReader();
            //if the myReader has any data, which we determine by calling the myReader.Read() method, then we can read the data
            while (myReader.Read())
            {
                strData += myReader["customerId"].ToString();
                intCounter++;
            }
            //close myReader
            myReader.Close();
        }
        catch (Exception ex)
        {
            //lblError.Text = "<br /><br />GetTheRowDataForAllCustomers: " + ex.ToString() + "<br />";
        }
        finally
        {
            //cleanup our garbage!
            //call the dispose method of the myCommand
            myCommand.Dispose();
            //call the close method of the myConnection - critical!!!
            myConnection.Close();
        }
        if (strData != "") // As long as this string is not empty, we can append the count of customers 
        {

            // using this functionality to assign the count of courses within the grade using the universal variable
            lblCustomerCount.Text = " - <em> There are " + intCounter.ToString() + " customer" + (intCounter == 1 ? "" : "s") + " in the system" + "</em>";
        }
        else
        {
            lblCustomerCount.Text = " - <em>No Current Customers</em>";
        }
        
    }

    protected void CountProducts()
    {
        string strData = "";
        int intCounter = 0;

        // build a variabe that wil store which attribute(s) we want to roder the data and use that variable when we execute the SQL statement
        

        //create an instance of a SqlConnection object so that we know where to find our database that we want to work with
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        //create an instance of a SqlCommand object so that we know what SQL to execute against the database
        SqlCommand myCommand = new SqlCommand("SELECT DISTINCT productCode FROM Product", myConnection);
        try
        {
            //let's open the database connection
            myConnection.Open();
            //create an instance of a SqlDataReader object so that we can read the data from the database
            SqlDataReader myReader = myCommand.ExecuteReader();
            //if the myReader has any data, which we determine by calling the myReader.Read() method, then we can read the data
            while (myReader.Read())
            {
                //this is where the database work gets done...
                strData += myReader["productCode"];
                intCounter++;
            }
            //close myReader
            myReader.Close();
        }
        catch (Exception ex)
        {
            //lblError.Text = "<br /><br />GetTheRowDataForAllProduct: " + ex.ToString() + "<br />";
        }
        finally
        {
            //cleanup our garbage!
            //call the dispose method of the myCommand
            myCommand.Dispose();
            //call the close method of the myConnection - critical!!!
            myConnection.Close();
        }
        if (strData != "") // As long as this string is not empty, we can append the count of customers 
        {

            // using this functionality to assign the count of courses within the grade using the universal variable
            lblProductCount.Text = " - <em> There are " + intCounter.ToString() + " product" + (intCounter == 1 ? "" : "s") + " in the system" + "</em>";
        }
        else
        {
            lblProductCount.Text = " - <em>No Current Products</em>";
        }

    }

    protected void CountOrders()
    {
        string strData = "";
        int intCounter = 0;

        // build a variabe that wil store which attribute(s) we want to roder the data and use that variable when we execute the SQL statement


        //create an instance of a SqlConnection object so that we know where to find our database that we want to work with
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        //create an instance of a SqlCommand object so that we know what SQL to execute against the database
        SqlCommand myCommand = new SqlCommand("SELECT DISTINCT orderId FROM Orders", myConnection);
        try
        {
            //let's open the database connection
            myConnection.Open();
            //create an instance of a SqlDataReader object so that we can read the data from the database
            SqlDataReader myReader = myCommand.ExecuteReader();
            //if the myReader has any data, which we determine by calling the myReader.Read() method, then we can read the data
            while (myReader.Read())
            {
                //this is where the database work gets done...
                strData += myReader["orderId"];
                intCounter++;
            }
            //close myReader
            myReader.Close();
        }
        catch (Exception ex)
        {
            //lblError.Text = "<br /><br />GetTheRowDataForAllProduct: " + ex.ToString() + "<br />";
        }
        finally
        {
            //cleanup our garbage!
            //call the dispose method of the myCommand
            myCommand.Dispose();
            //call the close method of the myConnection - critical!!!
            myConnection.Close();
        }
        if (strData != "") // As long as this string is not empty, we can append the count of customers 
        {

            // using this functionality to assign the count of courses within the grade using the universal variable
            lblOrderCount.Text = " - <em> There are " + intCounter.ToString() + " order" + (intCounter == 1 ? "" : "s") + " in the system" + "</em>";
        }
        else
        {
            lblOrderCount.Text = " - <em>No Current Orders</em>";
        }

    }


}