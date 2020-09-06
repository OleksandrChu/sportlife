namespace sportlife.Models
{
    public class ServiceHistory
    {
        public int Id { get; set; }
        public int MemberShipId { get; set; }
        public int ServiceId { get; set; }
        public int IsPaid { get; set; }
    }
}