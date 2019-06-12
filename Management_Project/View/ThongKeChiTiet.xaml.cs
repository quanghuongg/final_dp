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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
namespace Management_Project
{
    /// <summary>
    /// Interaction logic for ThongKeChiTiet.xaml
    /// </summary>
    public partial class ThongKeChiTiet : System.Windows.Window
    {
        private bool issetStartDay = false;
        private bool issetEndDay = false;
        private List<SaleProduct> ListSale;

        public ThongKeChiTiet()
        {
            
            InitializeComponent();
            DateTime date = DateTime.Now.Date;
            ListSale = new List<SaleProduct>();
            //ListSale.Add(new SaleProduct { STT = 1, ProductID = "HD001", Name = "HoaiDien", Cost = "20000", Qty = "2", Total = "40000" });
            ListSale = DataProvider.GetHistory(date, date);
            ListProducts.ItemsSource = ListSale;
            updateTotal();
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

        private void Loc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime startDate = DateTime.Parse(StartDate.Text);
                DateTime endDate = DateTime.Parse(EndDate.Text);
                ListSale = DataProvider.GetHistory(startDate, endDate);
                ListProducts.ItemsSource = null;
                ListProducts.ItemsSource = ListSale;
                updateTotal();
                if (ListSale.Count > 0) Export.IsEnabled = true;
                else Export.IsEnabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");

            }
        }

        private void updateTotal()
        {
            // Get total :
            int total = 0;
            for (int i = 0; i < ListSale.Count; i++)
            {
                total += Int32.Parse(ListSale[i].Total);
            }
            Total.Text = total.ToString("##,##0"+" VNĐ");
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true; 
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            //Set Header
            Range myRange = (Range)sheet1.Cells[1,6];
            sheet1.Cells[1, 6].Font.Italic = true;
            myRange.Value2 = "Từ ngày:";
            myRange = (Range)sheet1.Cells[1, 7];
            sheet1.Cells[1, 7].Font.Italic = true;
            myRange.Value2 = StartDate.Text;

            myRange = (Range)sheet1.Cells[2, 6];
            sheet1.Cells[2, 6].Font.Italic = true;
            myRange.Value2 = "Đến ngày:";
            myRange = (Range)sheet1.Cells[2, 7];
            sheet1.Cells[2, 7].Font.Italic = true;
            myRange.Value2 = EndDate.Text;

            myRange = (Range)sheet1.Cells[3, 6];
            sheet1.Cells[2, 6].Font.Italic = true;
            myRange.Value2 = "Tổng cộng:";
            myRange = (Range)sheet1.Cells[3, 7];
            sheet1.Cells[2, 7].Font.Italic = true;
            myRange.Value2 = Total.Text;

            //
            myRange = (Range)sheet1.Cells[4, 1];
            sheet1.Cells[4, 1].Font.Bold = true; 
            sheet1.Columns[1].ColumnWidth = 15;
            myRange.Value2 = "STT";
            //
            myRange = (Range)sheet1.Cells[4, 2];
            sheet1.Cells[4, 2].Font.Bold = true;
            sheet1.Columns[2].ColumnWidth = 15;
            myRange.Value2 = "ProductID";
            //
            myRange = (Range)sheet1.Cells[4, 3];
            sheet1.Cells[4, 3].Font.Bold = true;
            sheet1.Columns[3].ColumnWidth = 15;
            myRange.Value2 = "Tên Sản Phẩm";
            //
            myRange = (Range)sheet1.Cells[4, 4];
            sheet1.Cells[4, 4].Font.Bold = true;
            sheet1.Columns[4].ColumnWidth = 15;
            myRange.Value2 = "Loại Sản Phẩm";
            //
            myRange = (Range)sheet1.Cells[4, 5];
            sheet1.Cells[4, 5].Font.Bold = true;
            sheet1.Columns[5].ColumnWidth = 15;
            myRange.Value2 = "Giá";
            //
            myRange = (Range)sheet1.Cells[4, 6];
            sheet1.Cells[4, 6].Font.Bold = true;
            sheet1.Columns[6].ColumnWidth = 15;
            myRange.Value2 = "Số Lượng";
            //
            myRange = (Range)sheet1.Cells[4, 7];
            sheet1.Cells[4, 7].Font.Bold = true;
            sheet1.Columns[7].ColumnWidth = 15;
            myRange.Value2 = "Tổng";

            for (int i = 0; i < ListSale.Count; i++)
                for (int j = 0; j < 7; j++)
                {
                    //TextBlock b = dgrid.Columns[i].GetCellContent(dgrid.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange1 = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[6 + i, 1 + j];
                    switch (j)
                    {
                        case 0:
                            myRange1.Value2 = ListSale[i].STT;
                            break;
                        case 1:
                            myRange1.Value2 = ListSale[i].ProductID;
                            break;
                        case 2:
                            myRange1.Value2 = ListSale[i].Name;
                            break;
                        case 3:
                            myRange1.Value2 = ListSale[i].CategoryID;
                            break;
                        case 4:
                            myRange1.Value2 = ListSale[i].Cost;
                            break;
                        case 5:
                            myRange1.Value2 = ListSale[i].Qty;
                            break;
                        case 6:
                            myRange1.Value2 = ListSale[i].Total;
                            break;
                    }
                }
            }
        }

}
