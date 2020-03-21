var dateToday = new Date();

// Get Events
$(function () {
    debugger;
    var e = $("#events").DataTable({
        "columnDefs": [
            {
                "searchable": false,
                "orderable": false,
                "targets": 0
            },
            {
                "orderable": false,
                "targets": 5
            }
        ],
        "order": [[2, 'asc']]
    })
    e.on('order.dt search.dt', function () {
        e.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1 + ".";
        });
    }).draw();
});