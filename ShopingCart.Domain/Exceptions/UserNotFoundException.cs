namespace ShopingCart.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User Not Found"){}

    }
}
