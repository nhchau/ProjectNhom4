using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Data.OleDb;
using System.ServiceModel;
using System.ServiceModel.Description;
using Library;
using System.Net;

namespace ServerTN
{
    public partial class Server : Form
    {
        public ServiceHost host;
        private BindingSource EndpointSource = new BindingSource();
        public Server()
        {
            InitializeComponent();
        }        
       
        private void buttonStartListen_Click(object sender, EventArgs e)
        {
            Uri baseAddress = new Uri("http://"+GetIP()+"/:8000");
            Type contractType = typeof(IService);
            Type instanceType = typeof(Service);
            ServiceHost host = new ServiceHost(instanceType, baseAddress);
            host.AddServiceEndpoint(contractType, new BasicHttpBinding(), "IService");           
            host.Open();            
            UpdateControls(true);
            lblMessage.Text = "Server Is Listening At Port 8000";
            lblMessage.ForeColor = Color.Green;
        }
        private void UpdateControls(bool listening)
        {
            buttonStartListen.Enabled = !listening;
            buttonStopListen.Enabled = listening;
        }

        private void buttonStopListen_Click(object sender, EventArgs e)
        {           
            host.Close();
            UpdateControls(false);
        }              
       
        private void Form1_Load(object sender, EventArgs e)
        {            
           textBoxIP.Text = GetIP();          
        }
        String GetIP()
        {
            String strHostName = Dns.GetHostName();
            IPHostEntry iphostentry = Dns.GetHostByName(strHostName);
            String IPStr = "";
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                IPStr = ipaddress.ToString();
                return IPStr;
            }
            return IPStr;
        }
    }
}