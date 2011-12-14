using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class Service : IService
    {
        DBAccess Db = new DBAccess();        
        public bool CheckLoginAD(string UserName, string PassWord)
        {
            SqlConnection con = new SqlConnection(Db.chuoi().ToString());
            SqlCommand com = new SqlCommand("SELECT [MaAdmin],[MatKhau]FROM [Admin] where MaAdmin='" + UserName + "' and MatKhau='" + PassWord + "'", con);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool CheckLoginGV(string UserName, string PassWord)
        {
            SqlConnection con = new SqlConnection(Db.chuoi().ToString());
            SqlCommand com = new SqlCommand("SELECT [Ten],[Mk]FROM [nguoidang] where Ten='" + UserName + "' and Mk='" + PassWord + "'", con);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool CheckLoginSV(string UserName, string PassWord)
        {
            SqlConnection con = new SqlConnection(Db.chuoi().ToString());
            SqlCommand com = new SqlCommand("SELECT [Ten],[Mk]FROM [nguoihoc] where Ten='" + UserName + "' and Mk='" + PassWord + "'", con);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string GetAuthors()
        {
            return "Nguyễn Hữu Châu";
        }
        public void Register(string UserName, string PassWord, string dienthoai, bool IsGV)
        {
            if(IsGV==true)
            Db.TruyVan_XuLy("INSERT INTO [Nguoidang]([Ten],[Mk],[DT])VALUES(N'"+UserName+"',N'"+PassWord+"',N'"+dienthoai+"')");
            else
            Db.TruyVan_XuLy("INSERT INTO [Nguoihoc]([Ten],[Mk],[DT])VALUES(N'" + UserName + "',N'" + PassWord + "',N'" + dienthoai + "')");     
        }
        public void Addcourse(string Tenkh, string manganh, DateTime batdau, DateTime kethuc, string chitiet, int hocphi, int manguoidang)
        {            
            Db.TruyVan_XuLy("INSERT INTO [khoahoc]([Tenkh],[Manganh])VALUES(N'" + Tenkh + "',N'" + manganh + "')");
            int makh = Int32.Parse(Db.TruyVan_TraVe_GiaTri("select makh from khoahoc where Tenkh='" + Tenkh + "'").ToString());
            Db.TruyVan_XuLy("INSERT INTO [CTKH]([makh],[Manguoidang],[batdau],[ketthuc],[chitiet],[hocphi])VALUES(N'" + makh + "',N'" + manguoidang + "',N'" + batdau + "',N'" + kethuc + "',N'" + chitiet + "',N'" + hocphi + "')");
        }
        public DataTable GetAllSubject()
        {
            return Db.TruyVan_TraVe_DataTable("SELECT Tenkh, manganh FROM khoahoc");
        }

        public Chitietkh GetCourseDetail(string makh)
        {
            Chitietkh kh = new Chitietkh();
            kh.Manganh = Db.TruyVan_TraVe_DataTable("Select manganh from khoahoc where makh='"+makh+"' ").ToString();
            kh.Batdau = Db.TruyVan_TraVe_DataTable("").ToString();
            kh.Ketthuc = Db.TruyVan_TraVe_DataTable("").ToString();
            kh.Hocphi = Db.TruyVan_TraVe_DataTable("").ToString();
            kh.Chitiet = Db.TruyVan_TraVe_DataTable("").ToString();
            kh.Tenlienlac = Db.TruyVan_TraVe_DataTable("").ToString();
            kh.Dtlienlac = Db.TruyVan_TraVe_DataTable("").ToString();          
            
            return kh;
        }
        public DataTable SearchAll(string key)
        {
            return Db.TruyVan_TraVe_DataTable("select tenkh, manganh from KhoaHoc, CTKH where KhoaHoc.MaKH=CTKH.Makh and Chitiet like('%"+key+"%')");
        }
        public DataTable SearchByCategory(string manganh)
        {
            return Db.TruyVan_TraVe_DataTable("select tenkh, manganh from KhoaHoc where manganh like('%" + manganh + "%')");
        }
        public DataTable GetTeacher()
        {
            return Db.TruyVan_TraVe_DataTable("select * from nguoidang");
        }
        public DataTable GetStudent()
        {
            return Db.TruyVan_TraVe_DataTable("select * from nguoihoc");
        }
    }    
}
