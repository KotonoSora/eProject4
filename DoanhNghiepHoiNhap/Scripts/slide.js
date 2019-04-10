var nn;
var mm;
var widthImg;
var stopSlideDoanhNghiep;
var nn2;
var mm2;
var heightImage;
var stopSlideQuangCao;
$(document).ready(function () {
    nn = $("#IdTruot2 a").size();
    mm = 0;
    stopSlideDoanhNghiep = false;
    widthImg = 198;
    $("#IdTruot1").animate({ left: "" + (-widthImg * nn) + "px" }, 0);
    $("#IdTruot2").animate({ left: "0px" }, 0);
    $("#IdTruot3").animate({ left: "" + (widthImg * nn) + "px" }, 0);
    var i = 0;
    var tag1 = $("#contentIdTruot1 a:first");
    var tag2 = $("#contentIdTruot2 a:first");
    var tag3 = $("#contentIdTruot3 a:first");
    while (tag1.length != "") {
        tag1.animate({ left: "" + (i * widthImg) + "px" }, 0);
        tag2.animate({ left: "" + (i * widthImg) + "px" }, 0);
        tag3.animate({ left: "" + (i * widthImg) + "px" }, 0);
        i++;
        tag1 = tag1.next();
        tag2 = tag2.next();
        tag3 = tag3.next();
    }
    setInterval("TienClick()", 2000);


    nn2 = $("#IdTruot21 a").size();
    mm2 = 0;
    stopSlideQuangCao = false;
    heightImage = 90;

    $("#IdTruot21").animate({ top: "0px" }, 0);
    $("#IdTruot22").animate({ top: "" + (heightImage * nn2) + "px" }, 0);
    i = 0;
    var tag21 = $("#contentIdTruot21 a:first");
    var tag22 = $("#contentIdTruot22 a:first");
    while (tag21.length != "") {
        tag21.animate({ top: "" + (i * heightImage) + "px" }, 0);
        tag22.animate({ top: "" + (i * heightImage) + "px" }, 0);
        i++;
        tag21 = tag21.next();
        tag22 = tag22.next();
    }

    setInterval("TienClickQuangCao()", 2000);
});
function TienClickQuangCao() {
    if (!stopSlideQuangCao) {
        mm2++;
        if (mm2 > nn2) {
            mm2 = 0;
            $("#IdTruot21").animate({ top: "0px" }, 0);
            $("#IdTruot22").animate({ top: "" + (heightImage * nn2) + "px" }, 0);
        }
        else {
            $("#IdTruot21").animate({ top: "" + (-heightImage * mm2) + "px" }, 1000);
            $("#IdTruot22").animate({ top: "" + (heightImage * nn2 - heightImage * mm2) + "px" }, 1000);
        }
    }
}

function InitSlide() {
    mm = 0;
    $("#IdTruot1").animate({ left: "" + (-widthImg * nn) + "px" }, 500);
    $("#IdTruot2").animate({ left: "0px" }, 500);
    $("#IdTruot3").animate({ left: "" + (widthImg * nn) + "px" }, 500);
}
function TienClick() {
    if (!stopSlideDoanhNghiep) {
        mm++;
        if (mm > nn - 1) {
            $("#IdTruot1").animate({ left: "" + (-widthImg * nn + widthImg) + "px" }, 0);
            $("#IdTruot2").animate({ left: "" + widthImg + "px" }, 0);
            $("#IdTruot3").animate({ left: "" + (widthImg * nn + widthImg) + "px" }, 0);
            InitSlide();
        }
        else {
            $("#IdTruot1").animate({ left: "" + (-widthImg * nn - widthImg * mm) + "px" }, 500);
            $("#IdTruot2").animate({ left: "" + (-widthImg * mm) + "px" }, 500);
            $("#IdTruot3").animate({ left: "" + (widthImg * nn - widthImg * mm) + "px" }, 500);
        }
    }
}
function LuiClick() {
    if (!stopSlideDoanhNghiep) {
        mm--;
        if (mm < -nn + 1) {
            $("#IdTruot1").animate({ left: "" + (-widthImg * nn - widthImg) + "px" }, 0);
            $("#IdTruot2").animate({ left: "" + (-widthImg) + "px" }, 0);
            $("#IdTruot3").animate({ left: "" + (widthImg * nn - widthImg) + "px" }, 0);
            InitSlide();
        }
        else {
            $("#IdTruot1").animate({ left: "" + (-widthImg * nn - widthImg * mm) + "px" }, 500);
            $("#IdTruot2").animate({ left: "" + (-widthImg * mm) + "px" }, 500);
            $("#IdTruot3").animate({ left: "" + (widthImg * nn - widthImg * mm) + "px" }, 500);
        }
    }
}



function BaoOnMouseHover() {
    stopSlideDoanhNghiep = true;
}
function BaoOnMouseOut() {
    stopSlideDoanhNghiep = false;
}
function BaoOnMouseHover2() {
    stopSlideQuangCao = true;
}
function BaoOnMouseOut2() {
    stopSlideQuangCao = false;
}