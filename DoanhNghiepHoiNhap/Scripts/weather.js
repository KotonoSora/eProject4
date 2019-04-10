var oldweather;
function weather(city) {
    $("#" + city).show();
    if (oldweather == null) $("#hn").hide();
    else
    $("#" + oldweather).hide();
    oldweather = city;
}