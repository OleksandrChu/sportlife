using System.Collections.Generic;

namespace sportlife.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int Balance { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}