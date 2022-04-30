function Deletes(id) {
    var tr = $(event.currentTarget.parentElement.parentElement);
    debugger;
    if (confirm("Are You Sure You Want To Delete?")) {
        $.post("/Portfolio/PortfolioDelete/" + id, function (response) {
            toastr.success(response.message, "SuccessAlert", { timeOut: 5000, "closeButton": true, "progressBar": true });
            tr.remove();
        });
    }
};
