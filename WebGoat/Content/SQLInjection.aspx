<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQLInjection.aspx.cs" Inherits="OWASP.WebGoat.NET.SQLInjection" MasterPageFile="~/Resources/Master-Pages/Site.Master" %>


<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    Like many data-driven web applications, this page is vulnerable to SQL injection.  The page allows users to sign 
    up for their mailling list.  Before adding new users, the page does a check to make sure the email address isn&apos;t already
    in the database.  Exploit this page and retrieve all the email addresses in the database.
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

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
        <h1 class="title-regular-4 clearfix">
			Employee Email</h1>
        Are you looking to contact one of our employees?&nbsp; Use this form to find 
        their email quickly!<br />
        <br />
        Enter the first few letters of their first or last name:<br />
    <p>
        <table>
            <tr>
                <td>Name: </td><td><asp:TextBox ID="txtName" runat="server" Columns="25"></asp:TextBox></td>
            </tr>
            </table>
    </p>
    <p>
        <asp:Button ID="btnAdd" runat="server" onclick="btnFind_Click" 
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
