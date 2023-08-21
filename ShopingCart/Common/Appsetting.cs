namespace ShopingCart.Common
{
    public static class AppSetting
    {
        public static string  Premission = "Premission";
        public static string Product = "Product";
        public static string Purchase = "Purchase";
        public static string Sales = "Sales";

        public enum Roles
        {
            Admin,
            SuperAdmin,
            Basic,
            User,
        }
       
        public static List<string> GeneratePermissionsList(string module)
        {
            return new List<string>()
            {
                $"{AppSetting.Premission}.{module}.View",
                $"{AppSetting.Premission}.{module}.Add",
                $"{AppSetting.Premission}.{module}.Edit",
                $"{AppSetting.Premission}.{module}.Delete",
            };
        }
    }

}
