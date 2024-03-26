var objDataTable;

$(document).ready(function () {
    initializeDataTable();

    $('.btn-add').click(function () {
        loadModal('/AmenityOnly/Create', '#modal-add-content');
    });

    $('.btn-save').click(function () {
        saveRoom('/AmenityOnly/Create', '#form-add');
    });

    $('#tbl_AmenityOnly').on('click', '.select-edit-btn', function () {
        var rowData = getRowData($(this));
        loadModal('/AmenityOnly/Update', '#modal-edit-content', rowData);
    });

    $('.btn-edit').click(function () {
        saveRoom('/AmenityOnly/Update', '#form-edit');
    });

    $('#tbl_AmenityOnly').on('click', '.select-delete-btn', function () {
        var rowData = getRowData($(this));
        $('#id').val(rowData.id);
        $('#modal-delete').modal('show');
    });

    $('.btn-delete').click(function () {
        deleteRoom('#form-delete');
    });
});

function initializeDataTable() {
    objDataTable = $('#tbl_AmenityOnly').DataTable({
        'ajax': {
            url: '/AmenityOnly/GetAll'
        },
        'columns': [
            { data: 'id', visible: false },
            { data: 'amenitY_NAME', 'width': '25%' },               

            {
                data: 'id',
                'width': '5%',
                'render': function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm select-edit-btn w-100">Edit</button>';
                }
            },
            {
                data: 'id',
                'width': '5%',
                'render': function (data, type, row) {
                    return '<button class="btn btn-danger btn-sm select-delete-btn w-100">Delete</button>';
                }
            }
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
}


function saveRoom(url, formSelector) {

    var objRoomData = $(formSelector).serialize(); 
    
    if ($(formSelector)[0].checkValidity()) {
        $.ajax({
            type: 'POST',
            url: url,
            data: objRoomData,
            success: function (response) {

                if (response.success) {
                    objDataTable.ajax.reload();
                    $(formSelector.replace('form', 'modal')).modal('hide');
                    showToast('success', response.message);
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
        url: '/AmenityOnly/Delete',
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
    return objDataTable.row(btn.closest('tr')).data();
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
