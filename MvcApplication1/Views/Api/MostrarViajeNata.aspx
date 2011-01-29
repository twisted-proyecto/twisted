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
        <legend>Detalles del Viaje:</legend>
       
        <h2>
            <b>Ciudad:</b>
            <%=Html.Encode(Model.Destino)%>
        </h2>

       
              
        <%
            foreach (var item2 in Model.Destinos)
            {
%>
         <fieldset style=" width:20%; margin-left:6% ">
        <legend >Destino:</legend>

        <p>
            <b>Foto:</b>
            <img src="<%:item2.Url%>" height="15%"  alt="" />
        </p>
     
    
                        
           <p><b>Direccion:</b><%=Html.Encode(item2.Direccion)%></p>
           
           <p><b>Fecha:</b><%=String.Format("{0:dd/MM/yyyy}", item2.Fecha)%></p>
           
           
             </fieldset>
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

