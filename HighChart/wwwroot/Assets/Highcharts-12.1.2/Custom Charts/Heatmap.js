$(document).ready(function () {
    $.ajax({
        url: '/Home/GetHeatmapData', // آدرس اکشن کنترلر
        type: 'GET',
        success: function (data) {
            Highcharts.chart('HeatmapContainer', {
                chart: {
                    type: 'line'
                },
                title: {
                    text: 'Sales per employee'
                },
                series: [{
                    name: 'Sales per employee',
                    borderWidth: 1,
                    data: data,
                    dataLabels: {
                        enabled: true,
                        color: '#000000'
                    }
                }],
                yAxis: {
                    title: {
                        text: 'Sales'
                    }
                },
                responsive: {
                    rules: [{
                        condition: {
                            maxWidth: 500
                        },
                        chartOptions: {
                            yAxis: {
                                labels: {
                                    formatter: function () {
                                        return this.value.toFixed(1);
                                    }
                                }
                            }
                        }
                    }]
                }
            });
        }
    });
});