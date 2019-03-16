$(document).ready(function () {
    $("#btnShowModal").click(function () {
        $("#loginModal").modal('show');
    });

    $("#btnHideModal").click(function () {
        $("#loginModal").modal('hide');
    });
    $("#btnShowConfimartion").click(function () {
        $("#confirmationModal").modal('show');
    });
    $("#btnHideConfirmation").click(function () {
        $("#confirmationModal").modal('hide');
    });
});