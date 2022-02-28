using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.ViewModels.Home
{
    public class HomeIndexViewModel : ViewModel
    {
        public IEnumerable<Speaker> Speakers { get; set; }
        public Content Thumbnail { get; set; }
    }
}
