let objRegisterTable;

$(document).ready(function () {
    InitializeDataTable();

    $('.btn-add').click(function () {
        LoadModal('/Account/Create', '#modal-add-content');       
        InputBoxFocus('#Email', '#modal-add');
    });

    $('.btn-save').click(function () {
        SaveUser('/Account/Create', '#form-add');
    });

    $('#tbl_Users').on('click', '.select-edit-btn', function () {
        var rowData = GetRowData(objRegisterTable, $(this));        
        LoadModal('/Account/Update', '#modal-edit-content', rowData);       
        InputBoxFocus('#Fullname', '#modal-edit');
    });

    $('.btn-edit').click(function () {
        SaveUser('/Account/Update', '#form-edit');
        
    });

    $('#tbl_Users').on('click', '.select-delete-btn', function () {
        var rowData = GetRowData(objRegisterTable ,$(this));        
        $('#email').val(rowData.email);
        $('#modal-delete').modal('show');
    });

    $('.btn-delete').click(function () { 
        let email = $('#email').val();
        DeleteRecord(email);
    });

});

function InitializeDataTable() {

    objRegisterTable = $('#tbl_Users').DataTable({
        ajax: {
            url: '/Account/GetAll'
        },
        columns: [
            { data: 'fullname', width: '15%' },
            { data: 'email', width: '15%' },
            { data: 'phoneNumber', width: '5%' },
            { data: 'role', width: '5%' },
            {
                data: 'email',
                width: '5%',
                render: function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm select-edit-btn w-100">Edit</button>';
                }
            },
            {
                data: 'email',
                width: '5%',
                render: function (data, type, row) {
                    return '<button class="btn btn-danger btn-sm select-delete-btn w-100">Delete</button>';
                }
            },
        ],
        fixedColumns: true,
        scrollY: true
    });
}

function SaveUser(url, formSelector) {
    
    let email = $('#Email').val()
    let data = $(formSelector).serialize();  
    

    ValidateEmail(email);
    let is_true = false;

    is_true = IsFieldValid(formSelector);

    if (!is_true) {
        return;
    }    

    $.ajax({
        url: url,
        type: 'POST',
        data: data,
        success: function (response) {
            if (response) {

                ReloadDataTable(objRegisterTable);               
                HideModal(formSelector.replace('form', 'modal'));
                ShowToaster('success', 'REGISTER USER', response.message);
            }
            else {
                ShowToaster('error','REGISTER USER', response.message);
            }
        },
        error: function (xhr, status, error) {
            ShowToaster('error', 'REGISTER USER', error);
        }
    });
  
}

function DeleteRecord(email) {

    $.ajax({
        url: '/Account/Delete',
        method: 'POST',
        data: { email: email },
        success: function (response) {
            if (response.success) {               
                ReloadDataTable(objRegisterTable);
                HideModal('#modal-delete');
                ShowToaster('success', 'DELETE USER', response.message);
            }
            else {
                HideModal('#modal-delete');              
                ShowToaster('error', 'DELETE USER', response.message);
            }
        },
        error: function (xhr, status, error) {
            HideModal('#modal-delete');
            ShowToaster('error', 'DELETE USER', response.message);
        }
    });
}
