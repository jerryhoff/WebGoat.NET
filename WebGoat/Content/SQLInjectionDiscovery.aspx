<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQLInjectionDiscovery.aspx.cs" Inherits="OWASP.WebGoat.NET.SQLInjectionDiscovery" MasterPageFile="~/Resources/Master-Pages/Site.Master" %>



<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    Like many data-driven websites, this page will give you a SQL error message if you provide unexpected user input.  
    Try entering characters used in SQL statements into the textbox and see what happens!
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">

    <h1 class="title-regular-4 clearfix">
        Email Address Finder:
    </h1>

    Enter the three digit customer ID to find the customer's email address.  Only the first three characters will be recognized.
    <br />
    Example: 103

    <p />
    <hr />

        Enter the Customer ID:
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <asp:Button ID="btnFind" runat="server" onclick="btnFind_Click" 
            Text="Find Email!" />
    
    <br />
    <br />
    <asp:GridView ID="grdEmail" runat="server">
    </asp:GridView>
    <br />
    <p>
        <asp:Label ID="lblOutput" runat="server"></asp:Label>
    </p>
    <p>
    </p>




</asp:Content>
