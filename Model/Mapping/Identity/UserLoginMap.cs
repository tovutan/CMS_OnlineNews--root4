using Model.Entities;
using Model.Entities.Identity;
using System;
using System.Linq;

namespace Model.Mapping.Identity
{
    public partial class UserLoginMap : BaseMap<UserLogin>
    {
        public UserLoginMap()
        {
            this.ToTable("UserLogin");
            this.HasKey(l => new { l.UserId, l.LoginProvider, l.ProviderKey });
        }
    }
}
