using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MySql.Data.MySqlClient;
using Restourant.Commands;
using Restourant.Models;
using Restourant.Models.EntityModels;
using Restourant.Views.ChangeWindow;
using Restourant.Views.DialogWindow;

namespace Restourant.ViewModels
{
    public class SecondDishesViewModel : BaseViewModel.BaseViewModel
    {
        ChangeWindow changeWindow;
        public SecondDishesViewModel(ChangeWindow changeWindow1)
        {
            changeWindow = changeWindow1;

            plus = new RelayCommand(plusCommandExecuted, plusCommandExecute);
            minus = new RelayCommand(minusCommandExecuted, minusCommandExecute);
            transitionBack = new RelayCommand(transition_backCommandExecuted, transition_backComandExecute);

            #region Connection opened
            connection.Open();

            MySqlCommand count_Command = new MySqlCommand("SELECT COUNT(id) name FROM dishes;", connection);
            MySqlDataReader reader_count = count_Command.ExecuteReader();

            int count_Base = 0;
            while (reader_count.Read())
            {
                count_Base = reader_count.GetInt32(0);
            }

            for (int i = 0; i < count_Base; i++)
            {
                connection.Close();
                Conn();
                connection.Open();
                Foods.Add(new Foods(Id, Name, 0, Price, Image, Type, plus, minus));
                index++;
            }
            connection.Close();
            #endregion

            var save_Quantity = db.Chose_Dish;

            foreach (var item in save_Quantity)
            {
                foods[Convert.ToInt32(item.Product_Id) - 1].Quantity = Convert.ToInt32(item.Quantity);
            }
            db.SaveChanges();
        }


        public ICommand plus { get; set; }
        public ICommand minus { get; set; }
        public ICommand transitionBack { get; set; }

        MySqlConnection connection = new MySqlConnection("server=localhost;userid=root;password=1234;database=foods");

        #region Переменные 
        private string product_title = "";
        public string Product_title
        {
            get { return product_title; }
            set
            {
                Set(ref product_title, value);
            }
        }

        private int count = 0;
        public int Count
        {
            get { return count; }
            set { Set(ref count, value); }
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
        private string image = "";
        public string Image
        {
            get { return image; }
            set { Set(ref image, value); }
        }
        private decimal private_price = 0;
        public decimal Price
        {
            get { return private_price; }
            set { Set(ref private_price, value); }
        }
        private string type = "";
        public string Type
        {
            get { return type; }
            set { Set(ref type, value); }
        }

        private double total_price = 0;
        public double Total_price
        {
            get { return total_price; }
            set { Set(ref total_price, value); }
        }
        private string title_Table = "";
        public string Title_table
        {
            get { return title_Table; }
            set { Set(ref title_Table, value); }    
        }
        #endregion

        private List<Foods> foods = new List<Foods>();
        public List<Foods> Foods
        {
            get => foods;
            set => Set(ref foods, value);
        }

        List<FoodCard> info = new List<FoodCard>();
        ApplicationContext db = new ApplicationContext();

        DialogWindow dialogWindow = new();
        DialogWindowViewModel dialogWindowViewModel;


        #region Methods

        public void plusCommandExecuted(object obj)
        {
            TextBlock textBlock = (TextBlock)obj;
            int food_index = Convert.ToInt32(textBlock.Text) - 1;


            if (Foods[food_index].Quantity <= 0)
            {
                // INCLUDE DATA
                db.Add(new Chose_Dish
                {
                    Name = Convert.ToString(Foods[food_index].Name),
                    Price = (decimal)foods[food_index].Price,
                    Quantity = (int)foods[food_index].Quantity,
                    Product_Id = (long)foods[food_index].Id,
                    Total_price = (int)foods[food_index].Price * (int)foods[food_index].Quantity,
                    TItle_table = Title_table
                });
                db.SaveChanges();
            }
            if (Foods[food_index].Quantity >= 0)
            {
                Foods[food_index].Quantity++;

                var change_columns = db.Chose_Dish.Where(s => s.Name == Foods[food_index].Name);

                foreach (var change_value in change_columns)
                {
                    change_value.Quantity = (int)Foods[food_index].Quantity;
                    change_value.Total_price = (int)foods[food_index].Price * (int)foods[food_index].Quantity;
                }

                db.SaveChanges();
            }
        }
        public bool plusCommandExecute(object obj)
        {
            return true;
        }

        public void minusCommandExecuted(object obj)
        {

            TextBlock textBlock = (TextBlock)obj;
            int food_index = Convert.ToInt32(textBlock.Text) - 1;
            var food = db.Chose_Dish.Where(s => s.Name == Foods[food_index].Name);

            if (Foods[food_index].Quantity > 0)
            {
                Foods[food_index].Quantity--;
                var quantity = db.Chose_Dish.Where(s => s.Name == Foods[food_index].Name);
                foreach (var item in quantity)
                {
                    item.Quantity = (int)Foods[food_index].Quantity;
                }
                db.SaveChanges();
            }

            if (Foods[food_index].Quantity == 0)
            {
                foreach (var item in food)
                {
                    db.Chose_Dish.Remove(item);
                }
                db.SaveChanges();
            }
        }
        public bool minusCommandExecute(object obj)
        {
            return true;
        }


        private void transition_backCommandExecuted(object obj)
        {
            Title_table = (string)obj;
            dialogWindow.Show();
            dialogWindowViewModel = new DialogWindowViewModel(dialogWindow);
            dialogWindow.DataContext = dialogWindowViewModel; 
            dialogWindowViewModel.SetTitle(Title_table);
            changeWindow.Close();
        }


        private bool transition_backComandExecute(object obj)
        {
            return true;
        }

        int index = 0;

        public void Conn()
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT id, name, price, type, image FROM dishes;", connection);

            MySqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                info.Add(new FoodCard((uint)dr[0], dr[1].ToString(), (decimal)dr[2], dr[3].ToString(), dr[4].ToString()));
            }

            Id = info[index].Id;
            Name = info[index].Name;
            Price = info[index].Price;
            Type = info[index].Type;
            Image = info[index].Image;

            connection.Close();
        }

        public void SetTitle(string title)
        {
            Title_table = title;
        }
        #endregion

    }
}
