
using CMS_OnlineNews.Areas.Admin.Models.Category;
using CMS_OnlineNews.Areas.Admin.Models.Tag;
using CMS_OnlineNews.Areas.Admin.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace CMS_OnlineNews.Areas.Admin.Models.Post
{
    [Serializable]
    public class PostItemModel
    {
        public int ID { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Xin nhập tiêu đề")]
        [MinLength(5, ErrorMessage = "Tiêu đề phải có ít nhất 5 ký tự")]
        public string Title { get; set; }

        [Display(Name = "Link thân thiện")]
        [Required(ErrorMessage ="Xin nhập link")]
        [MinLength(5, ErrorMessage = "Link phải có ít nhất 5 ký tự")]
        public string URL { get; set; }

        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Xin nhập mô tả")]
        [MinLength(5, ErrorMessage ="Mô tả phải có ít nhất 5 ký tự")]
        public string ShortDesc { get; set; }

        [Display(Name = "Nội dung")]
        [Required(ErrorMessage ="xin nhập nội dung")]
        [MinLength(10, ErrorMessage = "Nội dung phải có ít nhất 10 ký tự")]
        public string FullDesc { get; set; }

        public ImageURLModel ImageURL { get; set; }

        [Display(Name = "Danh mục")]
        public IList<CategoryItemModel> Category { get; set; }
        public string CreateBy { get; set; }

        public UserItemModel CreateUser { get; set; }

        public UserItemModel UpdateUser { get; set; }

        public IList<TagItemModel> Tags { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        [Display(Name = "Ngày bắt đầu hiển thị")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Ngày kết thúc hiển thị")]
        public DateTime? EndDate { get; set; }
        public bool IsShow { get; set; }
        public bool IsHot { get; set; }
        public bool IsAllowComment { get; set; }
        public int View { get; set; }
        public bool IsDraft { get; set; }
        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "Xin chọn hình đại diện")]
        [MinLength(1, ErrorMessage = "Xin chọn hình đại diện")]
        public string AvataImage { get; set; }
        
        #region SEO
        [StringLength(50, ErrorMessage = "Tối đa chỉ bao gồm 50 ký tự")]
        public string SeoTitle { get; set; }
        public string SeoKeyword { get; set; }
        [StringLength(150)]
        public string SeoDescription { get; set; }
        #endregion

        [Display(Name = "Tag")]
        public string TagsString { get; set; }
        [Display(Name = "Danh mục")]
        public List<int> TagsID { get; set; }
        [Display(Name ="Danh mục")]
        public List<int> CategoriesID { get; set; }

        public IList<ComboboxCategoryModel> CategoriesList { get; set; }
    }
}