<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true"
 Inherits="OWASP.WebGoat.NET.Content.Random" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">

    <h1 class="title-regular-4 clearfix">Weak Random Number Generators</h1>
    
    <p>A weak number generator can be the source of a system break-in, as it is used in many important situations
    such as password salts, SSL handshakes etc.</p>
    
    <p>In the following example, try to predict the next number in the sequence:</p>
    
    <p>-- Sequence is created here...</p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">

</asp:Content>
