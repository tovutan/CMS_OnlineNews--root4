using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activities;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using PagedList;
using PagedList.Mvc;
using Newtonsoft.Json;
using CMS_OnlineNews.Helper.Admin;
using CMS_OnlineNews.Areas.Admin.Models;
using CMS_OnlineNews.Areas.Admin.Models.Post;
using CMS_OnlineNews.Areas.Admin.Models.User;
using Model.Services.Web;
using Model.Entities;

namespace CMS_OnlineNews.Areas.Admin.Controllers
{
   
    public class PostController : BaseController
    {
        private PostServices _postServices = PostServices.GetInstance();
        private CategoryServices _categoryServices = CategoryServices.GetInstance();

        //private UserServices _userServices = UserServices.GetInstance();
        //private TagServices _tagsServices = TagServices.GetInstance();
        //private ApplicationDbContext _db = PostServices.GetDBContext();
        // GET: Admin/Post

    
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(int? page=1,int pagesize=10)
        {

            //var kq = _postServices.Posts.OrderBy(p => p.StartDate ?? p.CreateDate).ToPagedList(page??1,10);
            //return View(kq);
            return View();
        }
        public ActionResult Detail(int Id)
        {
            //var kq = ol.Posts.FirstOrDefault(x => x.Id == Id);
            //return View(kq);
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PostItemModel model)
        {
            //var post = ol.Posts.FirstOrDefault(x => x.Id == model.ID);
            //using (var transaction = ol.Database.BeginTransaction())
            //{
            //var user = ol.Users.FirstOrDefault(x=>x.Id==model.ID);
            //try
            //{
            //    if (User.IsInRole("User") && !User.IsInRole("Admin") && !User.IsInRole("Manager"))
            //    {
            //if(post.CreateBy != User.id)
            //{
            //    return RedirectToAction("List", new { id = model.ID });
            //}                    
            //            }
            //        }
            //        catch (Exception ex)
            //        {

            //            throw;
            //        }
            //    }
            return View();
        }
        //[HttpPost]
        //public JsonResult GetList(int take = 20, int skip = 0, IEnumerable<Kendo.DynamicLinq.Sort> sort = null, Kendo.DynamicLinq.Filter filter = null)
        //{
        //    var post = ol.Posts.OrderBy(p => p.StartDate ?? p.CreateDate).Select(
        //        t => new
        //        {
        //            t.Id,
        //            t.Title,
        //            t.ImageURL,
        //            t.URL,
        //            AuthorName = t.CreateBy,
        //            t.CreateDate,
        //            t.IsShow
        //        });
        //    return Json(post.ToList(), JsonRequestBehavior.AllowGet);
        //}

        #region CheckData


        [NonAction]
        private bool CheckHaveNewImage(Post post, PostItemModel model)
        {
            if (string.IsNullOrEmpty(post.ImageURL))
            {
                return true;
            }
            try
            {
                var oldImage = JsonConvert.DeserializeObject<ImageURLModel>(post.ImageURL);
                if (oldImage.AvataImage != null && oldImage.AvataImage.Original == model.AvataImage)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return true;
            }
            return true;

        }
        #endregion


        private void AddDataToPost(Post post, PostItemModel model, UserItemModel curUser)
        {
            post.Title = model.Title;
            post.StartDate = model.StartDate;
            post.EndDate = model.EndDate;
            post.ShortDesc = model.ShortDesc;
            post.FullDesc = model.FullDesc;

            #region Image
            if (CheckHaveNewImage(post, model))
            {
                var imageUrl = new ImageURLModel();
                var imageOriganalUrl = $"{ImageHelper.IMAGE_URL}{model.ID}/{ImageHelper.IMAGE_ORIGINAL_Folder}/";
                var imageThumbPathURL = $"{ImageHelper.IMAGE_URL}{model.ID}/{ImageHelper.IMAGE_THUMB_Folder}/";
                var imageThumbPath = Server.MapPath(imageThumbPathURL);
                var imageOriganalPhy = Server.MapPath(model.AvataImage);
                imageUrl.AvataImage = new AvataImageUrlModel()
                {
                    Original = model.AvataImage,
                    Medium = imageThumbPathURL + ImageHelper.ResizeImageMedium(imageOriganalPhy, imageThumbPath),
                    Thumb = imageThumbPathURL + ImageHelper.ResizeImageThumb(imageOriganalPhy, imageThumbPath)
                };
                imageUrl.ImageList = ImageHelper.GetImageInFolder(Server.MapPath(imageOriganalUrl));
                post.ImageURL = JsonConvert.SerializeObject(imageUrl);
            }
            #endregion

            #region SEO
                post.SeoTitle = model.SeoTitle;
                post.SeoDescription = model.SeoDescription;
                post.SeoKeyword = model.SeoKeyword;
            #endregion

            #region Add Setting

            if (!post.IsShow && model.IsShow)
            {
                post.IsShow = model.IsShow;
                post.PublicBy = curUser.Id;
                post.PublicDate = DateTime.Now;
            }
            post.IsHot = model.IsHot;
            post.IsAllowComment = model.IsAllowComment;
            #endregion

            #region Add Category
            post.Categories.Clear();
            //var cat = ol.Posts.Where(model.CategoriesID.);
            #endregion

        }


    }
}