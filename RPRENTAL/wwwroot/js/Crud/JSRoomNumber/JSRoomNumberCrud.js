var objDataTable;

$(document).ready(function () {
    initializeDataTable();

    $('.btn-add').click(function () {
        loadModal('/RoomNumber/Create', '#modal-add-content');
        InputBoxFocus('#modal-add');
    });

    $('.btn-save').click(function () {
        saveRoom('/RoomNumber/Create', '#form-add');
    });

    $('#tbl_RoomNumber').on('click', '.select-edit-btn', function () {
        var rowData = getRowData($(this));
        loadModal('/RoomNumber/Update', '#modal-edit-content', rowData);
        InputBoxFocus('#modal-edit');
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

function InputBoxFocus(modal_name) {
    $(document).on('shown.bs.modal', modal_name, function () {
        var input = $('#room_number');
        input.focus();


        if (input.val().trim() !== '') {
            var inputLength = input.val().length;
            input[0].setSelectionRange(inputLength, inputLength);
        }
    });
}

function initializeDataTable() {
    objDataTable = $('#tbl_RoomNumber').DataTable({
        ajax: {
            url: '/RoomNumber/GetAll'
        },
        columns: [
            { data: 'roomNo', width: '15%' },
            { data: 'room.roomName', width: '15%' },
            {
                data: 'description',
                width: '25%',
                render: function (data, type, row) {
                    return '<div class="truncated-text" style="max-height: 25px;">' + data + '</div>';        
                }
            },        
            {
                data: 'roomNo',
                width: '10%',
                'render': function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm select-edit-btn w-100">Edit</button>';
                }
            },
            {
                data: 'roomNo',
                width: '10%',
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

    $(document).on('hidden.bs.modal', modalContentSelector.replace('-content', ''), function () {
        $(modalContentSelector).html('');
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
