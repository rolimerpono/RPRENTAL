$(document).ready(() => {
    $('.btn-login').click(() => loginUser('/Account/Login'));
    $('.btn-register').click(() => registerUser('/Account/Register'));
    $('.btn-logout').click(() => logoutUser('/Account/Logout'));
    $('#modal-login').on('shown.bs.modal', () => focusAndSelectInput($('#email')));
    $('#modal-register').on('shown.bs.modal', () => focusAndSelectInput($('#remail')));
});

function focusAndSelectInput(input) {
    input.focus().select();
}

function handleAjaxError(xhr, status, error) {
    console.error('AJAX Error:', error);
    showToast('error', 'An error occurred. Please try again later.');
}

function showToast(type, message) {
    const toaster = $('.toaster');
    toaster.text(message).css({
        'display': 'block',
        'background-color': type === 'success' ? '#006400' : 'red',
        'opacity': 1
    });

    setTimeout(() => {
        toaster.css('opacity', 0);
        setTimeout(() => toaster.css('display', 'none').css('opacity', 1), 500);
    }, 3000);
}

function loginUser(url) {
    const email = $('#email').val();
    const password = $('#password').val();
    const loginForm = { EMAIL: email, PASSWORD: password };

    $.post(url, loginForm)
        .done(response => {
            response.success ? (window.location.href = '/Home/Index') : showToast('error', response.message);
        })
        .fail(handleAjaxError);
}

function registerUser(url) {    
    const email = $('#remail').val();
    const fullname = $('#rfullname').val();
    const password = $('#rpassword').val();
    const confirmpass = $('#rconfirmpass').val();
    const phoneno = $('#rphoneno').val();
 
    const registerForm = { EMAIL: email, NAME: fullname, PASSWORD: password, CONFIRM_PASSWORD: confirmpass, PHONE_NUMBER: phoneno };
   

    if (!validateEmail(email)) {
        $('#email-validation').css('color', 'red').html('Please enter a valid email.');
        return;
    }

    $.post(url, registerForm)
        .done(response => {
            response.success ? (window.location.href = '/Home/Index') : showToast('error', response.message);
        })
        .fail(handleAjaxError);
}

function validateEmail(email) {
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email);
}

function logoutUser(url) {
    $.post(url)
        .done(response => {
            response.success ? (window.location.href = '/Home/Index') : showToast('error', response.message);
        })
        .fail(handleAjaxError);
}
