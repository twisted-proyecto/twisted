<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Persona>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Perfiles de Usuarios
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Perfiles de Usuarios</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Nickname
            </th>
            <th>
                Nombre
            </th>
            <th>
                Apellido
            </th>
            <th>
                FechaNacimiento
            </th>
            <th>
                Email
            </th>
            <th>
                Estatus
            </th>
             <th>
                Privacidad
            </th>
            
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
             <% if ((this.Session["data"]!=null) &&(this.Session["data"] as string ==item.Nickname))
                         { %>
                            <%: Html.ActionLink("Edit", "Edit", new {  id=item.Nickname  }) %> 
                      <%}%>
                                            |
                <%: Html.ActionLink("Details", "Details", new { id=item.Nickname })%> |
                
                <% if ((this.Session["data"]!=null) &&(this.Session["data"] as string ==item.Nickname))
                        { %>
                            <%: Html.ActionLink("Delete", "Delete", new {  id=item.Nickname })%>
                      <%}%> 

                <% if ((this.Session["data"]!=null) &&(this.Session["data"] as string ==item.Nickname))
                        { %>
                            <%: Html.ActionLink("Viajes", "Index","Viaje", new {  id=item.Nickname })%>
                      <%}%> 
               
            </td>
            <td>
                <%: item.Nickname %>
            </td>
            <td>
                <%: item.Nombre %>
            </td>
            <td>
                <%: item.Apellido %>
            </td>
             <td>
                <%: String.Format("{0:dd/MM/yyyy}", item.FechaNacimiento)%>
            </td>
            <td>
                <%: item.Email %>
            </td>
            <td>
                <%: item.Estatus %>
            </td>
            <td>
                <%: item.Privacidad %>
            </td>
            
        </tr>
    
    <% } %>

    </table>

    

</asp:Content>

