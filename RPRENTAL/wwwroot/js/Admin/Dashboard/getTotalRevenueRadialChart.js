﻿
$(document).ready(function () {
    loadTotalRevenueRadialChart();
});

function loadTotalRevenueRadialChart() {


    $.ajax({
        url: "/Dashboard/GetRevenueChartData",
        type: 'Get',
        dataType: 'json',
        success: function (data) {       
            
            $('#total_revenue_count').text(data.totalCount.toLocaleString());

            let sectionCurrentCount = document.createElement("span");
            if (data.hasRationIncreased) {
                sectionCurrentCount.className = "text-success me-2";
                sectionCurrentCount.innerHTML = '<i class="bi bi-arrow-up-right-circle me-2"></i> <span> ' + data.countInCurrentMonth + '</span>';
            }
            else {
                sectionCurrentCount.className = "text-danger me-2";
                sectionCurrentCount.innerHTML = '<i class="bi bi-arrow-down-right-circle me-2"></i> <span> ' + data.countInCurrentMonth + '</span>';
            }

            $('#revenue_increase_decrease_status').append(sectionCurrentCount);
            $('#revenue_increase_decrease_status').append("Since last month");

            loadRadialBarChart("total_revenue_radial_chart", data);

        }


    });

}




