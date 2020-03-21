// Get Questions
$(function () {
    debugger;
    var q = $("#questions").DataTable({
        "columnDefs": [
            {
                "searchable": false,
                "orderable": false,
                "targets": 0
            },
            {
                "orderable": false,
                "targets": 4
            }
        ],
        "order": [[1, 'asc']]
    })
    q.on('order.dt search.dt', function () {
        q.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1 + ".";
        });
    }).draw();
});

// Clear Screen Input Questions
function qClearScreen() {
    document.getElementById("qIdText").disabled = true;
    $("#qIdText").val('');
    $("#qValueText").val('');
    $("#qTypeText").val('null');
    $("#qTypeText").trigger('change');
    $("#qOptText").val('null');
    $("#qOptText").trigger('change');
    $("#qUpdate").hide();
    $("#qSave").show();
}

// Validation Input
function qValidation() {
    if ($("#qValueText").val().trim() == "") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Question'
        })
    }
    else if ($("#qTypeText").val() == "null") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Question Type'
        })
    }
    else if ($("#qOptText").val() == "null") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Option'
        })
    }
    else if ($("#qIdText").val() == "" || $("#qIdText").val() == " ") {
        qSave();
    }
    else {
        debugger
        qEdit($("#qIdText").val());
    }
}

// Save Question
function qSave() {
    debugger;
    var question = new Object();
    question.Q_Name = $("#qValueText").val();
    question.Type = $("#qTypeText").val();
    question.optionId = $("#qOptText").val();
    $.ajax({
        "url": "/Questions/Create",
        "type": "POST",
        "dataType": "json",
        "data": question
    }).then((result) => {
        if (result.statusCode == 200) {
            Swal.fire({
                icon: 'success',
                title: 'Your data has been saved',
                text: 'Success!'
            }).then((hasil) => {
                location.reload();
            });
            $("#qst-modal").modal("hide");
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

// Get Question Id
function qGetById(id) {
    debugger
    $.ajax({
        "url": "/Questions/Get/" + id,
        "type": "GET",
        "dataType": "json",
        "data": { Id: id }
    }).then((result) => {
        debugger
        if (result.data != null) {
            debugger
            document.getElementById("qIdText").disabled = true;
            debugger
            $("#qIdText").val(result.data.id);
            debugger
            $("#qValueText").val(result.data.q_Name);
            $("#qTypeText").val(result.data.type);
            $("#qTypeText").trigger('change');
            $("#qOptText").val(result.data.optionId);
            $("#qOptText").trigger('change');
            debugger
            $("#qst-modal").modal("show");
            $("#qUpdate").show();
            $("#qSave").hide();
        }
    })
}

// Edit Question
function qEdit(id) {
    var question = new Object();
    debugger
    question.Id = $("#qIdText").val();
    debugger
    question.Q_Name = $("#qValueText").val();
    question.Type = $("#qTypeText").val();
    question.optionId = $("#qOptText").val();
    $.ajax({
        "url": "/Questions/Edit/",
        "type": "POST",
        "dataType": "json",
        "data": { Id: question.Id, Q_Name: question.Q_Name, Type: question.Type, optionId: question.optionId }
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

// Delete Question
function qDelete(id) {
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
                "url": "/Questions/Delete/",
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

function ExportToPDF() {
    var exportURL = getRootUrl() + "Questions/ExportPDF?type=" + type;
    window.location.href = exportURL;
}

function getRootUrl() {
    return window.location.origin ? window.location.origin + '/' : window.location.protocol + '/' + window.location.host + '/';
}