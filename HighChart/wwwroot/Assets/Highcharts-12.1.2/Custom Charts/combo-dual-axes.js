document.addEventListener('DOMContentLoaded', function () {
    $.getJSON('/Home/GetComboDualAxesChartData', function (data) {
        Highcharts.chart('ComboDualAxesChartContainer', {
            chart: { zoomType: 'xy' },
            title: { text: data.title, align: 'center' }, // 🔹 عنوان داینامیک
            xAxis: { categories: data.categories },
            yAxis: [
                { // 🔹 محور اول (فروش)
                    title: { text: data.yAxis1Title },
                    labels: { format: '{value} میلیون تومان' }
                },
                { // 🔹 محور دوم (مشتریان)
                    title: { text: data.yAxis2Title },
                    labels: { format: '{value} نفر' },
                    opposite: true
                }
            ],
            tooltip: {
                shared: true
            },
            legend: { rtl: true, align: 'right' },
            series: data.series, // 🔹 سری داده‌های داینامیک
            credits: { enabled: false } // 🔹 حذف "highcharts.com"
        });
    });
});