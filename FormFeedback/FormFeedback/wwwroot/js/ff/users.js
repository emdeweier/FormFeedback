// Logout
function uLogout() {
    debugger;
    $.ajax({
        "url": "/Home/Logout"
    }).then((result) => {
        window.location.href = '/'
    })
}

var count = 0;
var testEmail = /^([a-zA-Z0-9_.+-])+\@@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;

// Login
function uLogin() {
    debugger;
    var login = new Object();
    login.UserName = $("#username").val();
    login.PasswordHash = $("#password").val();
    if ($("#username").val().trim() == "") {
        $("#login-alert").removeAttr('hidden');
        $("#login-alert").attr("class", "alert alert-danger alert-dismissible");
        $("#login-alert").html('<button type="button" class="close" data-dismiss="alert" aria-hidden="true"' +
            'onclick=uClearAlert();>&times;</button>Please fill username');
    }
    else if ($("#password").val().trim() == "") {
        $("#login-alert").removeAttr('hidden');
        $("#login-alert").attr("class", "alert alert-danger alert-dismissible");
        $("#login-alert").html('<button type="button" class="close" data-dismiss="alert" aria-hidden="true"' +
            'onclick=uClearAlert();>&times;</button>Please fill password');
    }
    else {
        $.ajax({
            "url": "/Home/Login",
            "type": "POST",
            "dataType": "json",
            "data": { UserName: login.UserName, PasswordHash: login.PasswordHash, Count: count }
        }).then((result) => {
            debugger;
            if (result.statusCode == 200) {
                window.location.href = '/Questions/'
            }
            else {
                $("#login-alert").removeAttr('hidden');
                $("#login-alert").attr("class", "alert alert-danger alert-dismissible");
                $("#login-alert").html('<button type="button" class="close" data-dismiss="alert" aria-hidden="true"' +
                    'onclick=uCount();>&times;</button>Username / password invalid');
            }
        })
    }
}

// Count Wrong Password
function uCount() {
    count += 1;
    $("#login-alert").removeAttr('class');
    $("#login-alert").html('');
    $("#login-alert").attr('hidden');
    if (count >= 3) {
        $("#login-alert").removeAttr('hidden');
        $("#login-alert").attr("class", "alert alert-danger alert-dismissible");
        $("#login-alert").html('<button type="button" class="close" data-dismiss="alert" aria-hidden="true"' +
            'onclick="window.location = ' + "/LockedAccount/" + '">&times;</button>Your account has been locked');
    }
}

// Clear Screen Login
function fClearScreen() {
    $("#uEmail").val('');
    $("#uSave").show();
    $("#forgot-alert").removeAttr('class');
    $("#forgot-alert").html('');
    $("#forgot-alert").attr('hidden');
}

// Clear Alert Forgot Password
function fClearAlert() {
    $("#forgot-alert").removeAttr('class');
    $("#forgot-alert").html('');
    $("#forgot-alert").attr('hidden');
}

// Clear Alert Login
function uClearAlert() {
    $("#login-alert").removeAttr('class');
    $("#login-alert").html('');
    $("#login-alert").attr('hidden');
}

// Validation Email
function uValidation() {
    var email = $("#uEmail").val();
    if (email.trim() == "") {
        $("#forgot-alert").removeAttr('hidden');
        $("#forgot-alert").attr("class", "alert alert-danger alert-dismissible");
        $("#forgot-alert")
            .html('<button type="button" class="close" data-dismiss="alert" aria-hidden="true" onclick=fClearAlert();>&times;</button><h5>'
                + '<i class="icon fas fa-times"></i> Alert!</h5>Please fill email');
    }
    else if (!testEmail.test(email)) {
        $("#forgot-alert").removeAttr('hidden');
        $("#forgot-alert").attr("class", "alert alert-danger alert-dismissible");
        $("#forgot-alert")
            .html('<button type="button" class="close" data-dismiss="alert" aria-hidden="true" onclick=fClearAlert();>&times;</button><h5>'
                + '<i class="icon fas fa-times"></i> Alert!</h5>Not a valid email');
    }
    else {
        uForgot();
    }
}

// Forgot Password
function uForgot() {
    var forgot = new Object();
    debugger;
    forgot.Email = $("#uEmail").val();
    $.ajax({
        "url": "/Home/ForgotPassword",
        "type": "POST",
        "dataType": "json",
        "data": forgot
    }).then((result) => {
        debugger;
        $("#forgot-alert").removeAttr('hidden');
        $("#forgot-alert").attr("class", "alert alert-success alert-dismissible");
        $("#forgot-alert")
            .html('<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button><h5>'
                + '<i class="icon fas fa-check"></i> Success!</h5>Reset password request has been sent to your email.');
    })
}