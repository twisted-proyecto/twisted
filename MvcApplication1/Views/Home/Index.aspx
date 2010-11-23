<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2 id="mapName"></h2>

    <div id="map" style="width : 700px; height : 400px; margin : 0px; padding : 0px; float : left; margin-right:20px;"></div>
    
    <h2><%: ViewData["Message"] %>Joe</h2>
    
    <%using (Html.BeginForm())
      {%>
    <div>
    <fieldset>
     <p>
       <label for="Name">Lugar:</label>
       <%= Html.TextBox("Name")%>
     </p>
     <input type="submit" value="Buscar" />
    </fieldset>
    </div>
    <% } %>
    
    <p id="info"></p>
    <div>
     <% for (int i = 0; i < ViewData.Count-1; i++)
        {%>
        <img id="image" src="<%: ViewData["Message"+i] %>" alt=""/>
     <% } %>
     </div>
    <div style="clear:both;"></div>

</asp:Content>

