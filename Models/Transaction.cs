namespace sportlife.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}