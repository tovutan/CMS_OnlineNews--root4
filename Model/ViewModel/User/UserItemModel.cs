
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Model.ViewModel.User
{
    [Serializable]
    public class UserItemModel
    {
        public string Id { get; set; }
        public string Email  { get; set; }
        public string FullName { get; set; }
        public string ImageURL { get; set; }

        public string AuthorName { get; set; }
        public string  Description { get; set; }

    }
}