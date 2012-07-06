<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="EncryptVSEncode.aspx.cs" Inherits="OWASP.WebGoat.NET.EncryptVSEncode" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    This page illustrates multiple encoding algorithms - type in a string and observe the output.
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
	<style>
		table, td, th
		{
			border:1px solid #e7f0fa;
			padding: 10px;
		}
	
		th
		{
			background-color:#e7f0fa;
			color:black;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
<h1 class="title-regular-4 clearfix">Encoding Basics</h1>
<asp:Table runat="server" CellPadding="5" HorizontalAlign="Center">
		<asp:TableRow>			
			<asp:TableCell>Enter String to Protect:</asp:TableCell>
			<asp:TableCell><asp:TextBox ID="txtString" runat="server" /></asp:TableCell>
		</asp:TableRow>
		
		<asp:TableRow>
			<asp:TableCell>Enter Encryption Password (optional):</asp:TableCell>
			<asp:TableCell><asp:TextBox ID="txtPassword" runat="server" /></asp:TableCell>
		</asp:TableRow>
	</asp:Table>
	<asp:Button ID="btnGo" runat="server" 
            Text="Encrypt/Encode!" onclick="btnGO_Click" />

</asp:Content>
