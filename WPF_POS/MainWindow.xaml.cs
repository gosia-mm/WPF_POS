using System;
using System.Collections.Generic;
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

namespace WPF_POS
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fillOrderListBox();
        }

        public void fillOrderListBox()
        {
            WPF_LicEntities db = new WPF_LicEntities();
            var orders = db.Zamowienie;

            foreach (var order in orders)
            {
                if (order.data_zrealizowania == null)
                    OrderListBox.Items.Add("ID: " + order.id_zamowienia + " | Utworzono: " + order.data_zlozenia);
                else
                    CompletedOrderListBox.Items.Add("ID: " + order.id_zamowienia + " | Zrealizowano: " + order.data_zrealizowania);
            }
        }

        private void Table_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrderListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Details.Visibility = Visibility.Visible;

        }
    }
}
