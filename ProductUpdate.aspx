<%@ Page Title="" Language="C#" MasterPageFile="~/MIS3200/MasterPagekb619814.master" AutoEventWireup="true" CodeFile="ProductUpdate.aspx.cs" Inherits="MIS3200_FPkb619814_Product_ProductUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Product Code:
        <asp:TextBox ID="txtProductCode" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p>
        Description:<asp:TextBox ID="txtDescription" runat="server" Enabled="True"></asp:TextBox>
    </p>
    <p>
        Price:<asp:TextBox ID="txtPrice" runat="server" Enabled="True"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revPrice" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="Please enter a price in the follwoing format (00.00)" SetFocusOnError="True" ValidationExpression="^\$?([1-9]{1}[0-9]{0,2}(\,[0-9]{3})*(\.[0-9]{0,2})?|[1-9]{1}[0-9]{0,}(\.[0-9]{0,2})?|0(\.[0-9]{0,2})?|(\.[0-9]{1,2})?)$"></asp:RegularExpressionValidator>
    </p>
     
   
    <p>
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Update product!" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
    </p>
    <p>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>

