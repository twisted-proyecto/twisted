<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Destino>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Gestion de Destino
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script src="http://cdn.jquerytools.org/1.2.5/full/jquery.tools.min.js"></script> 
<style>
    .tooltip {
	
	border:1px solid #fff;
	padding:10px 15px;
	width:300px;
	display:none;
	
	text-align:center;
	font-size:12px;
	background-color:White;

	/* outline radius for mozilla/firefox only */
	-moz-box-shadow:0 0 10px #000;
	-webkit-box-shadow:0 0 10px #000;
}
</style>

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
                  <img src="<%= Url.Content("~/Content/editar.png") %>" height="25px" width="25px" /></a>
                
                <a title="Eliminar" href="<%= Url.Action("Delete", "Destino", new {id = item.IdDestino, idViaje = ViewData["idViaje"]}, null) %>">
                  <img src="<%= Url.Content("~/Content/eliminar.png") %>" height="25px" width="25px" /></a>
            </td>
            <td>
                <%=Html.Encode(item.Nombre)%>
            </td>
            <td>
                 <%: String.Format("{0:dd/MM/yyyy}", item.Fecha)%>
            </td>
            <td>
                <details>
                <a title="Detalles" href="#">
                  <img src="<%= Url.Content("~/Content/consultar.png") %>" height="25px" width="25px" /></a>   
                </details>
                <div class="tooltip"><fieldset>
                <legend>Detalles:</legend>
                    <p>
                        Nombre:
                        <%= Html.Encode(item.Nombre) %>
                    </p>
                    <p>
                        Descripcion:
                        <%= Html.Encode(item.Descripcion) %>
                    </p>
                    <p>
                        Direccion:
                        <%= Html.Encode(item.Direccion) %>
                    </p>
                    <p>
                        Estatus:
                        <%= Html.Encode(item.Estatus) %>
                    </p>
                    <p>
            
                        <div class="display-field">Fecha: <%: String.Format("{0:dd/MM/yyyy}", item.Fecha)%></div>
                    </p>
                    <p>
                        Latitud:
                        <%= Html.Encode(item.Latitud) %>
                    </p>
                    <p>
                        Longitud:
                        <%= Html.Encode(item.Longitud) %>
                    </p>
                    <p>
                        Foto referencial:
                        <img src="<%: item.Url %>" alt="" />
                    </p>
                </fieldset>
                </div>
            </td>
        </tr>
    
    <%
           }
       }%>

    </table>
    <% if (Request.IsAuthenticated && this.Session["data"]!= null)
       { %>
    <p>
        <a title="Agregar" href="<%= Url.Action("Create", "Destino", new { idViaje = ViewData["idViaje"] }) %>">
          <img src="<%= Url.Content("~/Content/agregar.png") %>" height="25px" width="25px" /></a>
        <%= Html.ActionLink("Agregar nuevo destino", "Create", new { idViaje = ViewData["idViaje"] })%>
    </p>
    <%     
       }%>
    <script>
        $(document).ready(function () {
            $("details").tooltip({ offset: [90, 20], effect: 'slide' });
        });
    </script>
</asp:Content>