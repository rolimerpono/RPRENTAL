


function ConfirmBooking() {

    var serializedData = $('#checking_info').serialize();

    $.ajax({
        type: 'Post',
        url: '/Booking/ConfirmBooking',
        data: { jsonData: serializedData },
        success: function (result) {
            console.log('This is the result : ' + result);
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
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
            handleAjaxError(error);
        }
    }); 
}



