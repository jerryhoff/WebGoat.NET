<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="OWASP.WebGoat.NET.WebGoatCoins.Catalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
        <h1 class="title-regular-4 clearfix">Product Catalog</h1>
        <div class="notice">
        <asp:Literal runat="server" EnableViewState="False" ID="labelMessage">
        A full listing of all our current offerings.  Click on "More Info" to see the details for that item!
        </asp:Literal>
    </div>
    <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
</asp:Content>
