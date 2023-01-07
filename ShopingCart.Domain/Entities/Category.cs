using ShopingCart.Domain.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopingCart.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category() 
        {
            Items = new HashSet<Items>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } 
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<Items> Items { get; set; } 

    }
}
