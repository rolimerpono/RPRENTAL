let objRoomAmenityTable;

$(document).ready(function () {
    InitializeDataTable();
    let rowData = 0;
    $('#tbl_Rooms').on('click', '.select-edit-btn', function () {       
        rowData = GetRowData(objRoomAmenityTable, $(this));       
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

        if (rowData != null) {
            ApplyRoomAmenities('/RoomAmenity/ApplyRoomAmenities', rowData.roomId, serializedData);
        }
        else {           
            ShowToaster('error','AMENITIES', 'Please select a record.')
            
        }
       
    });
});


function InitializeDataTable() {
    objRoomAmenityTable = $('#tbl_Rooms').DataTable({
        ajax: {
            url: '/RoomAmenity/GetRoomList'
        },
        columns: [
            { data: 'roomId', visible: false },
            { data: 'roomName', width: '800px' },
            {
                data: 'roomId',
                width: '100px',
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
            ShowToaster('error', 'AMENITEIS', error);
        }
    });
}

function ApplyRoomAmenities(path, RoomId, serializedData) {
    
    $.ajax({
        url: path,
        type: 'POST',
        data: { Id: RoomId, jsonData: serializedData },
        success: function (response) {           
            if (response) {                
                ShowToaster('success','AMENITIES', response.message);
                ReloadDataTable(objRoomAmenityTable);
            }
            else {
              
                ShowToaster('error', 'AMENITIES', response.message);
            }
        },
        error: function (xhr, status, error) {
            ShowToaster('error', 'AMENITIES', error);
        }
    });
}

