<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="OWASP.WebGoat.NET.About" %>


<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    This is the About Page...
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
<h1 class="title-regular-4 clearfix">About WebGoat.NET</h1>
WebGoat.NET: Copyright 2011 Jerry Hoff
<br/>
Questions or Comments? Please contact jerry@owasp.org
<p/>
This application made possible through the funding and support of 
<a href="http://www.infraredsecurity.com">Infrared Security, LLC</a>
<div align="center">
	<img src="../resources/images/infrared_logo.png"/>
</div>
</asp:Content>
 