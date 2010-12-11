<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Viaje>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Gestion de Viajes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>- Gestion de Viajes -</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Nombre del Viaje
            </th>
            <th>
                Fecha de Inicio
            </th>
            <th></th>
        </tr>
    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Editar", "Edit", new {  id=item.IdViaje }) %> |
                <%= Html.ActionLink("Detalles", "Details", new { id = item.IdViaje })%>
            </td>
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
            <td>
                <%= Html.Encode(item.FechaInicio) %>
            </td>
            <td>
                <%= Html.ActionLink("Eliminar", "Delete", new { id = item.IdViaje })%>
            </td>
              <td>
                <%= Html.ActionLink("Destinos", "Index", "Destino", new { idViaje = item.IdViaje }, null)%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Agregar nuevo viaje", "Create") %>
    </p>

</asp:Content>

