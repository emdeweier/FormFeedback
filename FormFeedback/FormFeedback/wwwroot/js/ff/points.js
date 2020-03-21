// Get Points
$(function () {
    debugger;
    var p = $("#points").DataTable({
        "columnDefs": [
            {
                "searchable": false,
                "orderable": false,
                "targets": 0
            },
            {
                "orderable": false,
                "targets": 3
            }
        ],
        "order": [[1, 'asc']]
    });
    p.on('order.dt search.dt', function () {
        p.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1 + ".";
        });
    }).draw();
});

// Clear Screen Input Points
function pClearScreen() {
    document.getElementById("pIdText").disabled = true;
    $("#pIdText").val('');
    $("#pValueText").val('');
    $("#pNoteText").val('');
    $("#pNoteText").trigger('change');
    $("#pUpdate").hide();
    $("#pSave").show();
}

// Validation Input
function pValidation() {
    if ($("#pValueText").val().trim() == "") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Point'
        })
    }
    else if ($("#pNoteText").val() == "null") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Note'
        })
    }
    else if ($("#pIdText").val() == "" || $("#pIdText").val() == " ") {
        pSave();
    }
    else {
        debugger
        pEdit($("#pIdText").val());
    }
}

// Save Point
function pSave() {
    var point = new Object();
    debugger;
    point.Value = $("#pValueText").val();
    point.Note = $("#pNoteText").val();
    $.ajax({
        "url": "/Points/Create",
        "type": "POST",
        "dataType": "json",
        "data": point
    }).then((result) => {
        debugger;
        if (result.statusCode == 200) {
            Swal.fire({
                icon: 'success',
                title: 'Your data has been saved',
                text: 'Success!'
            }).then((hasil) => {
                location.reload();
            });
            $("#pts-modal").modal("hide");
        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'Your data not saved',
                text: 'Failed!'
            })
        }
    })
}

// Get Point Id
function pGetById(id) {
    debugger
    $.ajax({
        "url": "/Points/Get/" + id,
        "type": "GET",
        "dataType": "json",
        "data": { Id: id }
    }).then((result) => {
        debugger
        if (result.data != null) {
            debugger
            document.getElementById("pIdText").disabled = true;
            debugger
            $("#pIdText").val(result.data.id);
            debugger
            $("#pValueText").val(result.data.value);
            $("#pNoteText").val(result.data.note);
            $("#pNoteText").trigger('change');
            debugger
            $("#pts-modal").modal("show");
            $("#pUpdate").show();
            $("#pSave").hide();
        }
    })
}

// Edit Point
function pEdit(id) {
    var point = new Object();
    debugger
    point.Id = $("#pIdText").val();
    debugger
    point.Value = $("#pValueText").val();
    point.Note = $("#pNoteText").val();
    $.ajax({
        "url": "/Points/Edit/",
        "type": "POST",
        "dataType": "json",
        "data": { Id: point.Id, Value: point.Value, Note: point.Note }
    }).then((result) => {
        if (result.statusCode == 200) {
            $("#pts-modal").modal("hide");
            Swal.fire({
                icon: 'success',
                title: 'Your data has been updated',
                text: 'Success!'
            }).then((result) => {
                location.reload();
            });
        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'Your data not updated',
                text: 'Failed!'
            })
        }
    })
}

// Delete Point
function pDelete(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {
            debugger
            $.ajax({
                "url": "/Points/Delete/",
                "dataType": "json",
                "data": { Id: id }
            }).then((hasil) => {
                debugger
                if (hasil.data[0] != 0) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Your data has been deleted',
                        text: 'Deleted!'
                    }).then((result) => {
                        location.reload();
                    });
                }
                else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Your data not deleted',
                        text: 'Failed!'
                    })
                }
            })
        }
    })
}