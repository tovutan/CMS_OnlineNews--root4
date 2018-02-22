using Model.Entities;
using Model.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities.Identity;

namespace Model.Store
{
    /// <summary>
    ///     EntityFramework based implementation
    /// </summary>
    /// <typeparam name="TRole"></typeparam>
    public class RoleStore : RoleStore<Role, string, UserRole>, IQueryableRoleStore<Role>
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        public RoleStore()
            : base(BaseServices.GetDBContext())
        {
            DisposeContext = true;
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="context"></param>
        public RoleStore(DbContext context) : base(context)
        {
        }
    }
}
