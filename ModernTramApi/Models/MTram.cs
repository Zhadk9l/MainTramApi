using System.ComponentModel.DataAnnotations;

namespace ModernTramApi.Models
{
    public class MTram
    {
        [Key]
        public int Id { get; set; }
        public string BrandAndModel { get; set; }
        public string Condition { get; set; }
    }
}
