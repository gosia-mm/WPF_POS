﻿using System;
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
        WPF_LicEntities1 db = new WPF_LicEntities1();
        public MainWindow()
        {
            InitializeComponent();
            fillOrderListBox();
            TablesPage tablesPage = new TablesPage();
            pageLoading(tablesPage);
        }

        public void pageLoading(Page pageToLoad)
        {
            tablesFrame.Content = pageToLoad;
        }


        public void fillOrderListBox()
        {
            var orders = db.Zamowienie;

            foreach (var order in orders)
            {
                if (order.data_zrealizowania == null)
                    OrderListBox.Items.Add(order.id_zamowienia);
                else
                    CompletedOrderListBox.Items.Add(order.id_zamowienia);
            }
        }

        private void OrderListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DetailsLabel.Visibility = Visibility.Visible;
            DetailsStackPanel.Visibility = Visibility.Visible;

            decimal selectedOrderID = (decimal)OrderListBox.SelectedValue;
            var orders = db.Zamowienie;
            var order = orders.Where(en => en.id_zamowienia == selectedOrderID);
            var found = order.First<Zamowienie>();
            IDTextBox.Text = found.id_zamowienia.ToString();
            CreatedTextBox.Text = found.data_zlozenia.ToString();
            StatusTextBox.Text = found.status_zamowienia.ToString();
        }

        private void CompletedOrderListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DetailsLabel.Visibility = Visibility.Visible;
            DetailsStackPanel.Visibility = Visibility.Visible;

            decimal selectedOrderID = (decimal)CompletedOrderListBox.SelectedValue;
            var orders = db.Zamowienie;
            var order = orders.Where(en => en.id_zamowienia == selectedOrderID);
            var found = order.First<Zamowienie>();
            IDTextBox.Text = found.id_zamowienia.ToString();
            CreatedTextBox.Text = found.data_zlozenia.ToString();
            StatusTextBox.Text = found.status_zamowienia.ToString();
            DoneTextBox.Text = found.data_zrealizowania.ToString();
        }
    }
}
