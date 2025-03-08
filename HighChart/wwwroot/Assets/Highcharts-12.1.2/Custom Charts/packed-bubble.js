document.addEventListener('DOMContentLoaded', function () {
    $.getJSON('/Home/GetPackedBubbleData', function (data) {
        Highcharts.chart('packed-bubblechartContainer', {
            chart: { type: 'packedbubble', height: '100%' },
            title: { text: data.title, align: 'center' },
            legend: { rtl: true, align: 'right' },
            tooltip: {
                useHTML: true,
                pointFormat: '<b>{point.name}:</b> {point.value}'
            },
            plotOptions: {
                packedbubble: {
                    minSize: '20%',
                    maxSize: '100%',
                    zMin: 0,
                    zMax: 100,
                    layoutAlgorithm: {
                        splitSeries: true,
                        gravitationalConstant: 0.02
                    },
                    dataLabels: {
                        enabled: true,
                        format: '{point.name}',
                        style: {
                            color: 'black',
                            textOutline: 'none',
                            fontWeight: 'normal'
                        }
                    }
                }
            },
            series: data.series, // 🔹 سری داده‌های داینامیک
            credits: { enabled: false } // 🔹 حذف "highcharts.com"
        });
    });
});