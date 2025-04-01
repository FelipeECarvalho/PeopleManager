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
                data.forEach(function (employee) {
                    var li = $("<li />", {
                        text: employee.person.name + " -- " + employee.department + " -- " + employee.salary,
                    });

                    $("#employee-list").append(li)
                });
            }
        });
    });
});