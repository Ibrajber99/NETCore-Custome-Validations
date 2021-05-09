using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NET_Core_Custome_Validations.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;


namespace NET_Core_Custome_Validations.Controllers
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

        [HttpGet]
        public IActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProfile(Profile inputModel)
        {
            //The validation attribute gets called
            //before checking if the Model state if it's valid.

            try
            {
                if (ModelState.IsValid)
                {
                    //Worked. no issues!!   
                }
            }
            catch (Exception)
            {

                throw;
            }

            return View(inputModel);
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
    }
}
