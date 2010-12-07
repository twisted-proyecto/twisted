<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Viaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
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

    <h2>- Gestion de Viajes -</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Editar Viaje:</legend>
            <p>
            <div class="editor-label">
                <label for="Nombre">Nombre:</label>
            </div>
            <%= Html.TextBox("Nombre") %>
            <%= Html.ValidationMessage("Nombre", "*") %>
            </p>
            <p>
                <div class="editor-label">
                    <label for="Privacidad"> Privacidad:</label>
                </div>
                <%= Html.DropDownList("Privacidad") %>
                <%= Html.ValidationMessage("Privacidad", "*") %>
            </p>
            <p>
                <div class="editor-label">
                    <label for="fechaInicio"> Fecha inicio:</label>
                </div>
                <%= Html.TextBox("fechaInicio")%>
                <%= Html.ValidationMessage("fechaInicio", "*") %>
            </p>
            <p>
                <div class="editor-label">
                    <label for="fechaFin"> Fecha fin:</label>
                </div>
                <%= Html.TextBox("fechaFin")%>
                <%= Html.ValidationMessage("fechaFin", "*") %>
            </p>
            <p>
                <div class="editor-label">
                    <label for="Hospedaje"> Hospedaje:</label>
                </div>
                <%= Html.TextBox("Hospedaje") %>
                <%= Html.ValidationMessage("Hospedaje", "*") %>
            </p>
            <p>
                <div class="editor-label">
                    <label for="Destino"> Destino:</label>
                </div>
                <%= Html.TextBox("Destino") %>
                <%= Html.ValidationMessage("Destino", "*") %>
            </p>
            <p>
                <input type="submit" value="Actualizar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Regresar a la lista", "Index") %>
    </div>

</asp:Content>

