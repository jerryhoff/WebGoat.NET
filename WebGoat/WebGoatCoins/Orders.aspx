<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="OWASP.WebGoat.NET.WebGoatCoins.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    <h1 class="title-regular-4 clearfix">WebGoat Coins Customer Orders</h1>

    <div class="notice">
        <asp:Literal runat="server" EnableViewState="False" ID="labelMessage">
        Here is a listing of all the orders associated with your account.  Questions?  Call us anytime!
        </asp:Literal>
    </div>

    <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
        GridLines="None" Width="100%" onrowdatabound="GridView1_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>

    
    <asp:Panel ID="PanelShowDetailSuccess" runat="server" Visible="false">
           <div class="success">
            <asp:Literal runat="server" EnableViewState="False" ID="litSuccessDetailMessage">
            Here are the details for that order!
            </asp:Literal>
        </div>

    </asp:Panel>

    <asp:Panel ID="PanelShowDetailFailure" runat="server" Visible="false">
           <div class="error">
            <asp:Literal runat="server" EnableViewState="False" ID="litErrorDetailMessage">
            Failure...
            </asp:Literal>
        </div>

    </asp:Panel>

    <asp:Panel ID="PanelShowDetails" runat="server">



        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="100%" 
            CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
            GridLines="None" HorizontalAlign="Center" FieldHeaderStyle-Width="20%">
            <AlternatingRowStyle BackColor="White" />
            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
            <EditRowStyle BackColor="#2461BF" />
            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
        </asp:DetailsView>
        <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
    </asp:Panel>

</asp:Content>
