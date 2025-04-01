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
                for (var i = 0; i < data.length; i++) {
                    var employee = data[i];

                    var li = $("<li />", {
                        text: employee.person.name + " -- " + employee.department + " -- " + employee.salary,
                    });

                    $("#employee-list").append(li)
                }
            }
        });
    });
});