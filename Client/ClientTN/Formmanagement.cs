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
            dataGridView1.DataSource = proxy.GetStudent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EndpointAddress address = new EndpointAddress("http://" + HOST + "/:8000/IService");
            IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
            dataGridView1.DataSource = proxy.GetTeacher();
        }
    }
}
