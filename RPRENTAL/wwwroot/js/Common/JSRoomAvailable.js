const room_list_div = document.getElementById('room_list');
function GetRoomAvailable(PageId = '') {
    let checkInDate  = $('#CheckInDate').val();
    let checkOutDate = $('#CheckOutDate').val();
    

    $.ajax({
        url: '/Home/GetRoomAvailable',
        type: 'GET',
        data: { CheckinDate: checkInDate, CheckoutDate: checkOutDate, iPage : PageId },
        success: function (response) {   
            
            if (response.success) {
                room_list_div.innerHTML = '';
                room_list_div.innerHTML = response.htmlContent;
            }
            else {
                ShowToaster('warning', 'CHECK ROOM AVAILABILITY', response.message);
            }
            
        },
        error: function (xhr, status, error) {
            ShowToaster('error', 'CHECK ROOM AVAILABILITY', error);
        }
    });
}
