document.addEventListener('DOMContentLoaded', function () {
    $.getJSON('/Home/GetChartData', function (data) {
        Highcharts.chart('chartContainer', {
            chart: { type: 'line' },
            title: { text: data.title, align: 'right' }, // 🔹 دریافت عنوان از کنترلر
            legend: { rtl: true, align: 'right' },
            xAxis: { categories: data.categories },
            yAxis: { title: { text: data.yAxisTitle } }, // 🔹 دریافت عنوان محور Y از کنترلر
            series: data.series,
            credits: { enabled: false } // 🔹 حذف "highcharts.com"
        });
    });
});