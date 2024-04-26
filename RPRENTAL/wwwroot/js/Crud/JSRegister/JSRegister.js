﻿let objDataTable;

$(document).ready(function () {
    initializeDataTable();

    $('.btn-add').click(function () {
        loadModal('/Account/Create', '#modal-add-content');
        focusInput('#email');
    });

    $('.btn-save').click(function () {
        saveUser('/Account/Create', '#form-add');
    });

    $('#tbl_Users').on('click', '.select-edit-btn', function () {
        var row_data = getRowData($(this));
        loadModal('/Account/Update', '#modal-edit-content', row_data);
        focusInput('#email');
    });

    $('.btn-edit').click(function () {
        saveUser('/Account/Update', '#form-edit');
    });

    $('#tbl_Users').on('click', '.select-delete-btn', function () {
        var row_data = getRowData($(this));        
        $('#email').val(row_data.email);
        $('#modal-delete').modal('show');
    });

    $('.btn-delete').click(function () { 
        let email = $('#email').val();
        deleteRecord(email);
    });

});

function focusInput(inputSelector) {  
    $(inputSelector).focus().select();
}

function initializeDataTable() {
    objDataTable = $('#tbl_Users').DataTable({
        ajax: {
            url: '/Account/GetAll'
        },
        columns: [
            { data: 'name', width: '15%' },
            { data: 'email', width: '15%' },
            { data: 'phonE_NUMBER', width: '5%' },
            { data: 'role', width: '5%' },
            {
                data: 'email',
                width: '5%',
                render: function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm select-edit-btn w-100">Edit</button>';
                }
            },
            {
                data: 'email',
                width: '5%',
                render: function (data, type, row) {
                    return '<button class="btn btn-danger btn-sm select-delete-btn w-100">Delete</button>';
                }
            },
        ],
        fixedColumns: true,
        scrollY: true
    });
}

function loadModal(url, modalContentSelector, data = null) {
    $.get(url, data)
        .done(function (result) {
            $(modalContentSelector).html(result);
            $(modalContentSelector.replace('-content', '')).modal('show');
        })
        .fail(handleAjaxError);

    $(document).on('hidden.bs.modal', modalContentSelector.replace('-content', ''), function () {
        $(modalContentSelector).html('');
    });
}

function validateEmail(email) {
    let emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email);
}

function saveUser(url, formSelector) {
    let email = $('#email').val()
    let objUser = $(formSelector).serialize();

    if (!validateEmail(email)) {
        $('#email-validation').css('color', 'red').html('Please enter a valid email.');
        return;
    }

    if ($(formSelector)[0].checkValidity()) {
        $.post(url, objUser)
            .done(function (response) {
                if (response.success) {

                    $(formSelector.replace('form', 'modal')).modal('hide');
                    objDataTable.ajax.reload();
                } else {
                    showToast('error', response.message);
                }
            })
            .fail(handleAjaxError);
    } else {
        $(formSelector).addClass('was-validated');
    }
}

function deleteRecord(email) {

    $.ajax({
        url: '/Account/Delete',
        method: 'POST',
        data: { email: email },
        success: function (response) {
            if (response.success) {
                objDataTable.ajax.reload();
                $('#modal-delete').modal('hide');
                showToast('success', response.message);
            }
            else {
                $('#modal-delete').modal('hide');
                showToast('error', response.message);
            }
        },
        error: function (xhr, status, error) {
            $('#modal-delete').modal('hide');
        }
    });
}

function getRowData(btn) {
    return objDataTable.row(btn.closest('tr')).data();
}

function handleAjaxError(xhr, status, error) {
    console.log('Error: ' + error);
}

function showToast(type, message) {
    var toaster = $('.toaster');
    toaster.text(message);
    toaster.css('display', 'block').css('backgroundColor', type === 'success' ? '#006400' : 'red').css('opacity', 1);
    setTimeout(function () {
        toaster.css('opacity', 0);
        setTimeout(function () {
            toaster.css('display', 'none').css('opacity', 1);
        }, 500);
    }, 3000);
}
