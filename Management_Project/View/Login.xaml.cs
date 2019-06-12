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
using Management_Project.Model;
namespace Management_Project
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }


        private void login_Click(object sender, RoutedEventArgs e)
        {
            //get username
            String username = Username.Text;
            String pass = Password.Password.ToString();
            bool isLogin = DataProvider.checkLogin(username, pass);
            if (!isLogin)
            {
                MessageBox.Show("Your username or password incorrect!");
            }
            else
            {
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Closed += (s, args) => this.Close();
                mainWindow.Show();
            }
        }
    }
}
