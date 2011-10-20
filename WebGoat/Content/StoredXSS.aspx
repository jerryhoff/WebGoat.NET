<%@ Page Language="C#" validateRequest="false" AutoEventWireup="true" CodeBehind="StoredXSS.aspx.cs" Inherits="OWASP.WebGoat.NET.StoredXSS" MasterPageFile="~/resources/Master-Pages/Site.Master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    This webpage fails to properly validate and encode user-supplied data.  Users can add their own HTML and scripts to messages.  
    See if you can display your session cookie in a dialog box. 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
		<h1 class="title-regular-4 clearfix">Classifieds</h1>
        <p />
        <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        &nbsp;<asp:DetailsView ID="dtlView" runat="server" CellPadding="10" 
            CellSpacing="10" EnableModelValidation="True" ForeColor="#333333" 
            GridLines="None" Height="79px" Width="726px">
            <AlternatingRowStyle BackColor="White" />
            <CommandRowStyle BackColor="#C5BBAF" Font-Bold="True" />
            <EditRowStyle BackColor="#7C6F57" BorderWidth="5px" />
            <FieldHeaderStyle BackColor="#D0D0D0" Font-Bold="True" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
        </asp:DetailsView>

        Post your own listing:<br />
        <table>
        <tr>
            <td>Title:</td>
            <td><asp:TextBox ID="txtTitle" runat="server" Columns="70" Width="409px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Your Email:</td>
            <td><asp:TextBox ID="txtEmail" runat="server" Width="409px"></asp:TextBox></td>
        </tr>
        <tr>
        <td>Message:</td>
        <td><asp:TextBox ID="txtMessage" runat="server" Height="206px" TextMode="MultiLine" 
                Width="409px"></asp:TextBox></td>
        </tr>
        <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btnAdd" runat="server" Text="Add Listing!" 
                onclick="btnAdd_Click" />
            </td>
        </tr>
        </table>
        <br />
</asp:Content>