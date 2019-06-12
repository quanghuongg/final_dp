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
    /// Interaction logic for Bill.xaml
    /// </summary>
    public partial class Bill : Window
    {
        private int CouponRaw = 0;
        private bool changeQty = false;
        private bool changeID = false;
        private bool changeBillID = false;
        private bool changeName = false;
        private bool changeTT = false;
        private bool changeSP = false;
        private string CurrentCoupon;
        private List<Item> Items = new List<Item>();
        private long  totalCost = 0;
        public Bill()
        {
            InitializeComponent();
            // Load data into ListProducts
            List<string> ls = new List<string>();
            List<SanPham> result = DataProvider.getAllProduct();
            int count = result.Count;
            for(int i = 0; i < count; i++)
            {
                ls.Add(result[i].Name);
            }
            List_Products.ItemsSource = ls;
        }

        private void List_Products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            changeQty = true;
            if (changeID && changeQty) AddProduct.IsEnabled = true;

        }

        private void Ten_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(Qty.Text, out n);
            if (isNumeric)
            {
                changeID = true;
                if (changeID && changeQty) AddProduct.IsEnabled = true;
            }
            else changeID = false;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            // Get Products Id  +  Qty
            string ProductName = List_Products.Text;
            string Quantity = Qty.Text;
            Product p = new Product();
            p = DataProvider.GetInfoProduct(ProductName);
            try
            {
                if (p != null)
                {
                    Item it = new Item();
                    it.Cost = (Int32.Parse(p.Cost) * Int32.Parse(Quantity)).ToString();
                    it.Name = p.Name;
                    it.Qty = Quantity;
                    it.ProductID = p.ProductID;
                    Item result = Items.FirstOrDefault(x => x.ProductID == it.ProductID);
                    if (result != null) {
                        result.Qty = (Int32.Parse(result.Qty) + Int32.Parse(it.Qty)).ToString();
                        result.Cost = (Int32.Parse(result.Cost) + Int32.Parse(it.Cost)).ToString();
                    }
                    else {
                        Items.Add(it);
                    }
                    ListProducts.ItemsSource = null;
                    ListProducts.ItemsSource = Items;
                    totalCost = totalCost + Int32.Parse(it.Cost);
                    Total.Text = (totalCost - totalCost *CouponRaw/100).ToString() ;
                    changeSP = true;
                    Delete.IsEnabled = true;
                    if (changeName && changeBillID && changeTT && changeSP) CreateBill.IsEnabled = true;

                }
            }
            catch(Exception )
            {
                // do nothing
            }

        }

        private void ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            changeBillID = true;
            if (changeName && changeBillID && changeTT && changeSP) CreateBill.IsEnabled = true;
        }
    
        private void Ten_TextChanged(object sender, TextChangedEventArgs e)
        {
            changeName = true;
            if (changeName && changeBillID && changeTT && changeSP) CreateBill.IsEnabled = true;
        }

        private void CreateBill_Click(object sender, RoutedEventArgs e)
        {
            string customerName = Ten.Text;
            string billID = ID.Text;
            string total = Total.Text;
            string tt = TrangThai.Text;
            bool result;
            if (CouponRaw > 0)
            {
                result = DataProvider.CreateBill(Items, customerName, billID, total, tt,CurrentCoupon);
            }
            else result = DataProvider.CreateBill(Items, customerName, billID, total, tt);
            if (result)
            {
                MessageBox.Show("Create bill successfully!");
                this.Close();
            }
            else MessageBox.Show("Something went wrong!");
        }

        private void TrangThai_TextChanged(object sender, TextChangedEventArgs e)
        {
            changeTT = true;
            if (changeName && changeBillID && changeTT && changeSP) CreateBill.IsEnabled = true;
        }





        private void CreateBill_Copy_Click(object sender, RoutedEventArgs e)
        {
            int count = ListProducts.SelectedItems.Count;
            for (int x = 0; x < count; x++)
            {
                var item = ListProducts.SelectedItems[x] as Item;
                int index = Items.IndexOf(item);
                Items.RemoveAt(index);
                ListProducts.ItemsSource = null;
                ListProducts.ItemsSource = Items;
                totalCost -= Int32.Parse(item.Cost);
                Total.Text = (totalCost - totalCost*CouponRaw/100).ToString();
            }
            if (count > 0) MessageBox.Show("Delete " + count + " row successfully!");
            else MessageBox.Show("Nothing to delete");

        }

        private void Coupon_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnterCoupon.IsEnabled = true;
        }

        private void EnterCoupon_Copy_Click(object sender, RoutedEventArgs e)
        {
            string coupon = Coupon.Text;
            CurrentCoupon = coupon;
            int PhanTram = DataProvider.GetCoupon(coupon);
            if (PhanTram != 0)
            {
                CouponRaw = PhanTram;
                CouponStatus.Content = "-" + PhanTram.ToString() + " %";
                //Change total
                Total.Text = (totalCost - totalCost * PhanTram / 100).ToString();
            }
            else
            {
                CouponStatus.Content = "";
                Total.Text = totalCost.ToString();
            }
        }
    }

    public class Item
    {
        public string Cost { get; set; }
        public string ProductID { get; set; }
        public string Name { get; set; }
        public string Qty { get; set; }
    }
}
