<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShowOff.Core.Model.Item>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Confirm</h2>

    <div>Are you sure you want to delete this item?</div>
    <br />
    <br />    
    <div>
    
    <% using(Html.BeginForm(new {id = Model.ID }))  { %> 
        <input type="submit" value="Yes" />
        <%= Html.ActionLink("Cancel", "Index") %>
    <% } %>
        
    </div>
</asp:Content>
