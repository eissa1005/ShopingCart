using Microsoft.AspNetCore.Identity;

namespace ShopingCart.Domain.Entities
{
    public class UserTokens : IdentityUserToken<string> , IBaseEntity
    {
        
    }
}
