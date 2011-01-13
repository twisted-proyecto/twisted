<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Persona>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Perfiles de Usuarios
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestion de Perfiles</h2>
    <br />
    <% if (Model.Count() == 0)
       { %>
           No existen perfiles disponibles.
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
                <%
               if (Request.IsAuthenticated && Session["data"] != null)
               {
                   MvcHtmlString flag = Html.Action("EsAmigo", "Persona", new {nick = item.Nickname});
                   if (flag.ToString() == "false")
                   {%>
                        <td>
                            <a title="Agregar como amigo" href="<%=Url.Action("AgregarAmigo", "Persona", new {id = item.Nickname}, null)%>">
                                <img src="<%=Url.Content("~/Content/agregar.png")%>" height="25px" width="25px" /></a>
                        </td>
                        <%
                   }
                   else
                   {%>
                        <td>
                            <a title="Eliminar amigo" href="<%=Url.Action("EliminarAmigo", "Persona", new {nick = item.Nickname}, null)%>">
                                <img src="<%=Url.Content("~/Content/eliminar.png")%>" height="25px" width="25px" /></a>
                        </td>
                 <%
                   }
               }%>
            </tr>
    
        <%
           }
       }%>

    </table>

    

</asp:Content>

