using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace  CMS_OnlineNews.Areas.Admin.Models
{
    public class AlertModel
    {
         public enum ModeAlert
        {
            info,
            warning,
            danger,
            success
        }

        public ModeAlert Mode { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}