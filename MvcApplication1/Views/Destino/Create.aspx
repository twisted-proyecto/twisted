<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Destino>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

   
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
  <h2 id="mapName"></h2>

 <div id="map" style="width : 700px; height : 400px; margin : 0px; padding : 0px; float : left; margin-right:20px;"></div>
    
    <h2><%: ViewData["Message"] %></h2>
    
    <%Html.BeginForm();{%>
    <div>
    <fieldset>
     <p>
       <label for="Name">Lugar:</label>
       <%= Html.TextBox("Name")%>
     </p>
     <input type="submit" value="Buscar" name="Button"/>
    </fieldset>
    </div>
    <% } %>
    
    <p id="info"></p>
    <div>
     <% for (int i = 0; i < ViewData.Count-1; i++)
        {%>
        <img id="image" src="<%: ViewData["Message"+i] %>" alt=""/>
     <% } %>
     </div>
    <div style="clear:both;"></div>
 <script src="../../Scripts/jquery-1.4.3.js"></script>
    <script src="../../Scripts/jquery.ui.core.js"></script>
    <script src="../../Scripts/jquery.ui.datepicker-es.js"></script>
    <script src="../../Scripts/jquery.ui.datepicker.js"></script>
    <link rel="stylesheet" href="../../Content/jquery-ui-1.8.6.custom.css">
    <script type="text/javascript">
        $(function () {
            $("#Fecha").datepicker();
        });
	</script>
      <form id="form1" runat="server">
    <h2>Create</h2>

    <% Html.BeginForm();{%>
        <%: Html.ValidationSummary(true)%>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Descripcion)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Descripcion)%>
                <%: Html.ValidationMessageFor(model => model.Descripcion)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Direccion)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Direccion)%>
                <%: Html.ValidationMessageFor(model => model.Direccion)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Fecha)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Fecha)%>
                <%: Html.ValidationMessageFor(model => model.Fecha)%>
            </div>
            
            <p>
                <input type="submit" value="Agregar Destino" name="Button" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regreso a la lista", "Index") %>
    </div>
      </form>
</asp:Content>

