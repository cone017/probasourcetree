using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class MenuItem2
    {
        public int Id;
        public string Title;
        public string Description;
        public decimal Price;

        public MenuItem2() { }

        public MenuItem2(int id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }
    }
}
