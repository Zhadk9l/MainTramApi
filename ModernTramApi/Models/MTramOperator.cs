using System.ComponentModel.DataAnnotations;

namespace ModernTramApi.Models
{
    public class MTramOperator
    {
        [Key]
        public int OpTgID { get; set; }
        public string Name { get; set; }
        public string TgName { get; set; }
        public string OperatorPasswor { get; set; }
    }
}
