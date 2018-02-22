
using Model.ViewModel;
using Model.ViewModel.Post;
using Newtonsoft.Json;
using System;
using Utility;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.ViewModel.Category;
using Model.ViewModel.Tag;
using Model.ViewModel.User;
using Model.Entities.Identity;
using Model.Entities;

namespace CMS_OnlineNews.Helper.Web
{
    public static class ConvertModel
    {
        //private const string IMAGE_USER_DEFAULE = @"images/news/user.png";
        private const string IMAGE_USER_DEFAULE = "/images/news/user.png";
        private static readonly int POST_SHORT_DESC_LIMIT = int.Parse("150");

        #region Post
        // input vào là các giá trị của Post output là các giá trị của PostItemModel
        public static PostItemModel Convert(
            this Post post,
            bool withFullDesc = true,
            bool withUser = false,
            bool withTag = false,
            string catURL = null
            )
        {
            var _return = new PostItemModel()
            {
                Id = post.Id,
                URL = post.URL,
                CreateDate = post.StartDate ?? post.CreateDate,
                View = post.View
            };
            if (!string.IsNullOrEmpty(post.ImageURL))
            {
                try
                {
                    _return.ImageURL = JsonConvert.DeserializeObject<ImageURLModel>(post.ImageURL);
                }
                catch (Exception ex)
                {

                }
            }
            var cat = post.Categories.FirstOrDefault(c =>
                (string.IsNullOrEmpty(catURL) ? true : c.URL.CompareTo(catURL) == 0)
                && !c.IsDeleted
                && c.IsShow
            );
            if (cat != null)
                _return.Category = Convert(cat);

            if (withFullDesc)
            {
                _return.Title = post.Title;
                _return.ShortDesc = post.ShortDesc;
                _return.FullDesc = post.FullDesc;
                _return.SeoTitle = post.SeoTitle;
                _return.SeoKeyword = post.SeoKeyword;
                _return.SeoDescription = post.SeoDescription;
            }
            else
            {
                _return.Title = post.Title;
                _return.ShortDesc = StringLength.TrimLenght(post.ShortDesc,150);//HttpUtility.HtmlDecode(Utility.TrimLength(FPTShopUtils.RemoveHTMLTag((post.ShortDesc)), 220));
            }
            if (withUser)
            {
                _return.User = Convert(post.CreateUser, withDescription: withFullDesc);
            }
            if (withTag)
            {
                if (post.Tags.Any())
                {
                    _return.Tags = Convert(post.Tags.ToList());
                }
            }
            return _return;
        }

        // truyền vào các giá trị của Post để truyền ra các các giá trị cho PostItemModel
        public static IList<PostItemModel> Convert(this ICollection<Post> listPost, bool withUser = false, string catURL = null)
        {
            return listPost.Where(p => !p.IsDeleted && p.IsShow).Select(p => Convert(p,
                  withFullDesc: false,
                  withUser: withUser,
                  catURL: catURL
                  )).ToList();

            //var kq = listPost.Where(p => !p.IsDeleted && p.IsShow).Select(p => Convert(p,
            //       withFullDesc: false,
            //     withUser: withUser,
            //      catURL: catURL
            //       ));
            //return kq.ToList();
        }
        #endregion

        #region Category
        public static CategoryItemModel Convert(
            this Category category,
            bool withDescription = false,
            bool withSEO = false,
            bool withParner = false
            )
        {
            var _return = new CategoryItemModel()
            {
                Id = category.Id,
                Name = category.Name,
                URL = category.URL,
                CustomLayout = category.CustomLayout
            };
            if (withDescription)
            {
                _return.Description = category.Description;
            }
            if (withSEO)
            {
                _return.SeoTitle = category.SeoTitle;
                _return.SeoKeyword = category.SeoKeyword;
                _return.SeoDescription = category.SeoDescription;
            }
            if (withParner)
            {
                if (category.ParentCategory != null)
                    _return.ParnerCategory = Convert(category.ParentCategory);
            }
            return _return;
        }
        public static IList<CategoryItemModel> Convert(
            this ICollection<Category> listCategory,
            bool withDescription = false,
            bool withSEO = false
            )
        {
            return listCategory.Where(c => !c.IsDeleted && c.IsShow).Select(t => Convert(t,
                  withDescription: withDescription,
                  withSEO: withSEO
                  )).ToList();
        }
        #endregion

        #region Tag
        public static TagItemModel Convert(
            this Tag tag,
            bool withSEO = false
            )
        {
            var _return = new TagItemModel()
            {
                Id = tag.Id,
                Name = tag.Name,
                URL = tag.URL
            };
            if (withSEO)
            {
                _return.SeoTitle = tag.SeoTitle;
                _return.SeoKeyword = tag.SeoKeyword;
                _return.SeoDescription = tag.SeoDescription;
            }
            return _return;
        }
        public static IList<TagItemModel> Convert(
            this ICollection<Tag> listTag,
            bool withSEO = false
            )
        {
            return listTag.Where(t => !t.IsDeleted && t.IsShow).Select(t => Convert(t,
                withSEO: withSEO
                )).ToList();
        }
        #endregion

        #region User
        public static UserItemModel Convert(
            this User user,
            bool withDescription = false
            )
        {
            var _return = new UserItemModel()
            {
                Id = user.Id,
                Email = user.Email
            };
            _return.FullName = user.FullName;
            _return.ImageURL = string.IsNullOrEmpty(user.ImageURL) ? IMAGE_USER_DEFAULE : user.ImageURL;
            _return.AuthorName = user.AuthorName;
            if (withDescription)
                _return.Description = user.Description;
            else
            {
                _return.ImageURL = IMAGE_USER_DEFAULE;
            }
            return _return;
        }
        #endregion

        #region Navigation
        public static NavigationItemModel Convert(this Navigation navi)
        {
            var _return = new NavigationItemModel()
            {
                CustomTitle = navi.Title,
                CustomURL = navi.CustomURL,
                SeoTitle = navi.Title
            };
            if (navi.Category != null)
            {
                _return.Title = navi.Category.Name;
                _return.URL = navi.Category.URL;
                _return.SeoTitle = navi.Category.SeoTitle;
            }
            return _return;

        }
        public static IList<NavigationItemModel> Convert(this ICollection<Navigation> navi)
        {
            return navi.Where(t => t.IsShow).Select(t => Convert(t)).ToList();
        }
        #endregion
    }
}