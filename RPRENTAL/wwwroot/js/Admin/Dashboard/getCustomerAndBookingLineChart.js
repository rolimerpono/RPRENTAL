
$(document).ready(function () {
    loadMemberAndBookingLineChart();
});

function loadMemberAndBookingLineChart() {

    $.ajax({
        url: "/Dashboard/GetMemberAndBookingLineChartData",
        type: 'Get',
        dataType: 'json',
        success: function (data) {
            loadLineChart("new_member_booking_and_customer_line_chart", data);      
        }
    });
}

function loadLineChart(id, data) {

    var options = {
        series: data.series,
        chart: {
            height: 183,
            type: 'line',
            zoom: {
                enabled: false
            },
        },
        dataLabels: {
            enabled: false
        },

        stroke:
        {
            curve: 'smooth',
            show: true,
            width: 2,
            dashArray: [0, 9, 2]
        },   
        markers: {
            size: 0,
            hover: {
                sizeOffset: 6
            }
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
        legend:
        {
            labels:
            {
                colors: "#fff",
            },
        },
        tooltip: {
         
        },
        grid: {
            borderColor: '#f1f1f1',
        }
    };

    var chart = new ApexCharts(document.querySelector("#" + id), options);
    chart.render();

}

//function loadLineChart(id, data) {
//    let chartColors = getChartColor(id);
//    let options = {
//        series: data.series,        
//        colors: chartColors,       
//        stroke:
//        {
//            curve: 'smooth',
//            show: true,
//            width:2
//        },
//        chart: {
//            type: 'line',
//            height: '165%',
//            width: '100%'
//        },
//        markers: {
//            size: 3,
//            strokeWidth: 0,
//            hover: {
//                size: 7,             
//            }
//        },
//        xaxis: {          
//            categories: data.categories,
//            labels: {
//                style: {
//                    colors: "#fff",
//                },
//            }
//        },
//        yaxis: {
//            labels: {
//                style: {
//                    colors: "#fff",
//                },
//            }
//        },
//        legend:
//        {
//            labels:
//            {
//                colors: "#fff",
//            },
//        },
//        tooltip:
//        {
//            theme: 'dark'
//        }
//    };

//    let chart = new ApexCharts(document.querySelector("#" + id), options);
//    chart.render();

//}



