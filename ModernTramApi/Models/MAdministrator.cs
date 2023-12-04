using System.ComponentModel.DataAnnotations;

namespace ModernTramApi.Models
{
    public class MAdministrator
    {
        [Key]
        public int TgID { get; set; }
        public string Name {get; set;}
        public string TgName { get; set;}
        public string AdminPassword { get; set;}
    }
}
