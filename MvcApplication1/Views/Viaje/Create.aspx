<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Viaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Agregar un nuevo Viaje
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Scripts/jquery-1.4.3.js"></script>
    <script src="../../Scripts/jquery.ui.core.js"></script>
    <script src="../../Scripts/jquery.ui.datepicker-es.js"></script>
    <script src="../../Scripts/jquery.ui.datepicker.js"></script>
    <link rel="stylesheet" href="../../Content/jquery-ui-1.8.6.custom.css">
    <script type="text/javascript">
        $(function () {
            $("#fechaInicio").datepicker();
        });
        $(function () {
            $("#fechaFin").datepicker();
        });
	</script>

    <h2>- Gestion de Viajes - </h2>

    <%= Html.ValidationSummary("Ha ocurrido un error. Por favor corrijalos e intente de nuevo.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Crear nuevo Viaje:</legend>
            
            <div class="editor-label">
                <label for="Nombre">Nombre:</label>
            </div>
            <div>
            <%= Html.TextBox("Nombre") %>
            <%= Html.ValidationMessage("Nombre", "*") %>
            </div>
            
            <div class="editor-label">
                <label for="Privacidad"> Privacidad:</label>
            </div>
            <div>
                <%= Html.DropDownList("Privacidad") %>
                <%= Html.ValidationMessage("Privacidad", "*") %>
            </div>

            <div class="editor-label">
                <label for="fechaInicio"> Fecha inicio:</label>
            </div>
            <div>
                <%= Html.TextBox("fechaInicio")%>
                <%= Html.ValidationMessage("fechaInicio", "*") %>
            </div>

            <div class="editor-label">
                <label for="fechaFin"> Fecha fin:</label>
            </div>
            <div>
                <%= Html.TextBox("fechaFin")%>
                <%= Html.ValidationMessage("fechaFin", "*") %>
            </div>
            
            <div class="editor-label">
                <label for="Destino"> Destino:</label>
            </div>
            <div>  
                <%= Html.TextBox("Destino") %>
                <%= Html.ValidationMessage("Destino", "*") %>
            </div>

            <div class="editor-label">
                <label for="Hospedaje"> Hospedaje:</label>
            </div>
            <div>  
                <%= Html.TextBox("Hospedaje") %>
            </div>
            
            <p>
                <input type="submit" value="Aceptar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Volver a la lista", "Index") %>
    </div>

</asp:Content>

