let objDataTable;

$(document).ready(function () {
    initializeDataTable();
    let rowData = '';
    $('#tbl_Rooms').on('click', '.select-edit-btn', function () {
        rowData = objDataTable.row($(this).closest('tr')).data();
        if (rowData) {
            DisplayRoomAmenities('/RoomAmenity/DisplayRoomAmenities', rowData.roomId);
        }
    });

    $('#btn-apply').on('click', function () {
        const checkItems = $('input[type="checkbox"]:checked').map(function () {
            const id = $(this).attr('id').replace('selected-item-', '');
            const name = $(this).siblings('label').text();
            return { AmenityId : id, AmenityName: name, IsCheck: true };
        }).get();
        
     
        const serializedData = JSON.stringify(checkItems);     
       
        console.log(checkItems);
        if (rowData != null) {
            ApplyRoomAmenities('/RoomAmenity/ApplyRoomAmenities', rowData.roomId, serializedData);
        }
        else {
            showToast('error','Please select a record.');
        }
       
    });
});


function initializeDataTable() {
    objDataTable = $('#tbl_Rooms').DataTable({
        ajax: {
            url: '/RoomAmenity/GetRoomList'
        },
        columns: [
            { data: 'roomId', visible: false },
            { data: 'roomName', width: '60%' },
            {
                data: 'roomId',
                width: '5%',
                render: function (data, type, row) {
                    return '<button class="btn btn-danger btn-sm select-edit-btn w-100">Select</button>';
                }
            }
        ],
        fixedColumns: true,
        scrollY: true,
        drawCallback: function (settings) {         
            $('#tbl_Rooms tbody tr:first-child .select-edit-btn').trigger('click');
        }
    });
}

function DisplayRoomAmenities(path, RoomId) {
    $.ajax({
        url: path,
        type: 'POST',
        data: { Id: RoomId },
        success: function (response) {
            if (response) {
                $('#selected_room').html(response);
            }
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}

function ApplyRoomAmenities(path, RoomId, serializedData) {
    
    $.ajax({
        url: path,
        type: 'POST',
        data: { Id: RoomId, jsonData: serializedData },
        success: function (response) {           
            console.log(response);
            if (response) {                
                showToast('success', response.message);
                objDataTable.ajax.reload();
            }
            else {
                showToast('error', response.message);
            }
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
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
