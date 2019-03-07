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
    /// Logika interakcji dla klasy TablesPage.xaml
    /// </summary>
    public partial class TablesPage : Page
    {
        public TablesPage()
        {
            InitializeComponent();
        }

        private void Table_Click(object sender, RoutedEventArgs e)
        {
            var variable = ((Button)sender).Content;
            var number = ((Label)variable).Content.ToString();

            ChosenTablePage chosenTablePage = new ChosenTablePage(number);
            chosenTablePage.tableInfoLabel.Content = ((Button)sender).ToolTip;

            Frame chosenTableFrame = new Frame();
            chosenTableFrame.Content = chosenTablePage;

            this.Content = chosenTableFrame;
        }
    }
}
