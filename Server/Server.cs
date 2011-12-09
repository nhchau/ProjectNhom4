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
using ServiceHost_Form;

namespace ServerTN
{
    public partial class Server : Form
    {
        private ServiceHost host;
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
           //EndpointSource.DataSource = Config.GetListConfigEnpoint();
           //grvEndpoints.DataSource = EndpointSource;
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

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            BindingList<Endpoint> endpointList = (BindingList<Endpoint>)this.EndpointSource.DataSource;
            //Config.SaveEndpointAddressLinQ(endpointList);
            MessageBox.Show("Success");  
        }

        private void grvEndpoints_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && grvEndpoints.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                EndpointSource.RemoveAt(e.RowIndex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string binding = cboBinding.SelectedItem.ToString();
            string address = "";
            switch (binding.ToUpper())
            {
                case "BASICHTTPBINDING":
                case "WSHTTPBINDING":
                case "WSDUALHTTPBINDING":
                    address = string.Format(@"http://localhost:{0}/IService", txtEndpointLocal.Text);
                    break;
                case "NETTCPBINDING":
                    address = string.Format(@"net.tcp://localhost:{0}/IService", txtEndpointLocal.Text);
                    break;
                case "MEXHTTPBINDING":
                    address = @"mex";
                    break;
                case "NETNAMEDPIPEBINDING":
                    address = @"net.pipe://localhost/IService";
                    break;
                default: break;
            }
            if (address != "")
                EndpointSource.Add(new Endpoint(address, binding));
        }                
    }
}