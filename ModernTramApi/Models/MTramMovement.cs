using System.ComponentModel.DataAnnotations;

namespace ModernTramApi.Models
{
    public class MTramMovement
    {
        [Key]
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Coordinates { get; set; }
        public decimal Speed { get; set; }
        public string Direction { get; set; }
        public int TramId { get; set; }
    }
}
