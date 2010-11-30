<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master"  Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Twiteand
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <h2>Twitter</h2>
                   
                

               <h2><%: ViewData["XML"] %></h2>
                                 
                 <p>
                    <input type="submit" value="Registrarse" />
                    
                
                </p>
    </form>
</asp:Content>
