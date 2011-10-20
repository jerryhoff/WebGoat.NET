<%@ Page Title="" validateRequest="false" Language="C#" MasterPageFile="~/resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="ReflectedXSS.aspx.cs" Inherits="OWASP.WebGoat.NET.ReflectedXSS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    This webpage fails to properly validate and encode user-supplied data.  Users can add their own HTML and scripts to the page.  
    See if you can display your session cookie in a dialog box. 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
	<h1 class="title-regular-4 clearfix">Classifieds</h1>
	<asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
	        <asp:DetailsView ID="dtlView" runat="server" BorderStyle="Solid" 
            CellPadding="10" CellSpacing="10" EnableModelValidation="True" 
            ForeColor="#333333" GridLines="None" Height="50px" Width="100%">
            <AlternatingRowStyle BackColor="White" />
            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
            <EditRowStyle BackColor="#2461BF" />
            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
        </asp:DetailsView>


</asp:Content>
