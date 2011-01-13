<%@ Page Title="Category List" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Category>>" %>
<%@ Import Namespace="MvcApplication1.Dominio.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Index</h2>
   <div id="divCategoryList">    
    <% Html.RenderPartial("CategoryList", Model); %>
</div>
</asp:Content>

