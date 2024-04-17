function jQueryPost(url, data) {
    return $.ajax({
        type: 'POST',
        url: url,
        data: data,
        dataType: 'json' 
    });
    
}

function jQueryGet(url, data) {
    return $.ajax({
        type: 'GET',
        url: url,
        data: data
    });
    
}

function showPayment(id) {
    jQueryPost('/Booking/ShowPayment', { booking_id: id })
        .done(function (paymentResponse) {
            window.location.href = paymentResponse.redirectUrl;
        })
        .fail(function (xhr, status, error) {
            console.error('Error calling showpayment controller: ' + error);
        });
}

function confirmBooking(room_id) {
    var serializedData = $('#checking_info').serialize();
    jQueryPost('/Booking/ConfirmBooking', { ID: room_id, jsonData: serializedData })
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

function getBooking(room_id) {
    var objRoomData = $('#checking_info').serialize();    
    jQueryGet('/Booking/CreateBooking', { ID: room_id, jsonData: objRoomData })
        .done(function (result) {
            var modalContent = $('#modal-booking-content-' + room_id);
            modalContent.empty().html(result);
            $('#modal-booking-' + room_id).modal('show');            
        })
        .fail(function (xhr, status, error) {   
            showToast('error', 'To proceed you need to login first.');
            console.error('This is the error : ' + error);
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
