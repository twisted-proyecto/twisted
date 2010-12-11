<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Destino>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
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
                <%: Html.TextBoxFor(model => model.Fecha, String.Format("{0:g}", Model.Fecha)) %>
                <%: Html.ValidationMessageFor(model => model.Fecha) %>
            </div>
         
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Latitud) %>
            </div>
            
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Latitud, new { disabled = "disabled" })%>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Longitud) %>
            </div>
            <div class="editor-label-disable">
                <%: Html.TextBoxFor(model => model.Longitud, new { disabled="disabled" })%>
            </div>

            <p>
                <input type="submit" value="Save" />
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

