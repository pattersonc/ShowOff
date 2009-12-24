<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShowOff.Core.Model.Item>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create Item
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create Item</h2>
    
    <% Html.EnableClientValidation(); %>
    
    <% using (Html.BeginForm()) {%>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Name) %>
                <%= Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Description) %>
                <%= Html.ValidationMessageFor(model => model.Description) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Url) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Url) %>
                <%= Html.ValidationMessageFor(model => model.Url) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Type) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.Type, ViewData["Types"] as SelectList, "Select") %>
                <%= Html.ValidationMessageFor(model => model.Type) %>
            </div>
                       
            <div class="editor-label">
                <%= Html.LabelFor(model => model.DisplayPriority) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.DisplayPriority) %>
                <%= Html.ValidationMessageFor(model => model.DisplayPriority) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

