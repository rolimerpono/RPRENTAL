$(document).ready(function () {

    var screenWidth = $(window).width();

    $(window).resize(function () {
       
        if ($(window).width() != screenWidth) {
            location.reload(); // Refresh the page
        }
    });

    $("#navbar-toggler-btn").click(function () {
        $(".rotate-icon").toggleClass("rotate");
    });


    $('#dropdown-settings').click(function (e) {
        e.preventDefault();

        $('#settings-icon').animate({
            transform: 'rotate(90deg)'
        }, 100, function () {
            $(this).toggleClass('bi-caret-right bi-caret-down');
        });

        $('#settings-menu').slideToggle('slow'); // 'fast' for quick animation


    });

    $('#btn-toggler').click(function (e) {
        e.preventDefault();
        $('#sidebarMenu').removeClass('collapse');

    });


});