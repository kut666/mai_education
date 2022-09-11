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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string title;
        public int mass;
        public double price;

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("", "Название");
            dataGridView1.Columns.Add("", "Масса");
            dataGridView1.Columns.Add("", "Цена");
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void блюдоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newform = new Form2();
            newform.ShowDialog();
            AbstractFactory factory1 = new Dish();
            Client c = new Client(factory1);
            title = newform.Title;
            mass = newform.Mass;
            c.Mass = mass;
            price = c.Run1();

        }

        private void напитокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 newform1 = new Form3();
            newform1.ShowDialog();
            AbstractFactory factory2 = new Drink();
            Client c = new Client(factory2);
            title = newform1.Title;
            mass = newform1.Mass;
            c.Mass = mass;
            price = c.Run1();
        }

        private void вывестиМенюToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            dataGridView1.Rows.Insert(0, 1);
            dataGridView1[0, 0].Value = title;
            dataGridView1[1, 0].Value = mass;
            dataGridView1[2, 0].Value = price;
        }

    }
}
