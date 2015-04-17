<%@ Page Language="C#" MasterPageFile="~/Resources/Master-Pages/SiteNew.Master" AutoEventWireup="true" CodeBehind="DomXSS.aspx.cs" Inherits="OWASP.WebGoat.NET.DomXSS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
	<script type='text/javascript' src='<%= Page.ResolveUrl("~/Resources/client-scripts/jquery-migrate-1.2.1.js") %>'></script>

	<script type="text/javascript">
		$(document).ready(function () {
			x = $("a[href='" + window.location.hash + "']");
			console.log(x);
		})
	</script>
</asp:Content>
