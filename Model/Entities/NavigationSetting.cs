using Model.Entities;
using Model.Entities.Identity;
using Model.IEntities;
using System;
using System.ComponentModel;
using System.Linq;

namespace Model.Entities
{
    public class Navigation : ILogEntity    
    {
        public int Id { get; set; }

        [DefaultValue(0)]
        public int Priority { get; set; }

        public virtual int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string Title { get; set; }

        [DefaultValue(false)]
        public bool IsShow { get; set; }

        public string CustomURL { get; set; }

        #region Log
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual string CreateBy { get; set; }
        public virtual User CreateUser { get; set; }

        public virtual string UpdateBy { get; set; }
        public virtual User UpdateUser { get; set; }
        #endregion
    }
}
