using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("VideoGame")]
        public int ProductId { get; set; }
        public VideoGame VideoGame { get; set; }

        public int Quantity { get; set; }


    }
}
