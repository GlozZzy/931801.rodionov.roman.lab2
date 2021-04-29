using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lab2_2.Models;

namespace Lab2_2.Controllers
{
    public class CalculationController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CalculationController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult ManualSingle()
        {
            if (Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                CalculationModel calc = new CalculationModel();
                if (Request.Form["Val1"] == "" && Request.Form["Val2"] == "")
                {
                    calc.Val1 = 0;
                    calc.Val2 = 0;
                }
                else if (Request.Form["Val1"] != "" && Request.Form["Val2"] == "")
                {
                    calc.Val1 = Int32.Parse(Request.Form["Val1"]); 
                    calc.Val2 = 0;
                }
                else if (Request.Form["Val1"] == "" && Request.Form["Val2"] != "")
                {
                    calc.Val1 = 0;
                    calc.Val2 = Int32.Parse(Request.Form["Val2"]);
                }
                else
                {
                    calc.Val1 = Int32.Parse(Request.Form["Val1"]);
                    calc.Val2 = Int32.Parse(Request.Form["Val2"]);
                }

                calc.Operation = Request.Form["Operation"];
                calc.calc_Result();
                ViewBag.Result = calc.Result;
                return View("Result");
            }
            else return View();
        }


        [HttpGet]
        public IActionResult ManualSeparate()
        {
            return View();
        }

        [HttpPost, ActionName("ManualSeparate")]
        public IActionResult ManualSeparatePost()
        {
            CalculationModel calc = new CalculationModel();
            if (Request.Form["Val1"] == "" && Request.Form["Val2"] == "")
            {
                calc.Val1 = 0;
                calc.Val2 = 0;
            }
            else if (Request.Form["Val1"] != "" && Request.Form["Val2"] == "")
            {
                calc.Val1 = Int32.Parse(Request.Form["Val1"]);
                calc.Val2 = 0;
            }
            else if (Request.Form["Val1"] == "" && Request.Form["Val2"] != "")
            {
                calc.Val1 = 0;
                calc.Val2 = Int32.Parse(Request.Form["Val2"]);
            }
            else
            {
                calc.Val1 = Int32.Parse(Request.Form["Val1"]);
                calc.Val2 = Int32.Parse(Request.Form["Val2"]);
            }

            calc.Operation = Request.Form["Operation"];
            calc.calc_Result();
            ViewBag.Result = calc.Result;
            return View("Result");
        }


        [HttpGet]
        public IActionResult ModelParam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModelParam(int Val1, int Val2, string Operation)
        {
            CalculationModel calc = new CalculationModel();
            calc.Val1 = Val1;
            calc.Val2 = Val2;
            calc.Operation = Operation;
            calc.calc_Result();
            ViewBag.Result = calc.Result;
            return View("Result");
        }


        [HttpGet]
        public IActionResult ModelSeparate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModelSeparate(CalculationModel calc)
        {
            calc.calc_Result();
            ViewBag.Result = calc.Result;
            return View("Result");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

