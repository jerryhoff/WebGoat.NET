<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="XPathInjection.aspx.cs" Inherits="OWASP.WebGoat.NET.XPathInjection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    <h1 class="title-regular-4 clearfix">Our Offices</h1>
    Need to find a sales person?&nbsp; Click on a city below and get the details.<br />
    <br />
    
    <a href="XPathInjection.aspx?state=ca">California</a> | 
    <a href="XPathInjection.aspx?state=or">Oregon</a> | 
    <a href="XPathInjection.aspx?state=ny">New York</a> | 
    <a href="XPathInjection.aspx?state=tx">Texas</a> 
    
    <br />
    <br />
</asp:Content>