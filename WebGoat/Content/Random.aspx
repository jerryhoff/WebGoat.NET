<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true"
 Inherits="OWASP.WebGoat.NET.Content.Random" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">

    <h1 class="title-regular-4 clearfix">Weak Random Number Generators</h1>
    
    <p>A weak number generator can be the source of a system break-in, as it is used in many important situations
    such as password salts, SSL handshakes etc.</p>
    
    <p>In the following example, try to predict the next number in the sequence:</p>
       
    <p><asp:Label ID="lblSequence" runat="server" /></p>
    
    <table>
        <tr>
            <td><asp:Button ID="btnOneMore" runat="server" onclick="btnOneMore_Click" Text="Generate number!" /></td>
            <td><asp:Button ID="btnReset" Text="Reset" onclick="btnReset_Click" runat="server" /></td>
        </tr>
    </table>
    
    <p>The next number is: <asp:TextBox ID="txtNextNumber" runat="server" /> 
    <asp:Button ID="btnGo" Text="Go!" runat="server" onclick="btnGo_Click" /></p>
    
    <p><asp:Label ID="lblResult" runat="server" /></p>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">

</asp:Content>
