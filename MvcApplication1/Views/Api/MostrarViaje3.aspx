<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Viaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <%if (Model != null && Model.Hospedaje !=null)
        {%>
<h2>- Viajes -</h2>
    <fieldset>
        <legend>Detalles:</legend>
        <p>
            <b>Id Viaje:</b>
            <%=Html.Encode(Model.IdViaje)%>
        </p>
        <p>
            <b>Hospedaje:</b>
            <%=Html.Encode(Model.Hospedaje)%>
        </p>
       
        <p>
            <b>Fecha Inicio:</b>
          <%:String.Format("{0:dd/MM/yyyy}", Model.FechaInicio)%>
        </p>
        <p>
            <b>Fecha Fin:</b>
           <%:String.Format("{0:dd/MM/yyyy}", Model.FechaFin)%>
        </p>
    </fieldset>

        <%}else{%>
            <b><%=Html.Encode("No hay viaje")%></b>
       <% }
%>

</asp:Content>

