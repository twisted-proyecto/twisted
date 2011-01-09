<%@ Page Language="C#" MasterPageFile="~/Views/Shared/OneColumn.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Please enter your username and password. <%: Html.ActionLink("Register", "Register") %> if you don't have an account.
    </p>
    <br />
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.") %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                <div class="editor-row">
                    <div class="editor-label">
                        <%: Html.LabelFor(m => m.UserName) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor( m => m.UserName) %>
                    </div>
                    <%: Html.ValidationFor<MvcApplication1.Models.LogOnModel>(m => m.UserName)%>
                </div>
                <div class="editor-row">
                    <div class="editor-label">
                        <%: Html.LabelFor(m => m.Password) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.PasswordFor(m => m.Password) %>
                    </div>
                    <%: Html.ValidationFor<MvcApplication1.Models.LogOnModel>(m => m.Password)%>
                </div>
                <div class="editor-row">
                <div class="editor-label">
                    <%: Html.CheckBoxFor(m => m.RememberMe) %>
                    <%: Html.LabelFor(m => m.RememberMe) %>
                </div>
                </div>

                <div class="editor-row">
                <div class="editor-label">
                </div>
                    <br />
                    <p>
                        <input type="submit" value="Log On" />
                    </p>
                </div>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
