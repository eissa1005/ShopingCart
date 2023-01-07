using System.ComponentModel;

namespace ShopingCart.Common
{
    public static class CategoryRoute
    {
        public const string Index ="/Category/Index";
        public const string AddNew ="/Category/AddNew";
        public const string Edit = "/Category/{id}";
        public const string Delete ="/Category/Delete";
    }
    public static class CustomerRoute
    {
        public const string Index = "/Customer/Index";
        public const string AddNew = "/Customer/AddNew";
        public const string Edit = "/Customer/Edit";
        public const string Delete = "/Customer/Delete";
    }

    public static class ItemsRoute
    {
        public const string Index = "/Items/Index";
        public const string AddNew = "/Items/AddNew";
        public const string Edit = "/Items/Edit";
        public const string Delete = "/Items/Delete";
    }

    public static class CartItemRoute
    {
        public const string Index = "/CartItem/Index";
        public const string AddNew = "/CartItem/AddNew";
        public const string Edit = "/CartItem/Edit";
        public const string Delete = "/CartItem/Delete";
    }
}
