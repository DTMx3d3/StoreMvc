using System.ComponentModel.DataAnnotations.Schema;

namespace StoreMvc.Models
{
    [Table("Cart")]
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public List<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    }
}