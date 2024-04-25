function showPayment(id) {

    $.ajax({
        url: '/Booking/ShowPayment',
        method: 'POST',
        data: { booking_id: id },
        success: function (response) {

            if (response.success) {

                window.location.href = response.redirectUrl;
            }
            else {
                showToast('error', 'Somethign went wrong : ' + response.message);
            }
        },
        error: function (xhr, status, error) {
            showToast('error', 'Something went wrong : ' + error);
        }
    });

}

function confirmBooking(room_id) {
    var serializedData = $('#checking_info').serialize();


    $.ajax({
        url: '/Booking/ConfirmBooking',
        method: 'POST',
        data: { ID: room_id, jsonData: serializedData },
        success: function (response) {
            if (response.success) {
                let response_data = JSON.parse(response.booking);

                $('#modal-booking-' + room_id).modal('hide');
                showPayment(response_data.BOOKING_ID);
            }
            else {
                showToast('error', 'Somethign went wrong : ' + response.message);
            }
        },
        error: function (xhr, status, error) {
            showToast('error', 'Something went wrong : ' + error);
        }
    });



}

function getBooking(room_id) {
    var serializedData = $('#checking_info').serialize();  
  
    $.ajax({
        url: '/Booking/CreateBooking',
        method: 'GET',
        data: { ID: room_id, jsonData: serializedData },
        success: function (response) {
          
            let modalContent = $('#modal-booking-content-' + room_id);           
            modalContent.empty().html(response);
            $('#modal-booking-' + room_id).modal('show');   

        },
        error: function (xhr, status, error) {
            showToast('error', 'Something went wrong : ' + error);
        }
    });
}

// Function to show toast messages
function showToast(type, message) {
    var toaster = $('.toaster');
    toaster.text(message);
    toaster.css({
        'display': 'block',
        'background-color': type === 'success' ? '#006400' : 'red',
        'opacity': 1
    });
    setTimeout(function () {
        toaster.css('opacity', 0);
        setTimeout(function () {
            toaster.css('display', 'none').css('opacity', 1);
        }, 500);
    }, 3000);
}
