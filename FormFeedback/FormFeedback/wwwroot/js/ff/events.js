var dateToday = new Date();

// Access instance of plugin
$('#eDateText').datepicker({
    format: "mm/dd/yyyy",
    maxViewMode: 1,
    orientation: "bottom auto",
    keyboardNavigation: false,
    autoclose: true,
    todayHighlight: true,
    startDate: '-0d',
    endDate: '+2m'
});

$('#eStartTimeText').clockpicker({
    placement: 'bottom',
    align: 'left',
    autoclose: true,
    'default': 'now'
});

$('#eEndTimeText').clockpicker({
    placement: 'bottom',
    align: 'left',
    autoclose: true,
    'default': 'now'
});

$("#ePresentatorText").on("change", function(){
  var name = $("#ePresentatorText option:selected").attr("name");

  // pindahkan nilai ke input
  $("#ePresentatorNameText").val(name);
});

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
                "targets": 6
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

// Clear Screen Input Events
function eClearScreen() {
    document.getElementById("eIdText").disabled = true;
    $("#eIdText").val('');
    $("#eValueText").val('');
    $("#eDateText").val('');
    $("#eStartTimeText").val('');
    $("#eEndTimeText").val('');
    $("#eRoomText").val('null');
    $("#eRoomText").trigger('change');
    $("#ePresentatorText").val('null');
    $("#ePresentatorText").trigger('change');
    $("#ePresentatorNameText").val('');
    $("#eUpdate").hide();
    $("#eSave").show();
}

// Validation Input
function eValidation() {
    if ($("#eValueText").val().trim() == "") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Event Name'
        })
    }
    else if ($("#eDateText").val().trim() == "") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Date'
        })
    }
    else if ($("#eStartTimeText").val().trim() == "") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Start Time'
        })
    }
    else if ($("#eEndTimeText").val().trim() == "") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill End Time'
        })
    }
    else if ($("#eRoomText").val() == "null") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Room'
        })
    }
    else if ($("#ePresentatorText").val() == "null") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Presentator'
        })
    }
    else if ($("#eIdText").val() == "" || $("#eIdText").val() == " ") {
        eSave();
    }
    else {
        debugger
        eEdit($("#eIdText").val());
    }
}

// Save Events
function eSave() {
    debugger;
    var event = new Object();
    event.Name = $("#eValueText").val();
    event.Date = $("#eDateText").val();
    event.RoomId = $("#eRoomText").val();
    event.StartTime = $("#eStartTimeText").val();
    event.EndTime = $("#eEndTimeText").val();
    event.PresentatorId = $("#ePresentatorText").val();
    event.PresentatorName = $("#ePresentatorNameText").val();
    $.ajax({
        "url": "/Events/Create",
        "type": "POST",
        "dataType": "json",
        "data": event
    }).then((result) => {
        if (result.statusCode == 200) {
            Swal.fire({
                icon: 'success',
                title: 'Your data has been saved',
                text: 'Success!'
            }).then((hasil) => {
                location.reload();
            });
            $("#evt-modal").modal("hide");
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
function eGetById(id) {
    debugger
    $.ajax({
        "url": "/Events/Get/" + id,
        "type": "GET",
        "dataType": "json",
        "data": { Id: id }
    }).then((result) => {
        debugger
        if (result.data[0] != null) {
            debugger
            document.getElementById("eIdText").disabled = true;
            debugger
            $("#eIdText").val(result.data[0].id);
            debugger
            $("#eValueText").val(result.data[0].name);
            $("#eDateText").val(moment(result.data[0].date).format("DD/MM/YYYY"));
            $("#eStartTimeText").val(moment(result.data[0].startTime).format("HH:mm"));
            $("#eEndTimeText").val(moment(result.data[0].endTime).format("HH:mm"));
            $("#eRoomText").val(result.data[0].roomId);
            $("#eRoomText").trigger('change');
            $("#ePresentatorText").val(result.data[0].presentatorId);
            $("#ePresentatorText").trigger('change');
            $("#ePresentatorNameText").val(result.data[0].presentatorName);
            debugger
            $("#evt-modal").modal("show");
            $("#eUpdate").show();
            $("#eSave").hide();
        }
    })
}

// Edit Room
function eEdit(id) {
    var event = new Object();
    event.Id = $("#eIdText").val();
    event.Name = $("#eValueText").val();
    event.Date = $("#eDateText").val();
    event.RoomId = $("#eRoomText").val();
    event.StartTime = $("#eStartTimeText").val();
    event.EndTime = $("#eEndTimeText").val();
    event.PresentatorId = $("#ePresentatorText").val();
    event.PresentatorName = $("#ePresentatorNameText").val();
    $.ajax({
        "url": "/Events/Edit/",
        "type": "POST",
        "dataType": "json",
        "data": {
            Id: event.Id, Name: event.Name, Date: event.Date, RoomId: event.RoomId, StartTime: event.StartTime,
            EndTime: event.EndTime, PresentatorId: event.PresentatorId, PresentatorName: event.PresentatorName
        }
    }).then((result) => {
        if (result.statusCode == 200) {
            $("#evt-modal").modal("hide");
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
function eDelete(id) {
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
                "url": "/Events/Delete/",
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