
    const btnCheck = document.getElementById('btnCheck');
    const roomListDiv = document.getElementById('room_list');

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
                roomListDiv.innerHTML = data;
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
    }
