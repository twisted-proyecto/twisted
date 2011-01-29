<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Destino>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <%
        if (Model != null)
        {
%>
<h2>- Viaje -</h2>
    <fieldset>
        <legend>viajes del Usuario:</legend>
         
              
        <%
            foreach (var item2 in Model)
            {
%>
         <fieldset style=" width:20%; margin-left:6% ">
        <legend >Destino:</legend>

        <p><b>IdViaje:</b><%=Html.Encode(item2.Direccion)%></p>
     
        <p><b>nombre:</b><%=Html.Encode(item2.Descripcion)%></p>

      
           
           
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

