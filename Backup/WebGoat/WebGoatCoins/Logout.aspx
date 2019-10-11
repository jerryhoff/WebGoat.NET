<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="OWASP.WebGoat.NET.WebGoatCoins.Logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
<h1 class="title-regular-4 clearfix">Customer Logout</h1>
    <p>
        Are you sure you want to log out?
    </p>

    <asp:Button ID="btnLogout" SkinID="Button" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        
</asp:Content>
