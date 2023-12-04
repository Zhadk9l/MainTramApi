using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernTramApi.Models
{
    public class MTickets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        public DateTime ExpiryDateTime { get; set; }
        public decimal Price { get; set; }
        public int TgID { get; set; }   

    }
}
