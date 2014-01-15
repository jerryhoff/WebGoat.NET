<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="Clickjacking.aspx.cs" Inherits="OWASP.WebGoat.NET.Clickjacking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server" ></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    
    <asp:Label runat="server" EnableViewState="False" ID="labelMessage" onload="labelMessage_Load">No recent orders</asp:Label>
        
    <table style="width:100%;padding:10px">
        <tr>
            <td class="style 1"></td>
        </tr> 
        <tr>
            <td><asp:Button ID="btnOrder" SkinID="Button" runat="server" 
                    Text="Place One Click Order!" onclick="btnGo_Click" />
            
                <br />
                <br />
                <br />
                <br />
            
                <asp:LinkButton ID="lnkReset" runat="server" onclick="lnkReset_Click1">Reset Order History</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
</asp:Content>