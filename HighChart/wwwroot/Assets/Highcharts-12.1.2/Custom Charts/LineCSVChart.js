document.addEventListener('DOMContentLoaded', function () {
    $.getJSON('/Home/GetLineCSVChartData', function (data) {
        Highcharts.chart('lineCSVchartContainer', {
            chart: { type: 'line' },
            title: { text: data.title, align: 'center' }, // 🔹 دریافت عنوان از کنترلر
            legend: { rtl: true, align: 'right' },
            xAxis: { categories: data.categories },
            yAxis: { title: { text: data.yAxisTitle } }, // 🔹 دریافت عنوان محور Y از کنترلر
            series: data.series,
            credits: { enabled: false } // 🔹 حذف "highcharts.com"
        });
    });
});