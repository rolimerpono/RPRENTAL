


function ConfirmBooking(room_id) {

    var serializedData = $('#checking_info').serialize();

    $.ajax({
        type: 'Post',
        url: '/Booking/ConfirmBooking',
        data: { jsonData: serializedData },
        success: function (response) {
            if (response.success) {
                let responseData = JSON.parse(response.booking);          
                $('#modal-booking-' + room_id).modal('hide');  
            }
        },
        error: function (xhr, status, error) {
            console.log('This is the error : ' + error);
        }
    });
}

function ShowPayment(id) {    

    $.ajax({
        type: 'Post',
        url: '/Booking/ShowPayment',
        data: { booking_id: id },
        success: function (paymentResponse) {
            debugger
            alert('This is the response : ' + paymentResponse);           
        },
        error: function (xhr, status, error) {
            console.log('Error calling showpayment controller: ' + error);
        }
    });
}

function GetBooking(room_id) {

    var objRoomData = $('#checking_info').serialize(); 
    
    $.ajax({
        type: 'GET',
        url: '/Booking/CreateBooking',
        data: {ID: room_id, jsonData: objRoomData},
        success: function (result) {
            $('#modal-booking-content-' + room_id).html('');
            $('#modal-booking-content-'+ room_id).html(result);
            $('#modal-booking-'+ room_id).modal('show');
        },
        error: function (xhr, status, error) {
            console.log('This is the error : ' + error);
        }
    }); 
}



