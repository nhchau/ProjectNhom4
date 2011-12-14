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
    public partial class Register : Form
    {
        string HOST;
        BasicHttpBinding binding = new BasicHttpBinding();
        public Register(string IP)
        {
            InitializeComponent();
            HOST = IP;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tenSV = "SV"+textBox3.Text;
            string tenGV = "GV" + textBox3.Text;
            //DateTime ngaysinh=comboBox1.SelectedItem.ToString()+"/"+comboBox2.SelectedItem.ToString()+"/"+comboBox3.SelectedItem.ToString();
            EndpointAddress address = new EndpointAddress("http://"+HOST+"/:8000/IService");            
            IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
            if (checkBox1.Checked)
                proxy.Register(tenGV, textBox1.Text, textBox2.Text, true);
            else
                proxy.Register(tenSV, textBox1.Text, textBox2.Text, false);
        }        
    }
}
