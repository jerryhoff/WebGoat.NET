<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" 
	CodeBehind="UploadPathManipulation.aspx.cs" Inherits="OWASP.WebGoat.NET.UploadPathManipulation" %>
	
<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
	This lesson illustrates the common problem of trusting a user-supplied filename, then using it to generate a file path.  Try uploading a file that will execute on the server.
</asp:Content>

	
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
<h1 class="title-regular-4 clearfix">File Upload</h1>

Select the file you want to upload, then click the Upload Document button
<p />

    <asp:Label ID="labelUpload" runat="server" Visible="false">
    
    </asp:Label>

<div class="tiny" style="text-align:center">Attach a file (PDF, Excel or Plain Text)...
    <hr />
    <asp:FileUpload ID="FileUpload1" runat="server"/>
    <p>&nbsp;</p>
    <asp:Button ID="btnUpload" runat="server" Text="Upload File!" 
            CssClass="button medium blue" onclick="btnUpload_Click" />
    </div>
</asp:Content>

