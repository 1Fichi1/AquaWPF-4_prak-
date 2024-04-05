using AquaWPF_4_prak_.AquaDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace AquaWPF_4_prak_
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        OrdersTableAdapter Orders = new OrdersTableAdapter();
        public Page2()
        {
            InitializeComponent();
            Aqua2.ItemsSource = Orders.GetData();
            spisok.ItemsSource = Orders.GetData();
            spisok.DisplayMemberPath = "Quantity";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Aqua2.ItemsSource = Orders.QuantitySearch(SearchTxt.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Aqua2.ItemsSource = Orders.GetData();
        }
        private void spisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (spisok.SelectedItem != null)
            {
                var Quantity = (int)(spisok.SelectedItem as DataRowView).Row[0];
                Aqua2.ItemsSource = Orders.FilterByQuantity(Quantity);
            }
        }
    }
}
