using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Restourant.Views.ChangeWindow;
using Restourant.Views.DialogWindow;
using Restourant;
using System.Windows;
using System.Windows.Controls;
using Restourant.Commands;
using Restourant.Models.EntityModels;

namespace Restourant.ViewModels
{
    public class DialogWindowViewModel : BaseViewModel.BaseViewModel
    {

        public ICommand transition_second { get; set; }

        public ICommand transition_back { get; set; }
        public ICommand payment { get; set; }

        private 

        DialogWindow dialogwindow;
        ChangeWindow changeWindow = new();
        SecondDishesViewModel secondDishesViewModel;

        public DialogWindowViewModel(DialogWindow dialog)
        {
            dialogwindow = dialog;

            transition_second = new RelayCommand(transition_secondCommandExecuted, transition_secondCommandExecute);
            transition_back = new RelayCommand(transition_backCommandExecuted, transition_backComandExecute);

            payment = new RelayCommand(payment_CommandExecuted, payment_CommandExecute);

            using (ApplicationContext db = new ApplicationContext())
            {
                var chose_Dish = db.Chose_Dish;
                foreach (var item in chose_Dish)
                {
                    Foods.Add(new Chose_Dish
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        Quantity = (int)item.Quantity,
                        Total_price = item.Total_price,
                    });
                    Total_price += item.Total_price;
                }
            }
        }

        private List<Chose_Dish> foods = new List<Chose_Dish>();
        public List<Chose_Dish> Foods
        {
            get => foods;
            set => Set(ref foods, value);
        }

        private int total_price = 0;
        public int Total_price
        {
            get { return total_price; }
            set { Set(ref total_price, value); }
        }

        private string title_table;
        public string Title_table
        {
            get { return title_table; }
            set { Set(ref title_table, value); }
        }

        private Visibility pay_visibility = Visibility.Hidden;

        public Visibility payment_Visibility
        {
            get { return pay_visibility; }
            set { Set(ref pay_visibility, value); }
        }

        private string card_number = "XXXX XXXX XXXX XXXX";
        public string Card_number
        {
            get { return card_number; }
            set { Set(ref card_number, value); }
        }

        public void transition_secondCommandExecuted(object obj)
        {
            changeWindow.Show();
            secondDishesViewModel = new SecondDishesViewModel(changeWindow);
            changeWindow.DataContext = secondDishesViewModel;
            secondDishesViewModel.SetTitle(Title_table);
            dialogwindow.Close();
            
        }
        public bool transition_secondCommandExecute(object obj)
        {
            return true;
        }

        public void transition_backCommandExecuted(object obj)
        {

        }
        public bool transition_backComandExecute(object obj)
        {
            return true;
        }

        private void payment_CommandExecuted(object obj)
        {
            payment_Visibility = Visibility.Visible;
        }

        private bool payment_CommandExecute(object arg)
        {
            return true;
        }

        public void SetTitle(string Title_Table1)
        {
            Title_table = Title_Table1;
        }
    }
}
