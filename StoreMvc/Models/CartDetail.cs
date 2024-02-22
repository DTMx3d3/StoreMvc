using System.ComponentModel.DataAnnotations.Schema;

namespace StoreMvc.Models
{
    [Table("CartDetails")]
    public class CartDetail
    {
        public int Id { get; set; } 
        public int CartId { get; set; } 
        public int WatchId { get; set; } 
        public int Quantity { get; set; }
        public Cart Cart { get; set; } 
        public Watch Watch { get; set; }
    }
}
