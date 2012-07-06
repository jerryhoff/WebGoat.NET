<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="OWASP.WebGoat.NET.MainPage" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    Try uploading content that will run on the server, such as an .aspx file! 
    <br />
    For Example:
    <br />
    <pre>
    &lt;%
     lblTest.Text = &quot;Hello, world!&quot;;
    %&gt;

    &lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot; &gt;
     &lt;head runat=&quot;server&quot;&gt;
     &lt;/head&gt;
     &lt;body&gt;
      &lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;
       &lt;asp:Label runat=&quot;server&quot; id=&quot;lblTest&quot;&gt;
       &lt;/asp:Label&gt;
      &lt;/form&gt;
     &lt;/body&gt;
    &lt;/html&gt;
    </pre>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">

    <script type="text/javascript">
        $(document).ready(function() {
            var admin = <%= (User.IsInRole("admin") ? 1 : 0 ) %>;  
            if(admin == 0) //not an admin
            { 
                $("#ctl00_BodyContentPlaceholder_logoFileName").hide();
                $("#ctl00_BodyContentPlaceholder_question_id").hide();
                $("#ctl00_BodyContentPlaceholder_password").hide();
                $("#ctl00_BodyContentPlaceholder_answer").hide();
            }
                    
            $("div.success").hide();
                    
            setTimeout(function () {
                $("div.success").fadeIn("slow", function () {
                    $("div.success").show();
                });
            }, 500);
        });

     

    </script>


    <h1 class="title-regular-4 clearfix">Welcome to the WebGoat Coins Customer Portal!</h1>
    <asp:Label ID="labelOutput" runat="server" Text=""></asp:Label>

    <div class="notice">
    <asp:Literal runat="server" EnableViewState="False" ID="labelMessage">
        Welcome back!  This portal allows you to change your password, view your orders, view the entire catalog, write reviews for products and much more!
    </asp:Literal>
    </div>

    <div>
    <h1 class="title-regular-3 clearfix" style="text-align:center;">
    <asp:Literal runat="server" EnableViewState="False" ID="labelWelcome">Welcome Back...</asp:Literal>
    </h1>
    <asp:Image ID="Image1" runat="server" style=" display: block;margin-left: auto;margin-right: auto; text-align:center;" />
    <p>&nbsp;</p>
    </div>

    <asp:Label ID="labelUpload" runat="server">
    <div class="success" style="text-align:center">
        File Successfully Uploaded!
    </div>
    </asp:Label>

    <h1 class="title-regular-3 clearfix" style="text-align:center;">Your Customer Data</h1>
    
    <asp:Table ID="CustomerTable" runat="server" CssClass="customerdata">
    </asp:Table>

    <div>
        
    </div>

    <div class="tiny" style="text-align:center">Upload us your order (PDF, Excel or Plain Text)...
    <hr />    
    <asp:FileUpload ID="FileUpload1" runat="server"/>
    <p>&nbsp;</p>
    <asp:Button ID="btnUpload" runat="server" Text="Upload Document" 
            CssClass="button medium blue" onclick="btnUpload_Click" />
        
    </div>

</asp:Content>