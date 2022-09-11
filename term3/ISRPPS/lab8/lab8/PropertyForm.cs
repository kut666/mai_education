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
    public partial class PropertyForm : Form
    {
        public PropertyForm()
        {
            InitializeComponent();
        }
        // Определение свойств формы немодального окна с именами SMTP, POP3

        public string SMTP
        {
            get { return textBoxSMTP2.Text; }
            set { textBoxSMTP2.Text = value; }
        }

        public string POP3
        {
            get { return textBoxPOP32.Text; }
            set { textBoxPOP32.Text = value; }
        }

        public int Red
        {
            get { return hScrollBar1.Value; }
            set { hScrollBar1.Value = value; }
        }

        public int Green
        {
            get{return hScrollBar2.Value; }
            set { hScrollBar2.Value = value; }
        }

        public int Blue
        {
            get{ return hScrollBar3.Value; }
            set{ hScrollBar3.Value = value;}
        }

        public event EventHandler ApplyHandler;

        private void button1_Click(object sender, EventArgs e)
        {
            // Если определен обработчик события, то он вызывается
            // Ему передается ссылка на дочернее окно и параметры события
            if (ApplyHandler != null)
                // Генерируем событие, обработчик для которого зарегистрирован в главном окне
                ApplyHandler(this, new EventArgs());
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            // Если определен обработчик события, то он вызывается
            // Ему передается ссылка на дочернее окно и параметры события
            if (ApplyHandler != null)
                // Генерируем событие, обработчик для которого зарегистрирован в главном окне
                ApplyHandler(this, new EventArgs());
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (ApplyHandler != null)
            {
                this.BackColor = Color.FromArgb(this.Red, this.Green, this.Blue);
                ApplyHandler(this, new EventArgs());
            }
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            if (ApplyHandler != null)
            {
                this.BackColor = Color.FromArgb(this.Red, this.Green, this.Blue);
                ApplyHandler(this, new EventArgs());
            }
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (ApplyHandler != null)
            {
                this.BackColor = Color.FromArgb(this.Red, this.Green, this.Blue);
                ApplyHandler(this, new EventArgs());
            }
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PropertyForm_Load(object sender, EventArgs e)
        {

        }
    }
}
