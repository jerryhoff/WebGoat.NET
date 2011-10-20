<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQLInjection.aspx.cs" Inherits="OWASP.WebGoat.NET.SQLInjection" MasterPageFile="~/resources/Master-Pages/Site.Master" %>


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
			Mailing List
		</h1>
        Join our mailing list, and we&#39;ll send you updates on our fantastic deals!<p/><p/>
    <p>
        <table>
            <tr>
                <td>First Name: </td><td><asp:TextBox ID="txtFirst" runat="server" Columns="25"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Last Name: </td><td><asp:TextBox ID="txtLast" runat="server" Columns="25"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Email: </td><td><asp:TextBox ID="txtEmail" runat="server" Columns="50"></asp:TextBox></td>
            </tr>
        </table>
    </p>
    <p>
        <asp:Button ID="btnAdd" runat="server" onclick="btnFind_Click" 
            Text="Add Me To The List!" />
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
