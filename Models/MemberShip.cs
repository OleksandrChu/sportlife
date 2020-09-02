using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using sportlife.Services;

namespace sportlife.Models
{
    public class MemberShip
    {
        public int Id { get; set; }
        
        public MemberShipType Type { get; set; }

        public Account Account { get; set; }

        [NotMapped]
        public List<IService> Services { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}