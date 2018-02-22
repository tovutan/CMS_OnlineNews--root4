using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Model.ViewModel.Tag
{
    [Serializable]
    public class TagItemModel
    {
        public int Id { get; set; }

        public string  Name { get; set; }
        public string URL { get; set; }
        public string ImageURL { get; set; }

        #region SEO

        public string SeoTitle { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoDescription { get; set; }

        #endregion

    }
}