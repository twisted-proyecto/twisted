<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Category>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
     <%= Html.HiddenFor(model => model.Id) %>
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Voto) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Voto) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Nickname) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Nickname) %>
                <%= Html.ValidationMessageFor(model => model.Nickname) %>
            </div>

            <div class="editor-label">
                <%= Html.LabelFor(model => model.IdDestino) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.IdDestino) %>
                <%= Html.ValidationMessageFor(model => model.IdDestino) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

