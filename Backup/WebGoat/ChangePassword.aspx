<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="OWASP.WebGoat.NET.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <label runat="server" id="lblHeader"></label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
<h1 class="title-regular-4 clearfix">Change Password</h1>


<asp:ChangePassword ID="ChangePwdCtrl" runat="server">

<ChangePasswordTemplate>
Old Password:&nbsp; <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" />
<br /> 

New Password:&nbsp; <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" />
<br />

Confirmation:&nbsp; <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" />

<br /> 

<asp:Button ID="ChangePasswordPushButton" CommandName="ChangePassword" runat="server" Text="Change Password" /> 

<asp:Button ID="CancelPushButton" CommandName="Cancel" runat="server" Text="Cancel" />
<br /> 

<asp:Literal ID="FailureText" runat="server" EnableViewState="False" />

</ChangePasswordTemplate> 

<SuccessTemplate>
    Your password has been changed! 
    <asp:Button ID="ContinuePushButton" CommandName="Continue" runat="server" Text="Continue" />
</SuccessTemplate>

</asp:ChangePassword>

</asp:Content>