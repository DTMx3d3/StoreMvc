using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreMvc.Models
{
    [Table ("Orders")]
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string userId { get; set; }
        [Required]
        public DateTime orderDate { get; set; }
        [Required]
        public string payType { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } 

    }
} 
