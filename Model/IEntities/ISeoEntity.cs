using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.IEntities
{
    public interface ISeoEntity
    {
        string SeoTitle { get; set; }
        string SeoKeyword { get; set; }
        string SeoDescription { get; set; }
    }
}
