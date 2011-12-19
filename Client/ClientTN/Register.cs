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
            try
            {
                if (txtMk == txtRMk)
                {
                    string tenSV = txtTen.Text;
                    string tenGV = "GV" + txtTen.Text;
                    string ngaysinh = comboBox1.SelectedItem.ToString() + "/" + comboBox2.SelectedItem.ToString() + "/" + comboBox3.SelectedItem.ToString();
                    EndpointAddress address = new EndpointAddress("http://" + HOST + "/:8000/IService");
                    IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
                    if (checkBox1.Checked == true)
                        proxy.Register(tenGV, txtMk.Text, txtDt.Text, ngaysinh, true);
                    else
                        proxy.Register(tenSV, txtMk.Text, txtDt.Text, ngaysinh, false);
                }
                else
                    MessageBox.Show("Mật khẩu không đúng");

            }
            catch
            {
                MessageBox.Show("Thông tin bạn nhập vào không đúng");
            }
        }        
    }
}
