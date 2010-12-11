<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Destino>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalles de Destinos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>- Gestion de Destinos -</h2>

    <fieldset>
        <legend>Detalles:</legend>
        
        <div class="display-label">Nombre</div>
        <div class="display-field"><%: Model.Nombre %></div>

        <div class="display-label">Descripcion</div>
        <div class="display-field"><%: Model.Descripcion %></div>
        
        <div class="display-label">Direccion</div>
        <div class="display-field"><%: Model.Direccion %></div>
        
        <div class="display-label">Estatus</div>
        <div class="display-field"><%: Model.Estatus %></div>
        
        <div class="display-label">Fecha</div>
        <div class="display-field"><%: String.Format("{0:dd/MM/yyyy}", Model.Fecha)%></div>
        
        <div class="display-label">Latitud</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Latitud) %></div>
        
        <div class="display-label">Longitud</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Longitud) %></div>
        
        <div class="display-label">Foto referencial</div>
        <div class="display-field"><img src="<%: Model.Url %>" alt="" /></div>
        
    </fieldset>
    <p>
        <%=Html.ActionLink("Volver a la lista", "Index", "Destino", new { idViaje = ViewData["idViaje"] }, null)%>
    </p>

</asp:Content>

