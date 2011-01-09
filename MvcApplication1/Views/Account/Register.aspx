<%@ Page Language="C#" MasterPageFile="~/Views/Shared/OneColumn.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Html.ActionLink("Home", "index", "home") %> &gt;&gt; Register</h2>
    <p>
        Use the form below to create a new account. 
    </p>
    <br />
    <p>
        Passwords are required to be a minimum of <%: ViewData["PasswordLength"] %> characters in length.
    </p>
    <br />
    <br />
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "Account creation was unsuccessful. Please correct the errors and try again.") %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                <div class="editor-row">
                    <div class="editor-label">
                        <%: Html.LabelFor(m => m.UserName) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(m => m.UserName) %>
                        <%: Html.ValidationMessageFor(m => m.UserName) %>
                    </div>
                </div>        
                <div class="editor-row">
                    <div class="editor-label">
                        <%: Html.LabelFor(m => m.Email) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(m => m.Email) %>
                        <%: Html.ValidationMessageFor(m => m.Email) %>
                    </div>
                </div>        
                <div class="editor-row">
                    <div class="editor-label">
                        <%: Html.LabelFor(m => m.Password) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.PasswordFor(m => m.Password) %>
                        <%: Html.ValidationMessageFor(m => m.Password) %>
                    </div>
                </div>
                 
                <div class="editor-row">
                    <div class="editor-label">
                        <%: Html.LabelFor(m => m.ConfirmPassword) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                        <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                    </div>
                </div>
                <div class="editor-row">
                    <p>
                        <input type="submit" value="Register" />
                    </p>
                </div>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
