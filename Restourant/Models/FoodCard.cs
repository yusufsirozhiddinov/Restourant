using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restourant.Models
{
    public class FoodCard
    {
        public FoodCard(uint id, string name, decimal price, string type, string image)
        {
            Id = id;
            Name = name;
            this.Price = price;
            Type = type;
            Image = image;
        }
        public uint Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
    }
}
