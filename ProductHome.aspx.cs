using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class MIS3200_FPkb619814_Product_ProductHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Lets delcare a session varibale called "starting page" that will us temporarily move data to toher applications on our web server
        // in the case, let's store the name of our application so that we can send the user
        // back to the page once they comelte tasks using other applications
        Session["startingPage"] = "ProductHome.aspx";

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

        // Now calling the method to build that table with all the data
        BuildATableForProductData();
    }

    protected void btnNewCustomer_Click(object sender, EventArgs e)
    {
        // Redirecting to the insert page
        Response.Redirect("ProductInsert.aspx");
    }

    protected void BuildATableForProductData()
    {
        string strTable = "";

        //let's build an example of a table with two columns and two row of data
        strTable = "<table border=1>";


        //include a row that contains headers
        // note, the basic syntax for an "a href" html tag is this: <a href=urlInQuestions>Words that will be clickable</a>
        strTable += "<tr>";
        strTable += "<th> </th>"; // Leaving this header blank so I can use it as a edit delete area based on productId
        strTable += "<th><a href=ProductHome.aspx?sort=productcode>Product Code</a></th>";
        strTable += "<th><a href=ProductHome.aspx?sort=description>Description</a></th>";
        strTable += "<th><a href=ProductHome.aspx?sort=price>Price</a></th>";
        strTable += "</tr>";

        //next include a row that contains data
        strTable += GetTheRowDataForAllProducts();

        //close the table
        strTable += "</table>";

        lblTableData.Text = strTable;
    }

    protected string GetTheRowDataForAllProducts()
    {
        string strDataThatWeWillReturn = "";

        // build a variabe that wil store which attribute(s) we want to roder the data and use that variable when we execute the SQL statement
        string strSort = " ORDER BY productCode"; // this is considered to be the default order by
        if (Request.QueryString["sort"] != null)
        {
            if (Request.QueryString["sort"].ToString() == "description")
                strSort = " ORDER BY description";
            else if (Request.QueryString["sort"].ToString() == "price")
                strSort = " ORDER BY currentPrice";
        }

        //create an instance of a SqlConnection object so that we know where to find our database that we want to work with
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_PointofSales"].ToString());
        //create an instance of a SqlCommand object so that we know what SQL to execute against the database
        SqlCommand myCommand = new SqlCommand("SELECT * FROM Product" + strSort, myConnection);
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
                strDataThatWeWillReturn += "<tr>";
                //let's start building a sentence: display "customerId: " and then read the instructorId from the database and follow with a break, 
                //then display the rest of the attributes
                // recall here is an example of what our "a href" tag looks like for SORTING on the Customer Id:
                // edit the data for the customerId selected or we could send them someplace else to delete their data
                strDataThatWeWillReturn += "<td>";
                strDataThatWeWillReturn += "<a href=ProductUpdate.aspx?productcode=" + myReader["productCode"].ToString() + ">edit</a>";
                strDataThatWeWillReturn += " or <a href=ProductDelete.aspx?productcode=" + myReader["productCode"].ToString() + ">delete</a>";
                strDataThatWeWillReturn += "</td>";
                strDataThatWeWillReturn += "<td>" + Convert.ToInt32(myReader["productCode"]).ToString("00##") + "</td>";
                strDataThatWeWillReturn += "<td>" + myReader["description"].ToString() + "</td>";
                strDataThatWeWillReturn += "<td>" + "$" + myReader["currentPrice"].ToString() + "</td>";
                strDataThatWeWillReturn += "</tr>";
            }
            //close myReader
            myReader.Close();
        }
        catch (Exception ex)
        {
            lblError.Text = "<br /><br />GetTheRowDataForAllProduct: " + ex.ToString() + "<br />";
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