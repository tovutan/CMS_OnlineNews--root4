using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_OnlineNews.Areas.Admin.Models
{
    [Serializable]
    public class AvataImageUrlModel
    {
        public string Original { get; set; }
        public string Medium { get; set; }
        public string Thumb { get; set; }

    }
}