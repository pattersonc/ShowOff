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
        
        <div class="slideShow">

            <ul>
            <% foreach (var item in Model.Images.OrderBy(x => x.ID)) { %>
                <li>
                    <img alt="<%= Model.Name %>" src="<%= Html.UploadImageUrl(item.Filename) %>" />
                </li>  
            <% } %>
            </ul>
        </div>
        
        <div class="copy">
            <%= Html.Encode(Model.Description) %>
        </div>
        
        <div class="clear"></div>
        
    </div>

    <script type="text/javascript">

        $(function() {
            $(".slideShow").jCarouselLite({
                scroll: 1,
                visible: 1,
                auto: 3000
            });
        });
    
    </script>
    
</asp:Content>