using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Web
{
    public class CategoryServices:BaseServices
    {
        private static volatile CategoryServices _services = null;
        public static CategoryServices GetInstance()
        {
            if (_services == null)
            {
                lock (typeof(CategoryServices))
                {
                    _services = new CategoryServices();
                }
            }
            return _services;
        }

        private IOrderedQueryable<Category> _DefaultShowListCategory
        {
            get
            {
                return _db.Categories.Where(c =>
                    !c.IsDeleted
                    && c.IsShow
                ).OrderBy(c => c.Priority);
            }
        }

        public Category Get(string url, bool? haveParner = false)
        {
            var _return = _DefaultShowListCategory.FirstOrDefault(p =>
                p.URL == url
                && (haveParner.HasValue ? p.ParentId.HasValue == haveParner : true)
            );
            return _return;
        }
    }
}
