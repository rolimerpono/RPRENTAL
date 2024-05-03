let objDataTable;

$(document).ready(function () {
    InitializeDataTable();

    $('.btn-add').click(function () {
        LoadModal('/RoomNumber/Create', '#modal-add-content');
        InputBoxFocus('#RoomNo','#modal-add');
    });

    $('.btn-save').click(function () {
        SaveRoomNumber('/RoomNumber/Create', '#form-add');
    });

    $('#tbl_RoomNumber').on('click', '.select-edit-btn', function () {
        let rowData = GetRowData(objDataTable , $(this));
        LoadModal('/RoomNumber/Update', '#modal-edit-content', rowData);
        InputBoxFocus('#Description','#modal-edit');
    });

    $('.btn-edit').click(function () {
        SaveRoomNumber('/RoomNumber/Update', '#form-edit');
    });

    $('#tbl_RoomNumber').on('click', '.select-delete-btn', function () {
        let rowData = GetRowData(objDataTable, $(this));        
        $('#RoomNo').val(rowData.roomNo);    
        $('#modal-delete').modal('show');
    });

    $('.btn-delete').click(function () {
        DeleteRoomNumber();
    });
});

function InitializeDataTable() {
    objDataTable = $('#tbl_RoomNumber').DataTable({
        ajax: {
            url: '/RoomNumber/GetAll'
        },
        columns: [
            { data: 'roomNo', width: '20px', className: 'text-start' },
            { data: 'room.roomName', width: '100px' },
            {

                data: 'description',
                width: '400px',
                render: function (data, type, row) {
                    return '<span title="' + data + '" >' + (data.length > 80 ? data.substr(0, 80 - 3) + '....' : data) + '</span>';
                
                }

            },  
            {
                data: 'roomNo',
                width: '100px',
                render: function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm select-edit-btn w-100">Edit</button>';
                }
            },
            {
                data: 'roomNo',
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

function SaveRoomNumber(url, formSelector) {

    var data = $(formSelector).serialize();   

    let is_true = false;

    is_true = IsFieldValid(formSelector);

    if (!is_true) {
        return;
    }

    $.ajax({
        type: 'POST',
        url: url,
        data: data,
            
        success: function (response) {

            if (response.success) {             
                ReloadDataTable(objDataTable);
                HideModal(formSelector.replace('form', 'modal'));
               
                ShowToaster('success', 'ROOM NUMBER', response.message);
            } else {
               
                ShowToaster('error', 'ROOM NUMBER', response.message);
            }

        },
        error: function (xhr, status, error) {           
            ShowToaster('success', 'ROOM NUMBER', error);
        }
    });

}

function DeleteRoomNumber() {
    
    let data = $('#RoomNo').val();  
    
    $.ajax({
        type: 'POST',
        url: '/RoomNumber/Delete',
        data: { RoomNo: data },
        success: function (response) {            
            ReloadDataTable(objDataTable);     
            HideModal('#modal-delete');           
            ShowToaster('success', 'ROOM NUMBER', response.message);
        },
        error: function (xhr, status, error) {
            ShowToaster('error', 'ROOM NUMBER', response.message);
        }
    });
}

