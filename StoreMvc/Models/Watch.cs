using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreMvc.Models
{

    [Table ("Watch")]
    public class Watch
    {

        public int id { get; set; }
      [System.ComponentModel.DataAnnotations.Required]
        public string brand { get; set; }
        public string model { get; set; }
        public double price { get; set; }
        [MaxLength (255)]
        public string ImageUrl { get; set; }
    }
}
