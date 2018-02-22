using Model.Entities;
using Model.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Model.Entities.Identity;

namespace Model.Store
{
    /// <summary>
    ///     EntityFramework based user store implementation that supports IUserStore, IUserLoginStore, IUserClaimStore and
    ///     IUserRoleStore
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    public class UserStore : UserStore<User, Role, string, UserLogin, UserRole, UserClaim>, IUserStore<User>
    {
        /// <summary>
        ///     Default constuctor which uses a new instance of a default EntityyDbContext
        /// </summary>
        public UserStore()
            : this(BaseServices.GetDBContext())
        {
            DisposeContext = true;
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="context"></param>
        public UserStore(DbContext context)
            : base(context)
        {

        }

        public override Task<User> FindByNameAsync(string userName)
        {
            return GetUserAggregateAsync(u => u.UserName.ToUpper() == userName.ToUpper() && !u.IsDeleted);
        }
    }
}
