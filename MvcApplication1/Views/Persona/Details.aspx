<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Persona>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Apellido</div>
        <div class="display-field"><%: Model.Apellido %></div>
        
        <div class="display-label">Email</div>
        <div class="display-field"><%: Model.Email %></div>
        
        <div class="display-label">Estatus</div>
        <div class="display-field"><%: Model.Estatus %></div>
        
        <div class="display-label">FechaNacimiento</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.FechaNacimiento) %></div>
        
        <div class="display-label">Nickname</div>
        <div class="display-field"><%: Model.Nickname %></div>
        
        <div class="display-label">Nombre</div>
        <div class="display-field"><%: Model.Nombre %></div>
        
        <div class="display-label">Privacidad</div>
        <div class="display-field"><%: Model.Privacidad %></div>
        
        <div class="display-label">Twitter</div>
        <div class="display-field"><%: Model.Twitter %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

