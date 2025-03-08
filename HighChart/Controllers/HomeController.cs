using HighChart.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HighChart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult lineCSV()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetLineCSVChartData()
        {
            var chartData = new
            {
                title = "نمودار فروش ماهانه",  // 🔹 ارسال عنوان نمودار
                yAxisTitle = "مقدار (میلیون تومان)", // 🔹 ارسال عنوان محور Y
                categories = new[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" },
                series = new[]
                {
                    new { name = "نرخ", data = new[] { 10, 15, 25, 30, 40, 50, 10, 8, 24, 31, 12, 6 }, color = "#007bff" },
                    new { name = "میانگین خرید", data = new[] { 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18}, color = "#ff8000" },
                    new { name = "میانگین کمک", data = new[] { 17, 11, 38, 16, 49, 37, 39, 17, 37, 39, 24, 33}, color = "#fa4092" },

                }
            };
            return Json(chartData);
        }

        [HttpGet]
        public JsonResult GetDrillDownPieChartData()
        {
            var chartData = new
            {
                title = "فروش محصولات",
                series = new[]
                {
                new
                {
                    name = "محصولات",
                    colorByPoint = true,
                    data = new[]
                    {
                        new { name = "موبایل", y = 40, drilldown = "mobile" },
                        new { name = "لپ‌تاپ", y = 30, drilldown = "laptop" },
                        new { name = "لوازم جانبی", y = 20, drilldown = "accessories" },
                        new { name = "سایر", y = 10 , drilldown = "accessories" } // بدون Drilldown
                    }
                }
            },
                drilldown = new[]
                {
                new
                {
                    name = "موبایل",
                    id = "mobile",
                    data = new object[]
                    {
                        new object[] { "سامسونگ", 20 },
                        new object[] { "شیائومی", 15 },
                        new object[] { "اپل", 5 }
                    }
                },
                new
                {
                    name = "لپ‌تاپ",
                    id = "laptop",
                    data = new object[]
                    {
                        new object[] { "ایسوس", 15 },
                        new object[] { "لنوو", 10 },
                        new object[] { "دل", 5 }
                    }
                },
                new
                {
                    name = "لوازم جانبی",
                    id = "accessories",
                    data = new object[]
                    {
                        new object[] { "هندزفری", 10 },
                        new object[] { "کابل شارژ", 5 },
                        new object[] { "پاوربانک", 5 }
                    }
                }
            }
            };

            return Json(chartData);
        }
    }
}