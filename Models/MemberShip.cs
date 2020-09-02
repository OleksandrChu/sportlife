using System;
using System.Collections.Generic;
using sportlife.Services;

namespace sportlife.Models
{
    public class MemberShip
    {
        public MemberShipType Type { get; set; }
        public Account Account { get; set; }
        public List<IService> Services { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}