document.addEventListener("DOMContentLoaded", function () {
    fetch("/Home/GetHeatmapData") // آدرس متد API را تنظیم کنید
        .then(response => response.json())
        .then(data => {
            console.log("Received Data:", data)
            const chart = Highcharts.chart('heatmapContainer', {
                chart: {
                    type: 'heatmap',
                    plotBorderWidth: 1
                },
                title: {
                    text: 'Heatmap Example'
                },
                xAxis: {
                    categories: data.XCategories,  // اصلاح شد
                    title: { text: 'Names' }
                },
                yAxis: {
                    categories: data.YCategories,  // اصلاح شد
                    title: { text: 'Days' }
                },
                colorAxis: {
                    min: 0,
                    minColor: '#FFFFFF',
                    maxColor: Highcharts.getOptions().colors[0]
                },
                series: [{
                    name: 'Sales Data',
                    borderWidth: 1,
                    data: data.DataPoints.map(d => [d.x, d.y, d.value]), // اصلاح شد
                    dataLabels: {
                        enabled: true,
                        color: '#000000'
                    }
                }],
                tooltip: {
                    formatter: function () {
                        return `<b>${data.XCategories[this.point.x]}</b> - 
                        <b>${data.YCategories[this.point.y]}</b>: 
                        <b>${this.point.value}</b>`;
                    }
                }
            });
        })
        .catch(error => console.error('Error loading heatmap data:', error));
});
