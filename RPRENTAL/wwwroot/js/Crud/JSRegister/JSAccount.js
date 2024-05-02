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
        $('#reg-email').focus().select();
    });

    $('.btn-forgotpassword').click(function () {
        forgotPassword('/Account/ForgotPassword');
        
    });

    $('.btn-resetpassword').click(function () {
        ResetPassword('/Account/ResetPassword');        
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
    let objData = { Email: email, Password: password };

    $.ajax({
        url: url,
        type: 'POST',
        data: objData,
        success: function (response) {
            if (response.success) {
                if (response.role == 'Admin') {
                    window.location.href = '/Dashboard/Index'
                }
                else {
                    window.location.href = '/Home/Index'
                }
            }
            else {
                showToast('error', response.message)
            }
        },
        error: function (xhr, status, error) {

        }
    });
}


function forgotPassword(url) {
    let objData = {
        Email: $('#forgot-email').val()       
    };

    if (!validateEmail(formData.Email)) {
        $('#email-validation').css('color', 'red').html('Please enter a valid email.');
        return;
    } 

    if ($('#forgotPasswordForm')[0].checkValidity()) {

        $.ajax({
            url: url,
            type: 'POST',
            data: objData,
            success: function (response) {
                if (response.success) {

                    $('#modal-forgot-password').modal('hide');
                    $('#modal-reset-password').modal('show');
                    $('#reset-token').val(response.data);
                    showToast('success', response.message);
                }
                else {
                    showToast('error', response.message)
                }
            },
            error: function (xhr, status, error) {

            }
        });


    }
    else
    {
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
                if (response.success)
                {                         
                    $('#reset-token').val('');   
                    $('#modal-reset-password').modal('hide');                     
                    showToast('success', response.message);                    
                    if (response.role == 'Admin')
                    {
                        window.location.href = '/Dashboard/Index';
                    }
                    window.location.href = '/Home/Index';
                }
                else {
                    showToast('error', response.message);
                    $('#modal-reset-password').modal('show'); 
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
        Email: $('#reg-email').val(),
        Fullname: $('#reg-fullname').val(),
        PhoneNumber: $('#reg-phoneno').val(),
        Password: $('#reg-password').val(),
        ConfirmPassword: $('#reg-confirmpassword').val()       
    };

    if (!validateEmail(formData.Email)) {
        $('#email-validation').css('color', 'red').html('Please enter a valid email.');
        return;
    }

    if ($('#form-add')[0].checkValidity()) {
        
        $.post(url, formData)
            .done(function (response) {            
                if (response.success) {                   
                    window.location.href = '/Home/Index';
                    showToast('success', response.message);
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

function validateEmail(email) {
    let emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email);
}

function logoutUser(url) {
    $.post(url)
        .done(function (response) {
            response.success ? (window.location.href = '/Home/Index') : showToast('error', response.message);
        })
        .fail(function () {
            showToast('error', 'An error occurred. Please try again later.');
        });
}

