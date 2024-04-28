function loadRadialBarChart(id, data) {

    let chartColors = getChartColor(id);

  
    let options = {
        chart: {
            height: 200,
            width: 200,
            type: 'radialBar',
            left:0,
            position: 'absolute'
        },

        series: data.series,
        colors: chartColors,
        plotOptions: {
            radialBar: {            
                dataLabels: {                    
                    value: {
                        color: '#fff',
                        fontSize: '12px',
                        show: true,
                        offsetY:-12
                    }
                }
            }
        },        
        labels: ['']
    };

    var chart = new ApexCharts(document.querySelector("#" + id), options);

    chart.render();


}

function getChartColor(id) {
    if (document.getElementById(id) != null) {
        let colors = document.getElementById(id).getAttribute("data-colors");

        if (colors) {
            colors = JSON.parse(colors);
            return colors.map(function (value) {
                let new_color = value.replace(" ", "");
                if (new_color.indexOf(",") === -1) {
                    var color = getComputedStyle(document.documentElement).getPropertyValue(new_color);
                    if (color) return color;
                    else return new_color;
                }
            });
        }

    }

}