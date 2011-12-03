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
    public partial class FormLogin : Form
    {    
        public FormLogin()
        {
            InitializeComponent();            
        }
        public string HOST;        
        BasicHttpBinding binding = new BasicHttpBinding();
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            HOST = textBoxIP.Text;
            EndpointAddress address = new EndpointAddress("http://"+HOST+"/:8000/IService");
            if (textBoxIP.Text == "")
            {
                MessageBox.Show("IP Address are required to connect to the Server\n");
                return;
            }
            //try
            {                           
                string uname = TxtUserName.Text.Substring(0, 2);            
                switch (uname.ToUpper())
                {
                    case "AD":
                        {
                            IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
                            if (proxy.CheckLoginAD(TxtUserName.Text, TxtPassWord.Text))
                            {
                                this.Hide();
                                //new FormManagement(true, TxtUserName.Text, HOST).Show();
                            }
                            else
                            {
                                MessageBox.Show("Wrong Acount", "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                TxtUserName.Focus();
                                TxtPassWord.Clear();
                            }
                            break;
                        }
                    case "GV":
                        {
                            String uri = "tcp://" + HOST + ":123/IGiaoVien";
                            IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
                            if (proxy.CheckLoginGV(TxtUserName.Text, TxtPassWord.Text))
                            {
                                this.Hide();
                                //new FormManagement(false, TxtUserName.Text, HOST).Show();
                                new Main(HOST).Show();
                            }
                            else
                            {
                                MessageBox.Show("Wrong Acount", "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                TxtUserName.Focus();
                                TxtPassWord.Clear();
                            }
                            break;
                        }
                    default:
                        {
                            IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
                            
                            if (proxy.CheckLoginSV(TxtUserName.Text, TxtPassWord.Text))
                            {
                                this.Hide();
                                //new FormWaitforTesing(TxtUserName.Text, HOST).Show();
                                new Main(HOST).Show();
                            }
                            else
                            {
                                MessageBox.Show("Wrong Acount", "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                TxtUserName.Focus();
                                TxtPassWord.Clear();
                            }
                            break;
                        }
                }
            }
            //catch
            {
                MessageBox.Show("Can not connect to Server");
            }
        }
    }
}
