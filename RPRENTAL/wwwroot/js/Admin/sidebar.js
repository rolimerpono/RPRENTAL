$(document).ready(function () {
    $("#navbar-toggler-btn").click(function () {
        $(".rotate-icon").toggleClass("rotate");
    });

    $('#dropdown-settings').click(function (e) {
        e.preventDefault();

        // Close other dropdown if open
        $('#reports-menu').slideUp('slow');
        $('#reports-icon').removeClass('bi-caret-down').addClass('bi-caret-right');

        $('#settings-icon').animate({
            transform: 'rotate(90deg)'
        }, 100, function () {
            $(this).toggleClass('bi-caret-right bi-caret-down');
        });

        $('#settings-menu').slideToggle('slow');
    });

    $('#dropdown-reports').click(function (e) {
        e.preventDefault();

        // Close other dropdown if open
        $('#settings-menu').slideUp('slow');
        $('#settings-icon').removeClass('bi-caret-down').addClass('bi-caret-right');

        $('#reports-icon').animate({
            transform: 'rotate(90deg)'
        }, 100, function () {
            $(this).toggleClass('bi-caret-right bi-caret-down');
        });

        $('#reports-menu').slideToggle('slow');
    });
});
