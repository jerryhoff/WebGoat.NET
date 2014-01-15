<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="CustomerLogin.aspx.cs" Inherits="OWASP.WebGoat.NET.WebGoatCoins.CustomerLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
   
    <script type="text/javascript">
        //var return_url = <%= Request["ReturnUrl"] == null ? "\"\"" : "\"" + Request["ReturnUrl"].ToString() + "\"" %>
        //alert(return_url)
    </script>

    <h1 class="title-regular-4 clearfix">WebGoat Coins Customer Login</h1>
    
    <div class="notice" runat="server" id="divNotice">
        <asp:Literal runat="server" EnableViewState="False" ID="labelMessage">Hello! Please log in to view your private customer data</asp:Literal>
    </div>

    <asp:Panel ID="PanelError" runat="server">
        <div class="error">
            <asp:Literal runat="server" EnableViewState="False" ID="labelError">Your are not logged in.  Please authenticate before proceeding.</asp:Literal>
        </div>
    </asp:Panel>
    

    <p></p>                                                                                                                                                                                                                                                                                                                                                 
    <p class="inline">
        <label for="name">Username</label>
        <br />
        <asp:TextBox ID="txtUserName" runat="server" class="text"></asp:TextBox>
        <br />
        <label for="password">Password</label><br />
        <asp:TextBox ID="txtPassword" runat="server" class="text" TextMode="Password"></asp:TextBox>
    </p>
    <p class="inline">
        <br />
        <label for="check1">
            <input runat="server" title="remember" type="checkbox" name="checkboxRemember" id="checkBoxRemember" value="" />
            Remember me
        </label><br />
    </p>
    <p>
        <asp:Button ID="buttonLogOn" SkinID="Button" runat="server" Text="Login" OnClick="ButtonLogOn_Click" />
    </p>
</asp:Content>
