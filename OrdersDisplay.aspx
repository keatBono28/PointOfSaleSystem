<%@ Page Title="" Language="C#" MasterPageFile="~/MIS3200/MasterPagekb619814.master" AutoEventWireup="true" CodeFile="OrdersDisplay.aspx.cs" Inherits="MIS3200_FPkb619814_Orders_OrdersDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:HyperLink ID="hyplPOSDashboard" runat="server" NavigateUrl="~/MIS3200/FPkb619814/Default.aspx">Go To POS Dashboard</asp:HyperLink>
    </p>
    <p>
        <asp:Button ID="btnCreateOrder" runat="server" OnClick="btnCreateOrder_Click" Text="Create A New Order!" />
&nbsp;<asp:Label ID="lblMessage" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblTableData" runat="server"></asp:Label>
    </p>
    <p>
    </p>
    <p>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </p>
</asp:Content>

