<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master"
    AutoEventWireup="true" CodeBehind="MessageDigest.aspx.cs" Inherits="OWASP.WebGoat.NET.Content.Unsafe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">

    <%--
        Throw in some hints here. Many will have a hard time figuring it out:
            -- Write a looong message
    --%>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">

    <h1 class="title-regular-4 clearfix">Unsafe blocks in .NET</h1>

    <p>In this lesson we'll take a look at .NET's unsafe block and how it can be exploited through user input.
     When typing a string in the textbox below, the server will read it and compute its reverse. Try to exploit the
      server by typing in a 'bad' input.</p>
 
    <p><asp:TextBox ID="txtBoxMsg" runat="server" TextMode="MultiLine" Width="400px" Height="100px"/></p>
    
    <p><asp:Button ID="btnReverse" runat="server" onclick="btnReverse_Click" 
            Text="Reverse Message!" SkinID="Button"/></p>

    <p>Result: <asp:Label ID="lblReverse" runat="server" /></p>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">

</asp:Content>
