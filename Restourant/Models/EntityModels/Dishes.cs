using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restourant.Models.EntityModels
{
    public class Dishes
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Kitchen { get; set; }
        public int Cooking_time { get; set; }
        public string Type { get; set; }
        public Byte[] Image { get; set; }
    }
}
