// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
let lattitude, longtitude = "" 



if (navigator.geolocation){
    navigator.geolocation.getCurrentPosition(onSucces, onError);
}
else{
    alert("Cannot get your location details.")
}
// Write your JavaScript code.

function onSucces(position){
    lattitude = (position.coords.latitude);
    longtitude = (position.coords.longitude);
    
    initMap()
}
function onError(error){
    if(error.code == 1){
        alert("location services disable")
    }
    else{
        alert("Bug has been happened")
    }
}

let map;



function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {center: {lat:lattitude, lng:longtitude}, zoom:13});
    const marker = new google.maps.Marker({position:{lat:lattitude, lng:longtitude} , map:map, title :"Your location"});
    const marker1 = new google.maps.Marker({position:{lat:41.06693, lng:29.01756} , icon: {url: "http://maps.google.com/mapfiles/ms/icons/blue-dot.png"}, map:map, title :"ZES1 location"});
    const marker2 = new google.maps.Marker({position:{lat:41.0794158485905, lng: 29.02642607165166} , icon: {url: "http://maps.google.com/mapfiles/ms/icons/blue-dot.png"}, map:map, title :"ZES2 location"});
    const marker3 = new google.maps.Marker({position:{lat:41.080594349593866, lng:29.009207109659535} , icon: {url: "http://maps.google.com/mapfiles/ms/icons/blue-dot.png"}, map:map, title :"ZES3 location"});
    const marker4 = new google.maps.Marker({position:{lat:41.078615539606275, lng:29.011425522501483} , icon: {url: "http://maps.google.com/mapfiles/ms/icons/blue-dot.png"}, map:map, title :"ZES4 location"});
    const marker5 = new google.maps.Marker({position:{lat:41.07702687439106, lng:29.01098183993309} , icon: {url: "http://maps.google.com/mapfiles/ms/icons/blue-dot.png"}, map:map, title :"ZES5 location"});
    const marker6 = new google.maps.Marker({position:{lat:41.07920082763812, lng:29.017378263627375} , icon: {url: "http://maps.google.com/mapfiles/ms/icons/blue-dot.png"}, map:map, title :"ZES6 location"});
    const marker7 = new google.maps.Marker({position:{lat:41.01734009827869, lng:28.721903267402578} , icon: {url: "http://maps.google.com/mapfiles/ms/icons/blue-dot.png"}, map:map, title :"ZES7 location"});
    const marker8 = new google.maps.Marker({position:{lat:41.08592560954998, lng:28.901945266903585} , icon: {url: "http://maps.google.com/mapfiles/ms/icons/blue-dot.png"}, map:map, title :"ZES8 location"});
    const marker9 = new google.maps.Marker({position:{lat:41.01593041041637, lng:28.8178161961502} , icon: {url: "http://maps.google.com/mapfiles/ms/icons/blue-dot.png"}, map:map, title :"ZES9 location"});
    const marker10 = new google.maps.Marker({position:{lat:41.05883413134127, lng:28.980726440101126} , icon: {url: "http://maps.google.com/mapfiles/ms/icons/blue-dot.png"}, map:map, title :"ZES10 location"});
}



