using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Speaker
    {
        [Column("SpeakerId")]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Spikerning ismi")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Spikerning familiyasi")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "IT sohasidagi yo'nalishi")]
        public string Job { get; set; }

        [Required]
        [Display(Name = "Spikerga tegishli motivatsion so'zlar")]
        public string Quote { get; set; }

        [Required]
        [Display(Name = "Spikerning surati")]
        public string PhotoFilePath { get; set; }
    }
}
