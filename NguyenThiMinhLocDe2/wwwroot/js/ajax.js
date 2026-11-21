$(document).on("click", ".loc", function (e) {
    e.preventDefault();
    const maLoai = $(this).attr("data-ma-loai");

    $ajax({
        url: this.href,
        type: "GET",
        data: { maLoai : maLoai },
        success: function (result) {
            $("#danhSachTaiSan").html(result);
        }


    });

});