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

        public ICommand transition { get; set; }
        public MainWindowViewModel()
        {
            transition = new RelayCommand(transitionCommandExecuted, transitionCommandExecute);
            dialogWindow = new DialogWindowViewModel(dialogWindow1);
            dialogWindow1.DataContext = dialogWindow;

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
        
    }
}
