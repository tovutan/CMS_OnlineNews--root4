using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace CMS_OnlineNews.Areas.Admin.Models.Category
{
    [Serializable]
    public class ComboboxCategoryModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PostCount { get; set; }
        public IList<ComboboxCategoryModel> ChildCategory { get; set; }
    }
}