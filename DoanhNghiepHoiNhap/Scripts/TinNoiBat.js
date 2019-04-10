var $items;
var $index;
$(document).ready(function () {
    $items = $(".tinnoibat_item").size();
    $index = 0;
    LoadTinNoiBat($index);
    setInterval("LoadTinNoiBat()", 5000);
});
function LoadTinNoiBat() {
    $(".tinnoibat_item").css("display", "none");
    for ($i = $index; $i < $index + 3; $i++) {
        $(".tinnoibat_item").eq($i).css("display", "block");
    }
    if ($index < $items - 3)
        $index += 3;
    else $index = 0;
}
function ClickNext() {
    if ($index < $items - 3)
        $index += 3;
    else $index = 0;
    LoadTinNoiBat($index);
}
function ClickPreview() {
    if ($index > 3)
        $index -= 3;
    else $index = 0;
    LoadTinNoiBat($index);
}