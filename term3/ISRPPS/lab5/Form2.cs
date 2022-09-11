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
    public partial class Form2 : Form
    { 
        public Form2()
        {
            InitializeComponent();
        }

        public string Title { get; set; }
        public int Mass { get; set; }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Title = textBox1.Text;
            Mass = int.Parse(textBox2.Text);

            AbstractFactory factory1 = new Dish();
            Client c = new Client(factory1);
            c.Run2();

            Close();
        }
    }

}
