using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;

namespace QuanLyLuongNhanVien
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.UTF8;
            DSNhanVien ds = new DSNhanVien();
            ds.docfile("C:/Users/ngoct/Desktop/Lap Trinh Nang Cao/BaiTapFinal/QuanLyLuongNhanVien/QuanLyLuongNhanVien/DSNV.xml");
            Console.WriteLine("Đọc dữ liệu thành công.");
            int option;
            do
            {
                Console.WriteLine("\nCHƯƠNG TRÌNH QUẢN LÝ NHÂN VIÊN C#");
                Console.WriteLine("*******************************************MENU********************************************");
                Console.WriteLine("**  1. Xuất thông tin tất cả các nhân viên trong công ty.                                **");
                Console.WriteLine("**  2. Xuất ra được thông tin nhân viên theo từng nhóm hệ số thi đua.                    **");
                Console.WriteLine("**  3. Danh sách nhân viên theo phòng cho trước.                                         **");
                Console.WriteLine("**  4. Danh sách các nhân viên có chức vụ là ―Lãnh đạo.                                  **");
                Console.WriteLine("**  5. Tổng lương công ty phải trả cho toàn bộ nhân viên.                                **");
                Console.WriteLine("**  6. Loại bỏ các nhân viên có số ngày làm nhỏ hơn 10 trong danh sách.                  **");
                Console.WriteLine("**  7. Danh sách các nhân viên không phải là lãnh đạo mà có số ngày làm việc lớn hơn 22. **");
                Console.WriteLine("**  8. Lấy ra danh sách các nhân viên có hệ số lương từ 4.34 trở lên và ở phòng ―Tài vụ. **");
                Console.WriteLine("**  0. Thoát.                                                                            **");
                Console.WriteLine("*******************************************************************************************");
                Console.Write("Nhập lựa chọn: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("\n1. Xuất thông tin tất cả các nhân viên trong công ty.");
                        ds.showDSNhanVien(ds.getListNV());
                        break;
                    case 2:
                        Console.WriteLine("\n2. Xuất ra được thông tin nhân viên theo từng nhóm hệ số thi đua.");
                        Console.WriteLine("\n*****Nhóm có hệ số thi đua 1.0.*****");
                        ds.showGroupHSTD(ds.getListNV(),1.0);

                        Console.WriteLine("\n*****Nhóm có hệ số thi đua 0.8.*****");
                        ds.showGroupHSTD(ds.getListNV(), 0.8);

                        Console.WriteLine("\n*****Nhóm có hệ số thi đua 0.6.*****");
                        ds.showGroupHSTD(ds.getListNV(), 0.6);
                        break;
                    case 3:
                        Console.WriteLine("\n3. Lấy danh sách nhân viên theo phòng cho trước.");
                        ds.showGroupPB(ds.getListNV(), "Vipro");
                        break;
                    case 4:
                        Console.WriteLine("\n4. Lấy ra danh sách các nhân viên có chức vụ là ―Lãnh đạo.");
                        ds.showGroupCV(ds.getListNV(), "Lãnh đạo");
                        break;
                    case 5:
                        Console.WriteLine($"\n5. Tổng lương công ty phải trả cho toàn bộ nhân viên là: {ds.sumSaraly()}");
                        break;
                    case 6:
                        Console.WriteLine("\n6. Loại bỏ các nhân viên có số ngày làm nhỏ hơn 10 trong danh sách.");
                        ds.removeDK();
                        Console.WriteLine("\nĐã xoá thành công.");
                        break;
                    case 7:
                        Console.WriteLine("\n7. Danh sách các nv không phải là lãnh đạo mà có số ngày làm việc lớn hơn 22.");
                        foreach(NhanVien nv in ds.getListNV())
                        {
                            if (nv.SoNgayLam > 22 && nv.ChucVu != "Lãnh đạo")
                                nv.showNV();
                                
                        }
                        break;
                    case 8:
                        Console.WriteLine("\n8. Danh sách các nhân viên có hệ số lương từ 4.34 trở lên và ở phòng ―Tài vụ.");
                        foreach (NhanVien nv in ds.getListNV())
                        {
                            if (nv.HSL > 4.34 && nv.PhongBan == "Tài vụ")
                                nv.showNV();
                        }
                        break;
                    default:
                        if (!option.Equals(0))
                            Console.WriteLine("Lựa chọn của bạn không có sẵn!!");
                        break;
                }
            } while (!option.Equals(0));

        }
    }
}
