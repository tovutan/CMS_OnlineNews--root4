
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_OnlineNews.Areas.Admin.Models
{
    [Serializable]
    public class ImageURLModel
    {
        public AvataImageUrlModel AvataImage { get; set; }
        public IList<string> ImageList { get; set; }
    }
}