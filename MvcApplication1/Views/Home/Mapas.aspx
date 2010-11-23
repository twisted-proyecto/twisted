<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="mapasContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2 id="mapName"></h2>

    <div id="map" style="width : 700px; height : 400px; margin : 0px; padding : 0px; float : left; margin-right:20px;"></div>
    
    <p id="info"></p>

    <div style="clear:both;"></div>

</asp:Content>

