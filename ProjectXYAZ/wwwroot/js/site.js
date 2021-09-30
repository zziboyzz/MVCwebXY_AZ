// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.
function auto_height(elem) {  /* javascript */
    $(document).ready(function () {
        $('#chatInput').keydown(function () {
            var message = $("#chatInput").val();
            if (event.keyCode == 13) {
                if (message == "") {
                }
                else {
                    //$("#chatBoxShow2").load(location.href + " #chatBoxShow");
                    elem.style.height = "28px";
                    document.getElementById("chatBoxShow2").style.height = "250px";
                    document.getElementById("chatBoxTextArea").style.top = "260px";
                    document.getElementById("chatBoxTextArea").style.height = "28px";
                    document.getElementById("AddDlg").style.top = String(224) + "px";
                        $.ajax({
                            type: "POST",
                            url: "/Home/Thongbao",
                            data: { ms: $('#chatInput').val()},
                            cache: false,
                            success: function (response) {
                                if (response != null) {
                                    $("#chatBoxShow2").load(location.href + " #chatBoxShow");
                                    $("#chatBoxShow2").animate({ scrollTop: $('#chatBoxShow2')[0].scrollHeight }, 1000);

                                } else {
                                    alert("Something went wrong");
                                }
                            },
                            failure: function (response) {
                                alert("Failure");
                            },
                            error: (error) => {
                                console.log(JSON.stringify(error));
                            }
                        });
                }
                $("textarea").val('');
                return false;
            }
        });
    });
    elem.style.height = "1px";
    elem.style.height = (elem.scrollHeight) + "px";
    if (parseInt(elem.style.height) === 28) {
        document.getElementById("chatBoxShow2").style.height = "250px";
        document.getElementById("chatBoxTextArea").style.top = "260px";
        document.getElementById("chatBoxTextArea").style.height = "28px";
        document.getElementById("AddDlg").style.top = String(224) + "px";

    }
    else if (parseInt(elem.style.height) === 52) {
        document.getElementById("chatBoxShow2").style.height = "250px";
        document.getElementById("chatBoxShow2").style.height = String(250 - 24) + "px";
        document.getElementById("chatBoxTextArea").style.top = String(260 - 24) + "px";
        document.getElementById("chatBoxTextArea").style.height = String(28 + 24) + "px";
        document.getElementById("AddDlg").style.top = String(224 - 24) + "px";

    }
    else if (parseInt(elem.style.height) >= 76) {
        document.getElementById("chatBoxShow2").style.height = "250px";
        document.getElementById("chatBoxShow2").style.height = String(250 - 48) + "px";
        document.getElementById("chatBoxTextArea").style.top = String(260 - 48) + "px";
        document.getElementById("chatBoxTextArea").style.height = String(28 + 48) + "px";
        document.getElementById("AddDlg").style.top = String(224 - 48) + "px";
    }
}
//
$(document).ready(function () {
    $("#AddIconBtn").click(function () {
        if ($("#AddDlg").css('display') === 'none') {
            $("#AddDlg").fadeIn();
            $("#FilesIconBtn").fadeOut();
        }
        else {
            $("#AddDlg").fadeOut();
            $("#FilesIconBtn").fadeIn();
        }
    });
    //
});
//
setInterval(function () {
    $("#chatBoxShow2").load(location.href + " #chatBoxShow");
}, 1000);