using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.ViewModels.Dashboard
{
    public class DashboardAddContentViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Kontent mavzusini kiriting")]
        [Display(Name = "Kontent mavzusi")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kontent muallifining ismini kiriting")]
        [Display(Name = "Kontent muallifining ismi")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Kontent muallifining familiyasi kiriting")]
        [Display(Name = "Kontent muallifining familiyasi")]
        public string AuthorSurname { get; set; }

        [Required(ErrorMessage = "Kontent haqida qisqacha tavsifni kiriting")]
        [Display(Name = "Qisqacha tavsifi")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Kontentning batafsil ma'lumotini kiriting")]
        [Display(Name = "Batafsil ma'lumot")]
        public string LongDescription { get; set; }

        [Display(Name = "Git repository uchun link")]
        public string GitUrl { get; set; }

        [Display(Name = "YouTube url linki")]
        public string YoutubeUrl { get; set; }

        [Display(Name = "Bo'lib o'tgan vaqti")]
        public DateTime CreatedTime { get; set; }

        [Display(Name = "Thumbnail surati")]
        public IFormFile ThumbnailPhotoFilePath { get; set; }
    }
}
