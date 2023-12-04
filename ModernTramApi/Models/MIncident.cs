using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernTramApi.Models
{
    public class MIncident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime IncDateTime {get; set;}
        public string IncDescription { get; set;}
        public string IncStatus { get; set;}
        public int TramID { get; set;}
    }
}
