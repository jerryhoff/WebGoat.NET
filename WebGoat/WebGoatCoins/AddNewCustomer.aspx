<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="AddNewCustomer.aspx.cs" Inherits="OWASP.WebGoat.NET.WebGoatCoins.AddNewCustomer" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    <% if (!du.IsAdminCustomerLogin(User.Identity.Name))
       { %>
        <p>
            <asp:Label runat="server" EnableViewState="false" ForeColor="Red">
                ACCESS DENIED!
            </asp:Label>
        </p>
    <% }
       else
       { %>
        <p>
            <asp:Label runat="server" id="InvalidUserNameOrPasswordMessage" Visible="false" EnableViewState="false" ForeColor="Red"></asp:Label>
        </p>
        <p>
            <table>
                <tr>
                    <td>Enter a username: </td>
                    <td>
                        <asp:TextBox ID="Username" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Enter your email address:</td>
                    <td>
                        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Choose a password:</td>
                    <td>
                        <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Administrator:</td>
                    <td>
                        <asp:CheckBox ID="IsAdmin" runat="server"></asp:CheckBox>
                    </td>
                </tr>
            </table>

            <asp:Button ID="CreateCustomerButton" runat="server"
                        Text="Create the User ccount" OnClick="CreateCustomer"/>
        </p>
        <p>
            <asp:Label ID="CreateAccountResults" runat="server"></asp:Label>
        </p>
    <% } %>
</asp:Content>
