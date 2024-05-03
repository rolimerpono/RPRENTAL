const room_list_div = document.getElementById('room_list');
function GetRoomAvailable(PageId = '') {
        
    let dateToday = new Date().toISOString().split('T')[0];    
    let checkInDate  = $('#CheckInDate').val();
    let checkOutDate = $('#CheckOutDate').val();

    if (checkOutDate < checkInDate || checkInDate <= dateToday)
    {
        ShowToaster('warning', 'DATE RANGE INVALID', 'Please provide a valid date range, and choose dates from tomorrow onwards. Thank you.');
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
