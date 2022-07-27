using Restourant.ViewModels.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Restourant.Models
{
    public class AddTables : BaseViewModel
    {
        public AddTables(int id, bool isFree, ICommand transtion1, string table_name, string image)
        {
            Id = id;
            IsFree = isFree;
            transition = transtion1;
            Table_name = table_name;
            Image = image;
        }

        public int Id { get; set; }
        public bool IsFree { get; set; }
        public ICommand transition { get; set; }
        public string Table_name { get; set; }
        public string Image { get; set; }
    }
}
