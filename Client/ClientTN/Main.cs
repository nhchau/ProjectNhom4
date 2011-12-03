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
        BasicHttpBinding binding = new BasicHttpBinding();
        public Main(string IP)
        {
            InitializeComponent();
            HOST = IP;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            EndpointAddress address = new EndpointAddress("http://" + HOST + "/:8000/IService");
            IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
            Lb_Aut.Text = Lb_Aut.Text + proxy.GetAuthors();
            //dataGridView1.DataSource = proxy.LayDS_SinhVien();
            //dataGridView1.Show();
        }
    }
}
