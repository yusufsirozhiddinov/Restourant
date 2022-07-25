using ControlPanelRestourant.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ControlPanelRestourant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Chose_Dish> chose = new ObservableCollection<Chose_Dish>();
        int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            ApplicationContext db = new ApplicationContext();
            var item = db.Chose_Dish;

            foreach (var item2 in item)
            {
                chose.Add(new Chose_Dish
                {
                    Id = item2.Id,
                    Name = item2.Name,
                    Price = item2.Price,
                    Quantity = item2.Quantity,
                    Product_Id = item2.Product_Id,
                    Total_price = item2.Total_price,
                    TItle_table = item2.TItle_table
                });
                count++;
            }
            dataGrid.ItemsSource = new ObservableCollection<Chose_Dish>(chose);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationContext db = new ApplicationContext();
            var item = db.Chose_Dish.Count();

            if (count < item)
            {
                count++;
                foreach (var item1 in db.Chose_Dish.Where(s => s.Id == count))
                {
                    chose.Add(new Chose_Dish
                    {
                        Id = item1.Id,
                        Name = item1.Name,
                        Price = item1.Price,
                        Quantity = item1.Quantity,
                        Product_Id = item1.Product_Id,
                        Total_price = item1.Total_price,
                        TItle_table = item1.TItle_table
                    });
                }
            }
            
            dataGrid.ItemsSource = new  ObservableCollection<Chose_Dish>(chose);
        }
    }
}
