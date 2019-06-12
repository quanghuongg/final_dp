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
    /// Interaction logic for ChangeCategory.xaml
    /// </summary>
    public partial class ChangeCategory : Window
    {
        public ChangeCategory()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            string CategoryID = ID.Text;
            string CategoryName = Name.Text;
            bool res = DataProvider.UpdateCategory(CategoryID, CategoryName);
            if (res)
            {
                MessageBox.Show("Update successfully!");
                this.Close();
            }
            else MessageBox.Show("Something went wrong!");
        }
    }
}
