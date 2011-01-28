<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Destino>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <%if (Model != null && Model.Direccion !=null){%>
<h2>- Itinerario -</h2>
    <fieldset>
        <legend>Detalles:</legend>
        <p>
            <b>Direccion:</b>
            <%=Html.Encode(Model.Direccion)%>
        </p>
        <p>
            <b>Descripcion:</b>
            <%=Html.Encode(Model.Descripcion)%>
        </p>
        
        <p>
            <b>Fecha:</b>
          <%:String.Format("{0:dd/MM/yyyy}", Model.Fecha)%>
        </p>
        <p>
            <b>Foto:</b>
          <img src="<%: Model.Url %>" alt="" />
        </p>
        
        
    </fieldset>

        <%}else{%>
            <b><%=Html.Encode("No hay Itinerario")%></b>
       <% }%>

</asp:Content>

