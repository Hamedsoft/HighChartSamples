﻿using HighChart.Models;
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

        [HttpGet]
        public JsonResult GetComboDualAxesChartData()
        {
            var chartData = new
            {
                title = "فروش و تعداد مشتریان",
                yAxis1Title = "فروش (میلیون تومان)",
                yAxis2Title = "تعداد مشتریان",
                categories = new[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور" },
                series = new[]
                {
                new
                {
                    name = "فروش",
                    type = "column",    // 🔹 نمایش به صورت ستونی
                    data = new[] { 50, 70, 60, 80, 90, 100 },
                    yAxis = 0,           // 🔹 محور اول (چپ)
                    tooltip = new { valueSuffix = " میلیون تومان" }
                },
                new
                {
                    name = "مشتریان",
                    type = "spline",    // 🔹 نمایش به صورت خطی
                    data = new[] { 200, 240, 220, 280, 300, 320 },
                    yAxis = 1,           // 🔹 محور دوم (راست)
                    tooltip = new { valueSuffix = " نفر" }
                }
            }
            };

            return Json(chartData);
        }

        [HttpGet]
        public JsonResult GetBasicColumnChartData()
        {
            var chartData = new
            {
                title = "عملکرد فروش ماهانه",
                xAxisCategories = new[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور" },
                yAxisTitle = "فروش (میلیون تومان)",
                series = new[]
                {
                new
                {
                    name = "فروش سال 1401",
                    data = new[] { 50, 70, 60, 80, 90, 100 }
                },
                new
                {
                    name = "فروش سال 1402",
                    data = new[] { 65, 85, 75, 95, 105, 110 }
                }
            }
            };

            return Json(chartData);
        }

        [HttpGet]
        public JsonResult GetGaugeSpeedometerData()
        {
            var chartData = new
            {
                title = "سرعت خودرو",
                minValue = 0,
                maxValue = 220,
                currentValue = 140, // 🔹 مقدار فعلی سرعت
                zones = new[]
                {
                new { from = 0, to = 80, color = "#55BF3B" },     // 🔹 سبز (ایمن)
                new { from = 80, to = 160, color = "#DDDF0D" },  // 🔹 زرد (احتیاط)
                new { from = 160, to = 220, color = "#DF5353" }  // 🔹 قرمز (خطر)
            }
            };

            return Json(chartData);
        }

        public class HeatmapDataModel
        {
            public int X { get; set; }  // 🔹 موقعیت محور X
            public int Y { get; set; }  // 🔹 موقعیت محور Y
            public double Value { get; set; }  // 🔹 مقدار رنگ
        }

         [HttpGet]
    public JsonResult GetHeatmapData()
    {
            var data = new List<List<int>>
        {
            new List<int> { 0, 0, 10 }, new List<int> { 0, 1, 19 }, new List<int> { 0, 2, 8 }, new List<int> { 0, 3, 24 }, new List<int> { 0, 4, 67 },
            new List<int> { 1, 0, 92 }, new List<int> { 1, 1, 58 }, new List<int> { 1, 2, 78 }, new List<int> { 1, 3, 117 }, new List<int> { 1, 4, 48 },
            new List<int> { 2, 0, 35 }, new List<int> { 2, 1, 15 }, new List<int> { 2, 2, 123 }, new List<int> { 2, 3, 64 }, new List<int> { 2, 4, 52 },
            new List<int> { 3, 0, 72 }, new List<int> { 3, 1, 132 }, new List<int> { 3, 2, 114 }, new List<int> { 3, 3, 19 }, new List<int> { 3, 4, 16 },
            new List<int> { 4, 0, 38 }, new List<int> { 4, 1, 5 }, new List<int> { 4, 2, 8 }, new List<int> { 4, 3, 117 }, new List<int> { 4, 4, 115 },
            new List<int> { 5, 0, 88 }, new List<int> { 5, 1, 32 }, new List<int> { 5, 2, 12 }, new List<int> { 5, 3, 6 }, new List<int> { 5, 4, 120 },
            new List<int> { 6, 0, 13 }, new List<int> { 6, 1, 44 }, new List<int> { 6, 2, 88 }, new List<int> { 6, 3, 98 }, new List<int> { 6, 4, 96 },
            new List<int> { 7, 0, 31 }, new List<int> { 7, 1, 1 }, new List<int> { 7, 2, 82 }, new List<int> { 7, 3, 32 }, new List<int> { 7, 4, 30 },
            new List<int> { 8, 0, 85 }, new List<int> { 8, 1, 97 }, new List<int> { 8, 2, 123 }, new List<int> { 8, 3, 64 }, new List<int> { 8, 4, 84 },
            new List<int> { 9, 0, 47 }, new List<int> { 9, 1, 114 }, new List<int> { 9, 2, 31 }, new List<int> { 9, 3, 48 }, new List<int> { 9, 4, 91 }
        };

            return Json(data);
    }
    }
}