using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;

namespace Library
{
    public class Service : IService
    {
        DBAccess Db = new DBAccess();        
        public bool CheckLoginAD(string UserName, string PassWord)
        {
            SqlConnection con = new SqlConnection(Db.chuoi().ToString());
            SqlCommand com = new SqlCommand("SELECT [Tendangnhap],[MatKhau]FROM [Admin] where tendangnhap='" + UserName + "' and MatKhau='" + PassWord + "'", con);
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
            catch (ArgumentException exp)
            {               
                throw new FaultException("Tài khoản không hợp lệ:" +exp.ToString());
            }
            catch (Exception exp) 
            {                
                throw new FaultException("Can not connect to Server:" + exp.Message);
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
            catch (ArgumentException exp)
            {               
                throw new FaultException("Tài khoản không hợp lệ:" +exp.ToString());
            }
            catch (Exception exp) 
            {                
                throw new FaultException("Can not connect to Server:" + exp.Message);
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
            catch (ArgumentException exp)
            {
                throw new FaultException("Tài khoản không hợp lệ:" + exp.ToString());
            }
            catch (Exception exp)
            {
                throw new FaultException("Can not connect to Server:" + exp.Message);
            }
        }
        public string GetAuthors()
        {
            return "Nguyễn Hữu Châu";
        }
        public void Register(string UserName, string PassWord, string dienthoai, string SN, bool IsGV)
        {
            if(IsGV==true)
                Db.TruyVan_XuLy("INSERT INTO [Nguoidang]([Ten],[Mk],[DT],[SN])VALUES(N'" + UserName + "',N'" + PassWord + "',N'" + dienthoai + "',N'" + SN + "')");
            else
                Db.TruyVan_XuLy("INSERT INTO [Nguoihoc]([Ten],[Mk],[DT],[SN])VALUES(N'" + UserName + "',N'" + PassWord + "',N'" + dienthoai + "',N'" + SN + "')");     
        }
        public void Addcourse(string Tenkh, string manganh, DateTime batdau, DateTime kethuc, string chitiet, int hocphi, int manguoidang)
        {            
            Db.TruyVan_XuLy("INSERT INTO [khoahoc]([Tenkh],[Manganh])VALUES(N'" + Tenkh + "',N'" + manganh + "')");
            int makh = Int32.Parse(Db.TruyVan_TraVe_GiaTri("select makh from khoahoc where Tenkh='" + Tenkh + "'").ToString());
            Db.TruyVan_XuLy("INSERT INTO [CTKH]([makh],[Manguoidang],[batdau],[ketthuc],[chitiet],[hocphi])VALUES(N'" + makh + "',N'" + manguoidang + "',N'" + batdau + "',N'" + kethuc + "',N'" + chitiet + "',N'" + hocphi + "')");
        }        
        public AllSubject GetAllSubject()
        {
            AllSubject Su = new AllSubject();
            DataTable dt = new DataTable();
            dt=Db.TruyVan_TraVe_DataTable("Select * from khoahoc");
            Su.Makh = Int32.Parse(dt.Columns[0].ToString());
            Su.Tenkh = dt.Columns[1].ToString();
            Su.Manganh = dt.Columns[2].ToString();          
            return Su;
        }
        public Result SearchAll(string key)
        {
            Result Su = new Result();
            DataTable dt = new DataTable();
            dt=Db.TruyVan_TraVe_DataTable("select tenkh, manganh from KhoaHoc, CTKH where KhoaHoc.MaKH=CTKH.Makh and Chitiet like('%"+key+"%')");           
            Su.Tenkh = dt.Columns[1].ToString();
            Su.Manganh = dt.Columns[2].ToString();          
            return Su;            
        }
        public CourseDetail GetCourseDetail(string makh)
        {
            CourseDetail Su = new CourseDetail();
            DataTable dt = new DataTable();
            dt = Db.TruyVan_TraVe_DataTable(@"Select KhoaHoc.TenKH, KhoaHoc.Manganh, CTKH.batdau, CTKH.ketthuc, CTKH.Chitiet, CTKH.Hocphi, Nguoidang.Ten, Nguoidang.DT
                                             from KhoaHoc, CTKH, Nguoidang
                                             where KhoaHoc.MaKH=CTKH.Makh and CTKH.Manguoidang=Nguoidang.Ma and KhoaHoc.MaKH='"+makh+"'");
            Su.Tenkh = dt.Columns[0].ToString();
            Su.Manganh = dt.Columns[1].ToString();
            Su.Batdau = dt.Columns[2].ToString();
            Su.Ketthuc = dt.Columns[3].ToString();
            Su.Chitiet = dt.Columns[4].ToString();
            Su.Hocphi = Int32.Parse(dt.Columns[1].ToString());
            Su.Ten = dt.Columns[5].ToString();
            Su.Dt = dt.Columns[6].ToString();
            return Su;        
       
        }
        public ResultByCategory SearchByCategory(string manganh)
        {
            ResultByCategory Su = new ResultByCategory();
            DataTable dt = new DataTable();
            dt=Db.TruyVan_TraVe_DataTable("select tenkh, manganh from KhoaHoc, CTKH where KhoaHoc.MaKH=CTKH.Makh and Chitiet like('%"+manganh+"%')");           
            Su.Tenkh = dt.Columns[1].ToString();
            Su.Manganh = dt.Columns[2].ToString();          
            return Su;             
        }
        public Teacher GetTeacher()
        {
            Teacher Su = new Teacher();
            DataTable dt = new DataTable();
            dt=Db.TruyVan_TraVe_DataTable("select * from nguoidang");           
            Su.Ma = Int32.Parse(dt.Columns[1].ToString());
            Su.Ten = dt.Columns[2].ToString();
            Su.Mk= dt.Columns[2].ToString();
            Su.Dt = dt.Columns[2].ToString();
            Su.Sn = dt.Columns[2].ToString();             
            return Su; 
            
        }
        public Student GetStudent()
        {
            Student Su = new Student();
            DataTable dt = new DataTable();
            dt = Db.TruyVan_TraVe_DataTable("select * from nguoihoc");
            Su.Ma = Int32.Parse(dt.Columns[1].ToString());
            Su.Ten = dt.Columns[2].ToString();
            Su.Mk = dt.Columns[2].ToString();
            Su.Dt = dt.Columns[2].ToString();
            Su.Sn = dt.Columns[2].ToString();
            return Su; 
        }
    }    
}
