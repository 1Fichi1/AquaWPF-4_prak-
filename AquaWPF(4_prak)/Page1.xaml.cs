using AquaWPF_4_prak_.AquaDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        CustomersTableAdapter Customers = new CustomersTableAdapter();
        public Page1()
        {
            InitializeComponent();
            Aqua1.ItemsSource = Customers.GetData();
            spisok.ItemsSource = Customers.GetData();
            spisok.DisplayMemberPath = "Name1";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Aqua1.ItemsSource = Customers.SearchByName(SearchTxt.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Aqua1.ItemsSource = Customers.GetData();
        }
        private void spisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (spisok.SelectedItem != null)
            {
                var Name1 = (int)(spisok.SelectedItem as DataRowView).Row[0];
                Aqua1.ItemsSource = Customers.FilterByName1(Name1);
            }
        }
    }
}
