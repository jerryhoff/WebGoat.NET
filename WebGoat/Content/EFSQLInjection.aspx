<%@ Page Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="EFSQLInjection.aspx.cs" Inherits="OWASP.WebGoat.NET.Content.EFSQLInjection" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
	<style>
		table, td, th
		{
			padding: 5px;
		}
	
		th
		{
			background-color:#e7f0fa;
			color:black;
		}
	</style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
		<h1 class="title-regular-4 clearfix">
			Employee Email</h1>
		Are you looking to contact one of our employees?&nbsp; Use this form to find 
		their email quickly!<br />
		<br />
		Enter the first few letters of their first name:<br />
	<p>
		<table>
			<tr>
				<td>Name: </td><td><asp:TextBox ID="txtName" runat="server" Columns="25"></asp:TextBox></td>
			</tr>
			</table>
	</p>
	<p>
		<asp:Button ID="btnFind" runat="server" onclick="btnFind_Click" 
			Text="Find Employee" />
	</p>
	<hr />
	<p>
		<asp:Label ID="lblOutput" runat="server"></asp:Label>
	</p>
	<p>
		<asp:GridView ID="grdEmail" runat="server">
		</asp:GridView>
	</p>
</asp:Content>



