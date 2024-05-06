$(document).ready(function () {
    $('.btn-login').click(function () {
        LoginUser('/Account/Login');
    });

    $('.btn-register').click(function () {      
        
        RegisterUser('/Account/Register');
    });

    $('.btn-logout').click(function () {
        LogoutUser('/Account/Logout');
    });

    $('#modal-login').on('shown.bs.modal', function () {
        $('#email').focus().select();
    });

    $('#modal-register').on('shown.bs.modal', function () {      
        $('#reg-email').focus().select();
    });

    $('.btn-forgotpassword').click(function () {
        ForgotPassword('/Account/ForgotPassword');
        
    });

    $('.btn-resetpassword').click(function () {
        ResetPassword('/Account/ResetPassword');        
    });   


});

function LoginUser(url) {

    let email = $('#email').val();
    let password = $('#password').val();
    let data = { Email: email, Password: password };

    $.ajax({
        url: url,
        type: 'POST',
        data: data,
        success: function (response) {
            if (response.success) {
                localStorage.setItem('loginTriggered', true);

                 if (response.role == 'Admin') {
                    window.location.href = '/Dashboard/Index';   
                }
                else {
                    window.location.href = '/Home/Index'
                }              
              
            }
            else {
              
                ShowToaster('error', 'LOGIN USER', response.message);
            }
        },
        error: function (xhr, status, error) {
            ShowToaster('error', 'LOGIN USER', response.message);
        }
    });
}

function LogoutUser(url) {

    $.ajax({
        url: url,
        type: 'POST',

        success: function (response) {
            if (response.success) {
                localStorage.setItem('logoutTriggered', true);
                window.location.href = '/Home/Index';
            }
            else {
                ShowToaster('error', 'LOGOUT USER', response.message);
            }
        },
        error: function (xhr, status, error) {
            ShowToaster('error', 'LOGOUT USER', error);
        }
    });
}


function ForgotPassword(url) {
    
    let data = {
        Email: $('#forgot-email').val()       
    };
  
    ValidateEmail(data.Email);
    
    let is_true = false;

    is_true = IsFieldValid('#forgotPasswordForm');

    if (!is_true) {
        return;
    }

    
    $.ajax({
        url: url,
        type: 'POST',
        data: data,
        success: function (response) {
            if (response.success) {
               
                HideModal('#modal-forgot-password');
                $('#modal-reset-password').modal('show');
                $('#reset-token').val(response.data);               
                ShowToaster('success', 'FORGOT PASSWORD', response.message);
            }
            else {            
                ShowToaster('error', 'FORGOT PASSWORD', response.message);
            }
        },
        error: function (xhr, status, error) {
            ShowToaster('error', 'FORGOT PASSWORD', response.message);
        }
    });
 
}

function ResetPassword(url) {

   let data = {
        Email: $('#reset-email').val(),
        Password: $('#reset-password').val(),
        ConfirmPassword: $('#reset-con-password').val(),
        OTP: $('#reset-OTP').val(),
        Token: $('#reset-token').val()
    };

    ValidateEmail(data.Email);

    let is_true = false;

    is_true = IsFieldValid('#forgotPasswordForm');

    if (!is_true) {
        return;
    }

    $.ajax({
        url: url,
        type: 'POST',
        data: data,
        success: function (response) {
            if (response.success) {
                $('#reset-token').val('');
                $('#modal-reset-password').modal('hide');
                
                if (response.role == 'Admin') {
                    window.location.href = '/Dashboard/Index';
                }
                window.location.href = '/Home/Index';
                ShowToaster('success', 'RESET PASSWORD', response.message);
            }
            else {               
                ShowToaster('error', 'RESET PASSWORD', response.message);
                $('#modal-reset-password').modal('show');
            }  
        },
        error: function (xhr, status, error) {
            ShowToaster('error', 'RESET PASSWORD', error);
        }
    });   
}


function RegisterUser(url) {
    
    let data = {
        Email: $('#reg-email').val(),
        Fullname: $('#reg-fullname').val(),
        PhoneNumber: $('#reg-phoneno').val(),
        Password: $('#reg-password').val(),
        ConfirmPassword: $('#reg-confirmpassword').val()       
    };
    ValidateEmail(data.Email);

    let is_true = false;

    is_true = IsFieldValid('#form-add');

    if (!is_true) {
        return;
    }

    $.ajax({
        url: url,
        type: 'POST',
        data: data,
        success: function (response) {
            if (response.success) {
                window.location.href = '/Home/Index';
                ShowToaster('success','REGISTER USER', response.message);
            }
            else {
                ShowToaster('error', 'REGISTER USER', response.message);
            }
        },
        error: function (xhr, status, error) {
            ShowToaster('error', 'REGISTER USER', error);
        }
    });   
  
}



