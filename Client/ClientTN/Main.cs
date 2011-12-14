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
        BasicHttpBinding binding = new BasicHttpBinding();
        public Main(string IP, bool IsGV)
        {
            InitializeComponent();
            HOST = IP;
            ISGV = IsGV;
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
            dataGridView1.DataSource = Db.TruyVan_TraVe_DataTable("SELECT Makh, Tenkh, manganh FROM khoahoc");
            dataGridView1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int manguoidang = 1;
            EndpointAddress address = new EndpointAddress("http://" + HOST + "/:8000/IService");
            IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
            string manganh=comboBox1.SelectedItem.ToString();
            DateTime batdau=DateTime.Now;
            DateTime kethuc=DateTime.Now;            
            proxy.Addcourse(textBox1.Text, manganh, batdau, kethuc, richTextBox1.Text, Int32.Parse(textBox2.Text), manguoidang);          
        }        

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            EndpointAddress address = new EndpointAddress("http://" + HOST + "/:8000/IService");
            IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
            int r = dataGridView1.CurrentCell.RowIndex;
            int makh = (int)dataGridView1.Rows[r].Cells[0].Value;

            Chitietkh kh = proxy.GetCourseDetail(makh.ToString());
            string manganh = kh.Manganh;
            MessageBox.Show(manganh, "Thông tin chi tiết khóa học", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }             
    }
}
