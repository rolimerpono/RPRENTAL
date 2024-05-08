let objAmenityTable;

$(document).ready(function () {
    InitializedDataTable();

    $('.btn-add').click(function () {
        LoadModal('/Amenity/Create', '#modal-add-content');      
        InputBoxFocus('#AmenityName', '#modal-add')
    });

    $('.btn-save').click(function () {
        debugger
        SaveAmenity('/Amenity/Create', '#form-add');
    });

    $('#tbl_Amenity').on('click', '.select-edit-btn', function () {
        let rowData = GetRowData(objAmenityTable,$(this));
        LoadModal('/Amenity/Update', '#modal-edit-content', rowData);       
        InputBoxFocus('#AmenityName', '#modal-edit')

    });

    $('.btn-edit').click(function () {
        debugger
        SaveAmenity('/Amenity/Update', '#form-edit');
    });

    $('#tbl_Amenity').on('click', '.select-delete-btn', function () {
        let rowData = GetRowData(objAmenityTable, $(this));        
        $('#AmenityId').val(rowData.amenityId);
        $('#modal-delete').modal('show');
    });

    $('.btn-delete').click(function () {
        DeleteAmenity();
    });  

});

function InitializedDataTable() {
    objAmenityTable = $('#tbl_Amenity').DataTable({
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
   

    let data = new FormData($(formSelector)[0]);

    debugger
    let is_true = false;

    is_true = IsFieldValid(formSelector); 
     
    if (!is_true)
    {
        return;
    }

    $.ajax({
        type: 'POST',
        url: url,
        data: data,   
        success: function (response) {
            debugger
            if (response.success) {            
                ReloadDataTable(objAmenityTable);
                HideModal(formSelector.replace('form', 'modal'));
               
            } else {
               
            }
        },
        error: function (xhr, status, error) {
            
        }
    });   
}

function DeleteAmenity() {

    let amenityId = $('#AmenityId').val();
    let token = $('input[name="__RequestVerificationToken"]').val(); 

    let data =
    {
        AmenityId: amenityId,
        __RequestVerificationToken : token
    };
   
    
    $.ajax({
        type: 'POST',
        url: '/Amenity/Delete',
        data: data,
        success: function (response) {        
            ReloadDataTable(objAmenityTable);      
            HideModal('#modal-delete');
            ShowToaster('success', 'AMENITY', response.message);
        },
        error: function (xhr, status, error) {
            ShowToaster('success', 'AMENITY', error);
        }
    });
}




