document.addEventListener('DOMContentLoaded', function () {
    $.getJSON('/Home/GetGaugeSpeedometerData', function (data) {
        Highcharts.chart('GaugeSpeedometerChartContainer', {
            chart: {
                type: 'gauge',
                plotBorderWidth: 0,
                plotBackgroundColor: null,
                plotBackgroundImage: null,
                height: '80%'
            },
            title: { text: data.title, align: 'center' }, // 🔹 عنوان داینامیک

            pane: {
                startAngle: -150,
                endAngle: 150,
                background: [{
                    backgroundColor: '#EEE',
                    borderWidth: 0
                }]
            },

            yAxis: {
                min: data.minValue,
                max: data.maxValue,
                title: { text: 'کیلومتر بر ساعت' },
                plotBands: data.zones // 🔹 محدوده‌های رنگی
            },

            series: [{
                name: 'سرعت',
                data: [data.currentValue],
                tooltip: { valueSuffix: ' km/h' }
            }],

            credits: { enabled: false } // 🔹 حذف "highcharts.com"
        });
    });
});