<%@ Page Title="" Language="C#" MasterPageFile="~/MIS3200/MasterPagekb619814.master" AutoEventWireup="true" CodeFile="CustomerUpdate.aspx.cs" Inherits="MIS3200_FPkb619814_Customer_CustomerUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        First Name:
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    </p>
    <p>
        Last Name:<asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    </p>
    <p>
        Address:<asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
    </p>
    <p>
        City:<asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
    </p>
    <p>
        State:<asp:TextBox ID="txtState" runat="server"></asp:TextBox>
        &nbsp;<asp:RegularExpressionValidator ID="revState" runat="server" ControlToValidate="txtState" Display="Dynamic" ErrorMessage="Please enter a state abbreviation (OH)" ValidationExpression="^(?:(A[KLRZ]|C[AOT]|D[CE]|FL|GA|HI|I[ADLN]|K[SY]|LA|M[ADEINOST]|N[CDEHJMVY]|O[HKR]|P[AR]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY]))$"></asp:RegularExpressionValidator>
    </p>
    <p>
        Zip:<asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
        &nbsp;<asp:RegularExpressionValidator ID="revZipCode" runat="server" ControlToValidate="txtZip" Display="Dynamic" ErrorMessage="Please enter a valid zip code" SetFocusOnError="True" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
    </p>
    <p>
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save Changes" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
    </p>
    <p>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </p>
</asp:Content>

