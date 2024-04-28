
$(document).ready(function () {
    LoadCutomerBookings();
});

function LoadCutomerBookings() {

    $.ajax({
        url: "/Dashboard/GetCustomerBookingPieChart",
        type: 'Get',
        dataType: 'json',
        success: function (data) {
            loadCustomerPieChart("customer_increase_decrease_status", data);
          
        }
    });
}

function loadCustomerPieChart(id, data) {   


    let chartColors = getChartColor(id);

    var options = {
        series: data.series,
        chart: {
            height: 160,
            type: 'pie',
        },
        labels: data.labels,    
        colors: chartColors,
        legend: {
            show: false,
            showForSingleSeries: false,
            showForNullSeries: true,
            showForZeroSeries: true,
            position: 'bottom',
            horizontalAlign: 'center',      
            offsetY: 10,

            itemMargin: {
                horizontal: 15,
                vertical: 0
            }       
           
        },
        responsive: [{
            breakpoint: 190,
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
