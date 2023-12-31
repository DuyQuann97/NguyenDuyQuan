using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Program
    {
        static List<ViecCanLam> listViecCanLam = new List<ViecCanLam>();
        static void Main(string[] args)
        {
            while (true)
            {
                HienThiMenu();

                Console.WriteLine("Nhap so de chon menu");
                try 
                {
                    int selectMenu = int.Parse(Console.ReadLine());
                    switch (selectMenu)
                    {
                        case 1:
                            KhaiBaoViecLam();
                            break;
                        case 2:
                            XoaViecLam();
                            break;
                        case 3:
                            CapNhatTrangThai();
                            break;
                        case 4:
                            TimKiemViecLam();
                            break;
                        case 5:
                            HienThiTheoDoUuTien();
                            break;
                        case 6:
                            HienThiToanBoViecLam();
                            break;
                        default:
                            Console.WriteLine("Thong tin nhap khong hop le");
                            break;
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("{0}",ex.Message);
                }
                Console.WriteLine();
                Console.WriteLine("Nhan phim bat ky de tiep tuc chuong trinh");
                Console.WriteLine("Nhan phim ESC de thoat chuong trinh");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.Clear();
            }
        }
        public static void HienThiMenu()
        {
            Console.WriteLine(" --- UNG DUNG GHI CHU VIEC CAN LAM --- ");
            Console.WriteLine();
            Console.WriteLine("1. Khai bao viec can lam");
            Console.WriteLine("2. Xoa viec lam da nhap truoc do");
            Console.WriteLine("3. Cap nhat trang thai viec lam truoc do");
            Console.WriteLine("4. Tim kiem thong tin viec can lam");
            Console.WriteLine("5. Hien thi danh sach viec can lam theo du uu tien giam dan");
            Console.WriteLine("6. Hien thi toan bo danh sach viec can lam");
            Console.WriteLine();
        }

        public static void KhaiBaoViecLam() 
        {
            Console.Write("Ten viec can lam: ");
            string tenViecLam = Console.ReadLine().Trim();
            int doUuTien = 5;
            try 
            {
                while (true)
                {
                    Console.Write("Do uu tien: ");
                    doUuTien = int.Parse(Console.ReadLine());
                    if (doUuTien > 0 && doUuTien <= 5)
                    {
                        break;
                    }
                    Console.WriteLine("Do Uu Tien tu 1 - 5 voi 1 la Uu Tien . Moi nhap lai !!") ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.Replace(ex.Message,"Do uu tien mac dinh la 5")); ;
            }

            Console.Write("Thong tin chi tiet viec can lam: ");
            string thongTinViecLam = Console.ReadLine();

            Console.Write("Trang thai viec lam: ");
            string trangThaiViecLam = Console.ReadLine();

            var viecCanlam = new ViecCanLam(tenViecLam, doUuTien, thongTinViecLam, trangThaiViecLam);
            listViecCanLam.Add(viecCanlam);
        }
        public static void XoaViecLam() 
        {
            string message = "Khong co viec lam de xoa";
            if (listViecCanLam.Count() > 0)
            {
                var lastItem = listViecCanLam.Count();
                listViecCanLam.RemoveAt(lastItem - 1);
                message = " => Da duoc xoa thanh cong viec lam truoc do";
            }
            Console.WriteLine("{0}", message);
            Console.WriteLine();
        }
        public static void CapNhatTrangThai() 
        {
            string message = "Khong co viec lam de cap nhat";
            if (listViecCanLam.Count() > 0)
            {
                var lastItem = listViecCanLam.LastOrDefault();
                Console.WriteLine("Ten viec lam muon thay doi: {0}", lastItem.tenViecCanLam);
                Console.WriteLine("Trang thai hien tai : {0}",lastItem.trangThaiViecCanLam);
                Console.Write("Cap nhat lai trang thai viec lam: ");
                var trangThaiMoi = Console.ReadLine();
                lastItem.trangThaiViecCanLam = trangThaiMoi;
                message = "Trang thai viec lam da duoc cap nhat";
            }
            Console.WriteLine("{0}", message);
            Console.WriteLine();
        }
        public static void TimKiemViecLam() 
        {
            string message = "Khong co viec lam de tim kiem";
            if (listViecCanLam.Count > 0)
            {
                Console.Write("Nhap ten cong viec muon tim kiem: ");
                string tenViecLam = Console.ReadLine().Trim();
                var isContains = listViecCanLam.FirstOrDefault(c => c.tenViecCanLam == tenViecLam);
                if (isContains != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ten viec can lam: {0}", isContains.tenViecCanLam);
                    Console.WriteLine("Do uu tien: {0}", isContains.doUuTien);
                    Console.WriteLine("Thong tin chi tiet: {0}", isContains.thongTinViecCanLam);
                    Console.WriteLine("Trang thai: {0}", isContains.trangThaiViecCanLam);
                    Console.WriteLine();
                    message = null;
                }
            }

            Console.WriteLine("{0}", message);
            Console.WriteLine();
        }
        public static void HienThiTheoDoUuTien() 
        {
            var listDoUuTien = listViecCanLam.OrderBy(c => c.doUuTien);
            foreach (var viecLam in listDoUuTien)
            {
                Console.WriteLine();
                Console.WriteLine("Ten viec can lam: {0}", viecLam.tenViecCanLam);
                Console.WriteLine("Do uu tien: {0}", viecLam.doUuTien);
                Console.WriteLine("Thong tin chi tiet: {0}", viecLam.thongTinViecCanLam);
                Console.WriteLine("Trang thai: {0}", viecLam.trangThaiViecCanLam);
                Console.WriteLine();
            }
        }
        public static void HienThiToanBoViecLam() 
        {
            string message = "khong viec lam de hien thi";
            if (listViecCanLam.Count > 0)
            {
                foreach (var viecLam in listViecCanLam)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ten viec can lam: {0}", viecLam.tenViecCanLam);
                    Console.WriteLine("Do uu tien: {0}", viecLam.doUuTien);
                    Console.WriteLine("Thong tin chi tiet: {0}", viecLam.thongTinViecCanLam);
                    Console.WriteLine("Trang thai: {0}", viecLam.trangThaiViecCanLam);
                    Console.WriteLine();
                }
                message = null;
            }
            Console.WriteLine("{0}", message) ;
            
        }

    }

}
