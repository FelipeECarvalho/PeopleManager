$(function () {
    $("#employee-search").on("keyup", function () {
        $("#employee-list").html("");

        var name = $(this).val();

        if (!name) return;

        $.ajax({
            url: "Employees/GetByName",
            type: "GET",
            data: { name: name },
            contentType: "application/json",
            success: function (data) {
                data.forEach(function (name) {
                    $("#employee-list").append($("<li />", { text: name }))
                });
            }
        });
    });
});