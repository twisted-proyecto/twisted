<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/OneColumn.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Viaje>" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="<%:Url.Content("~/Scripts/jquery.loadimages.1.0.1.js") %>"></script>
    <script type="text/javascript">
        $(document).ready(initialiseSettings);
    </script>
    
    <div id="editprofile">
    <ul>
        <li>
            <a href="#tab_profile">Viaje, con sus destinos</a>
        </li>
    </ul>
    <br />
        <table style=" text-align:left">
        <tr>
            <td>
                <h2> Nombre del viaje: <%= Html.Encode(Model.Nombre)%></h2>
            </td>
        </tr>
        <tr>
            <td>
                <h3> Fecha de Inicio: <%= Html.Encode(Model.FechaInicio)%></h3>
            </td>
        </tr>
        <tr>
            <td>
                <h3> Fecha Fin: <%= Html.Encode(Model.FechaFin)%></h3>
            </td>
        </tr>
        <tr>
            <td>
                <h3> Hospedaje: <%= Html.Encode(Model.Hospedaje)%></h3>
            </td>
        </tr>
        <tr>
            <td>
                <h3> Estatus: <%= Html.Encode(Model.Estatus)%></h3>
            </td>
        </tr>
        <tr>
            <td>
                <h3> Privacidad: <%= Html.Encode(Model.Privacidad)%></h3>
            </td>
        </tr>
        </table>
                      
         <% foreach (var destino in Model.Destinos)
            {%>
            <table style=" text-align:left">
        <tr>
            <td>
                <img src="<%:destino.Url%>" alt="" />
                <h5>Foto Referencial.</h5>
            </td>
        </tr>
        <tr>
            <td>
                <h2> Nombre: <%=Html.Encode(destino.Nombre)%></h2>
            </td>
        </tr>
        <tr>
            <td>
                <h3> Descripcion: <%=Html.Encode(destino.Descripcion)%></h3>
            </td>
        </tr>
        <tr>
            <td>
                <h3> Direccion: <%=Html.Encode(destino.Direccion)%></h3>
            </td>
        </tr>
        <tr>
            <td>
                <h3> Latitud: <%=Html.Encode(destino.Latitud)%></h3>
            </td>
        </tr>
        <tr>
            <td>
                <h3> Longitud: <%=Html.Encode(destino.Longitud)%></h3>
            </td>
        </tr>
        </table>
                <br />
                <br />
            <%
            } %>
    </div>
</asp:Content>

