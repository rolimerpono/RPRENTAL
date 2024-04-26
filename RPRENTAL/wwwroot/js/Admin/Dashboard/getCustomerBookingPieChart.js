
$(document).ready(function () {
    loadTotalBookingPieChart();
});

function loadTotalBookingPieChart() {

    $.ajax({
        url: "/Dashboard/GetBookingPieChartData",
        type: 'Get',
        dataType: 'json',
        success: function (data) {
            loadPieChart("customer_increase_decrease_status", data);     
        }
    });
}

function loadPieChart(id, data) {
    let chartColors = getChartColor(id);
    let options = {
        series: data.series,
        colors: chartColors,
        chart: {
            type: 'pie',
            // Set fixed width and height
            width: 345,
            height: 345,
            position: 'absolute',
            left:0,
        },
        stroke: {
            show: false
        },
        labels: data.labels
    
    };

    var chart = new ApexCharts(document.querySelector("#" + id), options);
    chart.render();
}




