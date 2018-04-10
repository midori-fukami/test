var ViewModel = function () {
    var that = this;
    this.Book = ko.observable(null);

    this.SendCommand = function () {
        var form = $('#form1');

        var url;
        var msg;
        if (bookId != null && bookId != "") {
            url = "/api/Book/" + bookId + "/update";
            msg = "Alteração efetuada com sucesso.";
        } else {
            url = "/api/Book/create"
            msg = "Adição efetuada com sucesso."
        }

        $.post(url, form.serialize(), function (data) {
            if (data.result != null) {
                showDialogOK(msg, function () {
                    location.href = "/Book";
                });
            }
            else {
                showDialogOK("Error");
            }
        });
    }


    this.Load = function () {
        if (bookId != null && bookId != "") {
            $.get("/api/book/" + bookId)
                .then(function (book) {
                    if (book != null) {
                        that.Book(book);
                    }
                    else {
                        showDialogOK("Error");
                    }
                }).fail(function () {
                    showDialogOK("Error");
                });
        } else {
            that.Book({
                code: "",
                name: "",
                count:""
            });
        }
    }
};

viewModel = new ViewModel();

$(document).ready(function () {
    ko.applyBindings(viewModel);
    viewModel.Load();
});