var map;
var title;
title = '<span style="font-family:\'Roboto\';"><strong>Royal Express</strong></span><br /><span style="font-family:\'Roboto\';">Số 27 Huỳnh Thúc Kháng, Hà Nội<br /></span>Điện thoại: <strong>04 7300 8886</strong><br />';
var infowindow = new google.maps.InfoWindow({ size: new google.maps.Size(150, 50) });
function initialize() {
    var mapOptions = {
        zoom: 16,
        center: new google.maps.LatLng(21.017898, 105.811936),
    };
    var latlng = new google.maps.LatLng(21.017898, 105.811936);
    map = new google.maps.Map(document.getElementById('map-canvas'),
        mapOptions);
    createMarkerMaps(latlng, title);
}
function createMarkerMaps(latlng, html) {

    var contentString = html;
    var marker = new google.maps.Marker({
        position: latlng,
        map: map,
        zIndex: Math.round(latlng.lat() * -100000) << 5
    });

    infowindow.setContent(contentString);
    infowindow.open(map, marker);

    google.maps.event.addListener(marker, 'click', function () {
        infowindow.setContent(contentString);
        infowindow.open(map, marker);
    });
    //    gmarkers.push(marker);
}
google.maps.event.addDomListener(window, 'load', initialize);