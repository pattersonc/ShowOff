<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ShowOff.Master" Inherits="System.Web.Mvc.ViewPage<ShowOff.Core.Model.Item>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <%= Html.ScriptInclude("jquery-1.3.2.js") %>
    <%= Html.ScriptInclude("jcarousellite_1.0.1.js") %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="showOffDetail">
    
        <div class="header">
            <%= Html.Encode(Model.Name) %> 
        </div>
        
        <div class="clear"></div>
        
        <div id="item-wrapper">
            <div id="slideshow-wrapper">
                <div id="slideshow-items">
                    <ul>
                    <% foreach (var item in Model.Images.OrderBy(x => x.ID)) { %>
                        <li>
                            <img alt="<%= Model.Name %>" src="<%= Html.UploadImageUrl(item.Filename) %>" />
                        </li>  
                    <% } %>
                    </ul>
                </div>
            </div>
            <div id="item-description">
                <p><%= Html.Encode(Model.Description) %></p>
            </div>
        </div>       
    </div>
    <script type="text/javascript">

        $(function() {
            $("#slideshow-items").jCarouselLite({
                scroll: 1,
                visible: 1,
                auto: 3000
            });
        });
    
    </script>
    
</asp:Content>