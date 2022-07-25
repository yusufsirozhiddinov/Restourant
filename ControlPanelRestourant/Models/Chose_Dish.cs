using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPanelRestourant.Models
{
    public class Chose_Dish
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public long Product_Id { get; set; }
        public int Total_price { get; set; }
        public string TItle_table { get; set; }
    }
}
