<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Destino>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Editar Destino
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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


    <h2>- Gestion de Destinos -</h2>

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
         
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Latitud) %>
            </div>
            
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Latitud)%>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Longitud) %>
            </div>
            <div class="editor-label-disable">
                <%: Html.TextBoxFor(model => model.Longitud)%>
            </div>

            <p>
                <input type="submit" value="Modificar" />
            </p>
            
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
      <%=Html.ActionLink("Volver a la lista", "Index", "Destino", new { idViaje = ViewData["idViaje"] }, null)%>
    </div>

</asp:Content>

