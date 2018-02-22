using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;
using PagedList.Mvc;
using Model.Services.Web;
using System.Collections;
using Model.ViewModel.Post;
using CMS_OnlineNews.Helper.Web;
using Model.ViewModel;
using System.Configuration;
using Model.ViewModel.Tag;

namespace CMS_OnlineNews.Controllers
{
    public class HomeController : Controller
    {
        private PostServices _PostServices = GetServicesHelper.Post;
        private CategoryServices _categoryServices= GetServicesHelper.Category;
        private NavigationServices _navigationServices = GetServicesHelper.Navigation;
        private TagServices _tagServices = GetServicesHelper.Tag;

        // GET: Home

        // WebConfig
        private int HOME_HOT_POST_NUM_IN_PAGE => int.Parse(ConfigurationManager.AppSettings["HomeHotPostNumInPage"]);//14
        private int HOME_LIST_POST_NUM_IN_PAGE => int.Parse(ConfigurationManager.AppSettings["HomeListPostNumInPage"]);//11
        private int LIST_POST_LOADING_NUM_IN_PAGE => int.Parse(ConfigurationManager.AppSettings["ListPostLoadingNumInPage"]); //5
        private int MOBILE_HOME_HOT_POST_NUM_IN_PAGE => int.Parse(ConfigurationManager.AppSettings["MobileHomeHotPostNumInPage"]);//3
        private int MOBILE_HOME_LIST_POST_NUM_IN_PAGE => int.Parse(ConfigurationManager.AppSettings["MobileHomeListPostNumInPage"]);//4
        private int CATEGORY_LIST_POST_NUM_IN_PAGE => int.Parse(ConfigurationManager.AppSettings["CategoryListPostNumInPage"]); //8
        private int SEARCH_BOX_TAG_LIST_NUM_IN_PAGE => int.Parse(ConfigurationManager.AppSettings["SearchBoxTagListNumInPage"]); //8
        private int HOME_SALE_POST_NUM_IN_PAGE => int.Parse(ConfigurationManager.AppSettings["HomeSalePostNumInPage"]); //5
        private int HOME_VIEW_POST_NUM_IN_PAGE => int.Parse(ConfigurationManager.AppSettings["HomeViewPostNumInPage"]); //6

        private const int CATEGORY_HOT_POST_NUM_IN_PAGE=0;


        public ActionResult Index()
        {
            PostListModel model=new PostListModel();
            //int hotPostNum = 14;
            //int ListPostNum = 11;
            var hotPostNum = Request.Browser.IsMobileDevice ? MOBILE_HOME_HOT_POST_NUM_IN_PAGE : HOME_HOT_POST_NUM_IN_PAGE;
            var ListPostNum = Request.Browser.IsMobileDevice ? MOBILE_HOME_LIST_POST_NUM_IN_PAGE : HOME_LIST_POST_NUM_IN_PAGE;

            var hotPosts = _PostServices.GetListPost(hotPostNum, isHot: true);
            var posts = _PostServices.GetListPost(ListPostNum, hotPostNum: hotPostNum);
            model.HotPosts = hotPosts.Convert(withUser: true);
            model.Posts = posts.Convert(withUser: true);

            if (model == null)
            {
                model = new PostListModel();
            }

            return View(model);

            //var hot = model.HotPosts.ToList();
            //var post = model.Posts.ToList();


            //var total = hot.Concat(post);
            //var result = total.OrderByDescending(x => x.CreateDate).ToPagedList(page ?? 1, 25);
            //return View(result);
        }

        public ActionResult Detail(string catURL,string postUrl)
        {
            PostDetailModel postDetai = new PostDetailModel();
            var post = _PostServices.GetPost(catURL, postUrl);

            //chi tiết 
            postDetai.Post = post.Convert(withFullDesc: true, withUser: true, withTag: true);

            // liên quan tác giả
            var postAuhor = _PostServices.GetPostAuthor(post.Id, post.CreateUser.Email);
            postDetai.PostAuthor = postAuhor.Convert(withUser: true);

            // bài viết liên quan
            var postRelated = _PostServices.GetListPost(3, categoryId: postDetai.Post.Category.Id, PostID: postDetai.Post.Id);
            postDetai.PostRelated = postRelated.Convert(catURL:catURL);

            return View(postDetai);
        }  
        [ChildActionOnly]
        public ActionResult NavigationBars()
        {
            IList<NavigationItemModel> model;
            var kq = _navigationServices.GetList();
            model= ConvertModel.Convert(kq);
            return PartialView(model);           
        }

        // TopViewPostRight (lượng xem nhiều)

        #region columnRight

        [ChildActionOnly]
        public PartialViewResult SearchTagRight(string url)
        {
            IList<TagItemModel> model;
            var tag = _tagServices.GetListInSearchBox(SEARCH_BOX_TAG_LIST_NUM_IN_PAGE); // GetListInSearchBox(int num)
            model = ConvertModel.Convert(tag, true);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult TopViewPostRight()
        {
            IList<PostItemModel> model;
            var kq = _PostServices.GetTopViewPost(6);
            model = ConvertModel.Convert(kq);
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult TopSalePostRight()
        {
            IList<PostItemModel> model;
            var topSalePosts = _PostServices.GetListPost(HOME_SALE_POST_NUM_IN_PAGE,categoryUrl:"tin-khuyen-mai");
            model = topSalePosts.Convert();

            return PartialView(model);
        }
        #endregion
        public ActionResult ListPostCategory(string catURL)
        {
            string layout = "Layout/";
            PostListModel model = new PostListModel();
            try
            {

                if (Request.Browser.IsMobileDevice)
                {
                    var cat = _categoryServices.Get(catURL, haveParner: false);
                    if (cat == null)
                    {
                        return null;

                    }
                    int hotNum;
                    switch (cat.CustomLayout)
                    {
                        case "KhuyenMai":
                            hotNum = 0;
                            break;
                        default:
                            hotNum = CATEGORY_HOT_POST_NUM_IN_PAGE;
                            break;
                    }
                    model.Category = _categoryServices.Get(catURL, haveParner: false).Convert(withSEO: true);
                    var hotPost = _PostServices.GetListPost(hotNum, categoryId: model.Category.Id, isHot: true);
                    var Post = _PostServices.GetListPost(CATEGORY_LIST_POST_NUM_IN_PAGE, categoryId: model.Category.Id, hotPostNum: hotNum);
                    model.HotPosts = hotPost.Convert(withUser: true);
                    model.Posts = Post.Convert(withUser: true);

                }
                else
                {
                    var cat = _categoryServices.Get(catURL, haveParner: false);
                    if (cat == null)
                    {
                        return null;
                    }
                    int hotNum;
                    switch (cat.CustomLayout)
                    {
                        case "KhuyenMai":
                            hotNum = 5;
                            break;
                        default:
                            hotNum = CATEGORY_HOT_POST_NUM_IN_PAGE;
                            break;
                    }

                    model.Category = _categoryServices.Get(catURL, haveParner: false).Convert(withSEO:true);
                    var hotPost = _PostServices.GetListPost(hotNum, categoryId: model.Category.Id, isHot: true);
                    var post = _PostServices.GetListPost(CATEGORY_LIST_POST_NUM_IN_PAGE, categoryId: model.Category.Id, hotPostNum: hotNum);
                    model.HotPosts = hotPost.Convert(withUser: true);
                    model.Posts = post.Convert(withUser: true);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            switch (model.Category.CustomLayout)
            {
                case "KhuyenMai":
                    layout += model.Category.CustomLayout;
                    break;
                case "KhachHang":
                    layout += model.Category.CustomLayout;
                    break;
                default:
                    layout += "Default";
                    break;
            }
            return View(layout,model);
        }


        #region Ajax    
        [HttpGet]
        public PartialViewResult ListPostHome(int page)
        {
            var hotPostNum = Request.Browser.IsMobileDevice ? MOBILE_HOME_HOT_POST_NUM_IN_PAGE : HOME_HOT_POST_NUM_IN_PAGE;
            var ListPostNum = Request.Browser.IsMobileDevice ? MOBILE_HOME_LIST_POST_NUM_IN_PAGE : HOME_LIST_POST_NUM_IN_PAGE;

            PostListModel model = new PostListModel();

            int start = ((page - 2) * LIST_POST_LOADING_NUM_IN_PAGE) + ListPostNum;// ((page-2)*5)+11;
            var posts = _PostServices.GetListPost(LIST_POST_LOADING_NUM_IN_PAGE, start: start, hotPostNum: MOBILE_HOME_HOT_POST_NUM_IN_PAGE);
            if (!posts.Any())
                return null;
            model.Posts = posts.Convert(withUser: true);
            return PartialView("ListPostBox",model.Posts);
        }

        [HttpGet]
        public PartialViewResult LoadPostCategory(int page, string catURL, int hotNum = 0)
        {
            //IList<PostItemModel> model;
            PostListModel model = new PostListModel();
            int start = ((page - 2) * LIST_POST_LOADING_NUM_IN_PAGE) + CATEGORY_LIST_POST_NUM_IN_PAGE; // ((page-2)*5)+8;
            var post = _PostServices.GetListPost(LIST_POST_LOADING_NUM_IN_PAGE, start: start, categoryUrl: catURL, hotPostNum: hotNum);
            if (!post.Any())
            {
                return null;
            }
           // model= ConvertModel.Convert(post, withUser: true);
            model.Posts = post.Convert(withUser: true);
            if (model == null)
            {
                return null;
            }            
            return PartialView("ListPostBox", model.Posts);

        }
        #endregion
        #region MethodImage

        #endregion

    }
}