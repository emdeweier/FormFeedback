// Get Rooms
$(function () {
    debugger;
    var r = $("#rooms").DataTable({
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
        "order": [[3, 'asc']]
    })
    r.on('order.dt search.dt', function () {
        r.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1 + ".";
        });
    }).draw();
});

// Clear Screen Input Rooms
function rClearScreen() {
    document.getElementById("rIdText").disabled = true;
    $("#rIdText").val('');
    $("#rValueText").val('');
    $("#rSizeText").val('');
    $("#rFloorText").val('null');
    $("#rFloorText").trigger('change');
    $("#rUpdate").hide();
    $("#rSave").show();
}

// Validation Input
function rValidation() {
    if ($("#rValueText").val().trim() == "") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Room Name'
        })
    }
    else if ($("#rFloorText").val() == "null") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Floor'
        })
    }
    else if ($("#rIdText").val() == "" || $("#rIdText").val() == " ") {
        rSave();
    }
    else {
        debugger
        rEdit($("#rIdText").val());
    }
}

// Save Rooms
function rSave() {
    debugger;
    var room = new Object();
    room.Name = $("#rValueText").val();
    room.Size = $("#rSizeText").val();
    room.Floor = $("#rFloorText").val();
    $.ajax({
        "url": "/Rooms/Create",
        "type": "POST",
        "dataType": "json",
        "data": room
    }).then((result) => {
        if (result.statusCode == 200) {
            Swal.fire({
                icon: 'success',
                title: 'Your data has been saved',
                text: 'Success!'
            }).then((hasil) => {
                location.reload();
            });
            $("#rooms-modal").modal("hide");
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

// Get Rooms Id
function rGetById(id) {
    debugger
    $.ajax({
        "url": "/Rooms/Get/" + id,
        "type": "GET",
        "dataType": "json",
        "data": { Id: id }
    }).then((result) => {
        debugger
        if (result.data != null) {
            debugger
            document.getElementById("rIdText").disabled = true;
            debugger
            $("#rIdText").val(result.data.id);
            debugger
            $("#rValueText").val(result.data.name);
            $("#rSizeText").val(result.data.size);
            $("#rFloorText").val(result.data.floor);
            $("#rFloorText").trigger('change');
            debugger
            $("#rooms-modal").modal("show");
            $("#rUpdate").show();
            $("#rSave").hide();
        }
    })
}

// Edit Room
function rEdit(id) {
    var room = new Object();
    debugger
    room.Id = $("#rIdText").val();
    debugger
    room.Name = $("#rValueText").val();
    room.Size = $("#rSizeText").val();
    room.Floor = $("#rFloorText").val();
    $.ajax({
        "url": "/Rooms/Edit/",
        "type": "POST",
        "dataType": "json",
        "data": { Id: room.Id, Name: room.Name, Size: room.Size, Floor: room.Floor }
    }).then((result) => {
        if (result.statusCode == 200) {
            $("#qst-modal").modal("hide");
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

// Delete Room
function rDelete(id) {
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
                "url": "/Rooms/Delete/",
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