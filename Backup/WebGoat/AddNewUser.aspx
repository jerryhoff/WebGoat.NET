<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="AddNewUser.aspx.cs" Inherits="OWASP.WebGoat.NET.AddNewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    This page allows you to add a new user
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
<h1 class="title-regular-4 clearfix">Add New User</h1>
	<%-- 
    <p>
        <asp:CreateUserWizard ID="RegisterUser" runat="server" 
            CancelDestinationPageUrl="~/Default.aspx" 
            ContinueDestinationPageUrl="~/Default.aspx" DisplayCancelButton="True"
            oncreatinguser="RegisterUser_CreatingUser">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" />
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" />
            </WizardSteps>
        </asp:CreateUserWizard>
    </p>
    --%>
    <p>
        <asp:Label runat="server" id="InvalidUserNameOrPasswordMessage" Visible="false" EnableViewState="false" ForeColor="Red"></asp:Label>
    </p>
    
    <p>
    <table>
    <tr>
        <td>Enter a username: </td>
        <td><asp:TextBox ID="Username" runat="server"></asp:TextBox></td>
        
    </tr>
    <tr>
        <td>Choose a password:</td>
        <td><asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox></td>
    </tr>
    <tr>    
        <td>Enter your email address:</td>
        <td><asp:TextBox ID="Email" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label runat="server" ID="SecurityQuestion"></asp:Label>: </td>
        <td><asp:TextBox ID="SecurityAnswer" runat="server"></asp:TextBox> </td>
    </tr>
    </table>          
   	<p/>
        <asp:Button ID="CreateAccountButton" runat="server" 
            Text="Create the User Account" onclick="CreateAccountButton_Click" />
    </p>
    <p>
        <asp:Label ID="CreateAccountResults" runat="server"></asp:Label>
    </p>    
</asp:Content>

