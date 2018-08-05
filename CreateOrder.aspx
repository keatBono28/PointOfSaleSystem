<%@ Page Title="" Language="C#" MasterPageFile="~/MIS3200/MasterPagekb619814.master" AutoEventWireup="true" CodeFile="CreateOrder.aspx.cs" Inherits="MIS3200_FPkb619814_Orders_CreateOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:Button ID="btnBack" runat="server" Text="Go back to orders" OnClick="btnBack_Click" />
    </p>
    <p>
        Order Date:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:Label ID="lblOrderDateTime" runat="server"></asp:Label>
       <br>Customer:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;<asp:DropDownList ID="ddlCustomerList" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="dsCustomerList" DataTextField="customerFullName" DataValueField="customerId">
            <asp:ListItem Value="0"> Choose customer...</asp:ListItem>
        </asp:DropDownList>
        &nbsp;
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCreateOrder" runat="server" Text="Create Order" Width="104px" OnClick="btnCreateOrder_Click" />
        <asp:Button ID="btnFinish" runat="server" OnClick="btnFinish_Click" Text="Finish Order" Visible="False" />
       <br>----------------------------------------------------------------------------------------
    </p>
    <p>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblSelectProduct" runat="server" Text="Select a Product: " Visible="False"></asp:Label>
        <asp:DropDownList ID="ddlProductList" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="dsProductList" DataTextField="description" DataValueField="productCode" Visible="False">
            <asp:ListItem Value="0"> Choose product...</asp:ListItem>
        </asp:DropDownList>
    </p>
    <asp:Label ID="lblSelectQuantity" runat="server" Text="Select a Quantity: " Visible="False"></asp:Label>

        
        <asp:DropDownList ID="ddlQuantity" runat="server" AppendDataBoundItems="True" AutoPostBack="True" Visible="False">
            <asp:ListItem Value="0">Choose qty...</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
        </asp:DropDownList>
        

    <p>
        <asp:Button ID="btnAddProductToOrder" runat="server" OnClick="btnAddProductToOrder_Click" Text="Add Product To Order" Visible="False" />
    </p>
    <p>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </p><p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
        <asp:SqlDataSource ID="dsCustomerList" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_PointOfSales %>" SelectCommand="SELECT [customerId], [customerLastName] + ', ' + [customerFirstName] AS customerFullName FROM [Customer]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dsProductList" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_PointOfSales %>" SelectCommand="SELECT [productCode], [description] FROM [Product]"></asp:SqlDataSource>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

