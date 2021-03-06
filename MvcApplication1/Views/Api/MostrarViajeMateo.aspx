﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Dominio.Model.Viaje>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <%if (Model != null)
        {
            foreach (var item in Model)
            {%>

<h2>- Viajes -</h2>
    <fieldset style=" width:20%; margin-left:6% ">
        <legend>Detalles:</legend>
        <p>
            <b>Id Viaje:</b>
            <%=Html.Encode(item.IdViaje)%>
        </p>
        <p>
            <b>Hospedaje:</b>
            <%=Html.Encode(item.Hospedaje)%>
        </p>
       
        <p>
            <b>Fecha Inicio:</b>
          <%:String.Format("{0:dd/MM/yyyy}", item.FechaInicio)%>
        </p>
        <p>
            <b>Fecha Fin:</b>
           <%:String.Format("{0:dd/MM/yyyy}", item.FechaFin)%>
        </p>
    </fieldset>

        <%
            }
        }
      else{%>
            <b><%=Html.Encode("No hay viaje")%></b>
       <% }
%>

</asp:Content>

