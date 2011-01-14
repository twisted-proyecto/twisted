google.load("maps", "2");

// make a json request to get the map data from the Map action
$(function () {
    if (google.maps.BrowserIsCompatible()) {
        // $.getJSON("http://" + window.location.host + "/Home/Map", initialise);
        var pathArray = window.location.pathname.split('/');
        if ((pathArray[1] != "") && (pathArray[2] != ""))
            $.getJSON("/" + pathArray[1] + "/" + pathArray[2] + "/MapDestino", initialise);
        else
            $.getJSON("/Home/Map", initialise);
    }
});

function initialise(mapData) {
    $("#mapName").text(mapData.Name);
    //var map = new GMap2($("#map")[0]);
    var map = new google.maps.Map2($("#map")[0]);
    map.addControl(new google.maps.SmallMapControl());
    map.addControl(new google.maps.MapTypeControl());
    var lsc = new google.maps.LocalSearch();
    map.addControl(new google.maps.LocalSearch());

   map.setMapType(G_SATELLITE_MAP);

   var latlng = new google.maps.LatLng(mapData.LatLng.Latitude, mapData.LatLng.Longitude);
   var zoom = mapData.Zoom;

    map.setCenter(latlng, zoom);
    //var marker = new google.maps.Marker(latlng);
   //map.addOverlay(marker);
   //var point;
 // point = map.getCenter();

    

    // create a local search control and add it to your map
    
    


    $.each(mapData.Locations, function (i, location) {
        setupLocationMarker(map, location);
    });

   // google.maps.Event.addListener(map, "click", function (overlay, point) {
     //   marker.setPoint(point);
     //   map.addOverlay(marker);
     //   marker.openInfoWindowHtml("<div style='font-size: 8pt; font-family: verdana'>Mi marca situada en<br>Latitud: " + point.lat() + "<br>Longitud: " + point.lng() + "</div>");
    //});
}

function setupLocationMarker(map, location) {

    var latlng = new google.maps.LatLng(location.LatLng.Latitude, location.LatLng.Longitude);
    var marker = new google.maps.Marker(latlng);
    map.addOverlay(marker);

    google.maps.Event.addListener(marker, "click", function (latlng) {
     //$("#info").text(location.Name);
        //$("#image")[0].src = location.Image;
        map.openInfoWindow(latlng, ($("<img></img>")[0].text = (location.Name + "<br> <img src=\"" + location.Image + "\"/>")));
    });

}


