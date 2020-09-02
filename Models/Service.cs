using sportlife.Models;

namespace sportlife.Models
{
    public class Service
    {
        public Service(string title, int price)
        {
            Title = title;
            Price = price;
        }

        public Service(string title)
        {
            Title = title;
        }

        public string Title { get; set; }

        public int Price { get; set; }
    }
}