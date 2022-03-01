using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Procode.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> logger;
        private readonly IRepositoryManager repoManager;
        private readonly IWebHostEnvironment webHost;

        public DashboardController(ILogger<DashboardController> logger, IRepositoryManager repoManager, IWebHostEnvironment webHost)
        {
            this.logger = logger;
            this.repoManager = repoManager;
            this.webHost = webHost;
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
                repoManager.Contents.Create(content);
                
                repoManager.CompleteAsync();
                
                return View("~/Views/Account/Login.cshtml");
            }

            return View();
        }

        public IActionResult AllContents()
        {
            return View();
        }

        [HttpGet]
        public ViewResult AddSpeaker()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSpeaker(DashboardAddSpeakerViewModel speaker)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = string.Empty;
                if (speaker.Photo != null)
                {
                    string uploadFolder = Path.Combine(webHost.WebRootPath, "assets/img/speaker");
                    uniqueFileName = Guid.NewGuid() + "_" + speaker.Photo.FileName;
                    string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);
                    speaker.Photo.CopyTo(new FileStream(imageFilePath, FileMode.Create));
                }

                Speaker newSpeaker = new Speaker
                {
                    Id = Guid.NewGuid(),
                    Name = speaker.Name,
                    Surname = speaker.Surname,
                    Job = speaker.Job,
                    Quote = speaker.Quote,
                    PhotoFilePath = uniqueFileName
                };

                repoManager.Speakers.Create(newSpeaker);
                repoManager.CompleteAsync();
                return View("~/Views/Account/Login.cshtml");
            }

            return View();
        }

        public async Task<IActionResult> AllSpeakers()
        {
            DashboardAllSpeakersViewModel model = new DashboardAllSpeakersViewModel()
            {
                Title = "Barcha spikerlar",
                BannerTitle = "Barcha spikerlar",
                Speakers = Enumerable.Reverse(await repoManager.Speakers.GetAll())
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteSpeaker(Guid id)
        {
            repoManager.Speakers.Delete(id);
            repoManager.CompleteAsync();
            return RedirectToAction("allspeakers");
        }

        [HttpGet]
        public async Task<ViewResult> EditSpeaker(Guid id)
        {
            Speaker speaker = await repoManager.Speakers.GetById(id);

            DashboardEditSpeakerViewModel editModel = new DashboardEditSpeakerViewModel
            {
                Id = speaker.Id,
                Name = speaker.Name,
                Surname = speaker.Surname,
                Job = speaker.Job,
                Quote = speaker.Quote,
                ExistingPhotoFilePath = speaker.PhotoFilePath
            };

            return View(editModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditSpeaker(DashboardEditSpeakerViewModel model)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditSpaker(DashboardAddSpeakerViewModel model)
        {
            return View();
        }

    }
}
