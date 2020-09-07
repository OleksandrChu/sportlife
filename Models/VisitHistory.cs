using System;

namespace sportlife.Models
{
    public class VisitHistory
    {
        public int Id { get; set; }
        public int MembershipId { get; set; }
        public DateTime visitTime { get; set; }
    }
}