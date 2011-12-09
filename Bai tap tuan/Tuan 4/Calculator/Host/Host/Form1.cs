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

namespace Host
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Uri baseAddress = new Uri("http://localhost:8000/");
            Type contractType = typeof(ICalculator);
            Type instanceType = typeof(Calculator);
            ServiceHost host = new ServiceHost(instanceType, baseAddress);

            host.AddServiceEndpoint(contractType, new BasicHttpBinding(), "Calculator");
            // behavior = new ServiceMetadataBehavior();
            //behavior.HttpGetEnabled = true;
            //host.DescriptServiceMetadataBehaviorion.Behaviors.Add(behavior);
            //host.AddServiceEndpoint(typeof(IMetadataExchange), new BasicHttpBinding(), "MEX");

            host.Open();
            //host.Close();
        }
        
    }
}