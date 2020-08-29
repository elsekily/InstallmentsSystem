$(document).ready(function () {
    var table = $("#clients").DataTable({
        ajax: {
            url: "/api/client",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
            },
            {
                data: "nationalId"
            },
            {
                data: "mobileNumber"
            },
            {
                data: "id"
            }
        ]
    });
});