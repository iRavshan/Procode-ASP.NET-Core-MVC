using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> logger;

        private readonly IRepositoryManager repoManager;

        public DashboardController(ILogger<DashboardController> logger, IRepositoryManager repoManager)
        {
            this.logger = logger;
            this.repoManager = repoManager;
        }

        [HttpGet]
        public ViewResult Content()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Content(Content content)
        {
            if (ModelState.IsValid)
            {
                Content econtent = new Content
                {
                    Id = Guid.NewGuid(),
                    Name = content.Name,
                    Author = content.Author,
                    LongDescription = content.LongDescription,
                    ShortDescription = content.ShortDescription,
                    GitUrl = content.GitUrl,
                    YoutubeUrl = content.YoutubeUrl,
                    CreatedTime = DateTime.Now
                };

                repoManager.Contents.Create(econtent);

                repoManager.CompleteAsync();

                return View("~/Views/Home/Index.cshtml");
            }

            return View();
        }
    }
}
