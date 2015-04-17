<%@ Page Language="C#" MasterPageFile="~/Resources/Master-Pages/SiteNew.Master" AutoEventWireup="true" CodeBehind="DomXSS.aspx.cs" Inherits="OWASP.WebGoat.NET.DomXSS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    <script type='text/javascript' src='<%= Page.ResolveUrl("~/Resources/client-scripts/jquery-migrate-1.2.1.js") %>'></script>

    <script type="text/javascript">
        $(function () {
            var tabContainers = $('div.tabs > div');
            tabContainers.hide();

            $('div.tabs ul.tabNavigation a').click(function() {
                window.location.hash = this.hash;
                tabContainers.hide();
                $(this.hash).show();
                $('div.tabs ul.tabNavigation a').removeClass('selected');
                $(this).addClass('selected');
                return false;
            });

            var id = window.location.hash != '' ? window.location.hash : '#first';
            $('div.tabs ul.tabNavigation a[href=' + id + ']').click();
        });
    </script>
    
    <div class="tabs">
        <ul class="tabNavigation">
            <li><a class="" href="#first">Murphy’s Law I</a></li>
            <li><a class="" href="#second">Murphy’s Law II</a></li>
            <li><a class="" href="#third">Smith's Law</a></li>
        </ul>

        <div id="first">
            <h2>Murphy’s Law I</h2>
            <p>If that guy has any way of making a mistake, he will.</p>
        </div>
        <div id="second">
            <h2>Murphy’s Law II</h2>
            <p>Everything takes longer than you think.</p>
        </div>
        <div id="third">
            <h2>Smith's Law</h2>
            <p>Murphy was an optimist.</p>
        </div>
    </div>
</asp:Content>
