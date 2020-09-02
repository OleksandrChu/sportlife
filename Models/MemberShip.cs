using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sportlife.Models
{
    public class MemberShip
    {
        public int Id { get; set; }
        
        [NotMapped]
        public MemberShipType Type { get; set; }

        public Account Account { get; set; }

        [NotMapped]
        public List<Service> Services { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}