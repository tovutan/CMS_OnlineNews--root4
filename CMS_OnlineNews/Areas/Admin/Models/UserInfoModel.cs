using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_OnlineNews.Areas.Admin.Models
{
    public class UserInfoModel
    {
        public string ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ImageURL { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
    }
}