<%@ Page Title="" Language="C#" MasterPageFile="~/MIS3200/MasterPagekb619814.master" AutoEventWireup="true" CodeFile="CustomerDelete.aspx.cs" Inherits="MIS3200_FPkb619814_Customer_CustomerDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        First Name:
        <asp:TextBox ID="txtFirstName" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p>
        Last Name:<asp:TextBox ID="txtLastName" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p>
        Address:<asp:TextBox ID="txtAddress" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p>
        City:<asp:TextBox ID="txtCity" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p>
        State:<asp:TextBox ID="txtState" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p>
        Zip:<asp:TextBox ID="txtZip" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p>
        <mark>Do you want to delete this customer's data?</mark>
    </p>
    <p>
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Yes, delete this customer's data" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="No don't delete it!" />
    </p>
    <p>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </p>
</asp:Content>

