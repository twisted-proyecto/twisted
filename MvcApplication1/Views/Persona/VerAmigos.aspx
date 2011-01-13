<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Persona>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Mis Amigos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <table style=" width:700px;">
        <th style=" text-align: left">
            <h2>Mis Amigos</h2>
        </th>
        <th style=" text-align: right">
        <% if (Request.IsAuthenticated && this.Session["data"] != null)
        { %>
            <p>
                <a title="Agregar" href="<%=Url.Action("Index", "Persona")%>">
                    <img src="<%=Url.Content("~/Content/agregar.png")%>" height="25px" width="25px" /></a>
                <%= Html.ActionLink("Agregar nuevo amigo", "Index","Persona")%>
            </p>
            <%
        } %>
        </th>
    </table>
    <br />

    <% if (Model.Count() == 0)
       { %>
           Animate y haz amigos...
       <% }
       else
       {%>
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

    <%
           foreach (var item in Model)
           {%>
    
        <tr>
            <td>
                <img alt="avatar" src="<%:Html.GetGravatarUrlEmail(50, item.Email)%>" width="50px" height="50px" />
            </td>
            <td>
                <%:item.Nickname%>
            </td>
            <td>
                <%:item.Nombre%>
            </td>
            <td>
                <%:item.Apellido%>
            </td>
             <td>
                <%:String.Format("{0:dd/MM/yyyy}", item.FechaNacimiento)%>
            </td>
            <td>
                <%:item.Email%>
            </td>
            <td>
                <a title="Eliminar amigo" href="<%=Url.Action("EliminarAmigo", "Persona", new {nick = item.Nickname}, null)%>">
                    <img src="<%=Url.Content("~/Content/eliminar.png")%>" height="25px" width="25px" /></a>
            </td>
        </tr>
    
    <%
           }
       }%>

    </table>

    

</asp:Content>

