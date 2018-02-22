using Model.Entities;
using Model.Entities.Identity;
using System;
using System.Linq;

namespace Model.Mapping.Identity
{
    public partial class UserRoleMap : BaseMap<UserRole>
    {
        public UserRoleMap()
        {
            this.ToTable("UserRole");
            this.HasKey(r => new { r.UserId, r.RoleId });
        }
    }
}
