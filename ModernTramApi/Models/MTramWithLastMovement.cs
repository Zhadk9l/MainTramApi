namespace ModernTramApi.Models
{
    public class MTramWithLastMovement
    {
        public int Id { get; set; }
        public string BrandAndModel { get; set; }
        public string Condition { get; set; }
        public DateTime LastMovementDateTime { get; set; }
        public string LastMovementCoordinates { get; set; }
        public decimal LastMovementSpeed { get; set; }
        public string LastMovementDirection { get; set; }
    }
}
