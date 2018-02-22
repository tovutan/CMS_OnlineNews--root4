
using CMS_OnlineNews.Areas.Admin.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace CMS_OnlineNews.Areas.Admin.Models.Category
{
    [Serializable]
    public class CategoryItemModel
    {
        public int ID { get; set; }

        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Xin nhập tên danh mục")]
        [MinLength(5, ErrorMessage = "Tên danh mục phải có ít nhất 5 ký tự")]
        public string Name { get; set; }
        [Display(Name = "Link thân thiện")]
        [Required(ErrorMessage = "Xin nhập link")]
        [MinLength(5, ErrorMessage = "Link phải có ít nhất 5 ký tự")]
        public string URL { get; set; }
        [Display(Name = "Hình đại diện")]
        public AvataImageUrlModel ImageURL { get; set; }
        [Display(Name = "Hình đại diện")]
        public string AddImageURL { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Danh mục cha")]
        public int? ParnerID { get; set; }
        public CategoryItemModel ParnerCategory { get; set; }
        public ICollection<CategoryItemModel> ChildCategory { get; set; }
        [Display(Name = "Layout tùy chỉnh")]
        public string CustomLayout { get; set; }
        #region SEO
        [StringLength(50, ErrorMessage = "Tối đa chỉ bao gồm 50 ký tự")]
        public string SeoTitle { get; set; }
        public string SeoKeyword { get; set; }
        [StringLength(150)]
        public string SeoDescription { get; set; }
        #endregion
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public UserItemModel CreateBy { get; set; }
        public UserItemModel UpdateBy { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsShow { get; set; }
    }
}