$(document).ready(function () {
    $('#dropdownSettings').click(function () {
        // Toggle caret-right and caret-down classes with smooth transition
        $('#settings-icon').animate({
            transform: 'rotate(90deg)'
        }, 100, function () {
            $(this).toggleClass('bi-caret-right bi-caret-down');
        });
    });


    $('#dropdownMenuLink').click(function (e) {
        e.preventDefault();
        $('#dropdownMenu').slideToggle('slow'); // 'fast' for quick animation
    });


});
