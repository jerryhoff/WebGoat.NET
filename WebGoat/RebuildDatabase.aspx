<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dbtest.aspx.cs" Inherits="OWASP.WebGoat.NET.RebuildDatabase" MasterPageFile="~/Resources/Master-Pages/Site.Master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    Click to button to refresh the database used in WebGoat.NET
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
        <h1 class="title-regular-4 clearfix">Connect to Database</h1>
        
        <asp:Panel ID="PanelWelcome" runat="server">
            <div class="notice">
            <asp:Literal runat="server" EnableViewState="False" ID="labelMessage">WebGoat.NET requires a working data provider.&nbsp; Fill in the following (applicable) fields:</asp:Literal>
            </div>
        </asp:Panel>

           
        <br />
        <br />
            <table style="width:100%;">
                <tr>
                    <td class="style1">
                        Data Provider:</td>
                    <td class="style2">
                        <asp:DropDownList ID="dropDownDataProvider" runat="server" CssClass="container_24" 
                            Width="371px">
                            <asp:ListItem>Sqlite</asp:ListItem>
                            <asp:ListItem>MySql</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Data File Path:</td>
                    <td class="style2">
                        <asp:TextBox ID="txtFilePath" runat="server" Height="16px" Width="371px" 
                            CssClass="text"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Client Executable:</td>
                    <td class="style2">
                        <asp:TextBox ID="txtClientExecutable" runat="server" Height="16px" Width="371px" 
                            CssClass="text"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Server:</td>
                    <td class="style2">
                        <asp:TextBox ID="txtServer" runat="server" Height="16px" Width="371px" 
                            CssClass="text"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Port:</td>
                    <td class="style2">
                        <asp:TextBox ID="txtPort" runat="server" Height="16px" Width="371px" 
                            CssClass="text"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Database:</td>
                    <td class="style2">
                        <asp:TextBox ID="txtDatabase" runat="server" Height="16px" Width="371px" 
                            CssClass="text"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        User Name:</td>
                    <td class="style2">
                        <asp:TextBox ID="txtUserName" runat="server" Height="16px" Width="371px" 
                            CssClass="text"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Password:</td>
                    <td class="style2">
                        <asp:TextBox ID="txtPassword" runat="server" Height="16px" Width="371px" 
                            CssClass="text"></asp:TextBox>
                    </td>
                </tr>
            </table>
        <br />
        

        <asp:Panel ID="PanelSuccess" runat="server">
            <div class="success">
            <asp:Literal runat="server" EnableViewState="False" ID="labelSuccess"></asp:Literal>
        </div>
        </asp:Panel>


        <asp:Panel ID="PanelError" runat="server">
        <div class="error">
            <asp:Literal runat="server" EnableViewState="False" ID="labelError"></asp:Literal>
        </div>
        </asp:Panel>
 
        <asp:Button ID="btnTestConfiguration" runat="server" onclick="btnTestConfiguration_Click" 
            Text="Test Configuration" SkinID="Button"/>

        <br />
        <br />
        <br />

        <asp:Panel ID="PanelRebuildFailure" runat="server">
                <div class="error"/>
                <asp:Literal runat="server" EnableViewState="False" ID="labelRebuildFailure" />
        </asp:Panel>     
     
        <asp:Panel ID="PanelRebuildSuccess" runat="server">
            <div class="success">
            <asp:Literal runat="server" EnableViewState="False" ID="labelRebuildSuccess"></asp:Literal>
        </div>
        </asp:Panel>


        <asp:Button ID="btnRebuildDatabase" runat="server" onclick="btnRebuildDatabase_Click" 
            Text="Rebuild Database" SkinID="Button" />
        <br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblOutput" runat="server"></asp:Label>
        <br />
        <br />
        <br />


        <asp:GridView ID="grdView" runat="server" CellPadding="4" 
            EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
            Height="117px">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <br />

</asp:Content>
        
        <asp:Content ID="Content4" runat="server" 
    contentplaceholderid="HeadContentPlaceHolder">
            <style type="text/css">
                .style1
                {
                    width: 101px;
                }
                .style2
                {
                    width: 444px;
                }
                .style3
                {
                    width: 101px;
                    height: 32px;
                }
                .style4
                {
                    width: 444px;
                    height: 32px;
                }
            </style>
</asp:Content>

        
        