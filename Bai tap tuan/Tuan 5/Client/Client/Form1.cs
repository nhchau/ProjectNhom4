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

namespace Client
{
    public partial class Form1 : Form
    {
        BasicHttpBinding binding = new BasicHttpBinding();        
        public Form1()
        {               
            InitializeComponent();            
        }
        /*private void Bt_Ent_Click(object sender, EventArgs e)
        {
            try
            {
                EndpointAddress address = new EndpointAddress(Txt_EndAdd.Text); 
                ICalculator proxy = ChannelFactory<ICalculator>.CreateChannel(binding, address);               
                string s = proxy.GetAuthor();
                label1.Text = s.ToString();                             
            }
            catch
            { MessageBox.Show("Can not found End Point Address"); }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                EndpointAddress address = new EndpointAddress(Txt_EndAdd.Text);
                ICalculator proxy = ChannelFactory<ICalculator>.CreateChannel(binding, address);
                textBox3.Text = proxy.Add(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();
            }
            catch
            { MessageBox.Show("Can not found End Point Address"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                EndpointAddress address = new EndpointAddress(Txt_EndAdd.Text);
                ICalculator proxy = ChannelFactory<ICalculator>.CreateChannel(binding, address);
                textBox3.Text = proxy.Subtract(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();
            }
            catch
            { MessageBox.Show("Can not found End Point Address"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                EndpointAddress address = new EndpointAddress(Txt_EndAdd.Text);
                ICalculator proxy = ChannelFactory<ICalculator>.CreateChannel(binding, address);
                textBox3.Text = proxy.Multiply(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();
            }
            catch
            { MessageBox.Show("Can not found End Point Address"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //try
            {
                EndpointAddress address = new EndpointAddress(Txt_EndAdd.Text);
                ICalculator proxy = ChannelFactory<ICalculator>.CreateChannel(binding, address);
                textBox3.Text = proxy.Divide(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();
            }
           // catch
            //{ MessageBox.Show("Can not found End Point Address"); }
        }      
    }
}
