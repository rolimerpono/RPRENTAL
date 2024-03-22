document.addEventListener("DOMContentLoaded", function () { 
    const btnCheck = document.getElementById("pageLink");
    btnCheck.addEventListener("click", function () {debugger

        const currentPage = document.getElementById("currentPage").value;
        const roomListDiv = document.getElementById("ROOM_LIST");


        const url = '/Home/PageList';
        const body = new URLSearchParams();
        body.append('iPage', currentPage);   


        fetch(url, {
            method: 'POST',
            body: body,
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        })
            .then(response => {debugger
                if (response.ok) {
                    return response.text();
                }
            }).then(data => {
                debugger

                roomListDiv.innerHTML = ''; 
                const responseDataDiv = document.createElement('div');
                responseDataDiv.innerHTML = data;
                roomListDiv.appendChild(responseDataDiv);

            })
            .catch(error => {
                console.error('There was a problem with the fetch operation:', error);
            });
    });
});
