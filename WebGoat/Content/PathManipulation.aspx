<%@ Page Title="" Language="C#" MasterPageFile="~/resources/Master-Pages/Site.Master" AutoEventWireup="true" 
	CodeBehind="PathManipulation.aspx.cs" Inherits="OWASP.WebGoat.NET.PathManipulation" %>
	
<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
	This lesson illustrates the common problem of trusting a user-supplied filename, then using it to generate a file path.  Try manipulating the get paramter and download WebGoat.NET's Web.config file!
</asp:Content>

	
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
<h1 class="title-regular-4 clearfix">Files available for download</h1>
The following files are available for download:<p/><p/>
</asp:Content>

