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

        [HttpGet]
        public JsonResult GetPackedBubbleData()
        {
            var chartData = new
            {
                title = "مقایسه فروش در دسته‌های مختلف",
                series = new[]
                {
                new
                {
                    name = "الکترونیک",
                    data = new[]
                    {
                        new { name = "موبایل", value = 40 },
                        new { name = "لپ‌تاپ", value = 30 },
                        new { name = "A01", value = 24 },
                        new { name = "A02", value = 31 },
                        new { name = "A03", value = 42 },
                        new { name = "A04", value = 22 },
                        new { name = "A05", value = 19 },
                        new { name = "A06", value = 17 },
                        new { name = "A07", value = 27 },
                        new { name = "A08", value = 32 },
                        new { name = "A09", value = 14 },
                        new { name = "A10", value = 15 },
                        new { name = "A11", value = 27 },
                        new { name = "A12", value = 21 },
                        new { name = "A13", value = 20 },
                        new { name = "A14", value = 33 },
                        new { name = "لوازم جانبی", value = 20 }
                    }
                },
                new
                {
                    name = "پوشاک",
                    data = new[]
                    {
                        new { name = "تی‌شرت", value = 25 },
                        new { name = "کفش", value = 15 },
                        new { name = "شلوار", value = 10 }
                    }
                },
                new
                {
                    name = "مواد غذایی",
                    data = new[]
                    {
                        new { name = "میوه", value = 35 },
                        new { name = "سبزیجات", value = 20 },
                        new { name = "نوشیدنی", value = 15 }
                    }
                }
            }
            };

            return Json(chartData);
        }

        [HttpGet]
        public JsonResult GetBubbleChartData()
        {
            var chartData = new
            {
                title = "نمودار حبابی فروش محصولات",
                xAxisTitle = "تعداد فروش",
                yAxisTitle = "میزان درآمد (میلیون تومان)",
                series = new[]
                {
                new
                {
                    name = "الکترونیک",
                    data = new[]
                    {
                        new object[] { 10, 20, 15 },  // [x, y, z]
                        new object[] { 25, 30, 40 },
                        new object[] { 40, 50, 30 }
                    }
                },
                new
                {
                    name = "پوشاک",
                    data = new[]
                    {
                        new object[] { 15, 10, 20 },
                        new object[] { 20, 25, 35 },
                        new object[] { 35, 40, 25 }
                    }
                },
                new
                {
                    name = "مواد غذایی",
                    data = new[]
                    {
                        new object[] { 5, 15, 10 },
                        new object[] { 10, 20, 25 },
                        new object[] { 30, 35, 20 }
                    }
                }
            }
            };

            return Json(chartData);
        }
    }
}