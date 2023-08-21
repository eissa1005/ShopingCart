using Microsoft.AspNetCore.Identity;

namespace ShopingCart.Domain.Entities
{
    public class UserLogins : IdentityUserLogin<string> ,  IBaseEntity
    {
       
    }
}
