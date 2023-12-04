using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernTramApi.Models
{
    public class MMaintenanceLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime ScheduledService { get; set;}
        public string RepairDescription { get; set;}
        public int TramID { get; set;}
        public int TechnicalStaff { get; set;}
    }
}
