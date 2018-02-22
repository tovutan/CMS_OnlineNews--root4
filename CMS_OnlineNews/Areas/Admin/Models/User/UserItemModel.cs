

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace CMS_OnlineNews.Areas.Admin.Models.User
{
    [Serializable]
    public class UserItemModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "FullName")]
        public string FullName { get; set; }

        public string ImageURL { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; } 
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string RoleName { get; set; }
        //public Permission Permission { get; set; }
    }
}