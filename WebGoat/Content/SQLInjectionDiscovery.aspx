<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQLInjectionDiscovery.aspx.cs" Inherits="OWASP.WebGoat.NET.SQLInjectionDiscovery" MasterPageFile="~/resources/Master-Pages/Site.Master" %>



<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    Like many data-driven websites, this page will give you a SQL error message if you provide unexpected user input.  
    Try entering characters used in SQL statements into the textbox and see what happens!
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">

    <h1 class="title-regular-4 clearfix">
        Email Address Finder:
    </h1>
        Enter the User ID:
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <asp:Button ID="btnFind" runat="server" onclick="btnFind_Click" 
            Text="Find Email!" />
    
    <hr />
    <p>
        <asp:Label ID="lblOutput" runat="server"></asp:Label>
    </p>
    <p>
    </p>




</asp:Content>
