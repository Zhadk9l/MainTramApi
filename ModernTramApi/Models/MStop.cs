using System.ComponentModel.DataAnnotations;

namespace ModernTramApi.Models
{
    public class MStop
    {
        [Key]
        public int ID { get; set; }
        public string Name {get; set;}
        public int RouteID { get; set;}
        public TimeSpan Time { get; set;}
    }
}
