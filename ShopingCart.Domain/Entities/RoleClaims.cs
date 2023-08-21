using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart.Domain.Entities
{
    public class RoleClaims : IdentityRoleClaim<string> , IBaseEntity
    {
       
    }
}
