using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Project.Model
{
    class DataProvider
    {
        public static bool checkLogin(String username, String password)
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                var dataset = db.Users.Where(x => x.Username == username && x.Password == password).ToList();
                if (dataset.Count > 0) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<SanPham> getAllProduct()
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                var dataset = db.Products.Where(x => x.isDeleted == "0").ToList();
                List<SanPham> result = new List<SanPham>();
                for (int i = 0; i < dataset.Count; i++)
                {
                    SanPham temp = new SanPham();
                    temp.STT = (i + 1).ToString();
                    temp.Name = dataset[i].Name;
                    temp.ProductID = dataset[i].ProductID;
                    temp.CategoryID = dataset[i].CategoryID;
                    Category category = db.Categories.Where(x => x.CategoryID == temp.CategoryID).First();
                    temp.CategoryName = category.Name;
                    temp.Cost = dataset[i].Cost;
                    temp.Quantity = dataset[i].Quantity.ToString();
                    result.Add(temp);
                }
                return result;
            }
            catch (Exception)
            {
                List<SanPham> result = new List<SanPham>();
                return result;
            }
        }

        public static bool AddProduct(string Ten_SP, string ID_SP, string Gia_SP, string Loai_SP,int SoLuong)
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                var dataset = db.Categories.FirstOrDefault(x => x.Name == Loai_SP);
                Product product = new Product();
                product.Name = Ten_SP;
                product.isDeleted = "0";
                product.ProductID = ID_SP;
                product.Cost = Gia_SP;
                product.Quantity = SoLuong;
                product.CategoryID = dataset.CategoryID;
                db.Products.Add(product);
                int res = db.SaveChanges();
                if (res > 0) return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public static bool DeleteProducts(string ID)
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                var itemToRemove = db.Products.SingleOrDefault(x => x.ProductID == ID); //returns a single item.

                if (itemToRemove != null)
                {
                    db.Products.Remove(itemToRemove);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool UpdateProducts(string Ten_SP, string ID_SP, string Gia_SP, string Loai_SP,int So_Luong)
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                var dataset = db.Categories.FirstOrDefault(x => x.Name == Loai_SP);
                Product p = db.Products.First(x => x.ProductID == ID_SP);
                p.Name = Ten_SP;
                p.CategoryID = dataset.CategoryID;
                p.Cost = Gia_SP;
                p.Quantity = So_Luong;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static List<Category1> getAllCategory()
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                List<Category1> result = new List<Category1>();
                var dataset = db.Categories.Where(x => x.isDeleted == "0").ToList();
                for (int i = 0; i < dataset.Count; i++)
                {
                    Category1 temp = new Category1();
                    temp.STT = i + 1;
                    temp.Name = dataset[i].Name;
                    temp.CategoryID = dataset[i].CategoryID;
                    result.Add(temp);
                }
                return result;
            }
            catch (Exception)
            {
                return (new List<Category1>());
            }
        }

        public static bool AddCategory(string CategoryID, string Name)
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                Category category = new Category();
                category.isDeleted = "0";
                category.CategoryID = CategoryID;
                category.Name = Name;
                db.Categories.Add(category);
                int res = db.SaveChanges();
                if (res > 0) return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public static bool DeleteCategory(string CategoryID)
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                var itemToRemove = db.Categories.SingleOrDefault(x => x.CategoryID == CategoryID); //returns a single item.
                if (itemToRemove != null)
                {
                    itemToRemove.isDeleted = "1";
                    int res = db.SaveChanges();
                    if (res > 0) return true;
                    else return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool UpdateCategory(string CategoryID, string CategoryName)
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                Category p = db.Categories.First(x => x.CategoryID == CategoryID);
                p.Name = CategoryName;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Product GetInfoProduct(string ProductName)
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                Product p = new Product();
                p = db.Products.First(x => x.Name == ProductName);
                return p;
            }
            catch (Exception e)
            {
                return new Product();
            }
        }

        public static bool CreateBill(List<Item> items, string CustomerName, string BillID, string Total, string tt,string CurrentCoupon = "")
        {
            try
            {
                // Insert into table Bill
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                Bill ItemBill = new Bill();
                ItemBill.Total = Total;
                ItemBill.CustomerName = CustomerName;
                ItemBill.Bill_ID = BillID;
                ItemBill.TrangThai = tt;
                if (CurrentCoupon != "")
                {
                    ItemBill.CouponID = CurrentCoupon;
                    var dataset = db.Coupons.FirstOrDefault(x => x.CouponID == CurrentCoupon);
                    dataset.SoLuong = dataset.SoLuong - 1;
                }
                DateTime today = DateTime.Today;
                ItemBill.Created_at = today;
                db.Bills.Add(ItemBill);
                // Insert into table BillInfo
                for (int i = 0; i < items.Count; i++) {
                    BillInfo billInfo = new BillInfo();
                    billInfo.Bill_ID = BillID;
                    billInfo.ProductID = items[i].ProductID;
                    billInfo.Qty = Int32.Parse(items[i].Qty);
                    var dataset = db.Products.FirstOrDefault(x => x.ProductID == billInfo.ProductID);
                    dataset.Quantity = dataset.Quantity - billInfo.Qty;
                    db.BillInfoes.Add(billInfo);
                }
                int res = db.SaveChanges();
                if (res > 0) return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static List<KeyValuePair<string, int>> GetRevenue(DateTime start, DateTime end)
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                var ListDate = db.Bills.Where(m => m.Created_at >= start && m.Created_at <= end).Select(m => m.Created_at).Distinct().ToList();
                //Find total Revenue in this date
                List<int> TotalRevenue = new List<int>();
                for (int i = 0; i < ListDate.Count; i++)
                {
                    DateTime d = DateTime.Parse(ListDate[i].ToString());
                    var count = db.Bills.Where(x => x.Created_at == d).ToList();
                    int total = 0;
                    for (int j = 0; j < count.Count; j++)
                    {
                        total += Int32.Parse(count[j].Total);
                    }
                    TotalRevenue.Add(total);
                }
                List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
                for (int i = 0; i < ListDate.Count; i++)
                {
                    DateTime d = DateTime.Parse(ListDate[i].ToString());
                    valueList.Add(new KeyValuePair<string, int>(d.ToString("dd/MM/yyyy"), TotalRevenue[i]));
                }
                return valueList;


            }
            catch (Exception e)
            {
                List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
                return valueList;

            }
        }

        public static List<KeyValuePair<string, int>> GetProducts(DateTime start, DateTime end)
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                var dataset = (from p in db.Bills
                               join q in db.BillInfoes
                               on p.Bill_ID equals q.Bill_ID
                               where p.Created_at >= start && p.Created_at <= end
                               select q
                              ).ToList();
                List<string> ProductID = new List<string>();
                List<string> ProductName = new List<string>();
                List<int> Qty = new List<int>();
                for (int i = 0; i < dataset.Count; i++)
                {
                    int index = ProductID.IndexOf(dataset[i].ProductID);
                    int t = Int32.Parse(dataset[i].Qty.ToString());
                    if (index != -1)
                    {
                        Qty[index] = Qty[index] + t;
                    }
                    else {
                        ProductID.Add(dataset[i].ProductID);
                        Qty.Add(t);
                    }
                }
                for (int i = 0; i < ProductID.Count; i++)
                {
                    string str = ProductID[i].Trim();
                    Product p = db.Products.First(x => x.ProductID == str);
                    ProductName.Add(p.Name);
                }

                List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
                for (int i = 0; i < ProductName.Count; i++)
                {
                    string Name = ProductName[i].Trim();
                    valueList.Add(new KeyValuePair<string, int>(Name, Qty[i]));
                }
                return valueList;


            }
            catch (Exception e)
            {
                List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
                return valueList;

            }
        }

        public static List<SaleProduct> GetHistory(DateTime start, DateTime end)
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                var dataset = (from p in db.Bills
                               join q in db.BillInfoes
                               on p.Bill_ID equals q.Bill_ID
                               where p.Created_at >= start && p.Created_at <= end
                               select q
                              ).ToList();
                List<SaleProduct> result = new List<SaleProduct>();
                List<string> ProductID = new List<string>();
                List<string> ProductName = new List<string>();
                List<int> Qty = new List<int>();
                for (int i = 0; i < dataset.Count; i++)
                {
                    int index = ProductID.IndexOf(dataset[i].ProductID);
                    int t = Int32.Parse(dataset[i].Qty.ToString());
                    if (index != -1)
                    {
                        Qty[index] = Qty[index] + t;
                    }
                    else
                    {
                        ProductID.Add(dataset[i].ProductID);
                        Qty.Add(t);
                    }
                }
                for (int i = 0; i < ProductID.Count; i++)
                {
                    string str = ProductID[i].Trim();
                    Product p = db.Products.First(x => x.ProductID == str);
                    SaleProduct sp = new SaleProduct();
                    sp.CategoryID = p.CategoryID;
                    sp.Cost = p.Cost;
                    sp.ProductID = p.ProductID;
                    sp.Name = p.Name;
                    sp.Qty = Qty[i].ToString();
                    sp.Total = (Qty[i] * Int32.Parse(sp.Cost)).ToString();
                    sp.STT = i + 1;
                    result.Add(sp);
                }
                return result;
            }
            catch (Exception e)
            {
                List<SaleProduct> result = new List<SaleProduct>();
                return result;
            }
        }

        public static List<SanPham> GetProductsByName(string categoryName)
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                var dataset = (from p in db.Products
                               join q in db.Categories
                               on p.CategoryID equals q.CategoryID
                               where q.Name == categoryName && p.isDeleted == "0"
                               select new { p, q.Name }
                              ).ToList();
                List<SanPham> result = new List<SanPham>();
                for (int i = 0; i < dataset.Count; i++)
                {
                    SanPham temp = new SanPham();
                    temp.STT = (i + 1).ToString();
                    temp.ProductID = dataset[i].p.ProductID;
                    temp.CategoryName = dataset[i].Name;
                    temp.CategoryID = dataset[i].p.CategoryID;
                    temp.Cost = dataset[i].p.Cost;
                    temp.Name = dataset[i].p.Name;
                    temp.Quantity = dataset[i].p.Quantity.ToString();
                    result.Add(temp);
                }
                return result;
            }
            catch (Exception)
            {
                return (new List<SanPham>());
            }
        }

        public static bool CreateCoupon(string ID, int phanTram, int soLuong)
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                Coupon coupon = new Coupon();
                coupon.CouponID = ID;
                coupon.SoLuong = soLuong;
                coupon.PhanTram = phanTram;
                db.Coupons.Add(coupon);
                int res = db.SaveChanges();
                if (res > 0) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<CouponItem> getAllCoupon(){
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                var dataset = db.Coupons.Where(x => x.SoLuong > 0).ToList();
                List<CouponItem> result = new List<CouponItem>();
                for(int i = 0; i < dataset.Count; i++)
                {
                    CouponItem temp = new CouponItem();
                    temp.STT = (i + 1).ToString();
                    temp.CouponID = dataset[i].CouponID;
                    temp.SoLuong = dataset[i].SoLuong.ToString();
                    temp.PhanTram = dataset[i].PhanTram.ToString();
                    result.Add(temp);
                }
                return result;
            }
            catch
            {
                return (new List<CouponItem>());
            }

        }

        public static List<BillItem> GetBillItems(DateTime start, DateTime end)
        {
            try
            {
                List<BillItem> result = new List<BillItem>();
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                var dataset = db.Bills.Where(x => x.Created_at >= start && x.Created_at <= end).ToList();
                for(int i = 0; i < dataset.Count; i++)
                {
                    BillItem temp = new BillItem();
                    temp.STT = (i + 1).ToString();
                    temp.CustomerName = dataset[i].CustomerName;
                    temp.BillID = dataset[i].Bill_ID;
                    DateTime date = DateTime.Parse(dataset[i].Created_at.ToString());
                    temp.Created_at = date.ToString("dd/MM/yyyy");
                    temp.Status = dataset[i].TrangThai;
                    temp.Total = dataset[i].Total;
                    result.Add(temp);
                }
                return result;

            }
            catch
            {
                return (new List<BillItem>());
            }
        }

        public static int GetCoupon(string Coupon)
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                var dataset = db.Coupons.Where(x => x.CouponID == Coupon && x.SoLuong > 0).First();
                return dataset.PhanTram?? default(int);
            }
            catch
            {
                return 0;
            }
        }

        public static string getCategoryName(string CategoryID)
        {
            try
            {
                QuanLyBanHangEntities db = new QuanLyBanHangEntities();
                var dataset = db.Categories.FirstOrDefault(x => x.CategoryID == CategoryID);
                return dataset.Name;
            }
            catch
            {
                return "";
            }
        }
    }

    public class CouponItem
    {
        public string STT { get; set; }
        public string CouponID { get; set; }
        public string PhanTram { get; set; }
        public string SoLuong { get; set; }
    }
    public class SanPham
    {
        public string STT { get; set; }
        public string Name { get; set; }
        public string ProductID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryID { get; set; }
        public string Cost { get; set; }
        public string Quantity { get; set; }


    }

    public class Category1
    {
        public int STT { get; set; }
        public string CategoryID { get; set; }
        public string Name { get; set; }
    }

    public class SaleProduct
    {
        public int STT { get; set; }
        public string ProductID { get; set; }
        public string Name { get; set; }
        public string CategoryID { get; set; }
        public string Cost { get; set; }
        public string Qty { get; set; }
        public string Total { get; set; }

    }

    public class BillItem
    {
        public string STT { get; set; }
        public string BillID { get; set; }
        public string CustomerName { get; set; }
        public string Created_at { get; set; }
        public string Total { get; set; }
        public string Status { get; set; }
    }
}
