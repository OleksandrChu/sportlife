using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sportlife.Models
{
    public class Account
    {
        public int Id { get; set; }
        [NotMapped]
        public int Balance { get; set; }
        public int Debt { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}