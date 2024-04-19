$(document).ready(function () { 


    $('#dropdown-settings').click(function (e) {
        e.preventDefault();

        $('#settings-icon').animate({
            transform: 'rotate(90deg)'
        }, 100, function () {
            $(this).toggleClass('bi-caret-right bi-caret-down');
        });

        $('#dropdownMenu').slideToggle('slow'); // 'fast' for quick animation


    });

    $('#btn-toggler').click(function (e) {
        e.preventDefault(); 
        $('#sidebarMenu').removeClass('collapse');

    });


});
