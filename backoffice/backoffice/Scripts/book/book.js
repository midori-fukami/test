var ViewModel = function () {
    var that = this;
    this.Books = ko.observableArray(new Array());

    this.AddCommand = function () {
        location.href = "/book/create";
    }

    this.EditCommand = function (item) {
        location.href = "/book/create/" + item.id;
    }

    this.DeleteCommand = function (item) {
        showDialogYesNo('Deseja realmente deletar esse Livro?', item.id, function (result, itemId) {
            if (result && item.id == itemId) {
                $.post("/api/Book/delete/" + item.id, function (data) {
                    if (data != null) {
                        if (data) {
                            that.Load();
                            $('#confirm-delete').modal('hide');
                        }
                    }
                    else {
                        showDialogOK("Error");
                    }
                });
            }
        });
    }

    this.Load = function () {
        $.get("/api/Book/list", function (books) {
            if (books != null) {
                that.Books(books);
            }
            else {
                showDialogOK("Error");
            }
        }).fail(function () {
            showDialogOK("Error");
        });

    }
};

viewModel = new ViewModel();

$(document).ready(function () {
    ko.applyBindings(viewModel);
    viewModel.Load();
});