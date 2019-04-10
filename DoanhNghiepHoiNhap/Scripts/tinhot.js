var vtTinMoi = -1;
var SoTinMoi;
$(document).ready(function () {
    $("div.baidinh_item").css('display', 'none');
    $("div.baidinh_item:first").css('display', 'block');
    $("div.baidinh_item:first").addClass("thActive");
    SoTinMoi = $("div.baidinh_item").size();
    var i = 0;
    for (i = 0; i < SoTinMoi; i++) {
        $('.number_top1').append("<a href='javascript:void(null);' onclick='hienthi(" + i + ")'>" + (i + 1) + "</a>");
    }
    $('.number_top1 a:first').addClass('active');
    setInterval("thayTinMoi()", 7000);
});
function thayTinMoi() {
    if (vtTinMoi < SoTinMoi-1) {
        vtTinMoi = vtTinMoi + 1;
        hienthi(vtTinMoi);
    } else {
        vtTinMoi = 0;
        hienthi(vtTinMoi);
    }
}
function hienthi(vt) {
    vtTinMoi = vt;
    $("div.baidinh_item").css('display', 'none');
    $("div.baidinh_item:eq(" + vt + ")").css('display', 'block');
    $('.number_top1 a.active').removeClass('active');
    $('.number_top1 a:eq(' + vt + ')').addClass('active');
}