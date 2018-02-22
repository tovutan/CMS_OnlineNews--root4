using Model.Entities;
using Model.Entities.Identity;
using System;
using System.Linq;

namespace Model.Mapping.Identity
{
    public partial class UserClaimMap : BaseMap<UserClaim>
    {
        public UserClaimMap()
        {
            this.ToTable("UserClaim");
            this.HasKey(uc => uc.Id);
        }
    }
}
