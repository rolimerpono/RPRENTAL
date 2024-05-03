function ShowPayment(Id) {

    $.ajax({
        url: '/Booking/ShowPayment',
        method: 'POST',
        data: { BookingId: Id },
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
            showToast('error', 'Something went wrong : ' + error);
        }
    });
}

function GetBooking(RoomId) {
    var serializedData = $('#checking_info').serialize();  
  
    $.ajax({
        url: '/Booking/CreateBooking',
        method: 'GET',
        data: { Id: RoomId, jsonData: serializedData },
        success: function (response) {
          
            let modalContent = $('#modal-booking-content-' + RoomId);           
            modalContent.empty().html(response);
            $('#modal-booking-' + RoomId).modal('show');   

        },
        error: function (xhr, status, error) {         
            ShowToaster('error', 'PAYMENT', error);
        }
    });
}
