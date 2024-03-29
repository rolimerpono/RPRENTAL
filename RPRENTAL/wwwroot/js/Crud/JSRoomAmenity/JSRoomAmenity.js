let objDataTable;
const objSelectedRoom = document.getElementById('selected_room');
  
    initializeDataTable();


$('#tbl_Rooms').on('click', '.select-edit-btn', function () {        
    const body = new URLSearchParams();
    let rowData = getRowData($(this));     
    body.append('ID', rowData.rooM_ID);        
    Display('/RoomAmenity/GetSelectedRoom', body , objSelectedRoom); 
});


function initializeDataTable() {
    objDataTable = $('#tbl_Rooms').DataTable({
        'ajax': {
            url: '/RoomAmenity/GetRoomList'
        },
        'columns': [
            { data: 'rooM_ID', visible: false },
            { data: 'rooM_NAME', 'width': '60%' },            
            {
                data: 'rooM_ID',
                'width': '5%',
                'render': function (data, type, row) {
                    return '<button class="btn btn-danger btn-sm select-edit-btn w-100">Select</button>';
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
            debugger
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

    let objRoomData = $(formSelector).serialize();
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
    let objRoomData = $(formSelector).serialize();
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
    let toaster = $('.toaster');
    toaster.text(message);
    toaster.css('display', 'block').css('backgroundColor', type === 'success' ? '#006400' : 'red').css('opacity', 1);
    setTimeout(function () {
        toaster.css('opacity', 0);
        setTimeout(function () {
            toaster.css('display', 'none').css('opacity', 1);
        }, 500);
    }, 3000);
}
