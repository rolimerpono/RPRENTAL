
$(document).ready(function () {
    loadMemberAndBookingBarChart();
});

function loadMemberAndBookingBarChart() {

    $.ajax({
        url: "/Dashboard/GetMemberAndBookingBarChartData",
        type: 'Get',
        dataType: 'json',
        success: function (data) {            
            loadBarChart("new_member_booking_and_customer_bar_chart", data);      
        }
    });
}

function loadBarChart(id, data) {
  
    var options = {
        series: data.series,
     
        chart: {
            type: 'bar',
            height: 185
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '10%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: data.categories,
            labels: {
                style: {
                    colors: "#fff",
                },
            }
        },      
        yaxis: {
            labels: {
                style: {
                    colors: "#fff",
                },
            }
        },
        fill: {
            opacity: 1
        }      
    };

    var chart = new ApexCharts(document.querySelector("#" + id), options);
    chart.render();
}





