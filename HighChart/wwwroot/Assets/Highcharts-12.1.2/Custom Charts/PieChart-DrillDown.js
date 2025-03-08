document.addEventListener('DOMContentLoaded', function () {
    $.getJSON('/Home/GetDrillDownPieChartData', function (data) {
        Highcharts.chart('PieChart-DrillDownContainer', {
            chart: { type: 'pie' },
            title: { text: data.title, align: 'right' },
            legend: { rtl: true, align: 'right' },
            plotOptions: {
                series: {
                    dataLabels: { enabled: true, format: '{point.name}: {point.y}' }
                }
            },
            series: data.series,
            drilldown: { // 🔹 اضافه کردن Drilldown
                series: data.drilldown
            },
            credits: { enabled: false } // 🔹 حذف "highcharts.com"
        });
    });
});