

using Model.ViewModel;
using Model.ViewModel.Tag;
using Model.ViewModel.User;
using Model.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Model.ViewModel.Post
{
    [Serializable]
    public class PostItemModel
    {       
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public string ShortDesc { get; set; }
        public string FullDesc { get; set; }
        public ImageURLModel ImageURL { get; set; }
        public int TotalComment { get; set; }
        public CategoryItemModel Category { get; set; }
        public UserItemModel User { get; set; }
        public IList<TagItemModel> Tags { get; set; }
        public DateTime CreateDate { get; set; }
        public int View { get; set; }

        #region SEO
        public string SeoTitle { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoDescription { get; set; }
        #endregion
    }
}