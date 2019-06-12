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
    /// Interaction logic for ChangeProducts.xaml
    /// </summary>
    public partial class ChangeProducts : Window
    {
        public ChangeProducts()
        {
            InitializeComponent();
            List<string> data = new List<string>();
            int count = DataProvider.getAllCategory().Count;
            for (int i = 0; i < count; i++)
            {
                string categoryID = DataProvider.getAllCategory()[i].Name.Trim();
                data.Add(categoryID);
            }
            Category.ItemsSource = data;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            // Get info
            string product_ID = ID.Text;
            string name = Ten.Text;
            string categoryName = Category.Text;
            string cost = Gia.Text;
            int quantity = Int32.Parse(SoLuong.Text);
            bool result = DataProvider.UpdateProducts(name, product_ID, cost, categoryName, quantity);
            if (result) MessageBox.Show("Update successfully!");
            else MessageBox.Show("Something went wrong!");
            this.Close();
        }
    }
}
