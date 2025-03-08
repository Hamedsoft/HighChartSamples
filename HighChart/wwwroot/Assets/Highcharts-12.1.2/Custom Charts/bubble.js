document.addEventListener('DOMContentLoaded', function () {
    $.getJSON('/Home/GetBubbleChartData', function (data) {
        Highcharts.chart('BubbleChartContainer', {
            chart: { type: 'bubble', plotBorderWidth: 1, zoomType: 'xy' },
            title: { text: data.title, align: 'center' }, // 🔹 عنوان داینامیک
            xAxis: { title: { text: data.xAxisTitle }, gridLineWidth: 1 }, // 🔹 عنوان محور X
            yAxis: { title: { text: data.yAxisTitle } }, // 🔹 عنوان محور Y
            legend: { rtl: true, align: 'right' },
            plotOptions: {
                bubble: {
                    minSize: 10,
                    maxSize: 100,
                    dataLabels: {
                        enabled: true,
                        format: '{point.name}'
                    }
                }
            },
            series: data.series, // 🔹 سری داده‌های داینامیک
            credits: { enabled: false } // 🔹 حذف "highcharts.com"
        });
    });
});