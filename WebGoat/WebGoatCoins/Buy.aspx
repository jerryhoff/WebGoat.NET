<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="Buy.aspx.cs" Inherits="OWASP.WebGoat.NET.WebGoatCoins.Buy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    
    <asp:Wizard ID="BuyWizard" runat="server" ActiveStepIndex="0" Height="344px" Width="699px"
        OnActiveStepChanged="OnActiveStepChanged" OnFinishButtonClick="OnFinishButtonClick">
        <WizardSteps>
            <asp:WizardStep runat="server" EnableViewState="False" StepType="Start" title="Product">
                <asp:Label ID="lblOutputStep0" runat="server" Text=""></asp:Label>
            </asp:WizardStep>
            <asp:WizardStep runat="server" EnableViewState="False" title="Address">
                <h1>Enter a shipping address</h1>
                <p>
                    <b>Full Name:</b>
                    <asp:TextBox ID="tbFullName" runat="server"></asp:TextBox>
                    <br/>
                    <b>Country:</b>
                    <asp:DropDownList ID="ddlCountry" runat="server" CausesValidation="True" 
                        AutoPostBack="True" OnSelectedIndexChanged="OnSelectedIndexChanged">
                       <asp:ListItem value="US" selected="True">
                          US
                       </asp:ListItem>
                       <asp:ListItem value="Australia">
                          Australia
                       </asp:ListItem>
                    </asp:DropDownList>
                    <br/>
                    <b>Address:</b>
                    <asp:TextBox ID="tbAddress" runat="server"/>
                </p>
                <p>
                    Shipping price:
                    <asp:Label ID="lblShippingPrice" runat="server"/>
                </p>
                <p>
                    <b>Total price:</b>
                    <asp:Label ID="lblTotalPrice" runat="server"/>
                </p>
            </asp:WizardStep>
            <asp:WizardStep runat="server" EnableViewState="False" StepType="Finish" title="Finish">
                <h1>Press the Finish button<br/>to complete the purchase,<br/>and print an invoice</h1>
            </asp:WizardStep>

        </WizardSteps>
    </asp:Wizard>
    
</asp:Content>
