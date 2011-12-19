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
            try
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
                                new Formmanagement(HOST).Show();
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
                            IService proxy = ChannelFactory<IService>.CreateChannel(binding, address);
                            if (proxy.CheckLoginGV(TxtUserName.Text, TxtPassWord.Text))
                            {
                                this.Hide();
                                new Main(TxtUserName.Text, HOST, true).Show();
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
                                new Main(TxtUserName.Text, HOST, false).Show();                               
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
            catch (FaultException exp)
            {
                MessageBox.Show(exp.Code.Name + ": " + exp.Message.ToString(), exp.GetType().ToString());
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString(), exp.GetType().ToString());
            }
        }       

        private void button1_Click_1(object sender, EventArgs e)
        {
            HOST = textBoxIP.Text;
            if (textBoxIP.Text == "")
                MessageBox.Show("Bạn phải nhập địa chỉ máy chủ");
            else
                new Register(HOST).Show();
        }        
    }
}
