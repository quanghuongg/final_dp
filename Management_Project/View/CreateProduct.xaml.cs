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
    /// Interaction logic for CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : Window
    {
        private bool isEnterID = false;
        private bool isEnterName = false;
        private bool isEnterCategory = false;
        private bool isEnterCost = false;

        public CreateProduct()
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

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            string Id_SP, Loai_SP, Gia_SP, Ten_SP,So_Luong;
            Id_SP = ID.Text;
            Gia_SP = Gia.Text;
            Loai_SP = Category.Text;
            Ten_SP = Ten.Text;
            So_Luong = SoLuong.Text;
            string soLuong = SoLuong.Text.Trim();
            bool res = DataProvider.AddProduct(Ten_SP, Id_SP, Gia_SP, Loai_SP,Int32.Parse(So_Luong));
            if (res) MessageBox.Show("Insert successfully !");
            else
                MessageBox.Show("Something went wrong! ");

        }

        private void ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            isEnterID = true;
            checkEnterAll();
        }

        private void Ten_TextChanged(object sender, TextChangedEventArgs e)
        {
            isEnterName = true;
            checkEnterAll();
        }

        private void Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isEnterCategory = true;
            checkEnterAll();
        }

        private void Gia_TextChanged(object sender, TextChangedEventArgs e)
        {
            isEnterCost = true;
            checkEnterAll();
        }

        private void checkEnterAll()
        {
            if (isEnterID && isEnterCategory && isEnterCost && isEnterName)
            {
                Add.IsEnabled = true;
            }
        }

        private void SoLuong_TextChanged(object sender, TextChangedEventArgs e)
        {
            isEnterCost = true;
            checkEnterAll();
        }
    }
}
