using System.ComponentModel.DataAnnotations;

namespace ModernTramApi.Models
{
    public class MSchedule
    {
        [Key]
        public int ID { get; set; }
        public int RouteID { get; set; }
        public int TramID { get; set; }
        public string Weekdays { get; set; }
        public TimeSpan DepartureTime { get; set;}
        public int OpTgID { get; set; }



    }
}
