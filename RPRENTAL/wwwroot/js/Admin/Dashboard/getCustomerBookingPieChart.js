
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

    var options = {
        series: data.series,
        chart: {
            height: 480,
            type: 'pie',
        },
        labels: data.series,
        legend: {
            position: 'bottom',
            fontSize: '24px',
            fontWeight: 600,
        },
        colors: chartColors,
        responsive: [{
            breakpoint: 480,
            options: {
                chart: {
                    width: 200
                },
            }
        }]
    };
    var chart = new ApexCharts(document.querySelector("#" + id), options);
    chart.render();

}
