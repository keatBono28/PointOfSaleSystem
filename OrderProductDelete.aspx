<%@ Page Title="" Language="C#" MasterPageFile="~/MIS3200/MasterPagekb619814.master" AutoEventWireup="true" CodeFile="OrderProductDelete.aspx.cs" Inherits="MIS3200_FPkb619814_Orders_OrderProductDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:Label ID="lblDataToDelete" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <mark>Do you want to delete this product from the order?</mark>
    </p>
    <p>
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Yes, delete it!" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="No don't delete it!" />
    </p>
    <p>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>

</asp:Content>

