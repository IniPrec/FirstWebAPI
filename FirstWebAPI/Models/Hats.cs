using System.ComponentModel.DataAnnotations;

namespace FirstWebAPI.Models
{
    public class Hats
    {
        [Key]
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string Size { get; set; }
    }
}
