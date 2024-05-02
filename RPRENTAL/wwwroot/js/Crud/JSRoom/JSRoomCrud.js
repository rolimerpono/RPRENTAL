
var objDataTable;

$(document).ready(function () {
    initializeDataTable();

    $('.btn-add').click(function () {
        loadModal('/Room/Create', '#modal-add-content');
        InputBoxFocus('#modal-add');
        
    });

    $('.btn-save').click(function () {
        saveRoom('/Room/Create', '#form-add');
    });

    $('#tbl_Rooms').on('click', '.select-edit-btn', function () {
        var rowData = getRowData($(this));
        loadModal('/Room/Update', '#modal-edit-content', rowData);
        InputBoxFocus('#modal-edit');
    });

    $('.btn-edit').click(function () {
        saveRoom('/Room/Update', '#form-edit');
    });

    $('#tbl_Rooms').on('click', '.select-delete-btn', function () {
        var rowData = getRowData($(this));        
        $('#room_id').val(rowData.roomId);
        $('#modal-delete').modal('show');
    });

    $('.btn-delete').click(function () {
        deleteRoom();
    });


});

function displayImagePreview(event) {
    let imageSrc = URL.createObjectURL(event.target.files[0]);
    $('#image_preview').attr('src', imageSrc);
}


function InputBoxFocus(modal_name) {
    $(document).on('shown.bs.modal', modal_name, function () {
        var input = $('#room_name');
        input.focus();


        if (input.val().trim() !== '') {
            var inputLength = input.val().length;
            input[0].setSelectionRange(inputLength, inputLength);
        }
    });
}

function initializeDataTable() {
    objDataTable = $('#tbl_Rooms').DataTable({
        ajax: {
            url: '/Room/GetAll'
        },
        columns: [
            { data: 'roomId', visible: false },
            { data: 'roomName', width: '15%' },
            {
                data: 'description',
                width: '35%',
                render: function (data, type, row) {
                    if (type === 'display' && data.length > 100) {
                        return '<div style="max-height: 25px; overflow-x: auto;">' + data + '</div>';
                    } else {
                        return data;
                    }
                }
            },        

            { data: 'roomPrice', width: '5%' },
            { data: 'maxOccupancy', width: '5%' },
            { data: 'imageUrl', visible: false },
            {
                data: 'roomId',
                width: '5%',
                render: function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm select-edit-btn w-100">Edit</button>';
                }
            },
            {
                data: 'roomId',
                'width': '5%',
                render: function (data, type, row) {
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
        success: function (response) {   
  
            $(modalContentSelector).html('');
            $(modalContentSelector).html(response);    
            console.log(response);
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


    var form_data = new FormData($(formSelector)[0]);

    if ($(formSelector)[0].checkValidity()) {
        $.ajax({
            type: 'POST',
            url: url,
            data: form_data,
            contentType: false, // Ensure proper content type for file upload
            processData: false, // Prevent jQuery from automatically processing the data
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

function deleteRoom() { 
    let roomId = $('#room_id').val();    
    $.ajax({
        type: 'POST',
        url: '/Room/Delete',
        data: { RoomId: roomId },
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
