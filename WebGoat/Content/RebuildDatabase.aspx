<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dbtest.aspx.cs" Inherits="OWASP.WebGoat.NET.RebuildDatabase" MasterPageFile="~/resources/Master-Pages/Site.Master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    Click to button to refresh the database used in WebGoat.NET
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
	    <h1 class="title-regular-4 clearfix">Rebuild the Database</h1>
    	Click to button to refresh the database used in WebGoat.NET    
        <p /><p />
        <asp:Button ID="btnTest" runat="server" onclick="btnTest_Click" 
            style="height: 26px" Text="Rebuild Database" />
        <br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblOutput" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:GridView ID="grdView" runat="server" CellPadding="4" 
            EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
            Height="117px">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <br />

</asp:Content>
        
        