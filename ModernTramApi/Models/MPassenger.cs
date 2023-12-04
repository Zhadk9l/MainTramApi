using System.ComponentModel.DataAnnotations;

namespace ModernTramApi.Models
{
    public class MPassenger
    {
        [Key]
        public int TgID { get; set; }
        public string Name {get; set;}
        public string TgName { get; set;}
    }
}
