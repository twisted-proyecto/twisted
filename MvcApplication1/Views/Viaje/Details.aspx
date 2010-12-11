<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Viaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>- Gestion de Viajes -</h2>

    <fieldset>
        <legend>Detalles:</legend>
        <p>
            Nombre:
            <%= Html.Encode(Model.Nombre) %>
        </p>
        <p>
            Destino:
            <%= Html.Encode(Model.Destino) %>
        </p>
        <p>
            Hospedaje:
            <%= Html.Encode(Model.Hospedaje) %>
        </p>
        <p>
            Fecha Inicio:
            <%= Html.Encode(Model.FechaInicio) %>
        </p>
        <p>
            Fecha Fin:
            <%= Html.Encode(Model.FechaFin) %>
        </p>
        <p>
            Privacidad:
            <%= Html.Encode(Model.Privacidad) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Editar", "Edit", new { id=Model.IdViaje }) %> |
        <%=Html.ActionLink("Volver a la lista", "Index", "Destino", new { idViaje = ViewData["idViaje"] }, null)%>
    </p>

</asp:Content>

