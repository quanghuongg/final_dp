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
    /// Interaction logic for CreateCategory.xaml
    /// </summary>
    public partial class CreateCategory : Window
    {
        public CreateCategory()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            // Get info
            string categoryName = Category_Name.Text;
            string categoryID = Category_ID.Text;

            bool res = DataProvider.AddCategory(categoryID, categoryName);

            if (res) MessageBox.Show("Add 1 category successfully!");
            else MessageBox.Show("Something went wrong!");
        }
    }
}
