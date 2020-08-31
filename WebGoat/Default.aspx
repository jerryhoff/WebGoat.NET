<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OWASP.WebGoat.NET.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <asp:HtmlTitle>Welcome to WebGoat.NET</asp:HtmlTitle>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    This is the Welcome Page...
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">

    <h1 class="title-regular-4 clearfix">Bem vindo ao WebGoat dotNET</h1>

    <br />
    <br />
    <asp:Label ID="lblOutput" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="ButtonProceed" SkinID="Button" runat="server" 
        Text="Set Up Database!" onclick="ButtonProceed_Click"/>

</asp:Content>

