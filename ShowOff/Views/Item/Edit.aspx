<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ShowOff.Core.Model.Item>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Show Off - Edit <%= Model.Name %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Item</h2>
    <%= Html.ValidationSummary(true, "Could not save.") %>
    <%Html.EnableClientValidation(); %>
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
                <%= Html.LabelFor(model => model.DisplayPriority) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.DisplayPriority) %>
                <%= Html.ValidationMessageFor(model => model.DisplayPriority) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>
    
    <fieldset>
        <legend>Add Image</legend>
        <% using (Html.BeginForm("AddImage", "Item", new {id = Model.ID }, FormMethod.Post, new { enctype = "multipart/form-data" })) { %>
        <p>
            <input type="file" id="fileUpload" name="fileUpload" size="23"/>
            <input type="submit" value="Upload file" />
        </p>        
        <% } %> 
    </fieldset>

    <ul class="album">
    <% foreach (var image in Model.Images) { %>

    <li>
        <div id="editImageThumb">
            <img alt="<%= Model.Description %>" src="<%= Html.UploadImageUrl(image.ThumbFilename) %>" width="100px" />
        </div>
        <div id="editDefaultOptions">                
            <% if (Model.CoverImage.ID == image.ID) { %>
                <span>Cover Image</span>
            <% } 
               else 
               {
                using (Html.BeginForm("SetDefaultImage", "Item", new {id = Model.ID, imageID = image.ID}, FormMethod.Post)) { %>
                    <input type="submit" value="Set as Cover Image" />
            <% } } %>
        </div>
        <div id="editDeleteOptions">    
            <% if(Model.CoverImage.ID != image.ID) {
                using (Html.BeginForm("DeleteImage", "Item", new {id = Model.ID, imageID = image.ID}, FormMethod.Post)) { %>
                    <input type="submit" value="Delete" onclick="return confirm('Are you sure you want to delete this image?');" />
            <% } } %>
        </div>
    </li>

    <% } %>
    </ul>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

