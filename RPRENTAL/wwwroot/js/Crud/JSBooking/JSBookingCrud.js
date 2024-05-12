function ConfirmBooking(RoomId) {
   
    let serializedData = $('#checking_info').serialize();

    
    $.ajax({
        url: '/Booking/ConfirmBooking',
        method: 'POST',
        data: { Id: RoomId, jsonData: serializedData },
        success: function (response) {
            if (response.success) {
                
                let response_data = JSON.parse(response.booking);
                $('#modal-booking-' + RoomId).modal('hide');
                ShowPayment(response_data.BookingId);
            }
            else {
                ShowToaster('success', 'CONFIRM BOOKING', respons.message);
            }
        },
        error: function (xhr, status, error) {
            ShowToaster('error', 'Something went wrong : ' + error);
        }
    });
}

function ShowPayment(bookingId) {    
    

    let data = {
        BookingId: bookingId
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
                ShowToaster('error', 'SHOW PAYMENT', response.message);
            }
        },
        error: function (xhr, status, error) {
            ShowToaster('error', 'SHOW PAYMENT', error);
        }
    });

}



function GetBooking(RoomId) {
    
    let serializedData = $('#checking_info').serialize();  

    let data = {
        Id: RoomId,
        jsonData: serializedData       
    };
    
    $.ajax({
        url: '/Booking/CreateBooking',
        method: 'GET',
        data: data,
        success: function (response) {            
            
            if (response.success) {
                let modalContent = $('#modal-booking-content-' + RoomId);
                modalContent.empty();
                modalContent.html(response.htmlContent);
                $('#modal-booking-' + RoomId).modal('show');
            }
            else {
                ShowToaster('error', 'CHECK ROOM AVAILABITLIY', response.message);
            }

        },
        error: function (xhr, status, error) {         
            ShowToaster('warning', 'BOOKING', error + ', Please login first to procced booking. Thank you.');
        }
    });
}
