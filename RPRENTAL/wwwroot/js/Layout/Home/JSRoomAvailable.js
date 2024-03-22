$(document).ready(function () {

    const btnCheck = document.getElementById('btnCheck'); 

    btnCheck.addEventListener('click', function () {
        

        const checkInDate = document.getElementById('CheckInDate').value;
        const checkOutDate = document.getElementById('CheckOutDate').value;
        const roomListDiv = document.getElementById('room_list');

       


            const url = '/Home/GetRoomAvailable';
            const body = new URLSearchParams();
            body.append('CHECKIN_DATE', checkInDate);
            body.append('CHECKOUT_DATE', checkOutDate);

        if (checkOutDate >= checkInDate) {
            

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
                }).then(data => {
                    console.log(data);

                    roomListDiv.innerHTML = '';
                    const responseDataDiv = document.createElement('div');
                    responseDataDiv.innerHTML = data;
                    roomListDiv.appendChild(responseDataDiv);

                })
                .catch(error => {
                    console.error('There was a problem with the fetch operation:', error);
                });
        }

    });


    
   

});

function GetRoomAvailable(pageID) {    
    const checkInDate = document.getElementById('CheckInDate').value;
    const checkOutDate = document.getElementById('CheckOutDate').value;
    const roomListDiv = document.getElementById('room_list');
    




    const url = '/Home/GetRoomAvailable';
    const body = new URLSearchParams();
    body.append('CHECKIN_DATE', checkInDate);
    body.append('CHECKOUT_DATE', checkOutDate);
    body.append('iPage', pageID);

    if (checkOutDate >= checkInDate) {


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
            }).then(data => {
                console.log(data);

                roomListDiv.innerHTML = '';
                const responseDataDiv = document.createElement('div');
                responseDataDiv.innerHTML = data;
                roomListDiv.appendChild(responseDataDiv);

            })
            .catch(error => {
                console.error('There was a problem with the fetch operation:', error);
            });
    }

};

