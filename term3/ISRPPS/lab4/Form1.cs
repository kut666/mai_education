using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form2 Title;
        Form3 Dish;

        public int mass, price;
        public string name;

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("", "Название");
            dataGridView1.Columns.Add("", "Масса");
            dataGridView1.Columns.Add("", "Цена");
           dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Title = new Form2();
            Title.ShowDialog();
            name = Title.name;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Dish = new Form3();
            Dish.ShowDialog();
            mass = Dish.mass;
            price = Dish.price;
            dataGridView1.Rows.Insert(0, 1);
            dataGridView1[0, 0].Value = name;
            dataGridView1[1, 0].Value = mass;
            dataGridView1[2, 0].Value = price;
        }

        private void вывестиМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double s = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                s = s + (double)(dataGridView1[2, i].Value);
           
        }
    }
}
