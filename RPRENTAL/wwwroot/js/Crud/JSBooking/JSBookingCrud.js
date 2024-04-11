// Function to perform AJAX POST request
function ajaxPost(url, data) {
    return $.ajax({
        type: 'POST',
        url: url,
        data: data,
        dataType: 'json' // Assuming the response is JSON
    });
}

// Function to perform AJAX GET request
function ajaxGet(url, data) {
    return $.ajax({
        type: 'GET',
        url: url,
        data: data
    });
}

// Function to show payment
function showPayment(id) {
    ajaxPost('/Booking/ShowPayment', { booking_id: id })
        .done(function (paymentResponse) {
            window.location.href = paymentResponse.redirectUrl;
        })
        .fail(function (xhr, status, error) {
            console.error('Error calling showpayment controller: ' + error);
        });
}

// Function to confirm booking
function confirmBooking(room_id) {
    var serializedData = $('#checking_info').serialize();
    ajaxPost('/Booking/ConfirmBooking', { jsonData: serializedData })
        .done(function (response) {
            if (response.success) {
                var responseData = JSON.parse(response.booking);
                $('#modal-booking-' + room_id).modal('hide');
                showPayment(responseData.BOOKING_ID);
            }
        })
        .fail(function (xhr, status, error) {
            console.error('This is the error : ' + error);
        });
}

// Function to get booking
function getBooking(room_id) {
    var objRoomData = $('#checking_info').serialize();
    ajaxGet('/Booking/CreateBooking', { ID: room_id, jsonData: objRoomData })
        .done(function (result) {
            var modalContent = $('#modal-booking-content-' + room_id);
            modalContent.empty().html(result);
            $('#modal-booking-' + room_id).modal('show');
        })
        .fail(function (xhr, status, error) {
            console.error('This is the error : ' + error);
        });
}
