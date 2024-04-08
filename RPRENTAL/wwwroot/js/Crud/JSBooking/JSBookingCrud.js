function GetBooking(room_id) {


    var objRoomData = $('#checking_info').serialize(); 
    debugger
    $.ajax({
        type: 'GET',
        url: '/Booking/CreateBooking',
        data: {ID: room_id, jsonData: objRoomData},
        success: function (result) {
            $(modalContentSelector).html(result);
            $(modalContentSelector).modal('show');
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
        }
    }); 

}



