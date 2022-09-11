using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public string Title { get; set; }
        public int Mass { get; set; }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Title = textBox1.Text;
            Mass = int.Parse(textBox2.Text);

            AbstractFactory factory2 = new Drink();
            Client c = new Client(factory2);
            c.Run2();

            Close();
        }
    }
}
