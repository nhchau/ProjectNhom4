using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel.Description;
using System.ServiceModel;
using Library;

namespace ClientTN
{
    public partial class Main : Form
    {
        public string HOST;
        bool ISGV;
        string Ten;
        BasicHttpBinding binding = new BasicHttpBinding();
        public Main(string ten, string IP, bool IsGV)
        {
            InitializeComponent();
            HOST = IP;
            ISGV = IsGV;
            Ten = ten;
        } 

        private void Main_Load(object sender, EventArgs e)
        {
            DBAccess Db = new DBAccess();
            EndpointAddress address = new EndpointAddress("http://" + HOST + "/:8000/IService");
            IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
            Lb_Aut.Text = Lb_Aut.Text + proxy.GetAuthors();
            if (ISGV == false)
            {
                groupBox1.Enabled = false;
            }            
            gv.DataSource = Db.TruyVan_TraVe_DataTable("SELECT Makh, Tenkh, manganh FROM khoahoc");            
            gv.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBAccess Db = new DBAccess();
            int manguoidang = int.Parse(Db.TruyVan_TraVe_GiaTri("select ma from Nguoidang where Ten='"+Ten+"'").ToString());
            EndpointAddress address = new EndpointAddress("http://" + HOST + "/:8000/IService");
            IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
            string manganh=comboBox1.SelectedItem.ToString();
            DateTime batdau = DateTime.Today;
            DateTime kethuc = DateTime.Now;            
            proxy.Addcourse(txtTenkh.Text, manganh, batdau, kethuc, ricCT.Text, Int32.Parse(txtHocPhi.Text), manguoidang);          
        }      

        private void button3_Click(object sender, EventArgs e)
        {
            DBAccess Db = new DBAccess();
            EndpointAddress address = new EndpointAddress("http://" + HOST + "/:8000/IService");
            IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
            gv.DataSource = Db.TruyVan_TraVe_DataTable("select tenkh, manganh from KhoaHoc, CTKH where KhoaHoc.MaKH=CTKH.Makh and Chitiet like('%" + txtTen.Text + "%')");
            gv.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DBAccess Db = new DBAccess();
            string manganh = comboBox2.SelectedItem.ToString();
            gv.DataSource = Db.TruyVan_TraVe_DataTable("select tenkh, manganh from KhoaHoc, CTKH where manganh='"+manganh+"'");
            gv.Show();
        }

        /*private void gv_SelectionChanged(object sender, EventArgs e)
        {
            DBAccess Db = new DBAccess();
            int r = gv.CurrentCell.RowIndex;
            int makh = int.Parse(gv.Rows[r].Cells[0].Value.ToString());
            gv.DataSource = Db.TruyVan_TraVe_DataTable(@"Select KhoaHoc.TenKH, KhoaHoc.Manganh, CTKH.batdau, CTKH.ketthuc, CTKH.Chitiet, CTKH.Hocphi, Nguoidang.Ten, Nguoidang.DT
                                             from KhoaHoc, CTKH, Nguoidang
                                             where KhoaHoc.MaKH=CTKH.Makh and CTKH.Manguoidang=Nguoidang.Ma and KhoaHoc.MaKH=" + makh + "");
            gv.Show();
            //DateTime thoigian = DateTime.Now;
            //int Manguoihoc = Int32.Parse(Db.TruyVan_TraVe_GiaTri("Select Ma from Nguoihoc where Ten='" + Ten + "'").ToString());
            //MessageBox.Show(makh.ToString()+"\n nguoi hoc"+Manguoihoc.ToString(), "Bạn có muốn lưu khóa học này");
            //Db.TruyVan_XuLy("INSERT INTO [Quantam]([Makh],[Manguoihoc],[Thoigian])VALUES(N'" + makh + "',N'" + Manguoihoc + "',N'" + thoigian + "')");

        }*/
        private void btDS_Click(object sender, EventArgs e)
        {
            DBAccess Db = new DBAccess();
            int Manguoihoc = Int32.Parse(Db.TruyVan_TraVe_GiaTri("Select Ma from Nguoihoc where Ten='" + Ten + "'").ToString());
            EndpointAddress address = new EndpointAddress("http://" + HOST + "/:8000/IService");
            IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
            gv.DataSource = Db.TruyVan_TraVe_DataTable("select TenKH, Manganh from KhoaHoc, Quantam where KhoaHoc.MaKH=Quantam.Makh and Manguoihoc='"+Manguoihoc+"'");
            gv.Show();
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            DBAccess Db = new DBAccess();
            int makh = int.Parse(txtCT.Text);
            gv.DataSource = Db.TruyVan_TraVe_DataTable(@"Select KhoaHoc.TenKH, KhoaHoc.Manganh, CTKH.batdau, CTKH.ketthuc, CTKH.Chitiet, CTKH.Hocphi, Nguoidang.Ten, Nguoidang.DT
                                             from KhoaHoc, CTKH, Nguoidang
                                             where KhoaHoc.MaKH=CTKH.Makh and CTKH.Manguoidang=Nguoidang.Ma and KhoaHoc.MaKH=" + makh + "");
            gv.Show();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {           
            try
            {
                int makh = int.Parse(txtCT.Text);
                DBAccess Db = new DBAccess();
                DateTime thoigian = DateTime.Now;
                int Manguoihoc = Int32.Parse(Db.TruyVan_TraVe_GiaTri("Select Ma from Nguoihoc where Ten='" + Ten + "'").ToString());
                Db.TruyVan_XuLy("INSERT INTO [Quantam]([Makh],[Manguoihoc],[Thoigian])VALUES(N'" + makh + "',N'" + Manguoihoc + "',N'" + thoigian + "')");
                MessageBox.Show("Khóa học đã được thêm vào danh sách");
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn mã khóa học quan tâm");
            }
         }          
    }
}
