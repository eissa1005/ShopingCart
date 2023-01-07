using ShopingCart.Application.Core.Models;

namespace ShopingCart.Application.Core.Services
{
    public interface IEmailService
    {
        void SenMail(Email email);
    }
}
