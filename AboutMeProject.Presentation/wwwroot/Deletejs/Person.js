
function DeleteEducations(id) {
    var tr = $(event.currentTarget.parentElement.parentElement);
    debugger;
    if (confirm("Are You Sure You Want To Delete?")) {
        $.post("/Education/DeleteEducation/" + id, function (response) {
            toastr.info(response.message, "SuccessAlert", { timeOut: 5000, "closeButton": true, "progressBar": true });
            tr.remove();
        });
    }
};




