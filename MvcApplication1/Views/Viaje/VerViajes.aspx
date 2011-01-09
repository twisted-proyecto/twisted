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
    <h2>- Gestion de Viajes -</h2>
    <% if (Model.Count() == 0)
       { %>
           No participas en ningun Viaje.
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
           {%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Editar", "Edit", new {id = item.IdViaje})%> |
                
               
 
            </td>
            <td>
                <%=Html.Encode(item.Nombre)%>
            </td>
            <td>
                <%: String.Format("{0:dd/MM/yyyy}", item.FechaInicio)%>
            </td>
            <td>
                <%=Html.ActionLink("Eliminar", "Delete", new {id = item.IdViaje})%>
            </td>
            <td>
                <%=Html.ActionLink("Destinos", "Index", "Destino", new {idViaje = item.IdViaje}, null)%>
            </td>
            <td>
           <details>Detalles</details>

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
    </fieldset></div>

            </td>

        </tr>
    
    <%
           }
       }%>

    </table>

    <p>
        <%= Html.ActionLink("Agregar nuevo viaje", "Create") %>
    </p>
    <script>
        $(document).ready(function () {

            $("details").tooltip({ offset: [150, 170], effect: 'slide' });
        });
    </script>
</asp:Content>
