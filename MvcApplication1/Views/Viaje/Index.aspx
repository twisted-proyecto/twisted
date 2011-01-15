<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Viaje>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Gestion de Viajes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script src="http://cdn.jquerytools.org/1.2.5/full/jquery.tools.min.js"></script> 

    <table style=" width:700px;">
        <th style=" text-align: left">
        <h2> Gestion de Viajes </h2>
        </th>
        <th style=" text-align: right">
        <% if (Request.IsAuthenticated && this.Session["data"]!= null)
       { %>
            <div>
                <a title="Agregar" href="<%= Url.Action("Create", "Viaje") %>">
                  <img src="<%= Url.Content("~/Content/agregar.png") %>" height="25px" width="25px" /></a>
                <%= Html.ActionLink("Agregar nuevo viaje", "Create") %>
            </div>
            <%     
       }%>
        </th>
    </table>
    <br />
    <% if (Model.Count() == 0)
       { %>
           No existe ningun Viaje disponible.
       <% }
    else
       {%>
    <table>
        <tr>
            <th></th>    
            <th></th>
            <th>
                Nombre del Viaje
            </th>
            <th>
                Fecha de Inicio
            </th>
            <th></th>
            <th></th>
        </tr>
    <%
           foreach (var item in Model)
           {
              %>
    
        <tr>
            <td>
                <details> <a title="Detalles" href="#">
                <img src="<%=Url.Content("~/Content/consultar.png")%>" height="25px" width="25px" /></a></details>

                <div class="tooltip"><fieldset>
                <legend>Detalles:</legend>
                    <p>
                        Nombre:
                        <%= Html.Encode(item.Nombre) %>
                    </p>
                    <p>
                        Destino:
                        <%= Html.Encode(item.Destino) %>
                    </p>
                    <p>
                        Hospedaje:
                        <%= Html.Encode(item.Hospedaje) %>
                    </p>
                    <p>
            
                        <div class="display-field">Fecha Inicio: <%: String.Format("{0:dd/MM/yyyy}", item.FechaInicio)%></div>
                    </p>
                    <p>
          
                        <div class="display-field">Fecha Fin: <%: String.Format("{0:dd/MM/yyyy}", item.FechaFin)%></div>
                    </p>
                    <p>
                        Privacidad:
                        <%= Html.Encode(item.Privacidad) %>
                    </p>
                </fieldset>
                </div>
            </td>
            <% MvcHtmlString flag = Html.Action("EsMiViajeOParticipo", "Viaje", new {idViaje = item.IdViaje});
               if (flag.ToString() == "true")
               {%>
            <td>
                <a title="Editar" href="<%=Url.Action("Edit", "Viaje", new {id = item.IdViaje}, null)%>">
                  <img src="<%=Url.Content("~/Content/editar.png")%>" height="25px" width="25px" /></a>
            </td>
            <%
               }
               else
               { %>
                  <td></td>
            <% }%>
            <td>
                <%=Html.Encode(item.Nombre)%>
            </td>
            <td>
                <%:String.Format("{0:dd/MM/yyyy}", item.FechaInicio)%>
            </td>

            <% MvcHtmlString flagCerrado = Html.Action("ViajeCerrado", "Viaje", new { idViaje = item.IdViaje });
            if (flagCerrado.ToString() == "false")
            { %>
            <td>
                <a title="Destinos de este viaje" href="<%=Url.Action("Index", "Destino", new {idViaje = item.IdViaje}, null)%>">
                    <img src="<%=Url.Content("~/Content/destinos.png")%>" height="23px" width="23px" /></a>
            </td>
            <%
            }
            else
            { %>
            <td>
                <a title="Mostrar Itinerario" href="<%=Url.Action("ViajeDestinosReporte", "Viaje", new {idViaje = item.IdViaje}, null)%>">
                    <img src="<%=Url.Content("~/Content/itinerario.png")%>" height="23px" width="23px" /></a>
            </td>
         <% }%>
            <% MvcHtmlString flagDuenio = Html.Action("EsMiViaje", "Viaje", new { idViaje = item.IdViaje });
               if (flagDuenio.ToString() == "true")
               {%>
            <td>
                <a title="Eliminar" href="<%=Url.Action("Delete", "Viaje", new {id = item.IdViaje}, null)%>">
                    <img src="<%=Url.Content("~/Content/eliminar.png")%>" height="25px" width="25px" /></a>
            </td>
            <% if (flagCerrado.ToString() == "false")
               {%>
            <td>
                <a title="Cerrar Viaje" href="<%=Url.Action("CerrarViaje", "Viaje", new {idViaje = item.IdViaje}, null)%>">
                    <img src="<%=Url.Content("~/Content/cerrar.png")%>" height="37px" width="37px" /></a>
            </td>
            <%
               }
               }%>
        </tr>
   
    <%     
           }
       }%>

    </table>
    <script>
        $(document).ready(function () {
            $("details").tooltip({ offset: [30, -330], effect: 'slide' });
        });
    </script>
</asp:Content>

