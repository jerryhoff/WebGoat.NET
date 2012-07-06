<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" 
	CodeBehind="PathManipulation.aspx.cs" Inherits="OWASP.WebGoat.NET.PathManipulation" %>
	
<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
	This lesson illustrates the common problem of trusting a user-supplied filename, then using it to generate a file path.  Try manipulating the get paramter and download WebGoat.NET's Web.config file!
</asp:Content>

	
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
<h1 class="title-regular-4 clearfix">Files available for download</h1>
Here are files available for download.  Please click on a file and the download should initiate within 10 seconds.<p/>
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <p/>
</asp:Content>

