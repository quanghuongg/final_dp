using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Category.xaml
    /// </summary>
    public partial class Category : Window
    {
        private int currentPage = 0;
        private int itemPerPage = 8;
        public List<Category1> CategoryList { get; set; }
        public Category()
        {

            InitializeComponent();
            updateData();
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            CreateCategory window = new CreateCategory();
            window.Closed += (s, args) => this.updateData();
            window.ShowDialog();
        }
        
        private void updateData()
        {
            this.CategoryList = DataProvider.getAllCategory();
            ListCategory.ItemsSource = null;
            CategoryList = new List<Category1>();
            CategoryList = DataProvider.getAllCategory();
            this.DataContext = this;
            ListCategory.ItemsSource = CategoryList;

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int count = ListCategory.SelectedItems.Count;
            for (int x = 0; x < count; x++)
            {
                var ct = ListCategory.SelectedItems[x] as Category1;
                bool res = DataProvider.DeleteCategory(ct.CategoryID);
                if (res) MessageBox.Show("Delete " + count + " row successfully!");
                else MessageBox.Show("Something went wrong! ");
            }
            if (count > 0) {
               //Do nothing
            }
            else MessageBox.Show("Nothing to delete");
            updateData();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            int count = ListCategory.SelectedItems.Count;
            if (count == 0)
            {
                MessageBox.Show("Nothing to change");
                return;
            }
            ChangeCategory window = new ChangeCategory();
            for (int x = 0; x < count; x++)
            {
                var category = ListCategory.SelectedItems[x] as Category1;
                window.ID.Text = category.CategoryID.Trim();
                window.Name.Text = category.Name.Trim();
            }
            window.Closed += (s, args) => this.updateData();
            window.Show();
        }

        private void ListCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Change.IsEnabled = true;
            Delete.IsEnabled = true;
        }
    }
        
}
