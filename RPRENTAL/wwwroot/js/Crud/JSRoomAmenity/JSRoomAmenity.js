var objDataTable;

$(document).ready(function () {
    
    

    initializeDataTable();


    $('#tbl_Rooms').on('click', '.select-edit-btn', function () {
        const objSelectedRoom = document.getElementById('#selected_room');
        var rowData = getRowData($(this));
        Display('/RoomAmenity/GetSelectedRoom', rowData, objSelectedRoom);debugger
    });

    $('.btn-edit').click(function () {
        saveRoom('/RoomAmenity/Update', '#form-edit');
    });  

});

function initializeDataTable() {
    objDataTable = $('#tbl_Rooms').DataTable({
        'ajax': {
            url: '/RoomAmenity/GetRoomList'
        },
        'columns': [
            { data: 'rooM_ID', visible: false },
            { data: 'rooM_NAME', 'width': '15%' },            
            {
                data: 'rooM_ID',
                'width': '5%',
                'render': function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm select-edit-btn w-100">Edit</button>';
                }
            },
            {
                data: 'rooM_ID',
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

function Display(url, body, objDiv) {    
    debugger
    fetch(url, {
        method: 'POST',
        body: body,
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        }
    })
        .then(response => {
            if (response.ok) {
                return response.text();
            }
            throw new Error('Network response was not ok.');
        })
        .then(data => {
            objDiv.innerHTML = data;
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
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
        url: '/RoomAmenity/Delete',
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
