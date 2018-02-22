
using Model.ViewModel;
using Model.ViewModel.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Model.ViewModel.Category
{
    [Serializable]
    public class CategoryItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  URL { get; set; }
        public string Description  { get; set; }
        public string CustomLayout { get; set; }

        public CategoryItemModel ParnerCategory { get; set; }
        public AvataImageUrlModel ImageUrl { get; set; }

        #region SEO
        public string  SeoTitle { get; set; }
        public string SeoKeyword { get; set; }
        public string  SeoDescription { get; set; }
        #endregion
    }
}