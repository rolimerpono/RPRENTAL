function GetBooking(room_id) {


    var objRoomData = $('#checking_info').serialize(); 
    
    $.ajax({
        type: 'GET',
        url: '/Booking/CreateBooking',
        data: {ID: room_id, jsonData: objRoomData},
        success: function (result) {

            $('#modal-booking-content').html(result);
            $('#modal-booking').modal('show');
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
        }
    }); 

}



