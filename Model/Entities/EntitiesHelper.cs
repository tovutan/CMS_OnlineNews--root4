using Model.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public static class EntitiesHelper
    {
        public static T AddWhenAdd<T>(this T entity, string userId) where T : class, ILogEntity
        {
            entity.CreateDate = DateTime.Now;
            entity.CreateBy = userId;
            return entity;
        }

        public static T AddWhenEdit<T>(this T entity, string userId) where T : class, ILogEntity
        {
            entity.UpdateDate = DateTime.Now;
            entity.UpdateBy = userId;
            return entity;
        }

        public static T AddWhenDelete<T>(this T entity, string userId) where T : class, IBaseEntity, ILogEntity
        {
            entity.IsDeleted = true;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateBy = userId;
            return entity;
        }
    }
}
