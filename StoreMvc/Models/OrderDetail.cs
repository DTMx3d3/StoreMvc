
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreMvc.Models
{
    [Table ("OrderDetails")]
    public class OrderDetail
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [ForeignKey("Watch")]
        public int WatchId { get; set; }

       [Required]
        public int Quantity { get; set; }

        public virtual Order Order { get; set; } 

        public virtual Watch Watch { get; set; }
        public Cart Cart { get; set; }
    }
}
