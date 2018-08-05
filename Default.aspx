<%@ Page Title="" Language="C#" MasterPageFile="~/MIS3200/MasterPagekb619814.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="MIS3200_FPkb619814_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/MIS3200/FPkb619814/Customer/CustomerHome.aspx">Customers</asp:HyperLink>
&nbsp;<asp:Label ID="lblCustomerCount" runat="server"></asp:Label>
    </p>
    <p>
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/MIS3200/FPkb619814/Product/ProductHome.aspx">Products</asp:HyperLink>
&nbsp;<asp:Label ID="lblProductCount" runat="server"></asp:Label>
    </p>
    <p>
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/MIS3200/FPkb619814/Orders/OrdersDisplay.aspx">Orders</asp:HyperLink>
&nbsp;<asp:Label ID="lblOrderCount" runat="server"></asp:Label>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

