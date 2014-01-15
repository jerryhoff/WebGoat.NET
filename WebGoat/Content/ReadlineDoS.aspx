<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="ReadlineDoS.aspx.cs" Inherits="OWASP.WebGoat.NET.ReadlineDoS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
<asp:Label ID="lblFileContent" runat="server" />
<br />
<asp:FileUpload ID="file1" runat="server" />
<br />
<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
</asp:Content>

