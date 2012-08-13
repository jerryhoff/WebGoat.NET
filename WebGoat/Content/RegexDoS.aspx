<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="RegexDoS.aspx.cs" Inherits="OWASP.WebGoat.NET.RegexDoS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
<asp:Label ID="lblError" runat="server" />
<br />
Username:&nbsp;<asp:TextBox ID="txtUsername" runat="server" />
<br />
Password:&nbsp;<asp:TextBox ID="txtPassword" runat="server" type="password"/>
<br />
<asp:Button ID="btnCreate" runat="server" Text="Create Account" OnClick="btnCreate_Click" />
</asp:Content>
