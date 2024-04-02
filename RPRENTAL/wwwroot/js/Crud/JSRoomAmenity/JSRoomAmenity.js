let objDataTable;

$(document).ready(function () {
    initializeDataTable();
   
    $('#tbl_Rooms').on('click', '.select-edit-btn', function() {
        const rowData = objDataTable.row($(this).closest('tr')).data();
        if (rowData) {
            displayRoomAmenities('/RoomAmenity/GetSelectedRoom', rowData.rooM_ID);
        }

    });

   

   
});


const btnApply = document.getElementById('btn-apply');


btnApply.addEventListener('click', function () {

    console.log('Apply button click');
    let checkItems = [];

    $('input[type="checkbox"]').each(function () {
        if ($(this).is(':checked')) {

            let id = $(this).attr('id').replace('selected-item-', '');
            let name = $(this).siblings('label').text();
            let isChecked = $(this).is(':checked') ? 'True' : 'False';

            checkItems.push({ ID: id, AMENITY_NAME: name, IS_CHECK: isChecked });

        }

    });

    //let serializedData = JSON.stringify(checkItems);             
    ApplyRoomAmenities('/RoomAmenity/ApplyRoomAmenities', checkItems);

});

function initializeDataTable() {
    objDataTable = $('#tbl_Rooms').DataTable({
        ajax: {
            url: '/RoomAmenity/GetRoomList'
        },
        columns: [
            { data: 'rooM_ID', visible: false },
            { data: 'rooM_NAME', width: '60%' },
            {
                data: 'rooM_ID',
                width: '5%',
                render: function (data, type, row) {
                    return '<button class="btn btn-danger btn-sm select-edit-btn w-100">Select</button>';
                }
            }
        ],
        fixedColumns: true,
        scrollY: true
    });
}

function displayRoomAmenities(path, roomId) {
    $.ajax({
        url: path,
        type: 'POST',
        data: { ID: roomId },
        success: function (response) {
            $('#selected_room').html(response);
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}


function ApplyRoomAmenities(path, objData) {

    debugger
    $.ajax({
        url: path,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ objData: objData }),
        success: function (response) {
            console.log(response);
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}
