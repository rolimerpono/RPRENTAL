const objRoomListDiv = document.getElementById('room_list');
const btnCheckAvailability = document.getElementById('check-availability');
 
function sendFetchRequest(url, body) {

    fetch(url, {
        method: 'POST',
        body: body,
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        }
    })
        .then(response => {

            if (response.ok) {
                return response.text();
            }
            throw new Error('Network response was not ok.');
        })
        .then(data => {              
            objRoomListDiv.innerHTML = '';
            objRoomListDiv.innerHTML = data;
            console.log(data);
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });
}




function GetRoomAvailable(pageID = '') {
    const checkInDate = document.getElementById('CheckInDate').value;
    const checkOutDate = document.getElementById('CheckOutDate').value;

    if (checkOutDate >= checkInDate) {
        const url = '/Home/GetRoomAvailable';
        const body = new URLSearchParams();
        body.append('CHECKIN_DATE', checkInDate);
        body.append('CHECKOUT_DATE', checkOutDate);
        body.append('iPage', pageID);

        sendFetchRequest(url, body);
    }
    else {
        showToast('error', 'Warning!, Checkout date should be greater than or equal to checkin date. Thank you.');
    }
}



function showToast(type, message) {
    var toaster = $('.toaster');
    toaster.text(message);
    toaster.css('display', 'block').css('backgroundColor', type === 'success' ? '#006400' : 'red').css('opacity', 1);
    setTimeout(function () {
        toaster.css('opacity', 0);
        setTimeout(function () {
            toaster.css('display', 'none').css('opacity', 1);
        }, 500);
    }, 3000);
}