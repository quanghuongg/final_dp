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
    /// Interaction logic for CreateCoupon.xaml
    /// </summary>
    public partial class CreateCoupon : Window
    {
        private bool isEnterSoLuong = false;
        private bool isEnterID = false;
        private bool isEnterPhanTram = false;
        public CreateCoupon()
        {
            InitializeComponent();
        }

        private void SoLuong_TextChanged(object sender, TextChangedEventArgs e)
        {
            isEnterSoLuong = true;
            if (isEnterID && isEnterPhanTram && isEnterSoLuong) Add.IsEnabled = true;
        }

        private void ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            isEnterID = true;
            if (isEnterID && isEnterPhanTram && isEnterSoLuong) Add.IsEnabled = true;
        }

        private void PhanTram_TextChanged(object sender, TextChangedEventArgs e)
        {
            isEnterPhanTram = true;
            if (isEnterID && isEnterPhanTram && isEnterSoLuong) Add.IsEnabled = true;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string phanTram = PhanTram.Text.Trim();
                string Id = ID.Text.Trim();
                string soLuong = SoLuong.Text.Trim();
                bool result = DataProvider.CreateCoupon(Id, Int32.Parse(phanTram), Int32.Parse(soLuong));
                if (result)
                {
                    this.Close();
                    MessageBox.Show("Add Coupon sucessfully!");
                }
                else MessageBox.Show("Something went wrong!");
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
                return;
            }
        }
    }
}
