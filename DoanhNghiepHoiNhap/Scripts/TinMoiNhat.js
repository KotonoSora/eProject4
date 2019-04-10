$(document).ready(function () {
    $(".tin_moi_nhat a").animate({ display: "none" });
    $(".tin_moi_nhat a:first").fadeIn(0);
    $(".tin_moi_nhat a:first").addClass("tmnActive"); 
    setInterval("DoiTinMoiNhat()", 7000);
});
function DoiTinMoiNhat() {
    var tag = $(".tin_moi_nhat a.tmnActive");
    tag.fadeOut(100);
    tag.removeClass("tmnActive");
    tag = tag.next();
    if (tag.length == "") {
        tag = $(".tin_moi_nhat a:first");
    }
    tag.fadeIn(100);
    tag.addClass("tmnActive");
} 