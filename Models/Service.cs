using sportlife.Models;

namespace sportlife.Models
{
    public class Service
    {
        public Service(int id, string title, int price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }
    }
}