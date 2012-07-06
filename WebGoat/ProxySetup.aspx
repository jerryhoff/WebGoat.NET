<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProxySetup.aspx.cs" Inherits="OWASP.WebGoat.NET.ProxySetup" MasterPageFile="~/Resources/Master-Pages/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    Set up your web proxy, and test it here.  The field has a validator that only allows valid characters.  See if you can circumvent this protection using your proxy!
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
	<h1 class="title-regular-4 clearfix">Test Your Web Proxy</h1>
	<div class="ContentArea">
		Use this page to determine if webgoat is running properly, and to test your web proxy.<br />
        <asp:RequiredFieldValidator ID="valNameRequired" runat="server" 
            ErrorMessage="Name is Required" ControlToValidate="txtName"></asp:RequiredFieldValidator><br />
        <asp:RegularExpressionValidator ID="valRegEx" runat="server" 
            ErrorMessage="Invalid Characters Detected!" ControlToValidate="txtName" 
            ValidationExpression="[a-zA-Z\-\ \_]*"></asp:RegularExpressionValidator>
        <p />
        Enter your name (letters only): 
		<asp:TextBox ID="txtName" runat="server" Width="304px"></asp:TextBox>
		<asp:Button ID="btnReverse" runat="server" onclick="btnReverse_Click" Text="Submit" />
		<p />
		    <asp:Label ID="lblOutput" runat="server"></asp:Label>
		<br />
</div>
</asp:Content>