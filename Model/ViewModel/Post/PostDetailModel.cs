using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel.Post
{
    public  class PostDetailModel
    {
        public PostItemModel Post { get; set; }
        public IList<PostItemModel> PostAuthor { get; set; }
        public IList<PostItemModel> PostRelated { get; set; }
    }
}
