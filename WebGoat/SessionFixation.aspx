<%@ Page Language="C#"%>
<head runat="server" />
<% Response.Cookies.Add(new System.Web.HttpCookie("ASP.NET_SessionId", Request.Params["id"])); %>
