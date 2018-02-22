using Microsoft.AspNet.Identity.EntityFramework;

namespace Model.Entities.Identity
{
    public class UserClaim : IdentityUserClaim<string>
    {
        public virtual User User { get; set; }
    }
}
