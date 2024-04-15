$(document).ready(function () {

    // Event listener for login button
    $('.btn-login').click(function () {
        loginUser('/Account/Login');
    });

    // Event listener for register button
    $('.btn-register').click(function () {
        registerUser('/Account/Register');
    });

    // Event listener for logout button
    $('.btn-logout').click(function () {     
        logoutUser('/Account/Logout');
    });

    // Event handler for login modal shown
    $(document).on('shown.bs.modal', '#modal-login', function () {
        focusAndSelectInput($('#email'));
    });

    // Event handler for register modal shown
    $(document).on('shown.bs.modal', '#modal-register', function () {
        focusAndSelectInput($('#remail'));
    });

});

// Function to focus and select input
function focusAndSelectInput(input) {
    input.focus();
    if (input.val().trim() !== '') {
        var inputLength = input.val().length;
        input[0].setSelectionRange(inputLength, inputLength);
    }
}

// Function to handle AJAX errors
function handleAjaxError(error) {
    console.log('Error: ' + error);
}

// Function to show toast messages
function showToast(type, message) {
    var toaster = $('.toaster');
    toaster.text(message);
    toaster.css({
        'display': 'block',
        'background-color': type === 'success' ? '#006400' : 'red',
        'opacity': 1
    });
    setTimeout(function () {
        toaster.css('opacity', 0);
        setTimeout(function () {
            toaster.css('display', 'none').css('opacity', 1);
        }, 500);
    }, 3000);
}

// Function to handle login
function loginUser(url) {
    let email = $('#email').val();
    let password = $('#password').val();
    let loginForm = { EMAIL: email, PASSWORD: password };

    $.ajax({
        type: 'POST',
        url: url,
        data: loginForm,
        success: function (response) {
            if (response.success) {
                $('#modal-login').modal('hide');
                window.location.href = '/Home/Index';               
            } else {
                showToast('error', response.message);
            }
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
        }
    });
}

// Function to handle registration
function registerUser(url) {
    let email = $('#remail').val();
    let fullname = $('#rfullname').val();
    let password = $('#rpassword').val();
    let confirmpass = $('#rconfirmpass').val();
    let phoneno = $('#rphoneno').val();

    let registerForm = { EMAIL: email, NAME: fullname, PASSWORD: password, CONFIRM_PASSWORD: confirmpass, PHONE_NUBMER: phoneno };

    $.ajax({
        type: 'POST',
        url: url,
        data: registerForm,
        success: function (response) {
            if (response.success) {
                $('#modal-register').modal('hide');
                window.location.href = '/Home/Index';
                showToast('success', response.message);
            } else {
                showToast('error', response.message);
            }
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
        }
    });
}

// Function to handle login
function logoutUser(url) {
    $.ajax({
        type: 'POST',
        url: url,       
        success: function (response) {
            if (response.success) {
                window.location.href = '/Home/Index';               
            } else {
                showToast('error', response.message);
            }
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
        }
    });
}
