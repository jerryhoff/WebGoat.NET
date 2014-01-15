<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="OWASP.WebGoat.NET.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    <h1 class="title-regular-4 clearfix">
        WebGoat.NET Login</h1>
    <asp:Literal runat="server" EnableViewState="False" ID="labelMessage"></asp:Literal>
    
    <%--
    <p></p>
    <div class="notice">Get Credentials From Instructor</div>
    <p class="inline">
        <label for="name">Username</label>
        <br />
        <input runat="server" name="name" id="txtUserName" type="text" class="text" /><br />
        <label for="password">Password</label><br />
        <input runat="server" name="password" id="txtPassword" type="password" class="text" /><br />
        <label for="check1">
            <input runat="server" title="remember" type="checkbox" name="checkboxRemember" id="checkBoxRemember" value="" />
            Remember me
        </label><br />
    </p>
    --%>
    <p>
        <asp:Button ID="buttonLogOn" SkinID="Button" runat="server" Text="Customer Login" OnClick="ButtonLogOn_Click" />
        <p/>
        <asp:Button ID="buttonAdminLogOn" SkinID="Button" runat="server" Text="Employee Login" OnClick="ButtonAdminLogOn_Click" />
    </p>
    <hr />
</asp:Content>
 