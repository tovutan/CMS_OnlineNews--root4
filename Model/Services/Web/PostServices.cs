
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Web
{
    public class PostServices:BaseServices
    {
        private static volatile PostServices _postServices = null;
        public static PostServices GetInstance()
        {
            if (_postServices == null)
            {
                lock (typeof(PostServices))
                {
                    _postServices = new PostServices();
                }
            }
            return _postServices;
        }

        // lấy ra danh sách bài Post bình thường
        private IOrderedQueryable<Post> _DefaultShowPostList
        {
            get
            {
                return _db.Posts.Where(p =>
                !p.IsDeleted
                && !p.IsDraft
                && p.IsShow
                && p.Categories.Where(c => c.IsShow && !c.IsDeleted).Any()
                && (!p.StartDate.HasValue || p.StartDate <= DateTime.Now)
                && (!p.EndDate.HasValue || p.EndDate >= DateTime.Now)
                ).OrderByDescending(p => p.StartDate ?? p.CreateDate);
            }
        }
        public IList<Post> GetListPost(
            int num,
            int start = 0,
            bool? isHot = null,
            string categoryUrl = null,
            int? categoryId = null,
            string tagURL = null,
            int? tagId = null,
            int? PostID = null,
            int hotPostNum = 0)
        {
            // lấy ra danh sách theo các điều kiện 
            var _return = _DefaultShowPostList.Where(p =>
             isHot.HasValue ? p.IsHot ==isHot: true // nếu nó có giá trị thì trả về isHot, ngược lại là true.
             && (string.IsNullOrEmpty(categoryUrl) ? true :
             p.Categories.Any(c => c.URL.CompareTo(categoryUrl) == 0 ||
             (c.ParentCategory != null || c.ParentCategory.URL.CompareTo(categoryUrl) == 0)
             ))
             && (!categoryId.HasValue ? true :
             p.Categories.Any(c => c.Id == categoryId
             || (c.ParentCategory != null || c.ParentCategory.Id == categoryId)
             ))
             && (string.IsNullOrEmpty(tagURL) ? true : p.Tags.Any(t => t.URL.CompareTo(tagURL) == 0))
                    && (!tagId.HasValue ? true : p.Tags.Any(t => t.Id == tagId))
                    //&& (!postsId.Any() ? true: !postsId.Any(pp => pp == p.Id))//(string.IsNullOrEmpty(postURL) ? true : p.URL.CompareTo(postURL) != 0)
                    && (!PostID.HasValue ? true : PostID != p.Id)
            );
            if (hotPostNum > 0)
            {
                // nếu HotPostNum >0 thì lấy ra danh sách hotpost, đồng thời khi lấy danh sách Post sẽ 
                // loại ra những hotPost đó.

                //IQueryable<Post> hotPost = _return.Where(p => p.IsHot).Take(num);
                //_return = _return.Where(p => !hotPost.Any(hp => hp.Id == p.Id));

                IQueryable<Post> hotPost = _return.Where(p => p.IsHot).Take(num);
                _return = _return.Where(p => !hotPost.Any(hp => hp.Id == p.Id));
            }
            _return = _return.Skip(start).Take(num);
            return _return.ToList();  // sẽ lấy ra dạng IQuery, Ienumrable, nếu xảy ra lỗi ở đây thì là Lỗi TimeOut. có thể do dữ liệu Ram còn ít
        }

        public IList<Post> GetTopViewPost(int num)
        {
            var _return = _DefaultShowPostList.OrderByDescending(p => p.View).Take(num);
            return _return.ToList();
        }

        public Post GetPost(string catURL, string url)
        {
            var _return = _DefaultShowPostList.FirstOrDefault(
                    p => p.URL == url
                    && p.Categories.Any(c => c.URL.CompareTo(catURL) == 0)
                );
            return _return;
        }
        // lấy ra những bài viết liên quan đến tác giả
        public IList<Post> GetPostAuthor(int postId, string email, int start=0, int num=4)
        {
            var _return = _DefaultShowPostList.Where(p => p.CreateUser.Email == email && p.Id != postId).Skip(start).Take(num);
            return _return.ToList();
        }
    }
    
}
