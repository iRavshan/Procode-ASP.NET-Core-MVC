using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.ViewModels.Dashboard
{
    public class DashboardIndexViewModel : ViewModel
    {
        public int SpeakersCount { get; set; }
        public int ContentsCount { get; set; }

        //public int UsersCount { get; set; }
        public IEnumerable<Speaker> LastSpeakers { get; set; }

        //public IEnumerable<IdentityUser> LastUsers { get; set; }
    }
}
