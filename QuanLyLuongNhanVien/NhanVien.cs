using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyLuongNhanVien
{
    class NhanVien
    {
        const int LuongCB = 1150;

        private string _maNV;
        private string _tenNV;
        private string _phongBan;
        private string _chucVu;
        private double _hsl;
        private int _thamNien;
        private double _soNgayLam;
        public string MaNV
        {
            get { return this._maNV; }
            set { this._maNV = value; }
        }
        public string TenNV
        {
            get { return this._tenNV; }
            set { this._tenNV = value; }
        }
        public string PhongBan
        {
            get { return this._phongBan; }
            set { this._phongBan = value; }
        }
        public string ChucVu
        {
            get { return this._chucVu; }
            set { this._chucVu = value; }
        }
        public double HSL
        {
            get { return this._hsl; }
            set { this._hsl = value; }
        }
        public int ThamNien
        {
            get { return this._thamNien; }
            set { this._thamNien = value; }
        }
        public double SoNgayLam
        {
            get { return this._soNgayLam; }
            set { this._soNgayLam = value; }
        }
        public double HeSoThiDua
        {
            get
            {
                if (this._chucVu == "Lãnh đạo")
                    return 1.0;
                else
                {
                    if (this._soNgayLam > 22)
                        return 1.0;
                    else if (this._soNgayLam > 20)
                        return 0.8;
                    else
                        return 0.6;
                }
            }
        }
        public double PhuCap
        {
            get
            {
                if (this._chucVu == "Lãnh đạo")
                    return 2000;
                else
                    return 0;
            }
        }
        public double Luong
        {
            get { return this._hsl * LuongCB * HeSoThiDua + 1100 + PhuCap; }
        }
        public void showNV()
        {
            Console.WriteLine($"Thông tin nv {MaNV.PadRight(10)}");
            Console.WriteLine($"Tên: {TenNV.PadRight(10)}");
            Console.WriteLine($"Phòng ban: {PhongBan.PadRight(10)}");
            Console.WriteLine($"Chức vụ: {ChucVu.PadRight(10)}");
            Console.WriteLine($"Hệ số lương: {HSL}");
            Console.WriteLine($"Thâm niên: {ThamNien}");
            Console.WriteLine($"Số ngày làm: {SoNgayLam}");
            Console.WriteLine("-------------------------------------------");
        }
    }
}
