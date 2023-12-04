using System.ComponentModel.DataAnnotations;

namespace ModernTramApi.Models
{
    public class MTrRoute
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal RoutLength { get; set; }
        public int Duration { get; set; }
    }
}
