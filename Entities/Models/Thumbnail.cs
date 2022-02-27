using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Thumbnail
    {
        public string ThumbnailImagePath { get; set; }

        public string ThumbnailContentName { get; set; }

        public string ThumbnailContentAuthorName { get; set; }

        public string ThumbnailContentAuthorSurName { get; set; }

        public DateTime ThumbnailCreatedTime { get; set; }
    }
}
