using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Content
    {
        [Column("ContentId")]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Kontent mavzusi")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Kontent muallifi")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Qisqacha tavsifi")]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "Batafsil ma'lumot")]
        public string LongDescription { get; set; }

        [Required]
        [Display(Name = "Sarlavha uchun surat")]
        public string ThumbnailUrl { get; set; }

        [Display(Name = "Git repository uchun link")]
        public string GitUrl { get; set; }

        [Display(Name = "YouTube url linki")]
        public string YoutubeUrl  { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
