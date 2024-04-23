$(document).ready(function () {
    $('.btn-login').click(function () {
        authenticateUser('/Account/Login');
    });

    $('.btn-register').click(function () {
        registerUser('/Account/Register');
    });

    $('.btn-logout').click(function () {
        logoutUser('/Account/Logout');
    });

    $('#modal-login').on('shown.bs.modal', function () {
        $('#email').focus().select();
    });

    $('#modal-register').on('shown.bs.modal', function () {
        $('#remail').focus().select();
    });
});

function showToast(message, type) {
    $('.toaster').text(message).css({
        'display': 'block',
        'background-color': type === 'success' ? '#006400' : 'red',
        'opacity': 1
    }).delay(3000).fadeOut();
}

function authenticateUser(url) {
    var email = $('#email').val();
    var password = $('#password').val();
    var formData = { EMAIL: email, PASSWORD: password };

    $.post(url, formData)
        .done(function (response) {
            response.success ? (window.location.href = '/Home/Index') : showToast(response.message, 'error');
        })
        .fail(function () {
            showToast('An error occurred. Please try again later.', 'error');
        });
}

function registerUser(url) {
    var formData = {
        EMAIL: $('#remail').val(),
        NAME: $('#rfullname').val(),
        PASSWORD: $('#rpassword').val(),
        CONFIRM_PASSWORD: $('#rconfirmpass').val(),
        PHONE_NUMBER: $('#rphoneno').val()
    };

    if (!validateEmail(formData.EMAIL)) {
        $('#email-validation').css('color', 'red').html('Please enter a valid email.');
        return;
    }

    if ($('#form-add')[0].checkValidity()) {
        $.post(url, formData)
            .done(function (response) {
                response.success ? (window.location.href = '/Home/Index') : showToast(response.message, 'error');
            })
            .fail(function () {
                showToast('An error occurred. Please try again later.', 'error');
            });
    } else {
        $('#form-add').addClass('was-validated');
    }
}

function validateEmail(email) {
    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email);
}

function logoutUser(url) {
    $.post(url)
        .done(function (response) {
            response.success ? (window.location.href = '/Home/Index') : showToast(response.message, 'error');
        })
        .fail(function () {
            showToast('An error occurred. Please try again later.', 'error');
        });
}
