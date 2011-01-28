<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Dominio.Model.Viaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <%
        if (Model != null && Model.Destino !=null)
        {
%>
<h2>- Viaje -</h2>
    <fieldset>
        <legend>Detalles:</legend>
        <p>
            <b>Nombre:</b>
            <%=Html.Encode(Model.Nombre)%>
        </p>
        <p>
            <b>Destino:</b>
            <%=Html.Encode(Model.Destino)%>
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
        <p>
            <b>Privacidad:</b>
            <%=Html.Encode(Model.Privacidad)%>
        </p>
        <b>
            Destinos:
        </b>
       <p></p>
       
        <%
            foreach (var item2 in Model.Destinos)
            {
%>
        <p>

            <b>Destino:</b>
            <p><b>Descripcion:</b><%=Html.Encode(item2.Descripcion)%></p>
                        
           <p><b>Direccion:</b><%=Html.Encode(item2.Direccion)%></p>
           
           <p><b>Fecha:</b><%=String.Format("{0:dd/MM/yyyy}", item2.Fecha)%></p>
           <div></div>
           
            
       </p>
        <%
            }%>
    </fieldset>

    <%
             
        }else
        {%>
            <b><%=Html.Encode("No hay viaje")%></b>
       <% }
%>

</asp:Content>

