using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Procode.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.Controllers
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

        public IActionResult Blog()
        {
            HomeBlogViewModel model = new HomeBlogViewModel()
            {
                Title = "Blog"
            };

            return View(model);
        }

        public IActionResult Content()
        {
            return View();
        }
    }
}
