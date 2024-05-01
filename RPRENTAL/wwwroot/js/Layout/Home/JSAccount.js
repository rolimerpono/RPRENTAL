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

    $('.btn-forgotpassword').click(function () {
        forgotPassword('/Account/ForgotPassword');
        debugger
    });

    $('.btn-resetpassword').click(function () {
        ResetPassword('/Account/ResetPassword');
        debugger
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
  
    let email = $('#email').val();
    let password = $('#password').val();
    let formData = { EMAIL: email, PASSWORD: password };

    $.post(url, formData)
        .done(function (response) {   
            if (response.role  == "ADMIN") {
                response.success ? (window.location.href = '/Dashboard/Index') : showToast(response.message, 'error');
            }
            else {
                response.success ? (window.location.href = '/Home/Index') : showToast(response.message, 'error');
            }
        })
        .fail(function () {
            showToast('error', 'An error occurred. Please try again later.');
        });
}


function forgotPassword(url) {
    let formData = {
        EMAIL: $('#femail').val()       
    };

    if (!validateEmail(formData.EMAIL)) {
        $('#email-validation').css('color', 'red').html('Please enter a valid email.');
        return;
    }
    debugger

    if ($('#forgotPasswordForm')[0].checkValidity()) {
        $.post(url, formData)
            .done(function (response) {
                debugger
               /* response.success ? (window.location.href = '/Home/Index') : showToast(response.message, 'error');*/
                if (response.success) {
                    $('#modal-forgot-password').modal('hide');
                    $('#modal-reset-password').modal('show');
                    debugger
                    $('#reset-token').val(response.data);                   
                }
                else {
                    showToast(response.message, 'error');
                }
            })
            .fail(function () {
                showToast('error', 'An error occurred. Please try again later.');
            });
    } else {
        $('#form-add').addClass('was-validated');
    }
}

function ResetPassword(url) {
    let formData = {
        Email: $('#reset-email').val(),
        Password: $('#reset-password').val(),
        ConfirmPassword: $('#reset-con-password').val(),
        OTP: $('#reset-OTP').val(),
        Token: $('#reset-token').val()
    };

    if (!validateEmail(formData.Email)) {
        $('#email-validation').css('color', 'red').html('Please enter a valid email.');
        return;
    }

    if ($('#resetPasswordForm')[0].checkValidity()) {
        $.post(url, formData)
            .done(function (response) {  
                if (response.success) {
                    $('#reset-token').val('');
                    window.location.href = '/Home/Index'
                }
                else {
                    showToast('error', response.message);
                }                     
            })
            .fail(function () {
                showToast('error', 'An error occurred. Please try again later.');
            });
    } else {
        $('#form-add').addClass('was-validated');
    }
}


function registerUser(url) {
    let formData = {
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
                showToast('error', 'An error occurred. Please try again later.');
            });
    } else {
        $('#form-add').addClass('was-validated');
    }
}

function validateEmail(email) {
    let emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email);
}

function logoutUser(url) {
    $.post(url)
        .done(function (response) {
            response.success ? (window.location.href = '/Home/Index') : showToast(response.message, 'error');
        })
        .fail(function () {
            showToast('error', 'An error occurred. Please try again later.');
        });
}

