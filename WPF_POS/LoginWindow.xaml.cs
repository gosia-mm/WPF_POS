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
using System.Windows.Shapes;

namespace WPF_POS
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            
        }
        
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            textBoxPassword.PasswordChar = '*';
            WPF_LicEntities db = new WPF_LicEntities();

            var users = db.Uzytkownik;
            string foundUsername = "";
            string foundPassword = "";

            foreach (var user in users)
            {
                if (textBoxUsername.Text == user.nazwa_uzytkownika && textBoxPassword.Password == user.haslo)
                {
                    foundUsername = textBoxUsername.Text;
                    foundPassword = textBoxPassword.Password;
                }
            }

            if (foundUsername != "" && foundPassword != "")
            {
                MessageBox.Show("Witamy w systemie :)");
                MainWindow main = new MainWindow();
                this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("Błędne dane logowania!");
            }
        }
    }
}
