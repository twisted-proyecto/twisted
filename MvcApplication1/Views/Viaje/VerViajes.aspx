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
        <div>
            <a title="Agregar" href="<%= Url.Action("Create", "Viaje") %>">
                <img src="<%= Url.Content("~/Content/agregar.png") %>" height="25px" width="25px" /></a>
            <%= Html.ActionLink("Agregar nuevo viaje", "Create") %>
        </div>
        </th>
    </table>

    <% if (Model.Count() == 0)
       { %>
           <h3>No participas en ningun Viaje.</h3>
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
           {%>
    <tr>
            <td>
                <details> <a title="Detalles" href="#" rel="#petrol<%= item.IdViaje%>">
                <img src="<%=Url.Content("~/Content/consultar.png")%>" height="25px" width="25px" /></a></details>

                <div class="apple_overlay" id="petrol<%= item.IdViaje%>"><fieldset>
                <legend><h1><b>Detalles:</b></h1></legend>
                    <h2>
                        <b>Nombre:</b>
                        <%= Html.Encode(item.Nombre) %>
                    </h2>
                    <h2>
                        <b>Destino:</b>
                        <%= Html.Encode(item.Destino) %>
                    </h2>
                    <h2>
                        <b>Hospedaje:</b>
                        <%= Html.Encode(item.Hospedaje) %>
                    </h2>
                    <h2>
            
                        <div class="display-field"><b>Fecha Inicio:</b> <%: String.Format("{0:dd/MM/yyyy}", item.FechaInicio)%></div>
                    </h2>
                    <h2>
          
                        <div class="display-field"><b>Fecha Fin:</b> <%: String.Format("{0:dd/MM/yyyy}", item.FechaFin)%></div>
                    </h2>
                    <h2>
                        <b>Privacidad:</b>
                        <%= Html.Encode(item.Privacidad) %>
                    </h>
                </fieldset>
                </div>
            </td>
            <% MvcHtmlString flag = Html.Action("EsMiViajeOParticipo", "Viaje", new {idViaje = item.IdViaje});
               MvcHtmlString flagCerrado = Html.Action("ViajeCerrado", "Viaje", new { idViaje = item.IdViaje });
                    
               if (flag.ToString() == "true")
               {
                   if (flagCerrado.ToString() == "false")
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
                <% }
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

            <% 
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
               {
                   if (flagCerrado.ToString() == "false")
                   {%>
                        <td>
                            <a title="Eliminar" href="<%=Url.Action("Delete", "Viaje", new {id = item.IdViaje}, null)%>">
                                <img src="<%=Url.Content("~/Content/eliminar.png")%>" height="25px" width="25px" /></a>
                        </td>
                    <%
                   }
                   if (flagCerrado.ToString() == "false")
               {%>
            <td>
                <a title="Cerrar Viaje" href="<%=Url.Action("CerrarViaje", "Viaje", new {idViaje = item.IdViaje}, null)%>">
                    <img src="<%=Url.Content("~/Content/cerrarViaje.png")%>" height="37px" width="37px" /></a>
            </td>
            <%
               }
               }%>
        </tr>
    <%
           }
       }%>

    </table>
    <br />
    <script>
        $(function () {
            $("a[rel]").overlay({ mask: '#000', effect: 'apple' });
        });
    </script> 
</asp:Content>
