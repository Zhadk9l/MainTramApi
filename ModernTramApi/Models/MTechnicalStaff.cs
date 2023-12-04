using System.ComponentModel.DataAnnotations;

namespace ModernTramApi.Models
{
    public class MTechnicalStaff
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Qualification { get; set; }
        public string TechnicalStaffPassword { get; set; }
    }
}
