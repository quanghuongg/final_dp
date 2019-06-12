using Management_Project.View;
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

namespace Management_Project
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        public Payment()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Bill window = new Bill();
            this.Hide();
            window.ShowDialog();
            this.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateCoupon window = new CreateCoupon();
            this.Hide();
            window.ShowDialog();
            this.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CouponManage window = new CouponManage();
            this.Hide();
            window.ShowDialog();
            this.Show();
        }
        private void Manage_click(object sender, RoutedEventArgs e)
        {
            BillManage window = new BillManage();
            this.Hide();
            window.ShowDialog();
            this.Show();
        }

        
    }
}
