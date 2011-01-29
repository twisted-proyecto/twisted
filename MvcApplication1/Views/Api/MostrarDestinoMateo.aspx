<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Destino>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <%if (Model != null)
      {
          foreach (var item in Model)
          {%>
<h2>- Itinerario -</h2>
    <fieldset style=" width:20%; margin-left:6% ">
        <legend>Detalles:</legend>
        <p>
            <b>Direccion:</b>
            <%=Html.Encode(item.Direccion)%>
        </p>
        <p>
            <b>Descripcion:</b>
            <%=Html.Encode(item.Descripcion)%>
        </p>
        
        <p>
            <b>Fecha:</b>
          <%:String.Format("{0:dd/MM/yyyy}", item.Fecha)%>
        </p>
        <p>
            <b>Foto:</b>
            <img src="<%:item.Url%>" height="15%"  alt="" />
        </p>
        
        
    </fieldset>

        <%
          }
      }
      else
      {%>
            <b><%=Html.Encode("No hay Itinerario")%></b>
       <% }%>

</asp:Content>

