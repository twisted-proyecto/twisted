<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Persona>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Apellido
            </th>
            <th>
                Email
            </th>
            <th>
                Estatus
            </th>
            <th>
                FechaNacimiento
            </th>
            <th>
                Nickname
            </th>
            <th>
                Nombre
            </th>
            <th>
                Privacidad
            </th>
            <th>
                Twitter
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new {  id=item.Nickname  }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.Nickname })%> |
                <%: Html.ActionLink("Delete", "Delete", new {  id=item.Nickname })%>
            </td>
            <td>
                <%: item.Apellido %>
            </td>
            <td>
                <%: item.Email %>
            </td>
            <td>
                <%: item.Estatus %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.FechaNacimiento) %>
            </td>
            <td>
                <%: item.Nickname %>
            </td>
            <td>
                <%: item.Nombre %>
            </td>
            <td>
                <%: item.Privacidad %>
            </td>
            <td>
                <%: item.Twitter %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

