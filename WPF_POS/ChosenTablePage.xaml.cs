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
using System.Windows.Threading;

namespace WPF_POS
{
    /// <summary>
    /// Logika interakcji dla klasy ChosenTablePage.xaml
    /// </summary>
    public partial class ChosenTablePage : Page
    {
        WPF_LicEntities1 db = new WPF_LicEntities1();
        public ChosenTablePage(string tableNumber)
        {
            InitializeComponent();
   
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.dateTextBlock.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            }, this.Dispatcher);

            fillOrdersFromTableListBox(tableNumber);
        }

        public void fillOrdersFromTableListBox(string tableNumber)
        {
            var orders = db.Zamowienie;

            foreach (var order in orders)
            {
                if (order.stolik == tableNumber)
                    OrdersFromTableListBox.Items.Add(order.id_zamowienia);
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            // czy nie powinien być wykorzystany NavigationService ??? zamiast tworzenia ciągle nowych stron

            TablesPage tablesPage = new TablesPage();

            Frame chosenTableFrame = new Frame();
            chosenTableFrame.Content = tablesPage;

            this.Content = chosenTableFrame;
        }
    }
}
