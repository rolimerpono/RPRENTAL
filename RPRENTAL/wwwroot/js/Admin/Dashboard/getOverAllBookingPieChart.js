
$(document).ready(function () {
    LoadOverAllBookingPieChartData();
});

function LoadOverAllBookingPieChartData() {

    $.ajax({
        url: "/Dashboard/GetOverAllBookingPieChartData",
        type: 'Get',
        dataType: 'json',
        success: function (data) {
            loadPieChart("over_all_booking_status", data);
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
            width: 300,
            height: 300,
            position: 'absolute',
            left: 0,            
        },
    
        stroke: {
            show: false
        },
        labels: data.labels

    };

    var chart = new ApexCharts(document.querySelector("#" + id), options);
    chart.render();
}




