using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_OnlineNews.Areas.Admin.Models.Category
{
    public class CategoryListModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int? ParnerID { get; set; }
    }
}