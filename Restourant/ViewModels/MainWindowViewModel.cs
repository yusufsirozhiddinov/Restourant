using Restourant.Models;
using Restourant.Models.EntityModels;
using Restourant.Views.DialogWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Restourant.ViewModels
{
    public class MainWindowViewModel : BaseViewModel.BaseViewModel
    {
        string title_table1 = "";

        DialogWindow dialogWindow1 = new();
        DialogWindowViewModel dialogWindow;
        ApplicationContext db = new ApplicationContext();

        public ICommand transition { get; set; }
        public MainWindowViewModel()
        {
            transition = new RelayCommand(transitionCommandExecuted, transitionCommandExecute);
            dialogWindow = new DialogWindowViewModel(dialogWindow1);
            dialogWindow1.DataContext = dialogWindow;

            var table = db.Tables;
            foreach (var item in table)
            {
                if (item.IsFree == 1)
                {
                    is_Enabled = true;
                    Image = "/Recourses/Images/MainWindow/table_on.png";


                } else
                {
                    is_Enabled = false;
                    Image = "/Recourses/Images/MainWindow/table_off.png";
                }
                Tables.Add(new AddTables(Convert.ToInt32(item.Id), is_Enabled, transition, "Стол " + indexOfTable.ToString(), Image));
                indexOfTable++;
            }

        }

        public void transitionCommandExecuted(object obj)
        {
            title_table1 = (string)obj;
            dialogWindow.SetTitle((string)obj);
            PassTitle();
        }

        public void PassTitle()
        {
            dialogWindow1.Show();
            Application.Current.MainWindow.Close();
        }

        public bool transitionCommandExecute(object obj)
        {
            return true;
        }

        private List<AddTables> tables = new List<AddTables>();
        public List<AddTables> Tables
        {
            get { return tables; }
            set { Set(ref tables, value); }
        }

        private bool is_Enable;
        public bool is_Enabled
        {
            get { return is_Enable; }
            set { Set(ref is_Enable, value); }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set { Set(ref image, value); }
        }




        int indexOfTable = 1;
    }
}
