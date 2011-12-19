using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;

using Library;

namespace ClientTN
{
    public partial class Formmanagement : Form
    {
        string HOST;
        DBAccess Db = new DBAccess();
        BasicHttpBinding binding = new BasicHttpBinding();
        public Formmanagement(string IP)
        {
            InitializeComponent();
            HOST = IP;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            EndpointAddress address = new EndpointAddress("http://" + HOST + "/:8000/IService");
            IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
            dataGridView1.DataSource = Db.TruyVan_TraVe_DataTable("select * from nguoihoc");
            dataGridView1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EndpointAddress address = new EndpointAddress("http://" + HOST + "/:8000/IService");
            IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
            dataGridView1.DataSource = Db.TruyVan_TraVe_DataTable("select * from nguoidang");
            dataGridView1.Show();
        }
    }
}
