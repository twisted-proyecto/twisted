<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Destino>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Editar Destino
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <script src="../../Scripts/jquery-1.4.3.js"></script>
    <script src="../../Scripts/jquery.ui.core.js"></script>
    <script src="../../Scripts/jquery.ui.datepicker-es.js"></script>
    <script src="../../Scripts/jquery.ui.datepicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#Fecha").datepicker();
        });
	</script>


    
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Editar Destino:</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Nombre) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Nombre) %>
                <%: Html.ValidationMessageFor(model => model.Nombre) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Descripcion) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Descripcion) %>
                <%: Html.ValidationMessageFor(model => model.Descripcion) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Direccion) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Direccion) %>
                <%: Html.ValidationMessageFor(model => model.Direccion) %>
            </div>
                        
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Fecha) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Fecha, String.Format("{0:dd/MM/yyyy}", Model.Fecha))%>
                <%: Html.ValidationMessageFor(model => model.Fecha) %>
            </div>
         
            <div class="editor-field-hidden">
                <%: Html.TextBoxFor(model => model.Latitud)%>
            </div>

            <div class="editor-field-hidden">
                <%: Html.TextBoxFor(model => model.Longitud)%>
            </div>

            <div class="editor-label">
                <input type="submit"  class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only ui-state-hover" value="Modificar" />
            </div>
            
            <div class="editor-field-hidden">
                <%: Html.TextBoxFor(model => model.Estatus)%>
            </div>
            
            <div class="editor-field-hidden">
                <%: Html.TextBoxFor(model => model.Url)%>
            </div>
            
            <div class="editor-field-hidden">
                <%: Html.TextBoxFor(model => model.IdDestino)%>
            </div>

            
        </fieldset>

    <% } %>

    <div>
    <a title="Volver" href="<%= Url.Action("Index", "Destino") %>">
          <img src="<%= Url.Content("~/Content/atras.png") %>" height="25px" width="25px" /></a>
      <%=Html.ActionLink("Volver...", "Index", "Destino", new { idViaje = ViewData["idViaje"] }, null)%>
    </div>

</asp:Content>

