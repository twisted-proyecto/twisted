<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Destino>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Gestion de Destino
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Gestion de Destinos</h2>
    <br />
    <% if (Model.Count() == 0)
       { %>
           No existe ningun Destino para el viaje.
       <% }
       else
       {%>
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
    <%
           foreach (var item in Model)
           {%>
    
        <tr>
            <td>
                <a title="Editar" href="<%= Url.Action("Edit", "Destino", new {id = item.IdDestino, idViaje = ViewData["idViaje"]}, null) %>">
                  <img src="<%= Url.Content("~/Content/editar.png") %>" height="15px" width="15px" /></a>
                |
                <a title="Eliminar" href="<%= Url.Action("Delete", "Destino", new {id = item.IdDestino, idViaje = ViewData["idViaje"]}, null) %>">
                  <img src="<%= Url.Content("~/Content/eliminar.png") %>" height="15px" width="15px" /></a>
            </td>
            <td>
                <%=Html.Encode(item.Nombre)%>
            </td>
            <td>
                 <%: String.Format("{0:dd/MM/yyyy}", item.Fecha)%>
            </td>
            <td>
                <a title="Detalles" href="<%= Url.Action("Details", "Destino", new {id = item.IdDestino, idViaje = ViewData["idViaje"]}, null) %>">
                  <img src="<%= Url.Content("~/Content/consultar.png") %>" height="15px" width="15px" /></a>
            </td>
        </tr>
    
    <%
           }
       }%>

    </table>

    <p>
        <a title="Agregar" href="<%= Url.Action("Create", "Destino", new { idViaje = ViewData["idViaje"] }) %>">
          <img src="<%= Url.Content("~/Content/agregar.png") %>" height="15px" width="15px" /></a>
        <%= Html.ActionLink("Agregar nuevo destino", "Create", new { idViaje = ViewData["idViaje"] })%>
    </p>

</asp:Content>