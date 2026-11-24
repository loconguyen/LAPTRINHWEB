$(document).on("click", ".loc-sach", function (e) {
    e.preventDefault();
    const ma = $(this).attr("data-ma");
    $.ajax({
        url: this.href,
        type: "GET",
        data: { maTl:ma },
        success: function (result) {
            $("#ds").html(result);
        }

    });
});