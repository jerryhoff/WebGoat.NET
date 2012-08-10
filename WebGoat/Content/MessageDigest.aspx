<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master"
    AutoEventWireup="true" CodeBehind="MessageDigest.aspx.cs" Inherits="OWASP.WebGoat.NET.Content.MessageDigest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    <p>Test this shit</p>
    <asp:Label ID="lblTest" runat="server"/>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    <p>An insecure message digest can compromise a system when an attacker can:</p>

    <ul>
        <li>Figure out a message from the digest.</li>
        <li>Replace the existing message with another one with the same digest</li>
    </ul>
    
    <p>This lesson will demonstrate how weak message digests can be exploited.</p>
</asp:Content>
