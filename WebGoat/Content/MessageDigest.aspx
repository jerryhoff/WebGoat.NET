<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master"
    AutoEventWireup="true" CodeBehind="MessageDigest.aspx.cs" Inherits="OWASP.WebGoat.NET.Content.MessageDigest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">

    <%-- Throw in some hints here. Many will have a hard time figuring it out. --%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    <p>Try to construct a message that has the same digest as: <asp:Label ID="lblDigest" runat="server"/></p>

    <p><asp:TextBox ID="txtBoxMsg" runat="server" TextMode="MultiLine" Width="400px" Height="100px"/></p>
    
    <p><asp:Button ID="btnDigest" runat="server" onclick="btnDigest_Click" 
            Text="Digest Message!" SkinID="Button"/></p>
    <p>Result: <asp:Label ID="lblResultDigest" runat="server" /></p>

    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    <p>An insecure message digest can compromise a system when an attacker can:</p>

    <ul>
        <li>Figure out a message from the digest.</li>
        <li>Replace the existing message with another one with the same digest</li>
    </ul>
    
    <p>This lesson will demonstrate how weak message digests can be exploited.</p>
</asp:Content>
