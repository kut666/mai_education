using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ArrayList data;
        Menu menu;

        private void Form1_Load(object sender, EventArgs e)
        {
            data = new ArrayList();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = !comboBox2.Visible;
            textBox3.Visible = !textBox3.Visible;
            textBox4.Visible = !textBox4.Visible;
            button3.Visible = !button3.Visible;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = !comboBox1.Visible;
            textBox1.Visible = !textBox1.Visible;
            textBox2.Visible = !textBox2.Visible;
            button2.Visible = !button2.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length != 0)
                comboBox1.Items.Add(comboBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text.Length != 0)
                comboBox2.Items.Add(comboBox2.Text);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        { 
            comboBox1.SelectedIndex = -1;
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (radioButton1.Checked)
                menu = new Dish(comboBox1.Text, int.Parse(textBox1.Text), int.Parse(textBox2.Text));
            if (radioButton2.Checked)
                menu = new Drink(comboBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            data.Add(menu);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                menu = (Menu)data[i];
                    listBox1.Items.Add(menu.info());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int a;
            for (int i = 0; i < data.Count; i++)
            {
                a = menu.Price;
                menu = (Menu)data[i];
                if (a < 300)
                    listBox1.Items.Add(menu.info());
            }

          //  if (!checkBox1.Checked)
           //     listBox1.Items.Clear();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int b;
            for (int i = 0; i < data.Count; i++)
            {
                b = menu.Mass;
                menu = (Menu)data[i];
                if (b < 300)
                    listBox1.Items.Add(menu.info());
            }

           // if (!checkBox2.Checked)
            //    listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение <Меню ресторана> было разработано на языке C# в среде разработки Microsoft Visual Studio версии 2017 года \n\n" +
                            "Автор программы Махмудов Орхан, студент группы М8О-205Б-18 \n\n" +
                            "Версия приложения: 1.0");
        }
    }

}
