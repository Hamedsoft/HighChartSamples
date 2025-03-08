document.addEventListener('DOMContentLoaded', function () {
    $.getJSON('/Home/GetBasicColumnChartData', function (data) {
        Highcharts.chart('column-basicContainer', {
            chart: { type: 'column' },
            title: { text: data.title, align: 'center' }, // 🔹 عنوان داینامیک
            xAxis: {
                categories: data.xAxisCategories,
                crosshair: true
            },
            yAxis: {
                title: { text: data.yAxisTitle }
            },
            tooltip: {
                shared: true,
                useHTML: true
            },
            legend: { rtl: true, align: 'right' },
            plotOptions: {
                column: {
                    borderWidth: 0,
                    dataLabels: {
                        enabled: true
                    }
                }
            },
            series: data.series, // 🔹 سری داده‌های داینامیک
            credits: { enabled: false } // 🔹 حذف "highcharts.com"
        });
    });
});