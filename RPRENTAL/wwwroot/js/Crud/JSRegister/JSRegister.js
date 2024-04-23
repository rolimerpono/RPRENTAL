let objUsers;

$(document).ready(function () {
    initializeDataTable();

    $('.btn-add').click(function () {
        loadModal('/Account/Create', '#modal-add-content');
        InputBoxFocus('#modal-add');

    });

    $('.btn-save').click(function () {
        saveUser('/Account/Create', '#form-add');
    });

    $('#tbl_Users').on('click', '.select-edit-btn', function () {
        var rowData = getRowData($(this));        
        loadModal('/Account/Update', '#modal-edit-content', rowData);
        InputBoxFocus('#modal-edit');
    });

    $('.btn-edit').click(function () {
        saveUser('/Account/Update', '#form-edit');
    });

    $('#tbl_Users').on('click', '.select-delete-btn', function () {
        var rowData = getRowData($(this));
        $('#user_id').val(rowData.email);
        $('#modal-delete').modal('show');
    });

    $('.btn-delete').click(function () {
        deleteRoom('#form-delete');
    });

});

function InputBoxFocus(modal_name) {   
    $(document).on('shown.bs.modal', modal_name, function () {
        var input = $('#email');
        input.focus();


        if (input.val().trim() !== '') {
            var inputLength = input.val().length;
            input[0].setSelectionRange(inputLength, inputLength);
        }
    });
}

function initializeDataTable() {
    objUsers = $('#tbl_Users').DataTable({
        ajax: {
            url: '/Account/GetAll'
        },
        columns: [
            { data: 'name',     width: '15%' },
            { data: 'email',    width: '15%' },
            { data: 'phonE_NUMBER', width: '5%' },
            { data: 'role',     width: '5%' },           
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
    $.ajax({
        type: 'GET',
        url: url,
        data: data,
        success: function (result) {
            $(modalContentSelector).html(result);
            $(modalContentSelector.replace('-content', '')).modal('show');
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
        }
    });

    $(document).on('hidden.bs.modal', modalContentSelector.replace('-content', ''), function () {
        $(modalContentSelector).html('');
    });
}


function saveUser(url, formSelector) {
    
    var objUser = $(formSelector).serialize();

    if ($(formSelector)[0].checkValidity()) {
        $.ajax({
            type: 'POST',
            url: url,
            data: objUser,
            success: function (response) {

                if (response.success) {                   
                    $(formSelector.replace('form', 'modal')).modal('hide');
                    objUsers.ajax.reload();
                    
                } else {
                    showToast('error', response.message);
                }

            },
            error: function (xhr, status, error) {
                handleAjaxError(error);
            }
        });
    } else {
        $(formSelector).addClass('was-validated');
    }
}

function deleteRoom(formSelector) {
    var objRoomData = $(formSelector).serialize();
    $.ajax({
        type: 'POST',
        url: '/Account/Delete',
        data: objRoomData,
        success: function (response) {
            objDataTable.ajax.reload();
            $('#modal-delete').modal('hide');
            showToast('success', response.message);
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
        }
    });
}

function getRowData(btn) {
    return objUsers.row(btn.closest('tr')).data();
}

function handleAjaxError(error) {
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
