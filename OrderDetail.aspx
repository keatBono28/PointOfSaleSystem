<%@ Page Title="" Language="C#" MasterPageFile="~/MIS3200/MasterPagekb619814.master" AutoEventWireup="true" CodeFile="OrderDetail.aspx.cs" Inherits="MIS3200_FPkb619814_Orders_OrderDetail" %>

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
        <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
       <br>Customer ID:&nbsp;&nbsp; 
        <asp:Label ID="lblCustomerId" runat="server"></asp:Label>
       &nbsp;<br>Order ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:Label ID="lblOrderId" runat="server"></asp:Label>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDeleteOrder" runat="server" Text="Delete Order" Width="104px" OnClick="btnDeleteOrder_Click" />
       <br>----------------------------------------------------------------------------------------
    </p>
    <p>
        <asp:Label ID="lblAddProduct" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblOrderInfo" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </p>
</asp:Content>

