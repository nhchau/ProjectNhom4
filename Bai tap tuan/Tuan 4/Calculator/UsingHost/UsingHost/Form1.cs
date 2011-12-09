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

namespace UsingHost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EndpointAddress address = new EndpointAddress("http://localhost:8000/Calculator");
        BasicHttpBinding binding = new BasicHttpBinding();
        double a;
        double b;


        private void Form1_Load(object sender, EventArgs e)
        {
                           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            ICalculator proxy = ChannelFactory<ICalculator>.CreateChannel(binding, address);
            textBox3.Text = Convert.ToDouble(proxy.Add(a,b)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            ICalculator proxy = ChannelFactory<ICalculator>.CreateChannel(binding, address);
            textBox3.Text = Convert.ToDouble(proxy.Sub(a, b)).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            ICalculator proxy = ChannelFactory<ICalculator>.CreateChannel(binding, address);
            textBox3.Text = Convert.ToDouble(proxy.Multi(a, b)).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            ICalculator proxy = ChannelFactory<ICalculator>.CreateChannel(binding, address);
            textBox3.Text = Convert.ToDouble(proxy.Devi(a, b)).ToString();
        }
    }
}
