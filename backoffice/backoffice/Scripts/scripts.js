function showDialogOK(text) {
    alert(text);
}

function showDialogYesNo(text, itemId, yesCallback) {
    $("#confirm-delete .modal-body").text(text);
    $("#confirm-delete").modal();   

    $('.btn-ok').click(function () {
        yesCallback(true, itemId);
    });
}

function showDialogOK(text, redirectCallback) {
    $("#modal-ok .modal-body").text(text);
    $("#modal-ok").modal(); 
    setTimeout(redirectCallback, 2000);
}

$.ajaxSetup({
    beforeSend: function (xhr, options) {
        if (options.url.startsWith("/api")) {
            options.url = apiUrl + options.url;
        }
    }
})