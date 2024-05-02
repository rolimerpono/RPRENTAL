const room_list_div = document.getElementById('room_list'); 

function GetRoomAvailable(PageId = '') {

    let checkInDate  = $('#CheckInDate').val();
    let checkOutDate = $('#CheckOutDate').val();

    $.ajax({
        url: '/Home/GetRoomAvailable',
        type: 'POST',
        data: { CheckinDate: checkInDate, CheckoutDate: checkOutDate, iPage : PageId },
        success: function (response) {                      
            if (response) {
                room_list_div.innerHTML = '';
                room_list_div.innerHTML = response;
            }          
        },
        error: function (xhr, status, error) {
            
        }
    });
}
