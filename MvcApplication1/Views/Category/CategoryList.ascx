<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MvcApplication1.Dominio.Model.Category>>" %>
<%@ Import Namespace="MvcApplication1.Helpers" %>
    <table>
        <tr>
            <th>
                Edit
            </th>
            <th>
                Delete
            </th>
            <th>
                Voto
            </th>
            <th>
                Nickname
            </th>
            <th>
                Destino
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id = item.Id })%>                
            </td>
            <td>             
             <%= Html.ActionLink("Delete", "Delete", new { id = item.Id })%> 
              
            </td>
            <td>
                <%= Html.Encode(item.Voto) %>
            </td>
            <td>
                <%= Html.Encode(item.Nickname) %>
            </td>
            <td>
                <%= Html.Encode(item.IdDestino) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>


