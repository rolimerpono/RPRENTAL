var objDataTable;

$(document).ready(function () {
    initializeDataTable();

    $('.btn-add').click(function () {
        loadModal('/RoomNumber/Create', '#modal-add-content');
    });

    $('.btn-save').click(function () {
        saveRoom('/RoomNumber/Create', '#form-add');
    });

    $('#tbl_RoomNumber').on('click', '.select-edit-btn', function () {
        var rowData = getRowData($(this));
        loadModal('/RoomNumber/Update', '#modal-edit-content', rowData);
    });

    $('.btn-edit').click(function () {
        saveRoom('/RoomNumber/Update', '#form-edit');
    });

    $('#tbl_RoomNumber').on('click', '.select-delete-btn', function () {
        var rowData = getRowData($(this));
        $('#room_number').val(rowData.rooM_NUMBER);        
        $('#modal-delete').modal('show');
    });

    $('.btn-delete').click(function () {
        deleteRoom('#form-delete');
    });
});

function initializeDataTable() {
    objDataTable = $('#tbl_RoomNumber').DataTable({
        'ajax': {
            url: '/RoomNumber/GetAll'
        },
        'columns': [
            { data: 'rooM_NUMBER', 'width': '10%' },
            { data: '.room.rooM_NAME', 'width': '15%' },
            {
                data: 'description',
                'width': '35%',
                'render': function (data, type, row) {
                    if (type === 'display' && data.length > 100) {
                        return '<div style="max-height: 50px; overflow-x: auto;">' + data + '</div>';
                    } else {
                        return data;
                    }
                }
            },        
            {
                data: 'rooM_NUMBER',
                'width': '5%',
                'render': function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm select-edit-btn w-100">Edit</button>';
                }
            },
            {
                data: 'rooM_NUMBER',
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

    var objRoomNumberData = $(formSelector).serialize();
    if ($(formSelector)[0].checkValidity()) {
        $.ajax({
            type: 'POST',
            url: url,
            data: objRoomNumberData,
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
    var objRoomNumberData = $(formSelector).serialize();
    $.ajax({
        type: 'POST',
        url: '/RoomNumber/Delete',
        data: objRoomNumberData,
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
