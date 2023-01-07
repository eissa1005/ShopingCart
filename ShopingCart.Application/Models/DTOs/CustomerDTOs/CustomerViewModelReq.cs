namespace ShopingCart.Application.Models.DTOs.CustomerDTOs
{
    public class CustomerViewModelReq
    {
        public int ID { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
