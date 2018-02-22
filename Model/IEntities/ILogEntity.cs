
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entities.Identity;
using System.Threading.Tasks;

namespace Model.IEntities
{
    public interface ILogEntity
    {
        DateTime CreateDate { get; set; }
       
        DateTime? UpdateDate { get; set; }
        string CreateBy { get; set; }
        User CreateUser { get; set; }
        string UpdateBy { get; set; }
        User UpdateUser { get; set; }

        #region Log
        //public DateTime CreateDate { get; set; }
        //public DateTime? UpdateDate { get; set; }

        //[Required]
        //public virtual string CreateBy { get; set; }
        //public virtual User CreateUser { get; set; }

        //public virtual string UpdateBy { get; set; }
        //public virtual User UpdateUser { get; set; }
        #endregion
    }
}
