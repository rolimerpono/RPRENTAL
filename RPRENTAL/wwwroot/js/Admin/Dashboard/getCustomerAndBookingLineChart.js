
$(document).ready(function () {
    loadMemberAndBookingLineChart();
});

function loadMemberAndBookingLineChart() {

    $.ajax({
        url: "/Dashboard/GetMemberAndBookingLineChartData",
        type: 'Get',
        dataType: 'json',
        success: function (data) {
            loadLineChart("newMembersAndBookingsLineChart", data);      
        }
    });
}

function loadLineChart(id, data) {
    let chartColors = getChartColor(id);
    let options = {
        series: data.series,        
        colors: chartColors,       
        stroke:
        {
            curve: 'smooth',
            show: true,
            width:2
        },
        chart: {
            type: 'line',
            height: '165%',
            width: '100%'
        },
        markers: {
            size: 3,
            strokeWidth: 0,
            hover: {
                size: 7,             
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
        tooltip:
        {
            theme: 'dark'
        }
    };

    let chart = new ApexCharts(document.querySelector("#" + id), options);
    chart.render();

}



