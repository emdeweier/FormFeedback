// Get Options
$(function () {
    debugger;
    var o = $("#options").DataTable({
        "columnDefs": [
            {
                "searchable": false,
                "orderable": false,
                "targets": 0
            },
            {
                "orderable": false,
                "targets": 2
            }
        ],
        "order": [[1, 'asc']]
    });
    o.on('order.dt search.dt', function () {
        o.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1 + ".";
        });
    }).draw();
});

// Clear Screen Input Options
function oClearScreen() {
    document.getElementById("oIdText").disabled = true;
    $("#oIdText").val('');
    $("#oValueText").val('');
    $("#oUpdate").hide();
    $("#oSave").show();
}

// Validation Input
function oValidation() {
    if ($("#oValueText").val().trim() == "") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Option'
        })
    }
    else if ($("#oIdText").val() == "" || $("#oIdText").val() == " ") {
        oSave();
    }
    else {
        debugger
        oEdit($("#oIdText").val());
    }
}

// Save Option
function oSave() {
    var option = new Object();
    debugger;
    option.O_Name = $("#oValueText").val();
    $.ajax({
        "url": "/Options/Create",
        "type": "POST",
        "dataType": "json",
        "data": option
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
            $("#opt-modal").modal("hide");
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

// Get Option Id
function oGetById(id) {
    debugger
    $.ajax({
        "url": "/Options/Get/" + id,
        "type": "GET",
        "dataType": "json",
        "data": { Id: id }
    }).then((result) => {
        debugger
        if (result.data != null) {
            debugger
            document.getElementById("oIdText").disabled = true;
            debugger
            $("#oIdText").val(result.data.id);
            debugger
            $("#oValueText").val(result.data.o_Name);
            debugger
            $("#opt-modal").modal("show");
            $("#oUpdate").show();
            $("#oSave").hide();
        }
    })
}

// Edit Option
function oEdit(id) {
    var option = new Object();
    debugger
    option.Id = $("#oIdText").val();
    debugger
    option.O_Name = $("#oValueText").val();
    $.ajax({
        "url": "/Options/Edit/",
        "type": "POST",
        "dataType": "json",
        "data": { Id: option.Id, O_Name: option.O_Name }
    }).then((result) => {
        if (result.statusCode == 200) {
            $("#opt-modal").modal("hide");
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

// Delete Option
function oDelete(id) {
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
                "url": "/Options/Delete/",
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