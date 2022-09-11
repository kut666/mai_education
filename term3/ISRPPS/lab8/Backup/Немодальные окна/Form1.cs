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

        // Главное окно приложения исчезает с экрана
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Отображение на экране немодального окна Настройка свойств
        private void button2_Click(object sender, EventArgs e)
        {
            // Создание немодального окна и родительских отношений
            // между главным окном и дочерним немодальным окном
            PropertyForm dialog = new PropertyForm();
            dialog.Owner = this;

            // Копирование текста из полей ввода главного окна 
            // в свойства немодального диалогового окна 

            dialog.SMTP = this.textBoxSMTP.Text;
            dialog.POP3 = this.textBoxPOP3.Text;

            // Добавление обработчика события, 
            // создаваемого дочерним немодальным окном, в список события
            dialog.ApplyHandler += new EventHandler(PropertyForm_Apply);

            // отображение немодального окна
            dialog.Show();
        }
        // Обработчик события, созданного при нажатии кнопки Изменить 
        // в дочернем немодальном окне
        private void PropertyForm_Apply(object sender, System.EventArgs e)
        {
            PropertyForm dialog = (PropertyForm)sender;

            // Отображение адресов почтовых серверов, 
            // введенных в дочернее немодальное окно, в главном окне
            this.textBoxSMTP.Text = dialog.SMTP;
            this.textBoxPOP3.Text = dialog.POP3;
        }
    }
}
