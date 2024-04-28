
$(document).ready(function () {
    LoadCutomerBookings();
});

function LoadCutomerBookings() {

    $.ajax({
        url: "/Dashboard/GetCustomerBookingPieChart",
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
            width: 300,
            height: 300,
            position: 'absolute',
            left: 0,
        },      
        labels: data.labels

    };

    var chart = new ApexCharts(document.querySelector("#" + id), options);
    chart.render();
}




