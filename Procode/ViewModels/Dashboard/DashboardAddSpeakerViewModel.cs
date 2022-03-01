using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.ViewModels.Dashboard
{
    public class DashboardAddSpeakerViewModel
    {
        [Column("SpeakerId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Spikerning ismini kiriting")]
        [Display(Name = "Spikerning ismi")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Spikerning familiyasini kiriting")]
        [Display(Name = "Spikerning familiyasi")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Ushbu maydonni to'ldiring")]
        [Display(Name = "IT sohasidagi yo'nalishi")]
        public string Job { get; set; }

        [Required(ErrorMessage = "Ushbu maydonni to'ldiring")]
        [MinLength(20, ErrorMessage = "Gap eng kamida 20 ta so'zdan iborat bo'lishi kerak")]
        [Display(Name = "Spikerga tegishli motivatsion so'zlar")]
        public string Quote { get; set; }

        [Required(ErrorMessage = "Profil suratini tanlang")]
        [Display(Name = "Spikerning surati")]
        public IFormFile Photo { get; set; }
    }
}
