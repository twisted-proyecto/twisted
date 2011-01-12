<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Persona>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Perfiles de Usuarios
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Gestion de Perfiles Publicos</h2>
    <br />

    <table>
        <tr>
            <th>
                Avatar
            </th>
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
                Fecha de Nac.
            </th>
            <th>
                Email
            </th>
            
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <img alt="avatar" src="<%:Html.GetGravatarUrlEmail(50,item.Email)%>" width="50px" height="50px" />
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
        
        </tr>
    
    <% } %>

    </table>

    

</asp:Content>

