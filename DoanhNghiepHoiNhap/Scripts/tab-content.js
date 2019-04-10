$(document).ready(function () {
    $("a.tab").click(function () {
        $(".active").removeClass("active");
        $(this).addClass("active");
        $(".content").hide();
        var content_show = $(this).attr("title");
        $("#" + content_show).show();
    });
//    $("a.ctyan").click(function () {
//        $(".cty_an").toggle(300);
//    });
});