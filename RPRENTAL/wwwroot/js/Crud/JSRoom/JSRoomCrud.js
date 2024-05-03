
var objDataTable;

$(document).ready(function () {
    initializeDataTable();

    $('.btn-add').click(function () {
        loadModal('/Room/Create', '#modal-add-content');
        InputBoxFocus('#modal-add');       
     
        
    });

    $('.btn-save').click(function () {
        saveRoom('/Room/Create', '#form-add');
        
        ShowToaster('', '', '');
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
            { data: 'roomName', width: '100px' }, 
            {

                data: 'description',
                width: '400px',
                render: function (data, type, row) {
                    return '<span title="' + data + '" >' + (data.length > 80 ? data.substr(0, 80 - 3) + '....' : data) + '</span>';
                }


            },  
            { data: 'roomPrice', className: 'text-center', width: '100px' }, 
            { data: 'maxOccupancy', className: 'text-center', width: '100px' },
            { data: 'imageUrl', visible: false },
            {
                data: 'roomId',
                width: '100px', 
                render: function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm select-edit-btn w-100">Edit</button>';
                }
            },
            {
                data: 'roomId',
                width: '100px', 
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
            if (response)
            {
                $(modalContentSelector).html('');
                $(modalContentSelector).html(response);
                $(modalContentSelector.replace('-content', '')).modal('show');
            }
        },
        error: function (xhr, status, error) {
            ShowToaster('error', 'Room', error);
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
                    ShowToaster('success', 'Room', response.message);
                } else {
                    ShowToaster('error', 'Room', response.message);
                }

            },
            error: function (xhr, status, error) {             
                ShowToaster('error', 'Room', error);
            }
        });
    } else {
        $(formSelector).addClass('was-validated');
        ShowToaster('error', 'Room', 'Please make sure all fields input are valid.');
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
            ShowToaster('success', 'Room', response.message);
        },
        error: function (xhr, status, error) {           
            ShowToaster('error', 'Room', error);
        }
    });
}

function getRowData(btn) {
    return objDataTable.row(btn.closest('tr')).data();
}
