<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ShowOff.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ShowOff.Core.Model.Item>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <%= Html.ScriptInclude("jquery-1.3.2.js") %>
    <%= Html.ScriptInclude("jcarousellite_1.0.1.js") %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="showOff">
        <ul>
        <% foreach (var item in Model.OrderBy(x => x.DisplayPriority)) { %>
            <li>
                <img alt="<%= item.Description %>" src="<%= Html.UploadImageUrl(item.CoverImage.Filename) %>" width="400px" />
                <div><%= Html.Encode(item.Name) %></div>
                <div><%= Html.Encode(item.Description) %></div>
            </li>  
        <% } %>
        </ul>
    </div>
    
    <button id="prev"><<</button>
    <button id="next">>></button>
    
    <script type="text/javascript">

        $(function() {
            $("#showOff").jCarouselLite({
                btnNext: "#next",
                btnPrev: "#prev"
            });
        });
    
    </script>

</asp:Content>



