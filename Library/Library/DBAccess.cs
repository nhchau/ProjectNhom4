using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library
{
    public class DBAccess : MarshalByRefObject
    {
        public string chuoi()
        {
            return @"Data Source=.\;Initial Catalog=KhoaHoc;Integrated Security=True";
        }
        public SqlConnection taoketnoi()
        {
            SqlConnection con = new SqlConnection(chuoi().ToString());
            con.Open();
            return con;
        }        
        public DataTable TruyVan_TraVe_DataTable(string strSQL)
        {
            SqlConnection con = taoketnoi();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }        
        public int TruyVan_XuLy(string strSQL)
        {
            try
            {
                SqlConnection con = taoketnoi();                
                SqlCommand cmd = new SqlCommand(strSQL, con);
                int sodong = cmd.ExecuteNonQuery();
                return sodong;
            }
            catch
            {
                return -1;
            }
        }
        public object TruyVan_TraVe_GiaTri(string strSQL)
        {
            try
            {
                SqlConnection con = taoketnoi();
                SqlCommand cmd = new SqlCommand(strSQL, con);
                return cmd.ExecuteScalar();
            }
            catch
            {
                return -1;
            }
        }
    }
}
