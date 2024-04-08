function GetBooking(room_id) {


    var objRoomData = $('#checking_info').serialize(); 
    debugger
    $.ajax({
        type: 'GET',
        url: '/Booking/CreateBooking',
        data: {ID: room_id, jsonData: objRoomData},
        success: function (result) {

            $('#modal-booking-content').html(result);
            $('#booking_detail_modal').modal('show');
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
        }
    }); 

}



