<%@ Page Title="Insert/Update Category" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Category>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

 <script type="text/javascript" src="../../Scripts/jquery.validate.min.js"></script>
   <script src="../../Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>
   <%= Html.ValidationSummary() %>
   <% Html.EnableClientValidation(); %> 
    <% using (Html.BeginForm("Save","Category",FormMethod.Post)) {%>
    <%= Html.HiddenFor(model => model.Id) %>
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Voto) %>                
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Voto) %>
                <%= Html.ValidationMessageFor(model => model.Voto) %>
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
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

