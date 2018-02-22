using Model.ViewModel.Category;
using Model.ViewModel.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel.Post
{
    public class PostListModel
    {
        public IList<PostItemModel> HotPosts { get; set; }
        public IList<PostItemModel> Posts { get; set; }
        public CategoryItemModel Category { get; set; }
        public TagItemModel Tag { get; set; }
    }
}
