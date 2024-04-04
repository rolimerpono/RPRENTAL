var objDataTable;

$(document).ready(function () {
    initializeDataTable();

    $('.btn-add').click(function () {
        loadModal('/Amenity/Create', '#modal-add-content');
        InputBoxFocus('#modal-add');
    });

    $('.btn-save').click(function () {
        saveRoom('/Amenity/Create', '#form-add');
    });

    $('#tbl_Amenity').on('click', '.select-edit-btn', function () {
        var rowData = getRowData($(this));
        loadModal('/Amenity/Update', '#modal-edit-content', rowData);
        InputBoxFocus('#modal-edit');

    });

    $('.btn-edit').click(function () {
        saveRoom('/Amenity/Update', '#form-edit');
    });

    $('#tbl_Amenity').on('click', '.select-delete-btn', function () {
        var rowData = getRowData($(this));
        $('#id').val(rowData.amenitY_ID);
        $('#modal-delete').modal('show');
    });

    $('.btn-delete').click(function () {
        deleteRoom('#form-delete');
    });

    $('#btn-close').click(function () {
        deleteRoom('#form-delete');
    });



});

function InputBoxFocus(modal_name) {
    $(document).on('shown.bs.modal', modal_name, function () {
        var input = $('#amenity_name');
        input.focus();


        if (input.val().trim() !== '') {
            var inputLength = input.val().length;
            input[0].setSelectionRange(inputLength, inputLength);
        }
    });
}


function initializeDataTable() {
    objDataTable = $('#tbl_Amenity').DataTable({
        ajax: {
            url: '/Amenity/GetAll'
        },
        columns: [
            { data: 'amenitY_ID', visible: false },
            { data: 'amenitY_NAME', 'width': '25%' },

            {
                data: 'amenitY_ID',
                'width': '5%',
                'render': function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm select-edit-btn w-100">Edit</button>';
                }
            },
            {
                data: 'amenitY_ID',
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

    $(document).on('hidden.bs.modal', modalContentSelector.replace('-content', ''), function () {
        $(modalContentSelector).html('');
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
        url: '/Amenity/Delete',
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
