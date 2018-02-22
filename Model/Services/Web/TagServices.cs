using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Web
{
    public class TagServices:BaseServices
    {
        private static volatile TagServices _tagServices = null;
        public static TagServices GetInstance()
        {
            if (_tagServices == null)
            {
                lock (typeof(TagServices))
                {
                    _tagServices = new TagServices();
                }
            }
            return _tagServices;
        }

        private IOrderedQueryable<Tag> _DefaultShowListTag
        {
            get
            {
                 return _db.Tags.Where(
                        t => t.IsShow
                        && !t.IsDeleted

                    ).OrderBy(t => t.Posts.Count());
            }
        }
        public Tag Get(string url)
        {
            var _return = _DefaultShowListTag.FirstOrDefault(
                    t => t.URL.CompareTo(url) == 0);
            return _return;
        }

        public IList<Tag> GetListInSearchBox(int num)
        {
            var _return = _DefaultShowListTag.Where(t => t.PinInSearch).Take(num);
            return _return.ToList();
        }
    }
}
