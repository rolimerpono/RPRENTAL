$(document).ready(function () {
    loadTotalBookingRadialChart();
});

function loadTotalBookingRadialChart() {


    $.ajax({
        url: "/Dashboard/GetTotalBookingRadialChartData",
        type: 'Get',
        dataType: 'json',
        success: function (data) {
            $('#total_booking_count').text(data.totalCount);    

            let sectionCurrentCount = document.createElement("span");
            if (data.hasRationIncreased) {
                sectionCurrentCount.className = "text-success me-1";
                sectionCurrentCount.innerHTML = '<i class="bi bi-arrow-up-right-circle me-1"></i> <span> ' + data.countInCurrentMonth + '</span>';
            }
            else {
                sectionCurrentCount.className = "text-danger me-1";
                sectionCurrentCount.innerHTML = '<i class="bi bi-arrow-down-right-circle me-1"></i> <span> ' + data.countInCurrentMonth + '</span>';
            }
            
            $('#booking_increase_decrease_status').append(sectionCurrentCount);
            $('#booking_increase_decrease_status').append("Since last month");

            loadRadialBarChart("total_booking_radial_chart", data);
        }


    });

}




