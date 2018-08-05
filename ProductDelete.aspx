<%@ Page Title="" Language="C#" MasterPageFile="~/MIS3200/MasterPagekb619814.master" AutoEventWireup="true" CodeFile="ProductDelete.aspx.cs" Inherits="MIS3200_FPkb619814_Product_ProductDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Product Code:
        <asp:TextBox ID="txtProductCode" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p>
        Description:<asp:TextBox ID="txtDescription" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p>
        Price:<asp:TextBox ID="txtPrice" runat="server" Enabled="False"></asp:TextBox>
    </p>
     <p>
        <mark>Do you want to delete this product's data?</mark>
    </p>
   
    <p>
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Yes, delete product!" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
    </p>
    <p>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>

