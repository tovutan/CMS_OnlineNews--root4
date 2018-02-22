
using Model.Services.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_OnlineNews.Helper.Web
{
    public static class GetServicesHelper
    {
        public static PostServices Post => PostServices.GetInstance();
        public static CategoryServices Category => CategoryServices.GetInstance();
        //public static TagServices Tag => TagServices.GetInstance();
        public static TagServices Tag => TagServices.GetInstance();
        public static NavigationServices Navigation => NavigationServices.GetInstance();

        public static PostServices _postServices(this Controller controller) => Post;
        public static CategoryServices _categoryServices(this Controller controller) => Category;
        public static TagServices _tagServices(this Controller controller) =>Tag ;

        public static NavigationServices _navigationServices(this Controller controller) => Navigation;
    }
}