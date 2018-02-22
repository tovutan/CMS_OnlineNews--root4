using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    [Serializable]
    public class AvataImageUrlModel
    {
        public string Original { get; set; }
        public string Medium { get; set; }
        public string Thumb { get; set; }
    }
}
