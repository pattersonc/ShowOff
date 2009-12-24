<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    
    <% using(Html.BeginForm()) { %>
        <input type="submit" value="Run Setup" onclick="return confirm('This will reset the database. Are you sure?');"/>
    <% } %>

</asp:Content>
