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

        private 

        DialogWindow dialogwindow;
        ChangeWindow changeWindow = new();
        SecondDishesViewModel secondDishesViewModel;
        ApplicationContext db = new ApplicationContext();

        public DialogWindowViewModel(DialogWindow dialog)
        {
            transition_second = new RelayCommand(transition_secondCommandExecuted, transition_secondCommandExecute);
            transition_back = new RelayCommand(transition_backCommandExecuted, transition_backComandExecute);
            dialogwindow = dialog;
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

        public void SetTitle(string Title_Table)
        {
            Title_table = Title_Table;
        }
    }
}
