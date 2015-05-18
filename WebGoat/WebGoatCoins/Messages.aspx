<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="OWASP.WebGoat.NET.WebGoatCoins.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    <h2 class='title-regular-2'>Your messages:</h2>
    <asp:Label ID="lblMessages" runat="server"></asp:Label>
</asp:Content>
