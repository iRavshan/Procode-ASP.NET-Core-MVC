﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.ViewModels.Dashboard
{
    public class DashboardAllSpeakersViewModel : ViewModel
    {
        public IEnumerable<Speaker> Speakers { get; set; }
    }
}
