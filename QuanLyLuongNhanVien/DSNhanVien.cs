using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace QuanLyLuongNhanVien
{
    class DSNhanVien:NhanVien
    {
        private List<NhanVien> listNhanVien = null;
        public DSNhanVien()
        {
            listNhanVien = new List<NhanVien>();
        }
        public int soLuongNV()
        {
            int count = 0;
            if (listNhanVien != null)
                count = listNhanVien.Count;
            return count;
        }
        public void docfile(String file)
        {
            XmlDocument read = new XmlDocument();
            read.Load(file);
            XmlNodeList nodeList = read.SelectNodes("/DSNV/NhanVien");

            foreach(XmlNode node in nodeList)
            {
                NhanVien nv = new NhanVien();
                nv.MaNV = node["MaNV"].InnerText;
                nv.TenNV = node["TenNV"].InnerText;
                nv.PhongBan = node["PhongBan"].InnerText;
                nv.ChucVu = node["ChucVu"].InnerText;
                nv.HSL = XmlConvert.ToDouble(node["HSL"].InnerText);
                nv.ThamNien = XmlConvert.ToInt32(node["ThamNien"].InnerText);
                nv.SoNgayLam = XmlConvert.ToDouble(node["SoNgayLam"].InnerText);
                listNhanVien.Add(nv);
            }
        }
        public void showDSNhanVien(List<NhanVien> listNV)
        {
            if (listNhanVien != null && listNhanVien.Count > 0)
            {
                foreach (NhanVien nv in listNhanVien)
                {
                    nv.showNV();
                }
            }
            Console.WriteLine();
        }
        public void showGroupHSTD(List<NhanVien> listNV, double hstd)
        {
            if (listNhanVien != null && listNhanVien.Count > 0)
            {
                foreach (NhanVien nv in listNhanVien)
                {
                    if(nv.HeSoThiDua == hstd)
                    {
                        nv.showNV();
                    }
                }
            }
            Console.WriteLine();
        }
        public void showGroupPB(List<NhanVien> listNV, string phongban)
        {
            if (listNhanVien != null && listNhanVien.Count > 0)
            {
                foreach (NhanVien nv in listNhanVien)
                {
                    if (nv.PhongBan == phongban)
                    {
                        nv.showNV();
                    }
                }
            }
            Console.WriteLine();
        }
        public void showGroupCV(List<NhanVien> listNV, string chucvu)
        {
            if (listNhanVien != null && listNhanVien.Count > 0)
            {
                foreach (NhanVien nv in listNhanVien)
                {
                    if (nv.ChucVu == chucvu)
                    {
                        nv.showNV();
                    }
                }
            }
            Console.WriteLine();
        }
        public double sumSaraly()
        {
            double sum = 0;
            if (listNhanVien != null && listNhanVien.Count > 0)
            {
                foreach (NhanVien nv in listNhanVien)
                {
                    sum += nv.Luong;
                }
            }
            return sum;
        }
        public void removeDK()
        {
            int dem = soLuongNV();
            if (listNhanVien != null && listNhanVien.Count > 0)
            {
                for(int i = 0; i < dem; i++)
                {
                    if (listNhanVien[i].SoNgayLam < 10)
                    {
                        listNhanVien.Remove(listNhanVien[i]);
                        dem -= 1;
                        i -= 1;
                    }
                }
            }
        }
        public List<NhanVien> getListNV()
        {
            return listNhanVien;
        }
    }
}
