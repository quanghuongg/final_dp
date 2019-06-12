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
    /// Interaction logic for ThongKeDoanhThu.xaml
    /// </summary>
    public partial class ThongKeDoanhThu : Window
    {
        private bool issetStartDay = false;
        private bool issetEndDay = false;
        public ThongKeDoanhThu()
        {
            InitializeComponent();
            showColumnChart();

        }
        private void showColumnChart()
        {
            //Get data of Bill
            DateTime date = DateTime.Now.Date;

            List<KeyValuePair<string, int>> valueList =  DataProvider.GetRevenue(date,date);
            
            //Setting data for column chart
            lineChart.DataContext = valueList;
            //Setting data for bar chart

            //Setting data for line chart
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime startDate = DateTime.Parse(StartDate.Text);
                DateTime endDate = DateTime.Parse(EndDate.Text);
                lineChart.DataContext = null;
                List<KeyValuePair<string, int>> valueList = DataProvider.GetRevenue(startDate, endDate);
                lineChart.DataContext = valueList;
            }
            catch (Exception )
            {
                MessageBox.Show("Something went wrong!");
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
