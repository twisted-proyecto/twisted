<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Destino>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Gestion de Destino
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script src="http://cdn.jquerytools.org/1.2.5/full/jquery.tools.min.js"></script> 
<style type="text/css">
      @import url("http://www.google.com/uds/css/gsearch.css");
      @import url("http://www.google.com/uds/solutions/localsearch/gmlocalsearch.css");
    </style>

    <script src="http://www.google.com/uds/api?file=uds.js&v=1.0&key=ABQIAAAAp0Kj6-TRULdy9KWugN_GfxTAdLk6fhpyuNdDdRr81ySzv4W5CRSHcX_iuexOywKZQSEdjN-rXx8BAA" type="text/javascript"></script>
    <script src="http://www.google.com/jsapi?key=ABQIAAAAp0Kj6-TRULdy9KWugN_GfxTAdLk6fhpyuNdDdRr81ySzv4W5CRSHcX_iuexOywKZQSEdjN-rXx8BAA" type="text/javascript"></script>
    <script src="../../MvcApplication1/Scripts/DestinosMap.js" type="text/javascript" ></script>
    <script src="http://www.google.com/uds/solutions/localsearch/gmlocalsearch.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../../MvcApplication1/Content/style.css">

    <table style=" width:700px;">
        <th style=" text-align: left">
        <h2>Gestion de Destinos</h2>
        </th>
        <th style=" text-align: right">
        <% if (Request.IsAuthenticated && this.Session["data"]!= null)
        { 
            MvcHtmlString flag = Html.Action("EsMiViajeOParticipo", "Viaje", new {idViaje = Request["idViaje"]});
            if (flag.ToString() == "true")
            {%>
                <p>
                    <a title="Agregar" href="<%=Url.Action("Create", "Destino", new {idViaje = ViewData["idViaje"]})%>">
                      <img src="<%=Url.Content("~/Content/agregar.png")%>" height="25px" width="25px" /></a>
                    <%= Html.ActionLink("Agregar nuevo destino", "Create", new {idViaje = ViewData["idViaje"]})%>
                </p>
                <%
            }
        } %>
        </th>
    </table>
 
    <% if (Model.Count() == 0)
       { %>
           No existe ningun Destino para el viaje.
       <% }
       else
       {%>
    <h2 id="mapName"></h2>
    <div id="map" style="width : 700px; height : 400px;"></div> 
    
    <table>
        <tr>
        <% MvcHtmlString flag = Html.Action("EsMiViajeOParticipo", "Viaje", new {idViaje = Request["idViaje"]});
           MvcHtmlString flagCerrado = Html.Action("ViajeCerrado", "Viaje", new { idViaje = Request["idViaje"] });
           if (flag.ToString() == "true")
           { %>
            <th></th>
            <%
           }%>
            <th></th>
            <th>
                Nombre
            </th>
            <th>
                Fecha tentativa
            </th>
            <th>
                # Votos
            </th>
            <th></th>
        </tr>
    <%
           
           foreach (var item in Model)
           { %>
           <%= Html.Action("setDestinos", "Destino", new {destino = item})%> 
            
        <tr>
            <td>
                <details>
                <a title="Detalles" href="#" rel="#custom<%= item.IdDestino%>">
                  <img src="<%= Url.Content("~/Content/consultar.png") %>" height="25px" width="25px" /></a>   
                </details>
                <div class="apple_overlay" id="custom<%= item.IdDestino%>" >
                <fieldset>
                    <legend><h2><b>Detalles:</b></h2></legend>
                    <h2>
                        <b>Nombre:</b>
                        <%= Html.Encode(item.Nombre) %>
                    </h2>
                    <h2>
                        <b>Descripcion:</b>
                        <%= Html.Encode(item.Descripcion) %>
                    </h2>
                    <h2>
                        <b>Direccion:</b>
                        <%= Html.Encode(item.Direccion) %>
                    </h2>
                    <h2>
            
                        <div class="display-field"><b>Fecha:</b> <%: String.Format("{0:dd/MM/yyyy}", item.Fecha)%></div>
                    </h2>
                    <h2>
                        <img src="<%: item.Url %>" alt="" />
                    </h2>
                </fieldset>
                </div>
            </td>
            <% if (flag.ToString() == "true")
               {%>
            <td>
                <a title="Editar" href="<%=Url.Action("Edit", "Destino", new {id = item.IdDestino, idViaje = ViewData["idViaje"]}, null)%>">
                  <img src="<%=Url.Content("~/Content/editar.png")%>" height="25px" width="25px" /></a>
            </td>
            <%
               }%>
            <td>
                <%=Html.Encode(item.Nombre)%>
            </td>
            <td>
                 <%: String.Format("{0:dd/MM/yyyy}", item.Fecha)%>
            </td>
            <td>
                <%=item.Votos%> 
            </td>
            <% if (flag.ToString() == "true")
               {
                   if (flagCerrado.ToString() == "false")
                   {%>
                        <td>
                            <a title="Eliminar" href="<%=Url.Action("Delete", "Destino",
                                                    new {id = item.IdDestino, idViaje = ViewData["idViaje"]}, null)%>">
                              <img src="<%=Url.Content("~/Content/eliminar.png")%>" height="25px" width="25px" /></a>
                        </td>
                    <%
                   }
                   MvcHtmlString flagVoto = Html.Action("YaHiceUnVoto", "Destino", new {idDestino = item.IdDestino});
                   if (flagVoto.ToString() == "false")
                   { %>
                        <td>
                            <a title="Votar" href="<%=Url.Action("AgregarVoto", "Destino", new {id2 = item.IdDestino}, null)%>">
                                <img src="<%=Url.Content("~/Content/votar.png")%>" height="33px" width="33px" /></a>
                        </td>                       
                 <%
                   }
                   Session["idViaje"] = Request["idViaje"];
                   %>
                   <td>
                    <details> <a title="Comentar" href="#" rel="#petrol<%= item.IdDestino%>">
                    <img src="<%=Url.Content("~/Content/comentario.png")%>" height="25px" width="25px" /></a></details>
                   </td>
                    <div class="apple_overlay" id="petrol<%= item.IdDestino%>">
                    <% using (Html.BeginForm())
                       { %>
                    <fieldset>
                    <legend><h2><b>Haz tu comentario:</b></h2></legend>
                 
                        <div class="editor-label">
                            <label for="Nombre">Comentario:</label>
                        </div>
                        <div class="editor-field">
                            <%= Html.TextBox("comentario",null, new { @class = "text-box" })%>
                        </div>
                        <div class="editor-field">
                            <input type="hidden" name="idDestino" value="<%= item.IdDestino %>" />
                        </div>
                        <div class="editor-label">
                            <input type="submit" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only ui-state-hover" value="Agregar" />
                        </div>
                    </fieldset>
                    <%
                        foreach (var comentarios in item.Comentarios)
                        {%>
                       <fieldset>
                       <legend><h2><b>Comentarios:</b></h2></legend>
                       <div class="editor-field">
                            <%= Html.Label(comentarios.Nickname +": "+comentarios.Descripcion)%>
                        </div>
                       </fieldset>
                 
                    
                    <%
                        }
                       } %>
                <% }%>
        </tr>
    
    <%
           }
       }%>

    </table>
    <script>
        $(function () {
            $("a[rel]").overlay({ mask: '#000', effect: 'apple' });
        });
    </script> 
</asp:Content>