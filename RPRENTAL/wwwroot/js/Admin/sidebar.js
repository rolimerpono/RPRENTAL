$(document).ready(function () {
    $('.dropdown-toggle').on('click', function () {
        var icon = $('#settingsIcon');       

        // Apply super slow transition
        icon.css('transition', 'transform 3s ease');

        // Toggle icon class
        icon.toggleClass('bi-caret-right bi-caret-down');

        // Remove transition after animation completes
        setTimeout(function () {
            icon.css('transition', '');
        }, 3000); // Adjust the delay to match the transition duration
    });
});
