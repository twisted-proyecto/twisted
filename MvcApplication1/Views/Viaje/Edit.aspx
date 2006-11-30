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

    <h2>Editar Viaje</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
            <label for="Nombre">
                Name:</label>
            <%= Html.TextBox("Nombre") %>
            <%= Html.ValidationMessage("Nombre", "*") %>
            </p>
            <p>
                <label for="fechaInicio"> Fecha inicio:</label>
                <%= Html.TextBox("fechaInicio")%>
                <%= Html.ValidationMessage("fechaInicio", "*") %>
            </p>
            <p>
                <label for="fechaFin"> Fecha fin:</label>
                <%= Html.TextBox("fechaFin")%>
                <%= Html.ValidationMessage("fechaFin", "*") %>
            </p>
            <p>
                <label for="Hospedaje">
                    Hospedaje:</label>
                <%= Html.TextBox("Hospedaje") %>
                <%= Html.ValidationMessage("Hospedaje", "*") %>
            </p>
            <p>
                <label for="Destino">
                    Destino:</label>
                <%= Html.TextBox("Destino") %>
                <%= Html.ValidationMessage("Destino", "*") %>
            </p>
            <p>
                <label for="Privacidad">
                    Privacidad:</label>
                <%= Html.TextBox("Privacidad") %>
                <%= Html.ValidationMessage("Privacidad", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

