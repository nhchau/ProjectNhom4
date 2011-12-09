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

namespace Hosting
{
    public partial class Host : Form
    {       
        ServiceHost host;       
        public Host()
        {
            InitializeComponent();
        }

        /*public void State()
        {
            if (Bt_StaLis.Text == "Start Listening")
            {
                Bt_StaLis.Text = "Stop Listening";
                host.Open();
                Lb_Sta.Text = "Server stating at EndPointAddress " + Txt_BasAdd.Text + "/" + Txt_EndPoi.Text;
            }
            else
            {
                Bt_StaLis.Text = "Start Listening";
                host.Close();
                Lb_Sta.Text = "";
                Txt_BasAdd.Text = "";
                Txt_BasAdd.Focus();
                Txt_EndPoi.Text = "";
            }
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            host = new ServiceHost(typeof(Calculator), new Uri(Txt_BasAdd.Text));
            host.AddServiceEndpoint(typeof(ICalculator), new BasicHttpBinding(), Txt_EndPoi.Text);
            host.Open();
            Lb_Sta.Text = "Server stating at EndPointAddress " + Txt_BasAdd.Text + "/" + Txt_EndPoi.Text;
            Bt_StaLis.Enabled = false;
            button1.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Bt_StaLis.Enabled = true;
            host.Close();
            Lb_Sta.Text = "";
            Txt_BasAdd.Text = "";
            Txt_BasAdd.Focus();
            Txt_EndPoi.Text = "";
        }     
    }
}
