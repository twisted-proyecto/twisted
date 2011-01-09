<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Persona>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Editar Perfil
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Scripts/jquery-1.4.3.js"></script>
    <script src="../../Scripts/jquery.ui.core.js"></script>
    <script src="../../Scripts/jquery.ui.datepicker-es.js"></script>
    <script src="../../Scripts/jquery.ui.datepicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#FechaNacimiento").datepicker();
        });
	</script>
    
    <br />

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Editar Perfil:</legend>
            

              <div class="editor-label">
                <%: Html.LabelFor(model => model.Nombre) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Nombre) %>
                <%: Html.ValidationMessageFor(model => model.Nombre) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Apellido) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Apellido) %>
                <%: Html.ValidationMessageFor(model => model.Apellido) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.FechaNacimiento) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaNacimiento, String.Format("{0:dd/MM/yyyy}", Model.FechaNacimiento))%>
                <%: Html.ValidationMessageFor(model => model.FechaNacimiento) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Email) %>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>
            
            <div class="editor-label">
                <label for="Estatus"> Estatus:</label>
            </div>
            <div class="editor-field">
                <%= Html.DropDownList("Estatus")%>
                <%= Html.ValidationMessage("Estatus", "*")%>
            </div>
                          
            <div class="editor-label">
                <label for="Privacidad"> Privacidad:</label>
            </div>
            <div class="editor-field">
                <%= Html.DropDownList("Privacidad") %>
                <%= Html.ValidationMessage("Privacidad", "*") %>
            </div>
            
            <div class="editor-label">
                <input type="submit" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only ui-state-hover" value="Actualizar" />
            </div>
        </fieldset>

    <% } %>


</asp:Content>

