$(document).ready(function () {
    // Check if btnSoldOut or btnBookNow is visible
    var isBtnSoldOutVisible = $('#btnSoldOut').is(':visible');
    var isBtnBookNowVisible = $('#btnBookNow').is(':visible');

    // If either btnSoldOut or btnBookNow is visible, update btnBookNow action and route parameters
    if (isBtnSoldOutVisible || isBtnBookNowVisible) {
        $('#btnBookNow').attr('asp-action', 'GetRoomAvailable');       
    }
});
