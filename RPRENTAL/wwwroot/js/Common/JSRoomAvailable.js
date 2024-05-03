const room_list_div = document.getElementById('room_list');
function GetRoomAvailable(PageId = '') {
        
    let dateToday = new Date();
    let checkInDate  = $('#CheckInDate').val();
    let checkOutDate = $('#CheckOutDate').val();

    if (checkOutDate > checkInDate || checkInDate <= dateToday)
    {
        ShowToaster('error', 'DATE RANGE INVALID', 'Please provide a valid data range from tomorrow onwards. Thank you.');
        return;
    }

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
            ShowToaster('error', 'ROOMS', error);
        }
    });
}
