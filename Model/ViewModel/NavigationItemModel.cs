using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    [Serializable]
    public class NavigationItemModel
    {
        public string Title { get; set; }
        public string CustomTitle { get; set; }
        public string URL { get; set; }
        public string CustomURL { get; set; }
        public string SeoTitle { get; set; }
    }
}
