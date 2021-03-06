using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.ViewModels.Home
{
    public class HomeBlogViewModel : ViewModel
    {
        public IEnumerable<Content> Contents { get; set; }

        public IEnumerable<Content> LastContents { get; set; }
    }
}
