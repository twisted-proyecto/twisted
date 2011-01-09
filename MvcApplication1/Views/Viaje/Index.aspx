<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Viaje>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Gestion de Viajes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script src="http://cdn.jquerytools.org/1.2.5/full/jquery.tools.min.js"></script> 
<style>
    .tooltip {
	
	border:1px solid #fff;
	padding:10px 15px;
	width:250px;
	display:none;
	
	text-align:center;
	font-size:12px;
	background-color:White;

	/* outline radius for mozilla/firefox only */
	-moz-box-shadow:0 0 10px #000;
	-webkit-box-shadow:0 0 10px #000;
}
</style>

<h2>Gestion de Viajes</h2>
    <br />
    <% if (Model.Count() == 0)
       { %>
           No pexiste ningun Viaje disponible.
       <% }
    else
       {%>
    <table>
        <tr>
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
                <a title="Editar" href="<%=Url.Action("Edit", "Viaje", new {id = item.IdViaje}, null)%>">
                  <img src="<%=Url.Content("~/Content/editar.png")%>" height="15px" width="15px" /></a>
                |
                <a title="Eliminar" href="<%=Url.Action("Delete", "Viaje", new {id = item.IdViaje}, null)%>">
                    <img src="<%=Url.Content("~/Content/eliminar.png")%>" height="15px" width="15px" /></a>
            </td>
            <td>
                <%=Html.Encode(item.Nombre)%>
            </td>
            <td>
                <%:String.Format("{0:dd/MM/yyyy}", item.FechaInicio)%>
            </td>
            <td>
                <a title="Destinos de este viaje" href="<%=Url.Action("Index", "Destino", new {idViaje = item.IdViaje}, null)%>">
                    <img src="<%=Url.Content("~/Content/destinos.png")%>" height="15px" width="15px" /></a>
            </td>
              <td>
                <details> <a title="Detalles" href="#">
                <img src="<%=Url.Content("~/Content/consultar.png")%>" height="15px" width="15px" /></a></details>

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
        </tr>
   
    <%     
           }
       }%>

    </table>

    <p>
        <a title="Agregar" href="<%= Url.Action("Create", "Viaje") %>">
          <img src="<%= Url.Content("~/Content/agregar.png") %>" height="15px" width="15px" /></a>
        <%= Html.ActionLink("Agregar nuevo viaje", "Create") %>
    </p>
    <script>
        $(document).ready(function () {

            $("details").tooltip({ offset: [30, 10], effect: 'slide' });
        });
    </script>
</asp:Content>

