using Restourant.ViewModels.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Restourant.Models
{
    public class Foods : BaseViewModel
    {
        public Foods(uint id,string name, int quantity, decimal price, string image, string type, ICommand plus, ICommand minus)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            Image = image;
            Type = type;
            Plus = plus;
            Minus = minus;
        }
        private uint id = 0;
        public uint Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }
        private string name = "";
        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }

        }
        private int quantity = 0;
        public int Quantity
        {
            get { return quantity; }
            set { Set(ref quantity, value); }
        }
        private decimal price = 0;
        public decimal Price
        {
            get { return price; }
            set { Set(ref price, value); }
        }
        private string image = "";
        public string Image
        {
            get { return image; }
            set { Set(ref image, value); }
        }
        private string type = "";
        public string Type
        {
            get { return type; }
            set { Set(ref type, value); }
        }
        public ICommand Plus { get; set; }
        public ICommand Minus { get; set; }
    }
}
