let objBookingTable;
$(document).ready(function () {

    const urlParams = new URLSearchParams(window.location.search);
    let status = urlParams.get('status') ?? 'Pending';
    $('.btn-checkin').click(function () {    
        CheckIn();
    }); 

    $('.btn-checkout').click(function () {
        CheckOut();
    }); 

    $('.btn-cancel').click(function () {
        CancelBooking();
    }); 

    $('.btn-payment').click(function () {
        ProceedPayment();
    }); 

    const statusToButtonMap = {
        'all': '#all',
        'pending': '#pending',
        'approved': '#approved',
        'checkin': '#checkin',
        'checkout': '#checkout',
        'cancelled': '#cancelled'
    };

    const UpdateButtonColor = status => {
        const buttonId = statusToButtonMap[status.toLowerCase()];        
        if (buttonId) $(buttonId).toggleClass('btn-primary btn-success');
    };   

    UpdateButtonColor(status); 
    LoadBookings(status);

    $('#tbl_Bookings').on('click', '.select-view-btn', function () {     
        var rowData = GetRowData(objBookingTable, $(this));
        LoadModal('/Booking/BookingDetails', '#modal-booking-content', rowData);       
    });
  

});

function CheckIn() {
    let token = $('input[name="__RequestVerificationToken"]').val(); 

    let data = {
        BookingId: $('#BookingId').val(),
        RoomNo: $('#RoomNo').val(),
        __RequestVerificationToken: token
    };
  
    $.ajax({
        type: 'POST',
        url: '/Booking/CheckIn',
        data: data,
        success: function (response) {

            if (response.success) {              
                ReloadDataTable(objBookingTable);
                HideModal('#modal-booking');
                ShowToaster('success', 'CHECKIN', response.message);
            } else {
                ShowToaster('error', 'CHECKIN', response.message);
            }

        },
        error: function (xhr, status, error) {
            ShowToaster('error', 'CHECKIN', error);
        }
    });   
   
}

function CheckOut() {

    let token = $('input[name="__RequestVerificationToken"]').val(); 
    let bookingId = $('#BookingId').val()    

    let data = {
        BookingId: bookingId,
        __RequestVerificationToken : token
    };

    $.ajax({
        type: 'POST',
        url: '/Booking/CheckOut',
        data: data,
        success: function (response) {
            if (response.success) {              
                ReloadDataTable(objBookingTable);               
                HideModal('#modal-booking');
                ShowToaster('success','CHECKOUT', response.message);
            } else {
                ShowToaster('error','CHECKOUT', response.message);
            }
        },
        error: function (xhr, status, error) {          
            ShowToaster('error', 'CHECKOUT', error);
        }
    });

    $(document).on('hidden.bs.modal', modalContentSelector.replace('-content', ''), function () {
        $(modalContentSelector).html('');
    });
}

function ProceedPayment() {
    debugger

    let token = $('input[name="__RequestVerificationToken"]').val(); 
    let bookingId = $('#BookingId').val();    

    let data = {
        BookingId: bookingId,
        __RequestVerificationToken : token
    };

    $.ajax({
        url: '/Booking/ShowPayment',
        method: 'POST',
        data: data,
        success: function (response) {
            
            if (response.success) {
                window.location.href = response.redirectUrl;
            }
            else {               
                ShowToaster('error', 'PAYMENT', response.message);
            }
        },
        error: function (xhr, status, error) {      
            ShowToaster('error', 'PAYMENT', error);
        }
    });
    
}


function CancelBooking() {

    let token = $('input[name="__RequestVerificationToken"]').val(); 
    let bookingId = $('#BookingId').val();    

    let data = {
        BookingId: bookingId,
        __RequestVerificationToken : token
    };

    $.ajax({
        type: 'POST',
        url: '/Booking/CancelBooking',
        data: data,

        success: function (response) {
            if (response.success) {           
                ReloadDataTable(objBookingTable);               
                HideModal('#modal-booking');
                ShowToaster('success', 'CANCEL BOOKING', response.message);
            } else {              
                ShowToaster('error', 'CANCEL BOOKING', response.message);
            }
        },
        error: function (xhr, status, error) {           
            ShowToaster('error', 'CANCEL BOOKING', error);
        }
    });

    $(document).on('hidden.bs.modal', modalContentSelector.replace('-content', ''), function () {
        $(modalContentSelector).html('');
    });
}
function LoadBookings(status) { 
    objBookingTable = $('#tbl_Bookings').DataTable({
        ajax: {
            url: '/Booking/GetAll?status=' + status
        },
        columns: [
            { data: 'bookingId', visible: false },
            { data: 'userName', width: '5%' },
            { data: 'userEmail', width: '5%' },
            { data: 'bookingStatus', width: '5%' },
            { data: 'checkinDate', width: '5%' },
            { data: 'checkoutDate', width: '5%' },
            { data: 'noOfStay', width: '5%' },
            {
                data: 'totalCost',
                width: '5%',
                render: function (data, type, row) {                   
                    return '$' + parseFloat(data).toFixed(2); 
                }
            },
            {
                data: 'bookingId',
                width: '5%',
                'render': function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm select-view-btn w-100">View Details</button>';
                }
            },
        ],
        fixedColumns: true,
        scrollY: true        
        
    });    

}
