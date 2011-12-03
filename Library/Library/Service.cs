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
        public static string HostPath = "";
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
            SqlCommand com = new SqlCommand("SELECT [MaGiaoVien],[MatKhau]FROM [GiaoVien] where MaGiaoVien='" + UserName + "' and MatKhau='" + PassWord + "'", con);
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
            SqlCommand com = new SqlCommand("SELECT [MaSinhVien],[MatKhau]FROM [SinhVien] where Masinhvien='" + UserName + "' and MatKhau='" + PassWord + "'", con);
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
        
    }
}
