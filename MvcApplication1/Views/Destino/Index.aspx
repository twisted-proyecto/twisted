<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Destino>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Gestion de Destino
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>- Gestion de Destino -</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Nombre del Destino
            </th>
            <th>
                Fecha tentativa
            </th>
            <th></th>
        </tr>
    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Editar", "Edit", new { id = item.IdDestino, idViaje = ViewData["idViaje"] })%> |
                <%= Html.ActionLink("Detalles", "Details",new { id = item.IdDestino, idViaje = ViewData["idViaje"] })%>
            </td>
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
            <td>
                <%= Html.Encode(item.Fecha) %>
            </td>
            <td>
                <%= Html.ActionLink("Eliminar", "Delete", new { id = item.IdDestino, idViaje = ViewData["idViaje"] })%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Agregar nuevo destino", "Create", new { idViaje = ViewData["idViaje"] })%>
    </p>

</asp:Content>