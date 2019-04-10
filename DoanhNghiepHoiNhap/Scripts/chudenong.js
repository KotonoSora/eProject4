var n1;
var m1;
var widthImage1; //độ dài 1 bức ảnh
var numImgSlide; //sỐ lượng ảnh 1 lần chạy
var cu;
$(document).ready(function () {
    $("#menu ul li").last().addClass('last_li');
    cu = "box-tigia";
    var i = 0;
    widthImage1 = 153;
    numImgSlide = 4;
    m1 = 1;
    n1 = $("#Truot1 .contentsLide").size();
    if (n1 % numImgSlide != 0) {
        n1 = n1 / numImgSlide + 1;
    }
    else {
        n1 = n1 / numImgSlide + 1;
    }
    for (i = 1; i < n1; i++) {
        $('<a href="javascript:DkSlideTo(' + i + ');" onclick="javascript:dieukhienOnclick(' + i + ')">' + i + '</a>').appendTo('#SlideShow1 .dieukhien');
    }
    $('#SlideShow1 .dieukhien a:first').addClass('active');
    $('#SlideShow1 .dieukhien a').click(function () {
        $('#SlideShow1 .dieukhien .active').removeClass('active');
        $(this).addClass('active');
    });
    i = 0;
    var tagImg = $("#Truot1 .contentsLide:first");
    while (tagImg.length != "") {
        tagImg.css("left", "" + (i * (widthImage1)) + "px");
        i++;
        tagImg = tagImg.next();
    }
    setInterval("ChayslideTien(1)", 15000);
});
function ChayslideTien(a) {
    m1++;
    if (m1 >= n1) m1 = 1;
    DkSlideTo(m1);
}
function dieukhienOnclick(a) {
    m1 = a;
}
function DkSlideTo(a) {
    var i = 0;
    var tagImg = $("#Truot1 .contentsLide:first");
    while (tagImg.length != "") {
        tagImg.animate({ left: "" + (i * (widthImage1) - numImgSlide * widthImage1 * (a - 1)) + "px" }, 500);
        i++;
        tagImg = tagImg.next();
    }

    i = 1;
    $('#SlideShow1 .dieukhien .active').removeClass('active');
    var taga = $('#SlideShow1 .dieukhien a:first');
    while (i < a) {
        i++;
        taga = taga.next();
    }
    taga.addClass('active');
}