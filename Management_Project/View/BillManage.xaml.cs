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

namespace Management_Project.View
{
    /// <summary>
    /// Interaction logic for BillManage.xaml
    /// </summary>
    public partial class BillManage : Window
    {
        private bool issetStartDay = false;
        private bool issetEndDay = false;
        public BillManage()
        {
            InitializeComponent();
            DateTime date = DateTime.Now.Date;
            List<BillItem> ListBill = DataProvider.GetBillItems(date, date);
            ListBills.ItemsSource = ListBill;
        }

        private void Loc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string startDate = StartDate.Text;
                string endDate = EndDate.Text;
                ListBills.ItemsSource = null;
                List<BillItem> ListBill = DataProvider.GetBillItems(DateTime.Parse(startDate), DateTime.Parse(endDate));
                ListBills.ItemsSource = ListBill;
            }
            catch
            {
                //Do nothing 
                return;
            }
        }

        private void Start_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            issetStartDay = true;
            if (issetEndDay && issetStartDay) Loc.IsEnabled = true;
        }
        private void End_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            issetEndDay = true;
            if (issetEndDay && issetStartDay) Loc.IsEnabled = true;
        }
    }

}
