using System.ComponentModel.DataAnnotations;

namespace sportlife.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        // public MemberShip MemberShip { get; set; }
    }
}