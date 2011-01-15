<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Persona>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Invitar a mis Amigos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <table style=" width:700px;">

        <th style=" text-align: left">
            <h2>Gestion de participantes</h2>
        </th>
        <th style=" text-align: right">
        <div>
           <%= Html.ActionLink("Ver lista de participantes", "consultarInvitados", new { idViaje = Session["idViajeInvitado"] })%>
           
        </div>
        </th>
    </table>
    <br />

    <% if (Model.Count() == 0)
       { %>
           No hay amigos que puedas invitar...
       <% }
       else
       {%>
    <table>
        <tr>
        <th></th>
            <th>
                Avatar
            </th>
            <th>
                Nickname
            </th>
            <th>
                Nombre
            </th>
            <th>
                Apellido
            </th>
            <th>
                Fecha de Nac.
            </th>
            <th>
                Email
            </th>
            
        </tr>

    <%
           foreach (var item in Model)
           {%>
    
        <td>
            <td>
                <img alt="avatar" src="<%:Html.GetGravatarUrlEmail(50, item.Email)%>" width="50px" height="50px" />
            </td>
            <td>
                <%:item.Nickname%>
            </td>
            <td>
                <%:item.Nombre%>
            </td>
            <td>
                <%:item.Apellido%>
            </td>
             <td>
                <%:String.Format("{0:dd/MM/yyyy}", item.FechaNacimiento)%>
            </td>
            <td>
                <%:item.Email%>
            </td>
             <td>
               <a title="Invitar amigo" href="<%=Url.Action("InvitarAmigoViaje", "Persona", new {nick = item.Nickname, idViaje = Session["idViajeInvitado"]}, null)%>">
               <img src="<%=Url.Content("~/Content/participantes.png")%>" height="25px" width="25px" /></a>
            </td>
        </td>
    
    <%
           }
       }%>

    </table>

    

</asp:Content>

