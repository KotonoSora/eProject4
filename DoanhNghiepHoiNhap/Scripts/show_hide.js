var cu;
function show_div(string) {
    if (cu == string) {
        $("#" + cu).slideUp();
        cu = null;
    }
    else if (cu != string) {
        $("#" + string).slideDown();
        $("#" + cu).slideUp();
        cu = string;
    }
    else {
        $("#" + string).slideDown();
        cu = string;
    }
}
