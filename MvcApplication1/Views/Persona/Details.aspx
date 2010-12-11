<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Persona>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Nickname:</div>
        <div class="display-field"><%: Model.Nickname %></div>

        <div class="display-label">Nombre:</div>
        <div class="display-field"><%: Model.Nombre %></div>

        <div class="display-label">Apellido:</div>
        <div class="display-field"><%: Model.Apellido %></div>

        <div class="display-label">Fecha de Nacimiento</div>
        <div class="display-field"><%: String.Format("{0:dd/MM/yyyy}", Model.FechaNacimiento)%></div>
        
        <div class="display-label">Email:</div>
        <div class="display-field"><%: Model.Email %></div>
        
        <div class="display-label">Estatus de La Cuenta:</div>
        <div class="display-field"><%: Model.Estatus %></div>
        
        <div class="display-label">Privacidad del Perfil:</div>
        <div class="display-field"><%: Model.Privacidad %></div>
        
        
    </fieldset>
    <p>

    <% if ((this.Session["data"]!=null) &&(this.Session["data"] as string ==Model.Nickname))
                         { %>
                                  <%: Html.ActionLink("Edit", "Edit", new { id=Model.Nickname }) %> |
                      <%}%>
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

