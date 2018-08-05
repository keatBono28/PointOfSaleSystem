<%@ Page Title="" Language="C#" MasterPageFile="~/MIS3200/MasterPagekb619814.master" AutoEventWireup="true" CodeFile="AddProductToOrder.aspx.cs" Inherits="MIS3200_FPkb619814_Orders_AddProductToOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <p>
    </p>
    <p>
        Select the product to add to order
        <asp:Label ID="lblOrderId" runat="server"></asp:Label>
    </p>
    <asp:DropDownList ID="ddlProducts" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="dsProducts" DataTextField="description" DataValueField="productCode">
        <asp:ListItem Value="0">Please select a product to add...</asp:ListItem>
    </asp:DropDownList>
    <p>
        Select the quantity to add to order
        <asp:Label ID="lblOrderId0" runat="server"></asp:Label>
    </p>

        
        <asp:DropDownList ID="ddlQuantity" runat="server" AppendDataBoundItems="True" AutoPostBack="True">
            <asp:ListItem Value="0">Please select a quantity...</asp:ListItem>
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
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Add Product to Order" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
    </p>
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
    <p>
        <asp:SqlDataSource ID="dsProducts" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_PointOfSales %>" SelectCommand="SELECT [productCode], [description] FROM [Product]"></asp:SqlDataSource>
    </p>

</asp:Content>

