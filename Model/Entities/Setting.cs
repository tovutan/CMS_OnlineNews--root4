using Model.Entities.Identity;
using Model.IEntities;
using System;
using System.Linq;

namespace Model.Entities
{
    public class Setting
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        #region Log
        public DateTime? UpdateDate { get; set; }

        public virtual string UpdateBy { get; set; }
        public virtual User UpdateUser { get; set; }
        #endregion
    }
}
