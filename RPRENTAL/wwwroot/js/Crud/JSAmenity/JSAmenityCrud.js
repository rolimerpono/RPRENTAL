var objDataTable;

$(document).ready(function () {
    InitializedDataTable();

    $('.btn-add').click(function () {
        LoadModal('/Amenity/Create', '#modal-add-content');      
        InputBoxFocus('#AmenityName', '#modal-add')
    });

    $('.btn-save').click(function () {
        SaveAmenity('/Amenity/Create', '#form-add');
    });

    $('#tbl_Amenity').on('click', '.select-edit-btn', function () {
        var rowData = GetRowData(objDataTable,$(this));
        LoadModal('/Amenity/Update', '#modal-edit-content', rowData);       
        InputBoxFocus('#AmenityName', '#modal-edit')

    });

    $('.btn-edit').click(function () {
        SaveAmenity('/Amenity/Update', '#form-edit');
    });

    $('#tbl_Amenity').on('click', '.select-delete-btn', function () {
        var rowData = GetRowData(objDataTable, $(this));        
        $('#AmenityId').val(rowData.amenityId);
        $('#modal-delete').modal('show');
    });

    $('.btn-delete').click(function () {
        DeleteAmenity();
    });  

});

function InitializedDataTable() {
    objDataTable = $('#tbl_Amenity').DataTable({
        ajax: {
            url: '/Amenity/GetAll'
        },
        columns: [
            { data: 'amenityId', visible: false },
            { data: 'amenityName', 'width': '500px' },           
            {
                data: 'amenityId',
                width: '100px',
                render: function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm select-edit-btn w-100">Edit</button>';
                }
            },
            {
                data: 'amenityId',
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



function SaveAmenity(url, formSelector) {

    let objRoomData = $(formSelector).serialize();  
    let is_true = false;

    is_true = IsFieldValid(formSelector); 
     
    if (!is_true)
    {
        return;
    }

    $.ajax({
        type: 'POST',
        url: url,
        data: objRoomData,
        success: function (response) {

            if (response.success) {            
                ReloadDataTable(objDataTable);
                HideModal(formSelector.replace('form', 'modal'));
                ShowToaster('success', 'AMENITY', response.message);
            } else {
                ShowToaster('error', 'AMENITY', response.message);
            }

        },
        error: function (xhr, status, error) {
            ShowToaster('error', 'AMENITY', error);
        }
    });   
}

function DeleteAmenity() {
    let amenityId = $('#AmenityId').val();
    
    $.ajax({
        type: 'POST',
        url: '/Amenity/Delete',
        data: {AmenityId : amenityId},
        success: function (response) {
            objDataTable.ajax.reload();
            $('#modal-delete').modal('hide');
            ShowToaster('success', 'AMENITY', response.message);
        },
        error: function (xhr, status, error) {
            ShowToaster('success', 'AMENITY', error);
        }
    });
}




