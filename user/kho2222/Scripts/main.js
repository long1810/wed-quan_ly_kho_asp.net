$(document).ready(function () {

    $("#selectImg").click(function () {
        var f = new CKFinder();
        f.selectActionFunction = function (fileurl) {
            $("#txtimg").val(fileurl);
        };
        f.popup();
    });
}); 