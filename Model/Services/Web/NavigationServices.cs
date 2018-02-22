using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Web
{
    public class NavigationServices:BaseServices
    {
        private static volatile NavigationServices _navigationServices = null;
        public static NavigationServices GetInstance()
        {
            if (_navigationServices == null)
            {
                lock (typeof(NavigationServices))
                {
                    _navigationServices = new NavigationServices();
                }
            }
            return _navigationServices;
        }
        private IOrderedQueryable<Navigation> _DefaultShowListNavigation
        {
            get
            {
                return _db.Navigations.Where(n => n.IsShow).OrderByDescending(n => n.Priority).ThenBy(n => n.Id);
            }
        }
        public IList<Navigation> GetList()
        {
            return _DefaultShowListNavigation.ToList();
        }

    }
}
