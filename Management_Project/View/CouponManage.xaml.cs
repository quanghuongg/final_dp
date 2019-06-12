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
    /// Interaction logic for CouponManage.xaml
    /// </summary>
    public partial class CouponManage : Window
    {
        public CouponManage()
        {
            InitializeComponent();
            List<CouponItem> couponItems = DataProvider.getAllCoupon();
            ListCoupon.ItemsSource = couponItems;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
