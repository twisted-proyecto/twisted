<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Destino>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Descripcion</div>
        <div class="display-field"><%: Model.Descripcion %></div>
        
        <div class="display-label">Direccion</div>
        <div class="display-field"><%: Model.Direccion %></div>
        
        <div class="display-label">Estatus</div>
        <div class="display-field"><%: Model.Estatus %></div>
        
        <div class="display-label">Fecha</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.Fecha) %></div>
        
        <div class="display-label">IdDestino</div>
        <div class="display-field"><%: Model.IdDestino %></div>
        
        <div class="display-label">Latitud</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Latitud) %></div>
        
        <div class="display-label">Longitud</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Longitud) %></div>
        
        <div class="display-label">Nombre</div>
        <div class="display-field"><%: Model.Nombre %></div>
        
        <div class="display-label">Url</div>
        <div class="display-field"><%: Model.Url %></div>
        
    </fieldset>
    <p>
        <%=Html.ActionLink("Volver a la lista", "Index", "Destino", new { idViaje = ViewData["idViaje"] }, null)%>
    </p>

</asp:Content>

