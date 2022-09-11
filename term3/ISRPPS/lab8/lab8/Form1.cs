using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Немодальные_окна
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PropertyForm dialog = new PropertyForm();
            dialog.Owner = this;
            // Копирование текста из полей ввода главного окна 
            // в свойства немодального диалогового окна 
            dialog.SMTP = this.textBoxSMTP.Text;
            dialog.POP3 = this.textBoxPOP3.Text;

            dialog.Red = this.BackColor.R;
            dialog.Green = this.BackColor.G;
            dialog.Blue = this.BackColor.B;

            dialog.ApplyHandler += new EventHandler(PropertyForm_ApplyColor);
            dialog.ApplyHandler += new EventHandler(PropertyForm_Apply);

            dialog.Show();
        }
        private void PropertyForm_ApplyColor(object sender, System.EventArgs e)
        {
            PropertyForm dialog = (PropertyForm)sender;

            this.BackColor = Color.FromArgb(dialog.Red, dialog.Green, dialog.Blue);

             this.textBoxSMTP.Text= dialog.SMTP ;
             this.textBoxPOP3.Text= dialog.POP3;
        }

        private void PropertyForm_Apply(object sender, System.EventArgs e)
        {
            PropertyForm dialog = (PropertyForm)sender;

            this.textBoxSMTP.Text = dialog.SMTP;
            this.textBoxPOP3.Text = dialog.POP3;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выполнил студент группы М8О-205Б-18");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
