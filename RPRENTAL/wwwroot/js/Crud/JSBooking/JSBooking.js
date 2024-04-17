let objDataTable;

$(document).ready(function () {

    const urlParams = new URLSearchParams(window.location.search);
    let status = urlParams.get('status') ?? 'Pending';    


    const statusToButtonMap = {
        'all': '#all',
        'pending': '#pending',
        'approved': '#approved',
        'check_in': '#checkin',
        'check_out': '#checkout',
        'cancelled': '#cancelled'
    };

    const updateButtonColor = status => {
        const buttonId = statusToButtonMap[status.toLowerCase()];
        if (buttonId) $(buttonId).toggleClass('btn-primary btn-success');
    };

    updateButtonColor(status);  

    loadBookings(status);

    $('#tbl_Bookings').on('click', '.select-view-btn', function () {     
        var rowData = getRowData($(this));
        loadModal('/Booking/BookingDetails', '#modal-booking-content', rowData);       
    });

});

function getRowData(btn) {
    return objDataTable.row(btn.closest('tr')).data();
}

function loadBookings(status) {
    
    objDataTable = $('#tbl_Bookings').DataTable({
        'ajax': {
            url: '/Booking/GetAll?status=' + status
        },
        'columns': [
            { data: 'bookinG_ID', visible: false },
            { data: 'useR_NAME', 'width': '5%' },
            { data: 'useR_EMAIL', 'width': '5%' },
            { data: 'bookinG_STATUS', 'width': '5%' },
            { data: 'checK_IN_DATE', 'width': '5%' },
            { data: 'checK_OUT_DATE', 'width': '5%' },
            { data: 'nO_OF_STAY', 'width': '5%' },
            { data: 'totaL_COST', 'width': '5%' },
            {
                data: 'bookinG_ID',
                'width': '5%',
                'render': function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm select-view-btn w-100">View Details</button>';
                }
            },
        ],
        fixedColumns: true,
        scrollY: true,        
        
    });
    

}

function loadModal(url, modalContentSelector, data = null) {

    $.ajax({
        type: 'GET',
        url: url,
        data: data,
        success: function (result) {
            $(modalContentSelector).empty().html(result);
            $(modalContentSelector.replace('-content', '')).modal('show');
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
        }
    });

    $(document).on('hidden.bs.modal', modalContentSelector.replace('-content', ''), function () {
        $(modalContentSelector).html('');
    });
}