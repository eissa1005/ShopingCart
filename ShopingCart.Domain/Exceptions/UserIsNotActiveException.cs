namespace ShopingCart.Domain.Exceptions
{
    public class UserIsNotActiveException : Exception
    {
        public UserIsNotActiveException(): base("User Is Not Activated") { }
    }
}
