using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Курсовая_работа_по_ООП
{
    public partial class Form1 : Form, IObserver
    {

        private Form1Controller controller;
        private LaunchModel model;
        int i = 0;

        public Form1()
        {
            InitializeComponent();
            model = new LaunchModel();
            model.Register(this);
            controller = new Form1Controller(this, model);

            this.BackgroundImageLayout = ImageLayout.Stretch;
            textBox31.Enabled = false;
            textBox32.Enabled = false;
            textBox33.Enabled = false;
        }

        public void UpdateState()
        {
            textBox32.Text = Convert.ToString(model.L1);
            textBox33.Text = Convert.ToString(model.L2);

            if (model.I == 0 && model.Per)
            {
                textBox17.Text = textBox1.Text;
                textBox2.Enabled = false;
            }
            else if (model.I == 0 && !model.Per)
            {
                textBox17.Text = textBox2.Text;
                textBox1.Enabled = false;
            }

            if (model.I == 2 && model.Per)
            {
                textBox18.Text = textBox3.Text;
                textBox4.Enabled = false;
            }
            else if (model.I == 2 && !model.Per)
            {
                textBox18.Text = textBox4.Text;
                textBox3.Enabled = false;
            }

            if (model.I == 4 && model.Per)
            {
                textBox19.Text = textBox5.Text;
                textBox6.Enabled = false;
            }
            else if (model.I == 4 && !model.Per)
            {
                textBox19.Text = textBox6.Text;
                textBox5.Enabled = false;
            }

            if (model.I == 6 && model.Per)
            {
                textBox20.Text = textBox7.Text;
                textBox8.Enabled = false;
            }
            else if (model.I == 6 && !model.Per)
            {
                textBox20.Text = textBox8.Text;
                textBox7.Enabled = false;
            }

            if (model.I == 8 && model.Per)
            {
                textBox21.Text = textBox9.Text;
                textBox10.Enabled = false;
            }
            else if (model.I == 8 && !model.Per)
            {
                textBox21.Text = textBox10.Text;
                textBox9.Enabled = false;
            }

            if (model.I == 10 && model.Per)
            {
                textBox22.Text = textBox11.Text;
                textBox12.Enabled = false;
            }
            else if (model.I == 10 && !model.Per)
            {
                textBox22.Text = textBox12.Text;
                textBox11.Enabled = false;
            }

            if (model.I == 12 && model.Per)
            {
                textBox23.Text = textBox13.Text;
                textBox14.Enabled = false;
            }
            else if (model.I == 12 && !model.Per)
            {
                textBox23.Text = textBox14.Text;
                textBox13.Enabled = false;
            }

            if (model.I == 14 && model.Per)
            {
                textBox24.Text = textBox15.Text;
                textBox16.Enabled = false;
            }
            else if (model.I == 14 && !model.Per)
            {
                textBox24.Text = textBox16.Text;
                textBox15.Enabled = false;
            }

            if (model.I == 16 && model.Per)
            {
                textBox25.Text = textBox17.Text;
                textBox18.Enabled = false;
            }
            else if (model.I == 16 && !model.Per)
            {
                textBox25.Text = textBox18.Text;
                textBox17.Enabled = false;
            }

            if (model.I == 18 && model.Per)
            {
                textBox26.Text = textBox19.Text;
                textBox20.Enabled = false;
            }
            else if (model.I == 18 && !model.Per)
            {
                textBox26.Text = textBox20.Text;
                textBox19.Enabled = false;
            }

            if (model.I == 20 && model.Per)
            {
                textBox27.Text = textBox21.Text;
                textBox22.Enabled = false;
            }
            else if (model.I == 20 && !model.Per)
            {
                textBox27.Text = textBox22.Text;
                textBox21.Enabled = false;
            }

            if (model.I == 22 && model.Per)
            {
                textBox28.Text = textBox23.Text;
                textBox24.Enabled = false;
            }
            else if (model.I == 22 && !model.Per)
            {
                textBox28.Text = textBox24.Text;
                textBox23.Enabled = false;
            }

            if (model.I == 24 && model.Per)
            {
                textBox29.Text = textBox25.Text;
                textBox26.Enabled = false;
            }
            else if (model.I == 24 && !model.Per)
            {
                textBox29.Text = textBox26.Text;
                textBox25.Enabled = false;
            }

            if (model.I == 26 && model.Per)
            {
                textBox30.Text = textBox27.Text;
                textBox28.Enabled = false;
            }
            else if (model.I == 26 && !model.Per)
            {
                textBox30.Text = textBox28.Text;
                textBox27.Enabled = false;
            }

            if (model.I == 28 && model.Per)
            {
                MessageBox.Show("Турнир выйграла" + textBox29.Text + "!");
                textBox30.Enabled = false;
            }
            else if (model.I == 28 && !model.Per)
            {
                MessageBox.Show("Турнир выйграла" + textBox30.Text + "!");
                textBox29.Enabled = false;
            }
        }

        protected Form1Controller MakeController()
        {
            return new Form1Controller(this, model); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox31.Enabled = true;
            textBox32.Enabled = true;
            textBox33.Enabled = true;
            timer1.Interval = 5000;
            timer1.Enabled = true;  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i == 28)
                timer1.Stop();
            int n1, n2;
            List<int> list = new List<int>();
            Random num = new Random();
            for (int n = 0; n < 35; n++)
            list.Add(num.Next((int)1, (int)10));
            n1 = list[i];
            n2 = list[i + 1];
                controller.PassData(n1, n2, i, list[i], list[i+1]);
                i += 2;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void обАлгоритмеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Действия метода отражают процесс разыгрывания некоторого турнира, \n " +
                            "где его участники состязаются друг с другом для определения наилучшего игрока. \n" +
                            "Эта сортировка также называется сортировкой посредством выбора из дерева. \n");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Курсовая работа по ООП \n" +
                             "Тема: Турнирная выборка \n" +
                             "Выполнил студент группы М8О-205Б-18  " +
                             "Махмудов Орхан");
        }
    }
}

