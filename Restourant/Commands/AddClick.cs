using Restourant.ViewModels.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Restourant.Commands
{
    public class AddClick : BaseViewModel
    {
        public AddClick(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        private string name = "";
        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        private double price = 0;
        public double Price
        {
            get { return price; }
            set { Set(ref price, value); }
        }

        private int quantity = 0;
        public int Quantity
        {
            get { return quantity; }
            set { Set(ref quantity, value); }
        }

        private double total_price = 0;
        public double Total_price
        {
            get { return price * quantity; }
            set { Set(ref total_price, value); }
        }

        public void AddList(StackPanel parent)
        {
            #region Create Elements 
            Grid main_grid = new Grid();
            TextBlock food_title = new TextBlock();
            TextBlock food_quantity = new TextBlock();
            TextBlock food_price = new TextBlock();
            TextBlock foodTotal_price = new TextBlock();
            #endregion
            #region Element Parameters
            food_title.Text = Name;
            food_title.FontWeight = FontWeights.Bold;
            food_title.HorizontalAlignment = HorizontalAlignment.Left;
            food_title.VerticalAlignment = VerticalAlignment.Center;
            food_title.Margin = new Thickness(20, 0, 0, 0);

            food_quantity.Text = Quantity.ToString();
            food_quantity.FontWeight = FontWeights.Bold;
            food_quantity.HorizontalAlignment = HorizontalAlignment.Center;
            food_quantity.VerticalAlignment = VerticalAlignment.Center;

            food_price.Text = Price.ToString();
            food_price.FontWeight = FontWeights.Bold;
            food_price.HorizontalAlignment = HorizontalAlignment.Center;
            food_price.VerticalAlignment = VerticalAlignment.Center;

            foodTotal_price.Text = Total_price.ToString();
            foodTotal_price.FontWeight = FontWeights.Bold;
            foodTotal_price.HorizontalAlignment = HorizontalAlignment.Center;
            foodTotal_price.VerticalAlignment = VerticalAlignment.Center;
            #endregion
            #region Include Elements
            parent.Children.Add(main_grid);
            main_grid.Children.Add(food_title);
            main_grid.Children.Add(food_quantity);
            main_grid.Children.Add(food_price);
            main_grid.Children.Add(foodTotal_price);
            #endregion
            #region Create Columns
            ColumnDefinition column1 = new ColumnDefinition();
            ColumnDefinition column2 = new ColumnDefinition();
            ColumnDefinition column3 = new ColumnDefinition();
            ColumnDefinition column4 = new ColumnDefinition();
            #endregion
            #region ColumnParameters
            column1.Width = new GridLength(2.7, GridUnitType.Star);
            column2.Width = new GridLength(1, GridUnitType.Star);
            column3.Width = new GridLength(1, GridUnitType.Star);
            column4.Width = new GridLength(1, GridUnitType.Star);
            #endregion
            #region AddColumn
            main_grid.ColumnDefinitions.Add(column1);
            main_grid.ColumnDefinitions.Add(column2);
            main_grid.ColumnDefinitions.Add(column3);
            main_grid.ColumnDefinitions.Add(column4);
            #endregion
            #region SetColumns
            Grid.SetColumn(food_title, 0);
            Grid.SetColumn(food_quantity, 1);
            Grid.SetColumn(food_price, 2);
            Grid.SetColumn(foodTotal_price, 3);
            #endregion
        }
    }
}
