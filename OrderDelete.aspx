<%@ Page Title="" Language="C#" MasterPageFile="~/MIS3200/MasterPagekb619814.master" AutoEventWireup="true" CodeFile="OrderDelete.aspx.cs" Inherits="MIS3200_FPkb619814_Orders_OrderDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Order Number: <asp:TextBox ID="txtOrderId" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p>
        <mark>Are you sure you want to delete this order?</mark>
    </p>
    <p>
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Yes, delete this order" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="No don't delete it!" />
    </p>
    <p>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </p>
</asp:Content>

