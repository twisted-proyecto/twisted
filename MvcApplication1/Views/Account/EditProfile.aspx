<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/OneColumn.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.ProfileModel>" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
    <script type="text/javascript" src="<%:Url.Content("~/Scripts/jquery.loadimages.1.0.1.js") %>"></script>
    <script type="text/javascript">
        $(document).ready(initialiseSettings);
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Mi Perfil
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="editprofile">
    <ul>
        <li>
            <a href="#tab_profile">Detalles de usuario</a>
        </li>
    </ul>
    <div id="tab_profile">

    <a title="Volver" href="<%= Url.Action("Edit", "Persona",new {id = this.Session["data"]}) %>">
      <img src="<%= Url.Content("~/Content/editar.png") %>" height="15px" width="15px" /></a>
      <%= Html.ActionLink("Editar Perfil", "Edit", "Persona",new {id = this.Session["data"]},null)%>
    <% using (Html.BeginForm("editprofiledetails", "account"))
       { %>
        <%: Html.ValidationSummary(true, "Error.") %>
        <div class="editor-row">
            <div class="editor-label">
                <%: Html.Label("Fecha de Registro:") %>
            </div>
            <div class="editor-field">
                <%:Html.DisplayFor(m=>m.CreationDate)%>
            </div>
        </div>
        <div class="editor-row">
            <div class="editor-label">
                <%: Html.Label("Avatar:") %>
            </div>
            <div class="editor-field">
                <img alt="avatar" src="<%:Html.GetGravatarUrl(128)%>" width="128px" height="128px" />
            </div>
        </div>
        <div class="editor-row">
            <div class="editor-label">
                <%: Html.Label("Tema:") %>
            </div>
            <div class="editor-field">
                <select name="Theme" id="theme">
                    <%foreach (var theme in (IList<string>)Application["themes"])
                      {%>
                    <% if (theme == Model.Theme)
                       {%>
                    <option selected="selected">
                        <%:theme%></option>
                    <% }
                       else
                       {%>
                    <option>
                        <%:theme%></option>
                    <% }%>
                    <%} %>
                </select>
            </div>
            <br />
            <div id="thememessage" style="font-size:small"> Tema no guardado!</div>
        </div>

        <div class="editor-row">
            <div class="editor-label">
            </div>
            <br />
            <p>
                <input type="submit" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only ui-state-hover" value="Guardar cambios" />
            </p>
        </div>
    <% } %>
        <br />
    </div>

</div>

</asp:Content>
