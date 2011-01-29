<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Viaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <%if (Model != null)
        {%>
            

<h2>- Viajes -</h2>
    <fieldset>
        <legend>Viajes del Usuario:</legend>

        <fieldset style=" width:20%; margin-left:5% ">
        <legend >Viaje:</legend>
            <p>
                <b>Id Viaje:</b>
                <%=Html.Encode(Model.Destino)%>
            </p>
            <p>
                <b>Hospedaje:</b>
                <%=Html.Encode(Model.Hospedaje)%>
            </p>        
        </fieldset>
       
       
        
    </fieldset>

        <%
            
        }
      else{%>
            <b><%=Html.Encode("No hay viaje")%></b>
       <% }
%>

</asp:Content>

